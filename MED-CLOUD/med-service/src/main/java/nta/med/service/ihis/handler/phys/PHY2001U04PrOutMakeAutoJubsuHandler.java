package nta.med.service.ihis.handler.phys;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import java.math.BigDecimal;
import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04PrOutMakeAutoJubsuInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.nuro.UpdateJubsuDataHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04PrOutMakeAutoJubsuRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class PHY2001U04PrOutMakeAutoJubsuHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04PrOutMakeAutoJubsuRequest, SystemServiceProto.UpdateResponse> { 
	private static final Log LOGGER = LogFactory.getLog(PHY2001U04PrOutMakeAutoJubsuHandler.class);
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
	
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;  
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Ifs0003Repository ifs0003Repository;
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04PrOutMakeAutoJubsuRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
		if(!CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode())){ 
			List<Ifs0003> gwaLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_GWA.getValue(), request.getGwa());
			List<Ifs0003> doctorLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_DOCTOR.getValue(), request.getDoctor().substring(2, request.getDoctor().length()));
			String dept = !CollectionUtils.isEmpty(gwaLst) ? gwaLst.get(0).getIfCode() : "";
			String doctor = !CollectionUtils.isEmpty(doctorLst) ? doctorLst.get(0).getIfCode() : "";
			
			NuroModelProto.UpdateJubsuDataInfo.Builder jubsuDataInfo = NuroModelProto.UpdateJubsuDataInfo.newBuilder();
			jubsuDataInfo.setDepartmentCode(dept);
			jubsuDataInfo.setDoctorCode(doctor);
			jubsuDataInfo.setPatientCode(request.getBunho());
			jubsuDataInfo.setInsurCode(out1001Repository.getGubun(request.getPkout1001(), hospCode));
			jubsuDataInfo.setReceptionType(request.getJubsuGubun());
			jubsuDataInfo.setComingDate(request.getNaewonDate());
			jubsuDataInfo.setDataRowState(DataRowState.ADDED.getValue());
			NuroServiceProto.SaveExaminationRequest.Builder rq = NuroServiceProto.SaveExaminationRequest.newBuilder();
			rq.setId(System.currentTimeMillis());
			rq.setHospCode(hospCode);
			rq.setExamInfo(jubsuDataInfo);
			
			FutureEx<NuroServiceProto.SaveExaminationResponse> res = send(vertx, parser, rq.build(), hospCode);
			NuroServiceProto.SaveExaminationResponse r = res.get(30, TimeUnit.SECONDS);
			
			if(r != null){
				LOGGER.info("response from remote gateway: " + format(r));
				if(r.getResult() == NuroServiceProto.SaveExaminationResponse.Result.SUCCESS) {
					PHY2001U04PrOutMakeAutoJubsuInfo info = null;
					Double iSourcePkKey = CommonUtils.parseDouble(request.getPkout1001());
					 info = out1001Repository.callPrOutMakeAutoJubsuInfo(getHospitalCode(vertx, sessionId), iSourcePkKey, 
							request.getGwa(), request.getDoctor(), request.getJubsuGubun(), request.getUserId());
					if(info != null){
						if(!"0".equalsIgnoreCase(info.getIoErr())){
							response.setResult(false);
							throw new ExecutionException(response.build());
						}else{
							response.setResult(true);
						}
					}
				}				
//				response.setMsg(extMsgCode);
				response.setResult(r.getResult() == NuroServiceProto.SaveExaminationResponse.Result.SUCCESS);
			} else{
				response.setResult(false);
			}
			
			if(!response.getResult()){
				throw new ExecutionException(response.setResult(true).build());
			}
		} 
		return response.build();
	}

}
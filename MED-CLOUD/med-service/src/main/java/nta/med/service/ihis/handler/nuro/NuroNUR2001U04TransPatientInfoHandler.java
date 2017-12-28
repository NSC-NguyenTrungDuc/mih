package nta.med.service.ihis.handler.nuro;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.out.Out1001;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.out.Out0103Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out1002Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
@Transactional
public class NuroNUR2001U04TransPatientInfoHandler extends ScreenHandler<NuroServiceProto.NuroNUR2001U04TransPatientInfoRequest, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(NuroNUR2001U04TransPatientInfoHandler.class);
	
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
	
	@Resource
	private Out0103Repository out0103Repository;
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Out1002Repository out1002Repository;

	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Ifs0003Repository ifs0003Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR2001U04TransPatientInfoRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);

		/*NuroServiceProto.PatientEvent.Builder builder = NuroServiceProto.PatientEvent.newBuilder()
				.setHospCode(hospCode).setPatientCode(request.getBunho());
		NuroModelProto.UpdateJubsuDataInfo.Builder itemJubsu = NuroModelProto.UpdateJubsuDataInfo.newBuilder()
				.setDataRowState(DataRowState.DELETED.toString()).setButton(request.getBunho()).setPkout1001(request.getPkout1001())
				.setDepartmentCode(request.getGwa());

		builder.setAcceptInfo(itemJubsu);
		publish(vertx, builder.build());*/
		
		deleteAcceptExternal(vertx, request, hospCode, response);
		if(!response.getResult()) return response.setResult(false).build();
		
		out0103Repository.callPrOutInsertOut0103(hospCode, request.getIudGubun(), 
	     		request.getUser(), request.getNaewonDate(), request.getBunho(), 
	     		request.getGwa(), request.getGubun(), request.getTuyakIlsu(), 
	     		request.getDoctor(), request.getInOut(), request.getChartGwa(), 
	     		request.getSpecialYn(), request.getToiwonDate());
	    
		out1001Repository.deleteOut1001ById(hospCode, StringUtils.isEmpty(request.getPkout1001()) ? 0 : new Double(request.getPkout1001()));
        out1002Repository.deleteOut1002ById(hospCode,request.getPkout1001());
        
        response.setResult(true);
		return response.build();
	}
	
	private boolean deleteAcceptExternal(Vertx vertx, NuroServiceProto.NuroNUR2001U04TransPatientInfoRequest rq,
			String hospCode, SystemServiceProto.UpdateResponse.Builder response) throws Exception {
		
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
		if(!CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode())){
			Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(hospCode, CommonUtils.parseDouble(rq.getPkout1001()));
			String doctor = out1001 != null ? out1001.getDoctor() : ""; 
			
			List<Ifs0003> gwaLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode,
					AccountingConfig.IF_ORCA_GWA.getValue(), rq.getGwa());
			
			List<Ifs0003> doctorLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode,
					AccountingConfig.IF_ORCA_DOCTOR.getValue(),
					StringUtils.isEmpty(doctor) ? "" : doctor.substring(2, doctor.length()));
			
			String extDept = !CollectionUtils.isEmpty(gwaLst) ? gwaLst.get(0).getIfCode() : "";
			String extDoctor = !CollectionUtils.isEmpty(doctorLst) ? doctorLst.get(0).getIfCode() : "";
			
			NuroModelProto.UpdateJubsuDataInfo.Builder itemJubsu = NuroModelProto.UpdateJubsuDataInfo.newBuilder()
					.setDataRowState(DataRowState.DELETED.toString())
					.setButton(rq.getBunho())
					.setPkout1001(rq.getPkout1001())
					.setPatientCode(rq.getBunho())
					.setDoctorCode(extDoctor)
					.setDepartmentCode(extDept);
			
			NuroServiceProto.SaveExaminationRequest.Builder saveReqbuilder = NuroServiceProto.SaveExaminationRequest
					.newBuilder()
					.setId(System.currentTimeMillis())
					.setHospCode(hospCode)
					.setExamInfo(itemJubsu);
			
			FutureEx<NuroServiceProto.SaveExaminationResponse> res = send(vertx, parser, saveReqbuilder.build(), hospCode);
			NuroServiceProto.SaveExaminationResponse r = res.get(30, TimeUnit.SECONDS);
			
			if(r != null){
				LOGGER.info("response from remote gateway: " + format(r));
				String msg = "";
				if(r.hasMessageCode()) msg = r.getMessageCode(); 
				
				response.setMsg(msg);
				response.setResult(r.getResult() == NuroServiceProto.SaveExaminationResponse.Result.SUCCESS);
			} else{
				response.setResult(false);
			}
		}
		
		return true;
	}
}

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
import org.vertx.java.core.Vertx;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.NuroModelProto.NuroOUT0101U02GridPatientInfo;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class OUT0101U04SaveLayoutHandler extends ScreenHandler<NuroServiceProto.OUT0101U04SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(OUT0101U04SaveLayoutHandler.class); 
	
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
	
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U04SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		if(!CollectionUtils.isEmpty(request.getListInfoList())) {
			for (NuroModelProto.NuroManagePatientInfo info : request.getListInfoList()) {
				List<Bas0102> bas0102List = bas0102Repository.getByCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue(), language);
				if(!CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode())){
					NuroOUT0101U02GridPatientInfo profile = toApiProto(info);
					NuroServiceProto.CreatePatientRequest.Builder builder = NuroServiceProto.CreatePatientRequest.newBuilder()
							.setId(System.currentTimeMillis())
							.setHospCode(hospCode)
							.setPatientProfile(profile);
					
					FutureEx<NuroServiceProto.CreatePatientResponse> res = send(vertx, parser, builder.build(), hospCode);
					NuroServiceProto.CreatePatientResponse r = res.get(15, TimeUnit.SECONDS);
					if(r != null) {
						LOGGER.info("response from remote gateway: " + format(r));
						if(r.hasMessageCode()) response.setMsg(r.getMessageCode());
						response.setResult(r.getResult() == NuroServiceProto.CreatePatientResponse.Result.SUCCESS);
					} else {
						LOGGER.info("response from remote gateway: NULL");
						response.setResult(false);
					}
				} else{
					Integer result = out0101Repository.updateOUT0101U04(info.getZipCode1(), info.getZipCode2(), info.getAddress1(), info.getAddress2(), info.getTel(), info.getTel1(), info.getTelHp(), info.getTelType(), info.getTelType2(), info.getTelType3(), 
							info.getEMail(), info.getPaceMakerYn(), info.getSelfPaceMaker(), getHospitalCode(vertx, sessionId), info.getPatientCode());
					
					LOGGER.info("result = " + result);
					response.setResult(result > 0);
				}
			}
		}
		
		return response.build();
	}

	private NuroModelProto.NuroOUT0101U02GridPatientInfo toApiProto(NuroModelProto.NuroManagePatientInfo patientInfo) {
		NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder builder = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder()
				.setIuGubun("U")
				.setBunho(patientInfo.getPatientCode())
				.setBirth(patientInfo.getBirth())
				.setSex(patientInfo.getSex())
				.setZipCode1(patientInfo.getZipCode1())
				.setZipCode2(patientInfo.getZipCode2())
				.setAddress1(patientInfo.getAddress1())
				.setAddress2(patientInfo.getAddress2())
				.setTel(patientInfo.getTel())
				.setTel1(patientInfo.getTel1())
				.setTelHp(patientInfo.getTelHp())
				.setTelType(patientInfo.getTelType())
				.setTelType2(patientInfo.getTelType2())
				.setTelType3(patientInfo.getTelType3())
				.setEmail(patientInfo.getEMail())
				.setPaceMakerYn(patientInfo.getPaceMakerYn())
				.setSelfPaceMaker(patientInfo.getSelfPaceMaker())
				.setSuname(patientInfo.getPatientName1())
				.setSuname2(patientInfo.getPatientName2());
		
		return builder.build();
	}
}
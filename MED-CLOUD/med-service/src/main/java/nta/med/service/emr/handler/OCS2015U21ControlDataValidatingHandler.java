package nta.med.service.emr.handler;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
public class OCS2015U21ControlDataValidatingHandler extends ScreenHandler<EmrServiceProto.OCS2015U21ControlDataValidatingRequest, EmrServiceProto.OCS2015U21ControlDataValidatingResponse> {
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource                                                                                                       
	private Out0101Repository out0101Repository; 
	
	@Resource                                                                                                       
	private Inp1003Repository inp1003Repository;
	
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional
	public EmrServiceProto.OCS2015U21ControlDataValidatingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U21ControlDataValidatingRequest request) throws Exception {
		EmrServiceProto.OCS2015U21ControlDataValidatingResponse.Builder response = EmrServiceProto.OCS2015U21ControlDataValidatingResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
//		List<OcsoOCS1003P01LayPatInfo> listInfo = out1001Repository.getOcsoOCS1003P01LayPatInfo(hospCode, getLanguage(vertx, sessionId), 
//				request.getDoctor(), request.getBunho(), request.getNaewonDate(), request.getLoginDoctorYn());
//    	if (listInfo != null && !listInfo.isEmpty()) {
//			for (OcsoOCS1003P01LayPatInfo obj : listInfo) {
//				EmrModelProto.OcsoOCS1003P01LayPatInfo.Builder itemBuilder = EmrModelProto.OcsoOCS1003P01LayPatInfo.newBuilder();
//				BeanUtils.copyProperties(obj, itemBuilder);
//				response.addLayPatItem(itemBuilder);
//			}
//    	}
    	
    	String isJaewonPatient = out0101Repository.getIsJaewonPatientInfo(request.getBunho(), hospCode);
		if("Y".equalsIgnoreCase(isJaewonPatient)){
			response.setIsJaewonPatient(true);
		}else{
			response.setIsJaewonPatient(false);
		}
    	
    	if("CK".equalsIgnoreCase(request.getGwa())){
    		Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
    		String ableInsteadOrder = inp1003Repository.getAbleInsteadOrder(hospCode, request.getBunho(), naewonDate);
    		if(!StringUtils.isEmpty(ableInsteadOrder)){
    			response.setIsAbleInsteadOrder(ableInsteadOrder);
    		}
    	}
    	
    	String notApproveOrderCnt = out1001Repository.callFnOcsGetNotapproveOrdercnt(hospCode, request.getIoGubun(), request.getInsteadYn(), 
				request.getApproveYn(), request.getUserId(), request.getKey());
		if(!StringUtils.isEmpty(notApproveOrderCnt)){
			response.setNotApproveOrderCnt(notApproveOrderCnt);
		}
		
		String enablePostApprove = adm3200Repository.getEnablePostApprove(hospCode, request.getDoctor());
		if("Y".equalsIgnoreCase(enablePostApprove)){
			response.setEnablePostApprove(true);
		}else{
			response.setEnablePostApprove(false);
		}
		return response.build();
	}

}

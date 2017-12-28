package nta.med.service.ihis.handler.ocso;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.dao.medi.out.Out0123Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.GetOutJinryoCommentCntInfo;
import nta.med.service.ihis.proto.CommonModelProto.IpwonReserStatusInfo;
import nta.med.service.ihis.proto.CommonModelProto.KensaReserInfo;
import nta.med.service.ihis.proto.CommonModelProto.OutTaGwaJinryoCntInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003P01CheckPatientEtcHandler extends ScreenHandler<OcsoServiceProto.OCS1003P01CheckPatientEtcRequest, OcsoServiceProto.OCS1003P01CheckPatientEtcResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003P01CheckPatientEtcHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;                                                                    
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;                                                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	@Resource                                                                                                       
	private Out0123Repository out0123Repository;                                                                    
	@Resource                                                                                                       
	private Nur1016Repository nur1016Repository;                                                                    
	@Resource                                                                                                       
	private Inp1003Repository inp1003Repository;   
	
	@Override
	public boolean isValid(OcsoServiceProto.OCS1003P01CheckPatientEtcRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getKensaReserInfo().getNaewonDate()) && DateUtil.toDate(request.getKensaReserInfo().getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003P01CheckPatientEtcResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003P01CheckPatientEtcRequest request) throws Exception {
		OcsoServiceProto.OCS1003P01CheckPatientEtcResponse.Builder response = OcsoServiceProto.OCS1003P01CheckPatientEtcResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
//		1. KensaReserRequest
		KensaReserInfo info = request.getKensaReserInfo();
		Date hopeDate = DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		//String result = ocs1003Repository.getKensaReser(hospCode, info.getBunho(), hopeDate);
		String resultYN = ocs1003Repository.callFnOcsIsNextKensaReser(hospCode, info.getBunho(), hopeDate);
		if(!StringUtils.isEmpty(resultYN)){
			response.setKensaReserValue(resultYN);
		}
		
//		2. LoadPatientSpecificCommentRequest
		List<String> listResult = out0106Repository.getPatientSpecificComment(hospCode, request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(String comment : listResult){
				response.setSpecificComment(comment);
			}
		}
		
//		3. OcsOrderBizGetUserOptionRequest
		CommonModelProto.GetUserOptionInfo userInfo = request.getUserOptionInfo();
		String  userOpt = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(hospCode,userInfo.getDoctor(),
				userInfo.getGwa(),userInfo.getKeyword(),userInfo.getIoGubun());
		if(!StringUtils.isEmpty(userOpt)){
			response.setUserOption(userOpt);
		}
			
//		4. GetOutTaGwaJinryoCntRequest
		OutTaGwaJinryoCntInfo cntInfo = request.getOutTaGwaJinryoCnt();
		Date naewonDate = DateUtil.toDate(cntInfo.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		Integer cnt = out1001Repository.getOutTaGwaJinryoCnt(hospCode, info.getBunho(), cntInfo.getGwa(), naewonDate);
		if(cnt != null){
			response.setOutTaGwaJinryoCnt(cnt.toString());
		}
		
//		5. GetOutJinryoCommentCntRequest
		GetOutJinryoCommentCntInfo commentInfo = request.getCommentCntInfo();
		Integer comment = out0123Repository.getOutJinryoCommentCnt(hospCode, commentInfo.getBunho(), commentInfo.getDoctor());
		if(comment != null){
			response.setOutJinryoComment(comment.toString());
		}
		
//		6. ExistAllergyDataRequest
		Integer existData = nur1016Repository.checkExistAllergyData(hospCode, request.getBunho());
		if(existData > 0){
			response.setAllergyData(true);
		} else {
			response.setAllergyData(false);
		}
		
//		7. IpwonReserStatusRequest
		IpwonReserStatusInfo statusInfo = request.getReserStatusInfo();
		String status = inp1003Repository.getIpwonReserStatus(hospCode, statusInfo.getDoctor().substring(2), statusInfo.getBunho());
		if(!StringUtils.isEmpty(status)){
			response.setIpwonReserStatus(true);
		} else {
			response.setIpwonReserStatus(false);
		}
		return response.build();
	}                                                                                                                 
}
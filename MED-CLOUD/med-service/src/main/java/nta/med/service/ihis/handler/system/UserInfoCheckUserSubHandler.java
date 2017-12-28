package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.system.UserInfoCheckUserSubDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UserInfoCheckUserSubRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UserInfoCheckUserSubResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class UserInfoCheckUserSubHandler extends ScreenHandler <SystemServiceProto.UserInfoCheckUserSubRequest, SystemServiceProto.UserInfoCheckUserSubResponse> {
	
	@Resource
	private Adm3200Repository adm3200Repository;
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Transactional
	public UserInfoCheckUserSubResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			UserInfoCheckUserSubRequest request) throws Exception {
        SystemServiceProto.UserInfoCheckUserSubResponse.Builder response = SystemServiceProto.UserInfoCheckUserSubResponse.newBuilder();
    	SystemModelProto.UserRequestInfo requestInfo = request.getUserInfo();
    	String hospCode = getHospitalCode(vertx, sessionId);
    	String language = getLanguage(vertx, sessionId);
    	UserInfoCheckUserSubDoctorInfo info  = adm3200Repository.callProcAdmCheckLogin(hospCode, language, requestInfo.getSysId(),
    			requestInfo.getUserId(), requestInfo.getUserScrt(), requestInfo.getScrtCheckYn());
    	String hospName = bas0001Repository.getYoyangNameInfo(hospCode, language);
    	if(info != null){
    		if (!StringUtils.isEmpty(info.getErrMsg())) {
    			response.setErrorMessage(info.getErrMsg());
    		}else{
    			SystemModelProto.UserItemInfo.Builder userInfoBuilder = SystemModelProto.UserItemInfo.newBuilder(); 
        		BeanUtils.copyProperties(info, userInfoBuilder, getLanguage(vertx, sessionId));
        		userInfoBuilder.setHospName(hospName);
        		response.setUserItemInfo(userInfoBuilder);
    		}
    	}
    	return response.build();
	}
}

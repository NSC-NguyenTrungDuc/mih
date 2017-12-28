package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.system.UserInfoCheckUserSubDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UserInfoCheckUserSubDoctorRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UserInfoCheckUserSubDoctorResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class UserInfoCheckUserSubDoctorHandler extends ScreenHandler<SystemServiceProto.UserInfoCheckUserSubDoctorRequest, SystemServiceProto.UserInfoCheckUserSubDoctorResponse> {
	
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Transactional
	public UserInfoCheckUserSubDoctorResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			UserInfoCheckUserSubDoctorRequest request) throws Exception{
        SystemServiceProto.UserInfoCheckUserSubDoctorResponse.Builder response = SystemServiceProto.UserInfoCheckUserSubDoctorResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
    	SystemModelProto.UserRequestInfo requestInfo = request.getUserInfo();
    	UserInfoCheckUserSubDoctorInfo info  = adm3200Repository.callProcAdmCheckLogin(hospCode, language, requestInfo.getSysId(),
    			requestInfo.getUserId(), requestInfo.getUserScrt(), requestInfo.getScrtCheckYn());
    	String hospName = bas0001Repository.getYoyangNameInfo(hospCode, language);
    	if (!StringUtils.isEmpty(info.getErrMsg())) {
			response.setErrorMessage(info.getErrMsg());
		}else{
			SystemModelProto.UserItemInfo.Builder userInfoBuilder = SystemModelProto.UserItemInfo.newBuilder(); 
    		BeanUtils.copyProperties(info, userInfoBuilder, getLanguage(vertx, sessionId));
    		userInfoBuilder.setHospName(hospName);
    		response.setUserItemInfo(userInfoBuilder);
		}
    	
    	List<ComboListItemInfo> listCombo = bas0260Repository.getComboUserInfoCheckUserSubDoctor(hospCode, language, request.getGwa());
    	if(listCombo!=null && listCombo.size() > 0){
    		for(ComboListItemInfo item : listCombo){
    			CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
    			BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
    			response.addCboList(builder);
    		}
    	}
    	return response.build();
	}
}

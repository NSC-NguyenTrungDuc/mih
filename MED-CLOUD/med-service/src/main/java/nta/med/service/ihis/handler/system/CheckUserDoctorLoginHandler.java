package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.MonitorKey;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.system.AdmLoginFormCheckLoginUserInfo;
import nta.med.data.model.ihis.system.UserInfoCheckUserSubDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CheckUserDoctorLoginRequest;
import nta.med.service.ihis.proto.SystemServiceProto.CheckUserDoctorLoginResponse;

@Service
@Scope("prototype")
public class CheckUserDoctorLoginHandler
        extends ScreenHandler<SystemServiceProto.CheckUserDoctorLoginRequest, SystemServiceProto.CheckUserDoctorLoginResponse> {
    private static final Log LOGGER = LogFactory.getLog(CheckUserDoctorLoginHandler.class);
    @Resource
    private Adm3200Repository adm3200Repository;

    @Resource
    private Bas0260Repository bas0260Repository;
    @Resource
    private Bas0001Repository bas0001Repository;

    @Override
    @Transactional
    public CheckUserDoctorLoginResponse handle(Vertx vertx, String clientId,
                                               String sessionId, long contextId,
                                               CheckUserDoctorLoginRequest request) throws Exception {

        SystemServiceProto.CheckUserDoctorLoginResponse.Builder response = SystemServiceProto.CheckUserDoctorLoginResponse.newBuilder();
        SystemModelProto.UserRequestInfo requestInfo = request.getUserInfo();
        //TODO remove when change to new way to get session
        AdmLoginFormCheckLoginUserInfo item = adm3200Repository.getAdmLoginFormCheckLoginUserInfo(requestInfo.getUserId(), requestInfo.getUserScrt(), getHospitalCode(vertx, sessionId));
        if (item != null) {
        	if (!StringUtils.isEmpty(item.getUserGroup())) {
        		if(item.getUserGroup().equals("SMO") && StringUtils.isEmpty(item.getClisSmoId())){
            		return response.build();
            	}
            }
        	setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(item.getHospCode(), item.getLanguage(),
        			item.getUserId(), item.getClisSmoId() , item.getUserGroup()));
        }

        //end
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);

        String hospName = bas0001Repository.getYoyangNameInfo(hospCode, language);
        String gwaName = bas0260Repository.getOCS1003P01ChangeUserInfo(hospCode, request.getGwa(), language);
        if (!StringUtils.isEmpty(gwaName)) {
            response.setGwaName(gwaName);
        }

        UserInfoCheckUserSubDoctorInfo info = adm3200Repository.callProcAdmCheckLogin(hospCode, language, requestInfo.getSysId(),
                requestInfo.getUserId(), requestInfo.getUserScrt(), requestInfo.getScrtCheckYn());
        if (!StringUtils.isEmpty(info.getErrMsg())) {
            response.setErrorMessage(info.getErrMsg());
        } else {
            SystemModelProto.UserItemInfo.Builder userInfoBuilder = SystemModelProto.UserItemInfo.newBuilder();
            BeanUtils.copyProperties(info, userInfoBuilder, getLanguage(vertx, sessionId));
            userInfoBuilder.setHospName(hospName);
            response.setUserItemInfo(userInfoBuilder);
            MonitorLog.writeMonitorLog(MonitorKey.LOGIN_SUCCESS, "New user have been successfully logged in");
        }

        List<ComboListItemInfo> listCombo = bas0260Repository.getComboUserInfoCheckUserSubDoctor(hospCode, language, request.getGwa());
        if (listCombo != null && listCombo.size() > 0) {
            for (ComboListItemInfo comboItem : listCombo) {
                CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(comboItem, builder, getLanguage(vertx, sessionId));
                response.addCboList(builder);
            }
        }
        return response.build();
    }
}

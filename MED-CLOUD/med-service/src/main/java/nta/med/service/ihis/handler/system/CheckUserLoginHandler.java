package nta.med.service.ihis.handler.system;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.MonitorKey;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.system.AdmLoginFormCheckLoginUserInfo;
import nta.med.data.model.ihis.system.UserInfoCheckUserSubDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CheckUserLoginRequest;
import nta.med.service.ihis.proto.SystemServiceProto.CheckUserLoginResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class CheckUserLoginHandler
        extends ScreenHandler<SystemServiceProto.CheckUserLoginRequest, SystemServiceProto.CheckUserLoginResponse> {
    private static final Log LOGGER = LogFactory.getLog(CheckUserLoginResponse.class);
    @Resource
    private Adm3200Repository adm3200Repository;

    @Resource
    private Ocs0132Repository ocs0132Repository;

    @Resource
    private Bas0001Repository bas0001Repository;

    @Override
    @Transactional
    public CheckUserLoginResponse handle(Vertx vertx, String clientId,
                                         String sessionId, long contextId, CheckUserLoginRequest request)
            throws Exception {

        SystemServiceProto.CheckUserLoginResponse.Builder response = SystemServiceProto.CheckUserLoginResponse.newBuilder();
        SystemModelProto.UserRequestInfo requestInfo = request.getUserInfo();
        //TODO remove when change to new way to get session
        AdmLoginFormCheckLoginUserInfo item = adm3200Repository.getAdmLoginFormCheckLoginUserInfo(requestInfo.getUserId(), requestInfo.getUserScrt(), getHospitalCode(vertx, sessionId));
        if (item != null) {
        	if (!StringUtils.isEmpty(item.getUserGroup())) {
        		if(item.getUserGroup().equals("SMO") && StringUtils.isEmpty(item.getClisSmoId())){
            		return response.build();
            	}
            }
            Bas0001 bas0001 = bas0001Repository.findLatestByHospCode(item.getHospCode()).get(0);
            SessionUserInfo sessionUserInfo = SessionUserInfo.setSessionUserInfoByUserGroup(item.getHospCode(), item.getLanguage(), item.getUserId(), item.getClisSmoId(), item.getUserGroup());
            sessionUserInfo.setTimeZone(bas0001.getTimeZone());
        	setSessionInfo(vertx, sessionId, sessionUserInfo);
        }
        //end

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
        String subPartDoctoc = ocs0132Repository.getSubPartDoctor(hospCode, request.getUserId(), request.getSystemId());
        if (!StringUtils.isEmpty(subPartDoctoc)) {
            response.setSubPartDoctor(subPartDoctoc);
        }
        String hospName = bas0001Repository.getYoyangNameInfo(hospCode, language);

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
        return response.build();
    }
}

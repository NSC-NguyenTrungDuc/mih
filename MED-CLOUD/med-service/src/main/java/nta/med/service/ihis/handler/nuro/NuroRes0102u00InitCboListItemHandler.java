package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.res.Res0106Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class NuroRes0102u00InitCboListItemHandler extends ScreenHandler<NuroServiceProto.NuroRes0102u00InitCboListItemRequest, NuroServiceProto.NuroRes0102u00InitCboListItemResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRes0102u00InitCboListItemHandler.class);
	
	@Resource
	private Res0106Repository res0106Repository;
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRes0102u00InitCboListItemRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getComingDate()) && DateUtil.toDate(request.getComingDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NuroRes0102u00InitCboListItemRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRes0102u00InitCboListItemResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRes0102u00InitCboListItemRequest request) throws Exception {
        NuroServiceProto.NuroRes0102u00InitCboListItemResponse.Builder response = NuroServiceProto.NuroRes0102u00InitCboListItemResponse.newBuilder();
    	String hospCode = request.getHospCode();
    	String language = getLanguage(vertx, sessionId);
    	List<String> listCboAvgTime = res0106Repository.getCboAvgTime();
    	if (listCboAvgTime != null && !listCboAvgTime.isEmpty()) {
            for (String obj : listCboAvgTime) {
                CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
                if(!StringUtils.isEmpty(obj)) {
                	builder.setCode(obj);
                	builder.setCodeName(obj);
                }
                response.addAvgTime(builder);
            }
        }
    	
    	Date comingDate = DateUtil.toDate(request.getComingDate(), DateUtil.PATTERN_YYMMDD);	
    	List<ComboListItemInfo> listObject = bas0260Repository.getComboDepartmentItemInfo(language, hospCode, comingDate, false);
        if (listObject != null && !listObject.isEmpty()) {
            for (ComboListItemInfo obj : listObject) {
            	CommonModelProto.ComboListItemInfo.Builder comboInfo = CommonModelProto.ComboListItemInfo.newBuilder();
            	if (!StringUtils.isEmpty(obj.getCode())) {
            		comboInfo.setCode(obj.getCode());
            	}
            	if (!StringUtils.isEmpty(obj.getCodeName())) {
            		comboInfo.setCodeName(obj.getCodeName());
            	}
                response.addGwaItem(comboInfo);
            }
        }
		return response.build();
	}
}

package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class NuroRES0102U00CboDoctorItemHandler  extends ScreenHandler<NuroServiceProto.NuroRES0102U00CboDoctorRequest, NuroServiceProto.NuroRES0102U00CboDoctorResponse>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00CboDoctorItemHandler.class);
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00CboDoctorRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getAppDate())&& DateUtil.toDate(request.getAppDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NuroRES0102U00CboDoctorRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00CboDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00CboDoctorRequest request) throws Exception {
        NuroServiceProto.NuroRES0102U00CboDoctorResponse.Builder response = NuroServiceProto.NuroRES0102U00CboDoctorResponse.newBuilder();
        List<ComboListItemInfo> listNuroRES0102U00CboDoctorItem = bas0270Repository.getNuroRES0102U00CboDoctorItemInfo(request.getHospCode(), request.getGwa(), request.getAppDate());
        if (listNuroRES0102U00CboDoctorItem != null && !listNuroRES0102U00CboDoctorItem.isEmpty()) {
            for (ComboListItemInfo obj : listNuroRES0102U00CboDoctorItem) {
                CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getCode())) {
                	builder.setCode(obj.getCode());
                }
                if(!StringUtils.isEmpty(obj.getCodeName())) {
                	builder.setCodeName(obj.getCodeName());
                }
                response.addCboItemList(builder);
            }
        }
		return response.build();
	}
}

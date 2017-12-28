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
import nta.med.data.dao.medi.nur.Nur0301Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class NuroRES0102U00CboGwaRoomHandler  extends ScreenHandler<NuroServiceProto.NuroRES0102U00CboGwaRoomRequest, NuroServiceProto.NuroRES0102U00CboGwaRoomResponse>{
private static final Log logger = LogFactory.getLog(NuroRES0102U00CboGwaRoomHandler.class);
	
	@Resource
	private Nur0301Repository nur0301Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00CboGwaRoomRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getDate())&& DateUtil.toDate(request.getDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
		       
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NuroRES0102U00CboGwaRoomRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00CboGwaRoomResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00CboGwaRoomRequest request) throws Exception {
        NuroServiceProto.NuroRES0102U00CboGwaRoomResponse.Builder response = NuroServiceProto.NuroRES0102U00CboGwaRoomResponse.newBuilder();
        List<ComboListItemInfo> listNuroRES0102U00CboGwaRoom = nur0301Repository.getNuroRES0102U00CboGwaRoom(request.getHospCode(), request.getGwa(), request.getDate());
        if (listNuroRES0102U00CboGwaRoom != null && !listNuroRES0102U00CboGwaRoom.isEmpty()) {
            for (ComboListItemInfo obj : listNuroRES0102U00CboGwaRoom) {
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

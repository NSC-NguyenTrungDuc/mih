package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00FwkSymyaGubunRequest;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
@Transactional
public class BAS0203U00FwkSymyaGubunHandler
		extends ScreenHandler<BassServiceProto.BAS0203U00FwkSymyaGubunRequest, SystemServiceProto.ComboResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(BAS0203U00FwkSymyaGubunHandler.class);
	
	@Resource
	private Bas0102Repository bas0102Repository;

	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0203U00FwkSymyaGubunRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0203U00FwkSymyaGubunRequest request) throws Exception {
		
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> listCombo = bas0102Repository.getCodeCodeNameWhereFind1Item(request.getHospCode(),"SYMYA_GUBUN", request.getFind1(), true, language);

		if (!CollectionUtils.isEmpty(listCombo)) {
			for (ComboListItemInfo item : listCombo) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}
}
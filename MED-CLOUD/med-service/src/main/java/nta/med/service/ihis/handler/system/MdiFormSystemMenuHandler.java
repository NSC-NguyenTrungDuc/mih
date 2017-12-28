package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm4300Repository;
import nta.med.data.dao.medi.adm.Adm4310Repository;
import nta.med.data.model.ihis.system.MdiFormMenuItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.MdiFormSystemMenuRequest;
import nta.med.service.ihis.proto.SystemServiceProto.MdiFormSystemMenuResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class MdiFormSystemMenuHandler
	extends ScreenHandler<SystemServiceProto.MdiFormSystemMenuRequest, SystemServiceProto.MdiFormSystemMenuResponse> {
	@Resource
	private Adm4310Repository adm4310Repository;
	
	@Resource
	private Adm4300Repository adm4300Repository;
	
	@Override
	public MdiFormSystemMenuResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, MdiFormSystemMenuRequest request)
			throws Exception {
        SystemServiceProto.MdiFormSystemMenuResponse.Builder response = SystemServiceProto.MdiFormSystemMenuResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        Integer userRole = CommonUtils.parseInteger(getUserRole(vertx, sessionId));
    	adm4310Repository.callProcAdmGenMenu(hospCode, language, request.getUserId(), request.getSystemId(), userRole);
    	
    	List<MdiFormMenuItemInfo> listMenuInfo = adm4300Repository.getMdiFormSystemMenu(hospCode, language, request.getUserId(), request.getSystemId());
    	if (!CollectionUtils.isEmpty(listMenuInfo)) {
			for (MdiFormMenuItemInfo item : listMenuInfo) {
				SystemModelProto.MdiFormMenuItemInfo.Builder builder = SystemModelProto.MdiFormMenuItemInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addMenuItemInfo(builder);
			}
    	}
    	return response.build();
	}
}

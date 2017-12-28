package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0500Repository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.adm.Adm4300Repository;
import nta.med.data.dao.medi.adm.Adm4310Repository;
import nta.med.data.model.ihis.system.MdiFormMenuItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.MdiFormMainMenuRequest;
import nta.med.service.ihis.proto.SystemServiceProto.MdiFormMainMenuResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class MdiFormMainMenuHandler 
	extends ScreenHandler<SystemServiceProto.MdiFormMainMenuRequest, SystemServiceProto.MdiFormMainMenuResponse> {
	@Resource
	private Adm4310Repository adm4310Repository;
	@Resource
	private Adm4300Repository adm4300Repository;
	@Resource
	private Adm0500Repository adm0500Repository;
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	public MdiFormMainMenuResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, MdiFormMainMenuRequest request)
			throws Exception {
        SystemServiceProto.MdiFormMainMenuResponse.Builder response = SystemServiceProto.MdiFormMainMenuResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId); 
        String language = getLanguage(vertx, sessionId);
        Integer userRole = CommonUtils.parseInteger(getUserRole(vertx, sessionId));
    	adm4310Repository.callProcAdmGenMenu(hospCode, language, request.getUserId(), request.getSystemId(), userRole);
    	
    	List<MdiFormMenuItemInfo> listMenuInfo = adm4300Repository.getMdiFormSystemMenu(hospCode, language, request.getUserId(), request.getSystemId());    	
    	if (!CollectionUtils.isEmpty(listMenuInfo)) {
			for (MdiFormMenuItemInfo item : listMenuInfo) {
				SystemModelProto.MdiFormMenuItemInfo.Builder builder = SystemModelProto.MdiFormMenuItemInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				if(item.getPgmEntGrad() != null){
					builder.setPgmEntGrad(String.format("%.0f",item.getPgmEntGrad()));
				}
				if(item.getPgmUpdGrad() != null){
					builder.setPgmUpdGrad(String.format("%.0f",item.getPgmUpdGrad()));
				}
				if(item.getMenuLevel() != null){
					builder.setMenuLevel(String.format("%.0f",item.getMenuLevel()));
				}
				response.addMenuItemInfo(builder);
			}
    	}
    	
    	response.setResult(true);
    	return response.build();
	}
}

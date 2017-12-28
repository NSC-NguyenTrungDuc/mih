package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm4500Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.system.MenuViewFormItemInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.MenuViewFormRequest;
import nta.med.service.ihis.proto.SystemServiceProto.MenuViewFormResponse;

@Service
@Scope("prototype")
@Transactional
public class MenuViewFormHandler 
	extends ScreenHandler<SystemServiceProto.MenuViewFormRequest, SystemServiceProto.MenuViewFormResponse> {
	@Resource
	private Adm4500Repository adm4500Repository;
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public MenuViewFormResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, MenuViewFormRequest request)
			throws Exception {
        SystemServiceProto.MenuViewFormResponse.Builder response = SystemServiceProto.MenuViewFormResponse.newBuilder();
        String hospCode = request.getHospCode();
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
  	    String language = bas0001List.size() > 0 ? bas0001List.get(0).getLanguage() : "";
    	adm4500Repository.callProcAdmGenMyMenu(hospCode, language, request.getUserId(), getUserRole(vertx, sessionId));
    	
    	List<MenuViewFormItemInfo> listMenuInfo = adm4500Repository.getMenuViewFormItemInfo(hospCode, request.getUserId());
    	if (!CollectionUtils.isEmpty(listMenuInfo)) {
			for (MenuViewFormItemInfo item : listMenuInfo) {
				SystemModelProto.MenuViewFormItemInfo.Builder builder = SystemModelProto.MenuViewFormItemInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addMenuViewFormItemInfo(builder);
			}
    	}
    	response.setResult(true);
    	return response.build();
	}
}

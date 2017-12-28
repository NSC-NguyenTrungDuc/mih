package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.adm.Adm1110Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboADM1110GetByColNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class ComboADM1110GetByColNameHandler extends ScreenHandler<SystemServiceProto.ComboADM1110GetByColNameRequest, SystemServiceProto.ComboResponse> {
	
	@Resource
	private Adm1110Repository adm1110Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, ComboADM1110GetByColNameRequest request)
			throws Exception {
		
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		
		List<ComboListItemInfo> listResult = adm1110Repository.getComboUserGubun(request.getGetAll(), getLanguage(vertx, sessionId), request.getColName());
		if(listResult != null && !listResult.isEmpty()){
			for(ComboListItemInfo item : listResult){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}
}

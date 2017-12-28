package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.LoadComboINV0101Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service                                                                                                          
@Scope("prototype")
public class LoadComboINV0101Handler extends ScreenHandler<InvsServiceProto.LoadComboINV0101Request, SystemServiceProto.ComboResponse>{

	@Resource
    private Inv0101Repository inv0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadComboINV0101Request request) throws Exception {
		
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<ComboListItemInfo> listMaster = inv0101Repository.getINV0101U00GrdMasterInfo("", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listMaster)){
			for (ComboListItemInfo item : listMaster) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}
	
}

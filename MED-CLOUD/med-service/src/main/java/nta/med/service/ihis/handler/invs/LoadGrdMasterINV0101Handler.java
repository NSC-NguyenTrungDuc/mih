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
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.LoadGrdMasterINV0101Request;
import nta.med.service.ihis.proto.InvsServiceProto.LoadGrdMasterINV0101Response;

@Service                                                                                                          
@Scope("prototype")
public class LoadGrdMasterINV0101Handler extends ScreenHandler<InvsServiceProto.LoadGrdMasterINV0101Request, InvsServiceProto.LoadGrdMasterINV0101Response>{

	@Resource
    private Inv0101Repository inv0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public LoadGrdMasterINV0101Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadGrdMasterINV0101Request request) throws Exception {
		
		InvsServiceProto.LoadGrdMasterINV0101Response.Builder response = InvsServiceProto.LoadGrdMasterINV0101Response.newBuilder();
		List<ComboListItemInfo> listMaster = inv0101Repository.getINV0101U00GrdMasterInfo(request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listMaster)) {
			for(ComboListItemInfo item : listMaster) {
				InvsModelProto.LoadGrdMasterINV0101Info.Builder info = InvsModelProto.LoadGrdMasterINV0101Info.newBuilder();
				info.setCodeName(item.getCode());
				info.setCodeType(item.getCodeName());
				
				response.addListMaster(info);
			}
		}
		
		return response.build();
	}
	
}

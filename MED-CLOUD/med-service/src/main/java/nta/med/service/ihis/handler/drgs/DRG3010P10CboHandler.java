package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10CboRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10CboResponse;

@Service
@Scope("prototype")
public class DRG3010P10CboHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10CboRequest, DrgsServiceProto.DRG3010P10CboResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DRG3010P10CboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10CboRequest request) throws Exception {
		DrgsServiceProto.DRG3010P10CboResponse.Builder response = DrgsServiceProto.DRG3010P10CboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> actorList = adm3200Repository.getCbxActorByUserGroup(hospCode, "DRG");
		if(!CollectionUtils.isEmpty(actorList)){
			for (ComboListItemInfo item : actorList) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(item.getCode()).setCodeName(item.getCodeName());
				response.addCboActor(info);
			}
		}
		
		List<ComboListItemInfo> buseoList = bas0260Repository.getComboHoDongSystemCombobox(hospCode, getLanguage(vertx, sessionId), "2");
		if(!CollectionUtils.isEmpty(buseoList)){
			for (ComboListItemInfo item : buseoList) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(item.getCode()).setCodeName(item.getCodeName());
				response.addCboBuseo(info);
			}
		}
		
		return response.build();
	}

}

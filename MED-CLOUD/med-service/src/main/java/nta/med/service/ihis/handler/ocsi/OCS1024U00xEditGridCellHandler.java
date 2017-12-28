package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00xEditGridCellRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00xEditGridCellResponse;

@Service
@Scope("prototype")
public class OCS1024U00xEditGridCellHandler extends ScreenHandler<OcsiServiceProto.OCS1024U00xEditGridCellRequest , OcsiServiceProto.OCS1024U00xEditGridCellResponse>{
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00xEditGridCellResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00xEditGridCellRequest request) throws Exception {
		OcsiServiceProto.OCS1024U00xEditGridCellResponse.Builder response = OcsiServiceProto.OCS1024U00xEditGridCellResponse.newBuilder();
		List<ComboListItemInfo> cbxActor = adm3200Repository.getDRG0201U00CbxActor(getHospitalCode(vertx, sessionId), "DRG", true);
		if(!CollectionUtils.isEmpty(cbxActor)){
			for(ComboListItemInfo item : cbxActor){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCbxactorItem77(info);
			}
		}
		List<ComboListItemInfo> gridCell206 = adm3200Repository.getDRG0201U00CbxActor(getHospitalCode(vertx, sessionId), "DRG", false);
		if(!CollectionUtils.isEmpty(gridCell206)){
			for(ComboListItemInfo item : gridCell206){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXeditgridcell206(info);
			}
		}
		return response.build();
	}

}

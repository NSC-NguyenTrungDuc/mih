package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0811;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0811Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0811U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR0811U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR0811U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur0811Repository nur0811Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0811U00SaveLayoutRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getUserId();
		
		List<NuriModelProto.NUR0811U00GrdDetailInfo> infos = request.getSaveListList();
		for (NuriModelProto.NUR0811U00GrdDetailInfo info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				Nur0811 nur0811 = new Nur0811();
				nur0811.setSysDate(new Date());
				nur0811.setSysId(userId);
				nur0811.setUpdDate(new Date());
				nur0811.setUpdId(userId);
				nur0811.setHospCode(hospCode);
				nur0811.setNeedHType(info.getNeedHType());
				nur0811.setNeedType(info.getNeedType());
				nur0811Repository.save(nur0811);
			}
			else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				nur0811Repository.deleteByHospCodeNeedHTypeNeedType(hospCode, info.getNeedHType(), info.getNeedType());
			} 
		}
		
		response.setResult(true);
		return response.build();
	}

}

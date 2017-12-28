package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0812;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0812Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0812U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR0812U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR0812U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur0812Repository nur0812Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0812U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getUserId();
		
		List<NuriModelProto.NUR0812U00GrdDetailInfo> saveList = request.getSaveLstList();
		for (NuriModelProto.NUR0812U00GrdDetailInfo info : saveList) {
			if(DataRowState.ADDED.getValue().equals(info.getRowState())){
				Nur0812 nur0812 = new Nur0812();
				nur0812.setSysDate(new Date());
				nur0812.setSysId(userId);
				nur0812.setUpdDate(new Date());
				nur0812.setUpdId(userId);
				nur0812.setHospCode(hospCode);
				nur0812.setNeedHType(info.getNeedHType());
				nur0812.setNeedGubun(info.getNeedGubun());
				nur0812.setNeedAsmtCode(info.getNeedAsmtCode());
				nur0812.setPayloadNo(info.getPayloadNo());
				
				nur0812Repository.save(nur0812);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
				nur0812Repository.updatePayloadNoNUR0812U00(info.getPayloadNo()
						, hospCode
						, info.getNeedHType()
						, info.getNeedGubun()
						, info.getNeedAsmtCode());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getRowState())){
				nur0812Repository.deleteNUR0812U00(hospCode
												 , info.getNeedHType()
												 , info.getNeedGubun()
												 , info.getNeedAsmtCode());
			}
		}
		
		response.setResult(true);
		return response.build();
	}
}

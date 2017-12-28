package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0801;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0801Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0801U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR0801U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR0801U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur0801Repository nur0801Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0801U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Date sysDate = Calendar.getInstance().getTime();
		
		List<NuriModelProto.NUR0801U00GrdMasterInfo> infos = request.getSaveLstList();
		
		for (NuriModelProto.NUR0801U00GrdMasterInfo info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0801 nur0801 = new Nur0801();
				nur0801.setSysDate(sysDate);
				nur0801.setSysId(userId);
				nur0801.setUpdDate(sysDate);
				nur0801.setUpdId(userId);
				nur0801.setHospCode(hospCode);
				nur0801.setHoDong(info.getHoDong());
				nur0801.setNeedType(info.getNeedType());
				nur0801.setMakeHFileYn(info.getMakeHFileYn());
				
				nur0801Repository.save(nur0801);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0801Repository.updateByHospCodeHoDOng(userId, info.getMakeHFileYn(), hospCode, info.getHoDong());
			} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0801Repository.deleteByHospCodeHoDong(hospCode, info.getHoDong());
			}
		}
		
		response.setResult(true);
		return response.build();
	}

	
}

package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0802;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0802Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0802U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR0802U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR0802U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur0802Repository nur0802Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0802U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Date sysDate = Calendar.getInstance().getTime();
		
		List<NuriModelProto.NUR0802U00grdDetailInfo> infos = request.getGrddetailinfoList();
		for (NuriModelProto.NUR0802U00grdDetailInfo info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0802 nur0802 = new Nur0802();
				nur0802.setSysDate(sysDate);
				nur0802.setSysId(userId);
				nur0802.setUpdDate(sysDate);
				nur0802.setUpdId(userId);
				nur0802.setHospCode(hospCode);
				nur0802.setNeedType(info.getNeedType());
				nur0802.setNeedGubun(info.getNeedGubun());
				nur0802.setNeedAsmtCode(info.getNeedAsmtCode());
				nur0802.setMakeHFileYn(info.getMakeHFileYn());
				
				nur0802Repository.save(nur0802);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0802Repository.updateByHospCodeNeedGubunNeedTypeNeedAsmtCode(userId, info.getMakeHFileYn(), hospCode,
						info.getNeedGubun(), info.getNeedType(), info.getNeedAsmtCode());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0802Repository.deleteByHospCodeNeedGubunNeedTypeNeedAsmtCode(hospCode, info.getNeedGubun(),
						info.getNeedType(), info.getNeedAsmtCode());
			}
		}
		
		response.setResult(true);
		return response.build();
	}

}

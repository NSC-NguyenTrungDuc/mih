package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur8050;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur8050Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.NuriModelProto.NUR8050U00grdNur8050HisInfo;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR8050U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR8050U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur8050Repository nur8050Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8050U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Date sysDate = Calendar.getInstance().getTime();

		List<NUR8050U00grdNur8050HisInfo> infos = request.getGrdNur8050HisList();

		for (NUR8050U00grdNur8050HisInfo info : infos) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Nur8050 nur8050 = new Nur8050();
				nur8050.setSysDate(sysDate);
				nur8050.setSysId(userId);
				nur8050.setUpdDate(sysDate);
				nur8050.setUpdId(userId);
				nur8050.setHospCode(hospCode);
				nur8050.setBunho(info.getBunho());
				nur8050.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
				nur8050.setGubun(info.getGubun());
				nur8050.setDetail(info.getDetail());
				nur8050.setWriteDate(DateUtil.toDate(info.getWriteDate(), DateUtil.PATTERN_YYMMDD));
				nur8050.setWriteUser(info.getWriteUser());
				nur8050.setConfirmUser(info.getConfirmUser());

				nur8050Repository.save(nur8050);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				nur8050Repository.updateNUR8050U00(userId, info.getDetail(), info.getWriteUser(), info.getConfirmUser(),
						hospCode, info.getBunho(), CommonUtils.parseDouble(info.getFkinp1001()), info.getGubun(),
						DateUtil.toDate(info.getWriteDate(), DateUtil.PATTERN_YYMMDD));
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				nur8050Repository.deleteNUR8050U00(hospCode, info.getBunho(),
						CommonUtils.parseDouble(info.getFkinp1001()), info.getGubun(),
						DateUtil.toDate(info.getWriteDate(), DateUtil.PATTERN_YYMMDD));
			}
		}

		response.setResult(true);
		return response.build();
	}

}

package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1094;
import nta.med.core.domain.nur.Nur1095;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nur.Nur1094Repository;
import nta.med.data.dao.medi.nur.Nur1095Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR1094U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR1094U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private CommonRepository commonRepository;

	@Resource
	private Nur1094Repository nur1094Repository;

	@Resource
	private Nur1095Repository nur1095Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1094U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);

		List<NuriModelProto.NUR1094U00GrdMasterInfo> masterList = request.getGrdMasterList();
		List<NuriModelProto.NUR1094U00GrdDetailInfo> detailList = request.getGrdDetailList();
		
		String fknur1094 = "";
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR1094U00GrdMasterInfo info : masterList) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				String strSeq = commonRepository.getNextVal("NUR1094_SEQ");
				fknur1094 = strSeq;
				
				Nur1094 nur1094 = new Nur1094();
				nur1094.setSysDate(sysDate);
				nur1094.setSysId(userId);
				nur1094.setHospCode(hospCode);
				nur1094.setPknur1094(CommonUtils.parseDouble(fknur1094));
				nur1094.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
				nur1094.setCreateDate(DateUtil.toDate(info.getCreateDate(), DateUtil.PATTERN_YYMMDD));
				nur1094.setInputId(info.getInputId());
				nur1094.setSumScore(CommonUtils.parseDouble(info.getSumScore()));
				nur1094.setLevelScore(info.getLevelScore());
				nur1094.setRemark(info.getRemark());
				
				nur1094Repository.save(nur1094);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				fknur1094 = info.getPknur1094();
				nur1094Repository.updateByHospCodePknur1094(userId, info.getInputId(),
						CommonUtils.parseDouble(info.getSumScore()), info.getLevelScore(), info.getRemark(), hospCode,
						CommonUtils.parseDouble(info.getPknur1094()));
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				fknur1094 = info.getPknur1094();
				nur1094Repository.deleteByHospCodePknur1094(hospCode, CommonUtils.parseDouble(info.getPknur1094()));
			}
		}
		
		handleGrdDetail(hospCode, userId, detailList, CommonUtils.parseDouble(fknur1094));
		
		response.setResult(true);
		return response.build();
	}
	
	private void handleGrdDetail(String hospCode, String userId,
			List<NuriModelProto.NUR1094U00GrdDetailInfo> detailList, Double fknur1094) {
		Date sysDate = Calendar.getInstance().getTime();
		for (NuriModelProto.NUR1094U00GrdDetailInfo info : detailList) {
			if (DataRowState.ADDED.getValue().equals(info.getDataRowState())) {
				Nur1095 nur1095 = new Nur1095();
				nur1095.setSysDate(sysDate);
				nur1095.setSysId(userId);
				nur1095.setHospCode(hospCode);
				nur1095.setFknur1094(fknur1094);
				nur1095.setCodeType(info.getCodeType());
				nur1095.setCode(info.getCode());
				
				nur1095Repository.save(nur1095);
			} else if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
				nur1095Repository.updateByHospCodeFknur1094CodeTypeCode(userId, hospCode,
						CommonUtils.parseDouble(info.getFknur1094()), info.getCodeType(), info.getCode());
			} else if (DataRowState.DELETED.getValue().equals(info.getDataRowState())) {
				nur1095Repository.deleteByHospCodeFknur1094CodeTypeCode(hospCode,
						CommonUtils.parseDouble(info.getFknur1094()), info.getCodeType(), info.getCode());
			}
		}
	}

}

package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1093;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1093Repository;
import nta.med.service.ihis.proto.NuriModelProto.NUR1093U00grdMasterInfo;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1093U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR1093U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR1093U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur1093Repository nur1093Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1093U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		Date sysDate = Calendar.getInstance().getTime();
		String userId = getUserId(vertx, sessionId);
		
		List<NUR1093U00grdMasterInfo> infos = request.getItemsList();
		
		for (NUR1093U00grdMasterInfo info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur1093 nur1093 = new Nur1093();
				nur1093.setSysDate(sysDate);
				nur1093.setSysId(userId);
				nur1093.setHospCode(hospCode);
				nur1093.setCode(info.getCode());
				nur1093.setFromDate(DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
				nur1093.setToDate(DateUtil.toDate(info.getToDate(), DateUtil.PATTERN_YYMMDD));
				nur1093.setCodeName(info.getCodeName());
				nur1093.setFromScore(CommonUtils.parseDouble(info.getFromScore()));
				nur1093.setToScore(CommonUtils.parseDouble(info.getToScore()));
				nur1093.setSortSeq(CommonUtils.parseDouble(info.getSortSeq()));
				nur1093.setCodeCmt(info.getCodeCmt());
				nur1093.setBedDisplayYn(info.getBedDisplayYn());
				
				nur1093Repository.save(nur1093);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur1093Repository.updateByHospCodeCodeFromDate(userId
						, DateUtil.toDate(info.getToDate(), DateUtil.PATTERN_YYMMDD)
						, info.getCodeName()
						, CommonUtils.parseDouble(info.getFromScore())
						, CommonUtils.parseDouble(info.getToScore())
						, CommonUtils.parseDouble(info.getSortSeq())
						, info.getCodeCmt()
						, info.getBedDisplayYn()
						, hospCode
						, info.getCode()
						, DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur1093Repository.deleteByHospCodeCodeFromDate(hospCode, info.getCode(),
						DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
			}
		}
		
		response.setResult(true);
		return response.build();
	}

}

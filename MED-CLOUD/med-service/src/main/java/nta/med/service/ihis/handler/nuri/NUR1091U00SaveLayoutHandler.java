package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1091;
import nta.med.core.domain.nur.Nur1092;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1091Repository;
import nta.med.data.dao.medi.nur.Nur1092Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR1091U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR1091U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur1091Repository nur1091Repository;
	
	@Resource
	private Nur1092Repository nur1092Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1091U00SaveLayoutRequest request) throws Exception {

		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		List<NuriModelProto.NUR1091U00grdMasterInfo> grdMaster = request.getGrdmasterinfoList();
		List<NuriModelProto.NUR1091U00grdDetailInfo> grdDetail = request.getGrddetailinfoList();
		
		handleGrdMaster(hospCode, userId, grdMaster);
		
		handleGrdDetail(hospCode, userId, grdDetail);
		
		response.setResult(true);
		return response.build();
	}
	
	public void handleGrdMaster(String hospCode, String userId, List<NuriModelProto.NUR1091U00grdMasterInfo> grdMaster){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR1091U00grdMasterInfo info : grdMaster) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur1091 nur1091 = new Nur1091();
				nur1091.setSysDate(sysDate);
				nur1091.setSysId(userId);
				nur1091.setHospCode(hospCode);
				nur1091.setCodeType(info.getCodeType());
				nur1091.setFromDate(DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
				nur1091.setToDate(DateUtil.toDate(info.getToDate(), DateUtil.PATTERN_YYMMDD));
				nur1091.setCodeTypeName(info.getCodeTypeName());
				nur1091.setMaxScore(CommonUtils.parseDouble(info.getMaxScore()));
				nur1091.setSortSeq(CommonUtils.parseDouble(info.getSortSeq()));
				
				nur1091Repository.save(nur1091);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur1091Repository.updateByHospCodeCodeTypeFromDate(userId,
						DateUtil.toDate(info.getToDate(), DateUtil.PATTERN_YYMMDD), info.getCodeTypeName(),
						CommonUtils.parseDouble(info.getMaxScore()), CommonUtils.parseDouble(info.getSortSeq()),
						hospCode, info.getCodeType(), DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur1091Repository.deleteByHospCodeCodeTypeFromDate(hospCode, info.getCodeType(),
						DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
			}
		}
	}
	
	public void handleGrdDetail(String hospCode, String userId, List<NuriModelProto.NUR1091U00grdDetailInfo> grdDetail){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR1091U00grdDetailInfo info : grdDetail) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur1092 nur1092 = new Nur1092();
				nur1092.setSysDate(sysDate);
				nur1092.setSysId(userId);
				nur1092.setHospCode(hospCode);
				nur1092.setCodeType(info.getCodeType());
				nur1092.setCode(info.getCode());
				nur1092.setFromDate(DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
				nur1092.setToDate(DateUtil.toDate(info.getToDate(), DateUtil.PATTERN_YYMMDD));    
				nur1092.setCodeName(info.getCodeName());
				nur1092.setScore(CommonUtils.parseDouble(info.getScore()));
				nur1092.setSortSeq(CommonUtils.parseDouble(info.getSortSeq()));
				
				nur1092Repository.save(nur1092);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur1092Repository.updateByHospCodeCodeTypeCodeFromdate(userId,
						DateUtil.toDate(info.getToDate(), DateUtil.PATTERN_YYMMDD), info.getCodeName(), CommonUtils.parseDouble(info.getScore()), CommonUtils.parseDouble(info.getSortSeq()),
						hospCode, info.getCodeType(), info.getCode(), DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur1092Repository.deleteByHospCodeCodeTypeCodeFromdate(hospCode, info.getCodeType(), info.getCode(),
						DateUtil.toDate(info.getFromDate(), DateUtil.PATTERN_YYMMDD));
			}
		}
	}
}

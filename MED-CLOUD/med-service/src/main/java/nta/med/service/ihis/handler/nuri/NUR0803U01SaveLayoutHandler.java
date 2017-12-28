package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0803;
import nta.med.core.domain.nur.Nur0804;
import nta.med.core.domain.nur.Nur0805;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.data.dao.medi.nur.Nur0804Repository;
import nta.med.data.dao.medi.nur.Nur0805Repository;
import nta.med.service.ihis.proto.NuriModelProto.NUR0803U01grdNUR0803Info;
import nta.med.service.ihis.proto.NuriModelProto.NUR0803U01grdNUR0804Info;
import nta.med.service.ihis.proto.NuriModelProto.NUR0803U01grdNUR0805Info;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0803U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR0803U01SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR0803U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur0803Repository nur0803Repository;
	
	@Resource
	private Nur0804Repository nur0804Repository;
	
	@Resource
	private Nur0805Repository nur0805Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0803U01SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);

		List<NUR0803U01grdNUR0803Info> grdNUR0803List = request.getGrdNUR0803ListList();
		List<NUR0803U01grdNUR0804Info> grdNUR0804List = request.getGrdNUR0804ListList();
		List<NUR0803U01grdNUR0805Info> grdNUR0805List = request.getGrdNUR0805ListList();

		handleGrdNUR0803List(hospCode, userId, grdNUR0803List);
		
		handleGrdNUR0804List(hospCode, userId, grdNUR0804List);
		
		handleGrdNUR0805List(hospCode, userId, grdNUR0805List);
		
		response.setResult(true);
		return response.build();
	}

	private void handleGrdNUR0803List(String hospCode, String userId, List<NUR0803U01grdNUR0803Info> grdNUR0803List) {
		Date sysDate = Calendar.getInstance().getTime();
		for (NUR0803U01grdNUR0803Info info : grdNUR0803List) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0803 nur0803 = new Nur0803();
				nur0803.setSysDate(sysDate);
				nur0803.setSysId(userId);
				nur0803.setUpdDate(sysDate);
				nur0803.setUpdId(userId);
				nur0803.setHospCode(hospCode);
				nur0803.setNeedGubun(info.getNeedGubun());
				nur0803.setNeedAsmtCode(info.getNeedAsmtCode());
				nur0803.setNeedAsmtName(info.getNeedAsmtName());
				nur0803.setGlobalYn(info.getGlobalYn());
				nur0803.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				nur0803.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
				nur0803.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				
				nur0803Repository.save(nur0803);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0803Repository.updateByHospCodeNeedGubunNeedAsmtCodeStartDate(userId, info.getNeedAsmtName(),
						info.getGlobalYn(), DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD),
						CommonUtils.parseDouble(info.getSortKey()), hospCode, info.getNeedGubun(),
						info.getNeedAsmtCode(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0803Repository.deleteByHospCodeNeedGubunNeedAsmtCodeStartDate(hospCode, info.getNeedGubun(),
						info.getNeedAsmtCode(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
			}
		}
	}

	private void handleGrdNUR0804List(String hospCode, String userId, List<NUR0803U01grdNUR0804Info> grdNUR0804List) {
		Date sysDate = Calendar.getInstance().getTime();
		for (NUR0803U01grdNUR0804Info info : grdNUR0804List) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0804 nur0804 = new Nur0804();
				nur0804.setSysDate(sysDate);
				nur0804.setSysId(userId);
				nur0804.setUpdDate(sysDate);
				nur0804.setUpdId(userId);
				nur0804.setHospCode(hospCode);
				nur0804.setNeedGubun(info.getNeedGubun());
				nur0804.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				nur0804.setNeedAsmtCode(info.getNeedAsmtCode());
				nur0804.setNeedResultCode(info.getNeedResultCode());
				nur0804.setNeedResultName(info.getNeedResultName());
				nur0804.setNeedResultPoint(CommonUtils.parseDouble(info.getNeedResultPoint()));
				nur0804.setSumGubun(info.getSumGubun());
				nur0804.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0804.setGlobalYn(info.getGlobalYn());
				
				nur0804Repository.save(nur0804);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0804Repository.updateByHospCodeNeedGubunNeedAsmtCodeNeedResultCodeStartDate(userId,
						info.getNeedResultName(), info.getSumGubun(), CommonUtils.parseDouble(info.getSortKey()),
						info.getGlobalYn(), hospCode, info.getNeedGubun(), info.getNeedAsmtCode(),
						info.getNeedResultCode(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0804Repository.deleteByHospCodeNeedGubunNeedAsmtCodeNeedResultCodeStartDate(hospCode,
						info.getNeedGubun(), info.getNeedAsmtCode(), info.getNeedResultCode(),
						DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
			}
		}
	}

	private void handleGrdNUR0805List(String hospCode, String userId, List<NUR0803U01grdNUR0805Info> grdNUR0805List) {
		Date sysDate = Calendar.getInstance().getTime();
		for (NUR0803U01grdNUR0805Info info : grdNUR0805List) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0805 nur0805 = new Nur0805();
				nur0805.setSysDate(sysDate);
				nur0805.setSysId(userId);
				nur0805.setUpdDate(sysDate);
				nur0805.setUpdId(userId);
				nur0805.setHospCode(hospCode);
				nur0805.setNeedGubun(info.getNeedGubun());
				nur0805.setNeedAsmtCode(info.getNeedAsmtCode());
				nur0805.setNeedResultCode(info.getNeedResultCode());
				nur0805.setNeedSoCode(info.getNeedSoCode());
				nur0805.setNeedSoName(info.getNeedSoName());
				nur0805.setNeedSoPoint(CommonUtils.parseDouble(info.getNeedSoPoint()));
				nur0805.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0805.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				nur0805.setHFileFlag(info.getHFileFlag());
				
				nur0805Repository.save(nur0805);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0805Repository.updateNUR0803U01(userId, info.getNeedSoName(),
						CommonUtils.parseDouble(info.getNeedSoPoint()), CommonUtils.parseDouble(info.getSortKey()),
						//info.getHFileFlag(), 
						hospCode, info.getNeedGubun(), info.getNeedAsmtCode(),
						info.getNeedResultCode(), info.getNeedSoCode(),
						DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0805Repository.deleteNUR0803U01(hospCode, info.getNeedGubun(), info.getNeedAsmtCode(),
						info.getNeedResultCode(), info.getNeedSoCode(),
						DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
			}
		}
	}
}

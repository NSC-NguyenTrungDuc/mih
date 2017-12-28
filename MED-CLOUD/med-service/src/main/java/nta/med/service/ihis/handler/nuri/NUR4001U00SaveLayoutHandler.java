package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur4001;
import nta.med.core.domain.nur.Nur4003;
import nta.med.core.domain.nur.Nur4004;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nur.Nur4001Repository;
import nta.med.data.dao.medi.nur.Nur4003Repository;
import nta.med.data.dao.medi.nur.Nur4004Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

@Service
@Scope("prototype")
public class NUR4001U00SaveLayoutHandler extends
		ScreenHandler<NuriServiceProto.NUR4001U00SaveLayoutRequest, NuriServiceProto.NUR4001U00SaveLayoutResponse> {

	@Resource
	private Nur4001Repository nur4001Repository;
	
	@Resource
	private Nur4003Repository nur4003Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Nur4004Repository nur4004Repository;
	
	@Override
	@Transactional
	public NuriServiceProto.NUR4001U00SaveLayoutResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, NuriServiceProto.NUR4001U00SaveLayoutRequest request) throws Exception {
		NuriServiceProto.NUR4001U00SaveLayoutResponse.Builder response = NuriServiceProto.NUR4001U00SaveLayoutResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		List<NuriModelProto.NUR4001U00GrdNUR4001Info> grdSave = request.getGrdSaveList();
		List<NuriModelProto.NUR4001U00LayPlanQueryStartInfo> laySave = request.getLaySaveList();
		
		handleNur4001(hospCode, userId, grdSave);
		
		handleLaySave(hospCode, userId, laySave);
		
		response.setSaveResult(true);
		return response.build();
	}
	
	private boolean handleNur4001(String hospCode, String userId, List<NuriModelProto.NUR4001U00GrdNUR4001Info> grdSave){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR4001U00GrdNUR4001Info info : grdSave) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur4001 nur4001 = new Nur4001();
				nur4001.setSysDate(sysDate);
				nur4001.setSysId(userId);
				nur4001.setUpdDate(sysDate);
				nur4001.setUpdId(userId);
				nur4001.setHospCode(hospCode);
				nur4001.setPknur4001(CommonUtils.parseDouble(info.getPknur4001()));
				nur4001.setBunho(info.getBunho());
				nur4001.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
				nur4001.setNurPlanJin(info.getNurPlanJin());
				nur4001.setNurPlanJinName(info.getNurPlanJinName());
				nur4001.setPlanUser(info.getPlanUser());
				nur4001.setPlanDate(DateUtil.toDate(info.getPlanDate(), DateUtil.PATTERN_YYMMDD));
				nur4001.setVald("Y");
				nur4001.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur4001.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
				nur4001.setPurpose(info.getPurpose());
				
				nur4001Repository.save(nur4001);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur4001Repository.updateByHospCodePknur4001(userId, info.getNurPlanJin(), info.getNurPlanJinName(),
						info.getPlanUser(), DateUtil.toDate(info.getPlanDate(), DateUtil.PATTERN_YYMMDD), "Y", CommonUtils.parseDouble(info.getSortKey()),
						DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD), info.getPurpose(), hospCode, CommonUtils.parseDouble(info.getPknur4001()));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur4001Repository.callPrNurNur4001Delete(hospCode, CommonUtils.parseDouble(info.getPknur4001()));
			}
		}
		
		return true;
	}
	
	private boolean handleLaySave(String hospCode, String userId, List<NuriModelProto.NUR4001U00LayPlanQueryStartInfo> laySave){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR4001U00LayPlanQueryStartInfo info : laySave) {
			Double pknur4003 = null;
			
			// handle NUR4003
			if (!StringUtils.isEmpty(info.getPknur4003())
					&& CommonUtils.parseDouble(info.getPknur4003()).equals(CommonUtils.parseDouble("0"))) {
				String strPknur4003 = commonRepository.getNextVal("NUR4003_SEQ");
				pknur4003 = CommonUtils.parseDouble(strPknur4003);
				
				Nur4003 nur4003 = new Nur4003();
				nur4003.setSysDate(sysDate);
				nur4003.setSysId(userId);
				nur4003.setUpdDate(sysDate);
				nur4003.setUpdId(userId);
				nur4003.setHospCode(hospCode);
				nur4003.setPknur4003(pknur4003);
				nur4003.setFknur4001(CommonUtils.parseDouble(info.getFknur4001()));
				nur4003.setNurPlan(CommonUtils.parseDouble(info.getNurPlan()));
				nur4003.setNurPlanOte(info.getNurPlanOte());
				nur4003.setNurPlanName(info.getNurPlanName());
				nur4003.setSortKey(CommonUtils.parseDouble(info.getNurSort1()));
				nur4003.setVald(info.getNur4003Vald());
				nur4003.setInputDate(DateUtil.toDate(DateUtil.toString(sysDate, DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD));
				
				nur4003Repository.save(nur4003);
			}
			else if(!StringUtils.isEmpty(info.getPknur4003())
					&& !CommonUtils.parseDouble(info.getPknur4003()).equals(CommonUtils.parseDouble("0"))){
				pknur4003 = CommonUtils.parseDouble(info.getPknur4003());
				nur4003Repository.updateByHospCodeNur4003(userId, info.getNurPlanName(), info.getNur4003Vald(),
						hospCode, pknur4003);
			}
			
			// handle NUR4004
			if (!StringUtils.isEmpty(info.getPknur4004())
					&& CommonUtils.parseDouble(info.getPknur4004()).equals(CommonUtils.parseDouble("0"))) {
				String strPknur4004 = commonRepository.getNextVal("NUR4004_SEQ");
				Double pknur4004 = CommonUtils.parseDouble(strPknur4004);
				
				Nur4004 nur4004 = new Nur4004();
				nur4004.setSysDate(sysDate);
				nur4004.setSysId(userId);
				nur4004.setUpdDate(sysDate);
				nur4004.setUpdId(userId);
				nur4004.setHospCode(hospCode);
				nur4004.setPknur4004(pknur4004);
				nur4004.setFknur4003(pknur4003);
				nur4004.setNurPlan(CommonUtils.parseDouble(info.getNurPlan()));
				nur4004.setNurPlanDetail(info.getNurPlanDetail());
				nur4004.setNurPlanDename(info.getNurPlanDename());
				nur4004.setSortKey(CommonUtils.parseDouble(info.getNurSort2())); //TODO
				nur4004.setVald(info.getNur4004Vald());
				nur4004.setInputDate(DateUtil.toDate(DateUtil.toString(sysDate, DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD));
				
				nur4004Repository.save(nur4004);
			}
			else if(!StringUtils.isEmpty(info.getPknur4004())
					&& !CommonUtils.parseDouble(info.getPknur4004()).equals(CommonUtils.parseDouble("0"))){
				nur4004Repository.updateByHospCodePknur4004(userId, info.getNurPlanDename(), info.getNur4004Vald(),
						hospCode, CommonUtils.parseDouble(info.getPknur4004()));
			}
		}
		
		return true;
	}
	
	
}

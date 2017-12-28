package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inp.Inp1004;
import nta.med.core.domain.nur.Nur1001;
import nta.med.core.domain.nur.Nur1029;
import nta.med.core.domain.out.Out0106;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inp.Inp1004Repository;
import nta.med.data.dao.medi.nur.Nur1001Repository;
import nta.med.data.dao.medi.nur.Nur1029Repository;
import nta.med.data.dao.medi.out.Out0106Repository;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR1001U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(NUR1001U00SaveLayoutHandler.class);
	
	@Resource
	private Out0106Repository out0106Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Nur1029Repository nur1029Repository;

	@Resource
	private Nur1001Repository nur1001Repository;
	
	@Resource
	private Inp1004Repository inp1004Repository;
	
	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00SaveLayoutRequest request) throws Exception {
				
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		String bunho = request.getBunho();
		
		List<NuriModelProto.NUR1001U00LayNUR1001Info> layNur1001 = request.getLayNUR1001List();
		List<NuriModelProto.NUR1001U00GrdOUT0106Info> grdOut0106 = request.getGrdOUT0106List();
		List<NuriModelProto.NUR1001U00GrdINP1004Info> grdInp1004 = request.getGrdINP1004List();
		List<NuriModelProto.NUR1001U00GrdNUR1029Info> grdNur1029 = request.getGrdNUR1029List();
		
		for(NuriModelProto.NUR1001U00GrdOUT0106Info item : grdOut0106){
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				Double nextSeq = out0106Repository.getSerOUT0106U00SaveComments(hospCode, bunho);
				if(nextSeq == null){
					LOGGER.info(String.format("%s順番がありません。", bunho));
					throw new ExecutionException(response.setResult(false).build());
				}
				insertOut0106(item, bunho, nextSeq, hospCode, userId);
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if(out0106Repository.updateOUT0106U00SaveComments(userId, new Date(), item.getComments(), item.getDisplayYn(), 
						hospCode, bunho, CommonUtils.parseDouble(item.getSer())) < 0){
					throw new ExecutionException(response.setResult(false).build());
				}
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if(out0106Repository.deleteOUT0106U00SaveComments(hospCode, bunho, CommonUtils.parseDouble(item.getSer())) < 0){
					throw new ExecutionException(response.setResult(false).build());
				}
			}
		}
		
		for(NuriModelProto.NUR1001U00GrdNUR1029Info item : grdNur1029){
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				String nexVal = commonRepository.getNextVal("NUR1029_SEQ");
				if(nexVal == null){
					LOGGER.info(String.format("NUR1029_SEQ順番がありません。"));
					throw new ExecutionException(response.setResult(false).build());
				}
				insertNur1029(item, bunho, hospCode, userId, CommonUtils.parseDouble(nexVal));
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if(nur1029Repository.updateNur1029SaveLayout(userId, item.getBuwi(), item.getStartDate(), item.getBuwiComment(), hospCode, bunho,
						CommonUtils.parseDouble(item.getPknur1029())) < 0){
					throw new ExecutionException(response.setResult(false).build());
				}
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if(nur1029Repository.deleteNur1029SaveLayout(CommonUtils.parseDouble(item.getPknur1029()), hospCode, bunho) < 0){
					throw new ExecutionException(response.setResult(false).build());
				}
			}
		}
		
		for(NuriModelProto.NUR1001U00LayNUR1001Info item : layNur1001){
			if(nur1001Repository.checkNUR1001U00isExist(hospCode, bunho, CommonUtils.parseDouble(item.getFkinp1001())) != null){
				handleNur1001(item, hospCode, bunho, userId, "U");
			}else{
				handleNur1001(item, hospCode, bunho, userId, "I");
			}
		}
		
		for(NuriModelProto.NUR1001U00GrdINP1004Info item : grdInp1004){
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				Double nextSeq = inp1004Repository.getNextSeqInp1004ByBunho(hospCode, bunho);
				insertInp1004(item, hospCode, bunho, userId, nextSeq);
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if(item.getSeq() == "" || StringUtils.isEmpty(item.getSeq())){
					LOGGER.info(String.format("保証人順番が見つかりません。"));
					throw new ExecutionException(response.setResult(false).setMsg("保証人順番が見つかりません。").build());
				}
				if(inp1004Repository.updateInp1004ByBunhoSeq(userId, item.getName(), item.getZipCode1(), item.getZipCode2(), item.getAddress1(),
						item.getAddress2(), item.getTel1(), item.getTel2(), item.getBigo(), item.getBoninGubun(), item.getTel3(), item.getTelGubun(),
						item.getTelGubun2(), item.getTelGubun3(), item.getName2(), CommonUtils.parseDouble(item.getPriority()), item.getBirth(),
						item.getWithYn(), item.getLiveYn(), hospCode, bunho, CommonUtils.parseDouble(item.getSeq())) < 0){
					throw new ExecutionException(response.setResult(false).build());
				}
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if(inp1004Repository.deleteInp1004ByBunhoSeq(hospCode, bunho, CommonUtils.parseDouble(item.getSeq())) < 0){
					throw new ExecutionException(response.setResult(false).build());
				}
			}
		}
		response.setResult(true);
		return response.build();
	}
	
	
	private void insertOut0106(NuriModelProto.NUR1001U00GrdOUT0106Info item, String bunho, Double nextSeq, String hospCode, String userId){
		Out0106 out0106 = new Out0106();
		out0106.setSysDate(new Date());
		out0106.setSysId(userId);
		out0106.setUpdDate(new Date());
		out0106.setUpdId(userId);
		out0106.setHospCode(hospCode);
		out0106.setComments(item.getComments());
		out0106.setSer(nextSeq);
		out0106.setBunho(bunho);
		out0106.setDisplayYn(item.getDisplayYn());
		out0106.setCmmtGubun("B");
		out0106Repository.save(out0106);
	}
	
	private void insertNur1029(NuriModelProto.NUR1001U00GrdNUR1029Info item, String bunho, String hospCode, String userId, Double nextPk){
		Nur1029 nur1029 = new Nur1029();
		nur1029.setSysDate(new Date());
		nur1029.setSysId(userId);
		nur1029.setUpdDate(new Date());
		nur1029.setUpdId(userId);
		nur1029.setHospCode(hospCode);
		nur1029.setPknur1029(nextPk);
		nur1029.setBunho(bunho);
		nur1029.setBuwi(item.getBuwi());
		nur1029.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
		nur1029.setBuwiComment(item.getBuwiComment());
		nur1029Repository.save(nur1029);
	}
	
	private void handleNur1001(NuriModelProto.NUR1001U00LayNUR1001Info item, String hospCode, String bunho, String userId, String updGubun){
		Nur1001 nur1001 = new Nur1001();
		if("U".equals(updGubun)){
			List<Nur1001> listNur1001 = nur1001Repository.findByHospCodeBunhoFkinp1001(hospCode, bunho, CommonUtils.parseDouble(item.getFkinp1001()));
			nur1001 = listNur1001.get(0);
		}
		if("I".equals(updGubun)){
			nur1001.setSysDate(new Date());
			nur1001.setSysId(userId);
		}
		nur1001.setUpdDate(new Date());
		nur1001.setUpdId(userId);
		nur1001.setHospCode(hospCode);
		nur1001.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		nur1001.setBunho(item.getBunho());
		nur1001.setBloodTypeAbo(item.getBloodTypeAbo());
		nur1001.setBloodTypeRh(item.getBloodTypeRh());
		nur1001.setPurpose(item.getPurpose());
		nur1001.setInformant(item.getInformant());
		nur1001.setKeyName1(item.getKeyName1());
		nur1001.setKeyRelation1(item.getKeyRelation1());
		nur1001.setKeyHome1(item.getKeyHome1());
		nur1001.setWriter(item.getWriter());
		nur1001.setDiagnosisName(item.getDiagnosisName());
		nur1001.setDiagnosisGubun(item.getDiagnosisGubun());
		nur1001.setInpatientCourse(item.getInpatientCourse());
		nur1001.setAssessment0(item.getAssessment0());
		nur1001.setPastHis(item.getPastHis());
		nur1001.setBringDrugYn(item.getBringDrugYn());
		nur1001.setBringDrugComment(item.getBringDrugComment());
		nur1001.setHealthcareYn(item.getHealthcareYn());
		nur1001.setHealthcareComment(item.getHealthcareComment());
		nur1001.setSmokingDay(CommonUtils.parseDouble(item.getSmokingDay()));
		nur1001.setDrinking(item.getDrinking());
		nur1001.setExplainDoctor(item.getExplainDoctor());
		nur1001.setExplainPatient(item.getExplainPatient());
		nur1001.setExplainFamily(item.getExplainFamily());
		nur1001.setAssessment1(item.getAssessment1());
		nur1001.setMainFood(item.getMainFood());
		nur1001.setSubFood(item.getSubFood());
		nur1001.setFoodDislikeYn(item.getFoodDislikeYn());
		nur1001.setFoodDislikeComment(item.getFoodDislikeComment());
		nur1001.setAppetiteYn(item.getAppetiteYn());
		nur1001.setAppetiteComment(item.getAppetiteComment());
		nur1001.setDysphagiaYn(item.getDysphagiaYn());
		nur1001.setDysphagiaComment(item.getDysphagiaComment());
		nur1001.setIntakeWay(item.getIntakeWay());
		nur1001.setIntakeComment(item.getIntakeComment());
		nur1001.setFoodLimit(item.getFoodLimit());
		nur1001.setMouthPollutionYn(item.getMouthPollutionYn());
		nur1001.setMouthPollutionComment(item.getMouthPollutionComment());
		nur1001.setFalseTeethYn(item.getFalseTeethYn());
		nur1001.setFalseTeethComment(item.getFalseTeethComment());
		nur1001.setWeightUpdownStart(item.getWeightUpdownStart());
		nur1001.setWeightUpdownHow(item.getWeightUpdownHow());
		nur1001.setHeight(item.getHeight());
		nur1001.setWeight(item.getWeight());
		nur1001.setDungCount(item.getDungCount());
		nur1001.setDungDay(item.getDungDay());
		nur1001.setDungState(item.getDungState());
		nur1001.setDungLast(item.getDungLast());
		nur1001.setDungWillYn(item.getDungWillYn());
		nur1001.setDiapersYn(item.getDiapersYn());
		nur1001.setOrthoticsYn(item.getOrthoticsYn());
		nur1001.setEnemaYn(item.getEnemaYn());
		nur1001.setLaxativeYn(item.getLaxativeYn());
		nur1001.setSuppositoryYn(item.getSuppositoryYn());
		nur1001.setAntidiarrhealYn(item.getAntidiarrhealYn());
		nur1001.setLaxationComment(item.getLaxationComment());
		nur1001.setUrinCount(item.getUrinCount());
		nur1001.setUrinDay(item.getUrinDay());
		nur1001.setUrinNightCount(item.getUrinNightCount());
		nur1001.setUrinWillYn(item.getUrinWillYn());
		nur1001.setIntermittentYn(item.getIntermittentYn());
		nur1001.setIntermittentComment(item.getIntermittentComment());
		nur1001.setCatheterYn(item.getCatheterYn());
		nur1001.setCatheterStartDate(DateUtil.toDate(item.getCatheterStartDate(), DateUtil.PATTERN_YYMMDD));
		nur1001.setAbdominalInflationYn(item.getAbdominalInflationYn());
		nur1001.setAbdominalInflationVeryYn(item.getAbdominalInflationVeryYn());
		nur1001.setEnterokinesiaYn(item.getEnterokinesiaYn());
		nur1001.setAssessment2(item.getAssessment2());
		nur1001.setAdlFoodState(item.getAdlFoodState());
		nur1001.setAdlFoodComment(item.getAdlFoodComment());
		nur1001.setAdlBathState(item.getAdlBathState());
		nur1001.setAdlBathComment(item.getAdlBathComment());
		nur1001.setAdlClothState(item.getAdlClothState());
		nur1001.setAdlClothComment(item.getAdlClothComment());
		nur1001.setAdlWashState(item.getAdlWashState());
		nur1001.setAdlWashComment(item.getAdlWashComment());
		nur1001.setAdlExcretionState(item.getAdlExcretionState());
		nur1001.setAdlExcretionComment(item.getAdlExcretionComment());
		nur1001.setAdlStruggleState(item.getAdlStruggleState());
		nur1001.setAdlStruggleComment(item.getAdlStruggleComment());
		nur1001.setAdlBoardState(item.getAdlBoardState());
		nur1001.setAdlBoardComment(item.getAdlBoardComment());
		nur1001.setAdlWheelchairState(item.getAdlWheelchairState());
		nur1001.setAdlWheelchairComment(item.getAdlWheelchairComment());
		nur1001.setAdlWalkState(item.getAdlWalkState());
		nur1001.setAdlWalkComment(item.getAdlWalkComment());
		nur1001.setNeedCare(item.getNeedCare());
		nur1001.setNeedSupport(item.getNeedSupport());
		nur1001.setServiceComment(item.getServiceComment());
		nur1001.setCareOfficeComment(item.getCareOfficeComment());
		nur1001.setSleepTime(item.getSleepTime());
		nur1001.setSleepStartTime(item.getSleepStartTime());
		nur1001.setSleepEndTime(item.getSleepEndTime());
		nur1001.setSleepEnoughYn(item.getSleepEnoughYn());
		nur1001.setSleepEnoughComment(item.getSleepEnoughComment());
		nur1001.setSleeplessComment(item.getSleeplessComment());
		nur1001.setSnoringYn(item.getSnoringYn());
		nur1001.setSleepTalkYn(item.getSleepTalkYn());
		nur1001.setTeethGrindingYn(item.getTeethGrindingYn());
		nur1001.setSleepEtcYn(item.getSleepEtcYn());
		nur1001.setSleepEtcComment(item.getSleepEtcComment());
		nur1001.setAssessment4(item.getAssessment4());
		nur1001.setSenseLevel(item.getSenseLevel());
		nur1001.setObstacleSpeechYn(item.getObstacleSpeechYn());
		nur1001.setObstacleSenseYn(item.getObstacleSenseYn());
		nur1001.setObstacleYn(item.getObstacleYn());
		nur1001.setObstacleComment(item.getObstacleComment());
		nur1001.setRecognitionYn(item.getRecognitionYn());
		nur1001.setRecognitionComment(item.getRecognitionComment());
		nur1001.setSensorYn(item.getSensorYn());
		nur1001.setEyeRightYn(item.getEyeRightYn());
		nur1001.setEyeRightComment(item.getEyeRightComment());
		nur1001.setEyeLeftYn(item.getEyeLeftYn());
		nur1001.setEyeLeftComment(item.getEyeLeftComment());
		nur1001.setEyeGlassesYn(item.getEyeGlassesYn());
		nur1001.setEyeLensYn(item.getEyeLensYn());
		nur1001.setEarRightYn(item.getEarRightYn());
		nur1001.setEarRightComment(item.getEarRightComment());
		nur1001.setEarLeftYn(item.getEarLeftYn());
		nur1001.setEarLeftComment(item.getEarLeftComment());
		nur1001.setEarAidYn(item.getEarAidYn());
		nur1001.setNoseComment(item.getNoseComment());
		nur1001.setMouthComment(item.getMouthComment());
		nur1001.setDizzyYn(item.getDizzyYn());
		nur1001.setDizzyComment(item.getDizzyComment());
		nur1001.setStaggerYn(item.getStaggerYn());
		nur1001.setStaggerComment(item.getStaggerComment());
		nur1001.setPainYn(item.getPainYn());
		nur1001.setPainComment(item.getPainComment());
		nur1001.setPerceptionYn(item.getPerceptionYn());
		nur1001.setPerceptionComment(item.getPerceptionComment());
		nur1001.setMovementYn(item.getMovementYn());
		nur1001.setParalysisYn(item.getParalysisYn());
		nur1001.setParalysisComment(item.getParalysisComment());
		nur1001.setContractureYn(item.getContractureYn());
		nur1001.setContractureComment(item.getContractureComment());
		nur1001.setLossPartYn(item.getLossPartYn());
		nur1001.setLossPartComment(item.getLossPartComment());
		nur1001.setWorryYn(item.getWorryYn());
		nur1001.setWorryComment(item.getWorryComment());
		nur1001.setFearYn(item.getFearYn());
		nur1001.setFearComment(item.getFearComment());
		nur1001.setAssessment5(item.getAssessment5());
		nur1001.setFamilyYn(item.getFamilyYn());
		nur1001.setFamilyComment(item.getFamilyComment());
		nur1001.setJob(item.getJob());
		nur1001.setJobMate(item.getJobMate());
		nur1001.setHouseKind(item.getHouseKind());
		nur1001.setBarrierFreeYn(item.getBarrierFreeYn());
		nur1001.setMenses(item.getMenses());
		nur1001.setMensesAge(item.getMensesAge());
		nur1001.setMensesProblemYn(item.getMensesProblemYn());
		nur1001.setMensesProblemComment(item.getMensesProblemComment());
		nur1001.setPregnancyYn(item.getPregnancyYn());
		nur1001.setHobbyYn(item.getHobbyYn());
		nur1001.setHobbyComment(item.getHobbyComment());
		nur1001.setStressYn(item.getStressYn());
		nur1001.setStressComment(item.getStressComment());
		nur1001.setStressManage(item.getStressManage());
		nur1001.setReligionYn(item.getReligionYn());
		nur1001.setReligionComment(item.getReligionComment());
		nur1001.setAssessment7(item.getAssessment7());
		nur1001.setKeyCell1(item.getKeyCell1());
		nur1001.setKeyOffice1(item.getKeyOffice1());
		nur1001.setKeyName2(item.getKeyName2());
		nur1001.setKeyRelation2(item.getKeyRelation2());
		nur1001.setKeyHome2(item.getKeyHome2());
		nur1001.setKeyCell2(item.getKeyCell2());
		nur1001.setKeyOffice2(item.getKeyOffice2());
		nur1001.setKeyComment(item.getKeyComment());
		nur1001.setKeyHome1Pri(CommonUtils.parseDouble(item.getKeyHome1Pri()));
		nur1001.setKeyCell1Pri(CommonUtils.parseDouble(item.getKeyCell1Pri()));
		nur1001.setKeyOffice1Pri(CommonUtils.parseDouble(item.getKeyOffice1Pri()));
		nur1001.setKeyHome2Pri(CommonUtils.parseDouble(item.getKeyHome2Pri()));
		nur1001.setKeyCell2Pri(CommonUtils.parseDouble(item.getKeyCell2Pri()));
		nur1001.setKeyOffice2Pri(CommonUtils.parseDouble(item.getKeyOffice2Pri()));

		nur1001Repository.save(nur1001);
	}
	
	private void insertInp1004(NuriModelProto.NUR1001U00GrdINP1004Info item, String hospCode, String bunho, String userId, Double nextSeq){
		Inp1004 inp1004 = new Inp1004();
		inp1004.setSysDate(new Date());
		inp1004.setSysId(userId);
		inp1004.setUpdDate(new Date());
		inp1004.setUpdId(userId);
		inp1004.setHospCode(hospCode);
		inp1004.setSeq(nextSeq);
		inp1004.setBunho(bunho);
		inp1004.setName(item.getName());
		inp1004.setZipCode1(item.getZipCode1());
		inp1004.setZipCode2(item.getZipCode2());
		inp1004.setAddress1(item.getAddress1());
		inp1004.setAddress2(item.getAddress2());
		inp1004.setTel1(item.getTel1());
		inp1004.setTel2(item.getTel2());
		inp1004.setBigo(item.getBigo());
		inp1004.setBoninGubun(item.getBoninGubun());
		inp1004.setTel3(item.getTel3());
		inp1004.setTelGubun(item.getTelGubun());
		inp1004.setTelGubun2(item.getTelGubun2());
		inp1004.setTelGubun3(item.getTelGubun3());
		inp1004.setName2(item.getName2());
		inp1004.setPriority(CommonUtils.parseDouble(item.getPriority()));
		inp1004.setBirth(DateUtil.toDate(item.getBirth(), DateUtil.PATTERN_YYMMDD));
		inp1004.setWithYn(item.getWithYn());
		inp1004.setLiveYn(item.getLiveYn());
		
		inp1004Repository.save(inp1004);
	}
}

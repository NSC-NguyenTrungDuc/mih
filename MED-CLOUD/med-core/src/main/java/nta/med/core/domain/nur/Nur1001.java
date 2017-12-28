package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR1001 database table.
 * 
 */
@Entity
@Table(name = "NUR1001")
public class Nur1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String abdominalInflationVeryYn;
	private String abdominalInflationYn;
	private String adlBathComment;
	private String adlBathState;
	private String adlBoardComment;	
	private String adlBoardState;
	private String adlClothComment;
	private String adlClothState;
	private String adlExcretionComment;
	private String adlExcretionState;
	private String adlFoodComment;
	private String adlFoodState;
	private String adlStruggleComment;
	private String adlStruggleState;
	private String adlWalkComment;
	private String adlWalkState;	
	private String adlWashComment;	
	private String adlWashState;	
	private String adlWheelchairComment;	
	private String adlWheelchairState;	
	private String antidiarrhealYn;	
	private String appetiteComment;	
	private String appetiteYn;	
	private String assessment0;	
	private String assessment1;	
	private String assessment2;	
	private String assessment4;	
	private String assessment5;	
	private String assessment7;	
	private String barrierFreeYn;	
	private String bloodTypeAbo;	
	private String bloodTypeRh;	
	private String bringDrugComment;	
	private String bringDrugYn;	
	private String bunho;	
	private String careOfficeComment;	
	private Date catheterStartDate;	
	private String catheterYn;	
	private String contractureComment;	
	private String contractureYn;	
	private String diagnosisGubun;	
	private String diagnosisName;	
	private String diapersYn;	
	private String dizzyComment;	
	private String dizzyYn;	
	private String drinking;	
	private String dungCount;	
	private String dungDay;	
	private String dungLast;	
	private String dungState;	
	private String dungWillYn;	
	private String dysphagiaComment;	
	private String dysphagiaYn;	
	private String earAidYn;	
	private String earLeftComment;	
	private String earLeftYn;	
	private String earRightComment;	
	private String earRightYn;	
	private String enemaYn;	
	private String enterokinesiaYn;	
	private String explainDoctor;	
	private String explainFamily;	
	private String explainPatient;	
	private String eyeGlassesYn;	
	private String eyeLeftComment;	
	private String eyeLeftYn;	
	private String eyeLensYn;	
	private String eyeRightComment;	
	private String eyeRightYn;	
	private String falseTeethComment;	
	private String falseTeethYn;	
	private String familyComment;	
	private String familyYn;	
	private String fearComment;	
	private String fearYn;	
	private Double fkinp1001;	
	private String foodDislikeComment;	
	private String foodDislikeYn;	
	private String foodLimit;	
	private String healthcareComment;	
	private String healthcareYn;	
	private String height;	
	private String hobbyComment;	
	private String hobbyYn;	
	private String hospCode;	
	private String houseKind;	
	private String informant;	
	private String inpatientCourse;	
	private String intakeComment;	
	private String intakeWay;	
	private String intermittentComment;	
	private String intermittentYn;	
	private String job;	
	private String jobMate;	
	private String keyCell1;	
	private Double keyCell1Pri;	
	private String keyCell2;	
	private Double keyCell2Pri;	
	private String keyComment;	
	private String keyHome1;	
	private Double keyHome1Pri;	
	private String keyHome2;	
	private Double keyHome2Pri;	
	private String keyName1;	
	private String keyName2;	
	private String keyOffice1;	
	private Double keyOffice1Pri;	
	private String keyOffice2;	
	private Double keyOffice2Pri;	
	private String keyRelation1;	
	private String keyRelation2;	
	private String laxationComment;	
	private String laxativeYn;	
	private String lossPartComment;	
	private String lossPartYn;	
	private String mainFood;	
	private String menses;	
	private String mensesAge;	
	private String mensesProblemComment;	
	private String mensesProblemYn;	
	private String mouthComment;	
	private String mouthPollutionComment;	
	private String mouthPollutionYn;	
	private String movementYn;	
	private String needCare;	
	private String needSupport;	
	private String noseComment;	
	private String obstacleComment;	
	private String obstacleSenseYn;	
	private String obstacleSpeechYn;	
	private String obstacleYn;	
	private String orthoticsYn;	
	private String painComment;	
	private String painYn;	
	private String paralysisComment;	
	private String paralysisYn;	
	private String pastHis;	
	private String perceptionComment;	
	private String perceptionYn;	
	private String pregnancyYn;	
	private String purpose;	
	private String recognitionComment;	
	private String recognitionYn;	
	private String religionComment;	
	private String religionYn;	
	private String senseLevel;	
	private String sensorYn;	
	private String serviceComment;	
	private String sleepEndTime;	
	private String sleepEnoughComment;
	private String sleepEnoughYn;	
	private String sleepEtcComment;	
	private String sleepEtcYn;	
	private String sleepStartTime;	
	private String sleepTalkYn;	
	private String sleepTime;	
	private String sleeplessComment;	
	private Double smokingDay;	
	private String snoringYn;	
	private String staggerComment;	
	private String staggerYn;	
	private String stressComment;	
	private String stressManage;	
	private String stressYn;	
	private String subFood;	
	private String suppositoryYn;	
	private Date sysDate;	
	private String sysId;	
	private String teethGrindingYn;	
	private Date updDate;	
	private String updId;	
	private String urinCount;	
	private String urinDay;	
	private String urinNightCount;	
	private String urinWillYn;	
	private String weight;	
	private String weightUpdownHow;	
	private String weightUpdownStart;	
	private String worryComment;	
	private String worryYn;	
	private String writer;

	public Nur1001() {
	}

	@Column(name = "ABDOMINAL_INFLATION_VERY_YN")
	public String getAbdominalInflationVeryYn() {
		return this.abdominalInflationVeryYn;
	}

	public void setAbdominalInflationVeryYn(String abdominalInflationVeryYn) {
		this.abdominalInflationVeryYn = abdominalInflationVeryYn;
	}

	@Column(name = "ABDOMINAL_INFLATION_YN")
	public String getAbdominalInflationYn() {
		return this.abdominalInflationYn;
	}

	public void setAbdominalInflationYn(String abdominalInflationYn) {
		this.abdominalInflationYn = abdominalInflationYn;
	}
	
	@Column(name = "ADL_BATH_COMMENT")
	public String getAdlBathComment() {
		return this.adlBathComment;
	}

	public void setAdlBathComment(String adlBathComment) {
		this.adlBathComment = adlBathComment;
	}
	
	@Column(name = "ADL_BATH_STATE")
	public String getAdlBathState() {
		return this.adlBathState;
	}

	public void setAdlBathState(String adlBathState) {
		this.adlBathState = adlBathState;
	}
	
	@Column(name = "ADL_BOARD_COMMENT")
	public String getAdlBoardComment() {
		return this.adlBoardComment;
	}

	public void setAdlBoardComment(String adlBoardComment) {
		this.adlBoardComment = adlBoardComment;
	}
	
	@Column(name = "ADL_BOARD_STATE")
	public String getAdlBoardState() {
		return this.adlBoardState;
	}

	public void setAdlBoardState(String adlBoardState) {
		this.adlBoardState = adlBoardState;
	}
	
	@Column(name = "ADL_CLOTH_COMMENT")
	public String getAdlClothComment() {
		return this.adlClothComment;
	}

	public void setAdlClothComment(String adlClothComment) {
		this.adlClothComment = adlClothComment;
	}
	
	@Column(name = "ADL_CLOTH_STATE")
	public String getAdlClothState() {
		return this.adlClothState;
	}

	public void setAdlClothState(String adlClothState) {
		this.adlClothState = adlClothState;
	}

	@Column(name = "ADL_EXCRETION_COMMENT")
	public String getAdlExcretionComment() {
		return this.adlExcretionComment;
	}

	public void setAdlExcretionComment(String adlExcretionComment) {
		this.adlExcretionComment = adlExcretionComment;
	}
	
	@Column(name = "ADL_EXCRETION_STATE")
	public String getAdlExcretionState() {
		return this.adlExcretionState;
	}

	public void setAdlExcretionState(String adlExcretionState) {
		this.adlExcretionState = adlExcretionState;
	}

	@Column(name = "ADL_FOOD_COMMENT")
	public String getAdlFoodComment() {
		return this.adlFoodComment;
	}

	public void setAdlFoodComment(String adlFoodComment) {
		this.adlFoodComment = adlFoodComment;
	}

	@Column(name = "ADL_FOOD_STATE")
	public String getAdlFoodState() {
		return this.adlFoodState;
	}

	public void setAdlFoodState(String adlFoodState) {
		this.adlFoodState = adlFoodState;
	}

	@Column(name = "ADL_STRUGGLE_COMMENT")
	public String getAdlStruggleComment() {
		return this.adlStruggleComment;
	}

	public void setAdlStruggleComment(String adlStruggleComment) {
		this.adlStruggleComment = adlStruggleComment;
	}

	@Column(name = "ADL_STRUGGLE_STATE")
	public String getAdlStruggleState() {
		return this.adlStruggleState;
	}

	public void setAdlStruggleState(String adlStruggleState) {
		this.adlStruggleState = adlStruggleState;
	}

	@Column(name = "ADL_WALK_COMMENT")
	public String getAdlWalkComment() {
		return this.adlWalkComment;
	}

	public void setAdlWalkComment(String adlWalkComment) {
		this.adlWalkComment = adlWalkComment;
	}

	@Column(name = "ADL_WALK_STATE")
	public String getAdlWalkState() {
		return this.adlWalkState;
	}

	public void setAdlWalkState(String adlWalkState) {
		this.adlWalkState = adlWalkState;
	}

	@Column(name = "ADL_WASH_COMMENT")
	public String getAdlWashComment() {
		return this.adlWashComment;
	}

	public void setAdlWashComment(String adlWashComment) {
		this.adlWashComment = adlWashComment;
	}

	@Column(name = "ADL_WASH_STATE")
	public String getAdlWashState() {
		return this.adlWashState;
	}

	public void setAdlWashState(String adlWashState) {
		this.adlWashState = adlWashState;
	}

	@Column(name = "ADL_WHEELCHAIR_COMMENT")
	public String getAdlWheelchairComment() {
		return this.adlWheelchairComment;
	}

	public void setAdlWheelchairComment(String adlWheelchairComment) {
		this.adlWheelchairComment = adlWheelchairComment;
	}

	@Column(name = "ADL_WHEELCHAIR_STATE")
	public String getAdlWheelchairState() {
		return this.adlWheelchairState;
	}

	public void setAdlWheelchairState(String adlWheelchairState) {
		this.adlWheelchairState = adlWheelchairState;
	}

	@Column(name = "ANTIDIARRHEAL_YN")
	public String getAntidiarrhealYn() {
		return this.antidiarrhealYn;
	}

	public void setAntidiarrhealYn(String antidiarrhealYn) {
		this.antidiarrhealYn = antidiarrhealYn;
	}

	@Column(name = "APPETITE_COMMENT")
	public String getAppetiteComment() {
		return this.appetiteComment;
	}

	public void setAppetiteComment(String appetiteComment) {
		this.appetiteComment = appetiteComment;
	}

	@Column(name = "APPETITE_YN")
	public String getAppetiteYn() {
		return this.appetiteYn;
	}

	public void setAppetiteYn(String appetiteYn) {
		this.appetiteYn = appetiteYn;
	}

	@Column(name = "ASSESSMENT_0")
	public String getAssessment0() {
		return this.assessment0;
	}

	public void setAssessment0(String assessment0) {
		this.assessment0 = assessment0;
	}

	@Column(name = "ASSESSMENT_1")
	public String getAssessment1() {
		return this.assessment1;
	}

	public void setAssessment1(String assessment1) {
		this.assessment1 = assessment1;
	}

	@Column(name = "ASSESSMENT_2")
	public String getAssessment2() {
		return this.assessment2;
	}

	public void setAssessment2(String assessment2) {
		this.assessment2 = assessment2;
	}

	@Column(name = "ASSESSMENT_4")
	public String getAssessment4() {
		return this.assessment4;
	}

	public void setAssessment4(String assessment4) {
		this.assessment4 = assessment4;
	}

	@Column(name = "ASSESSMENT_5")
	public String getAssessment5() {
		return this.assessment5;
	}

	public void setAssessment5(String assessment5) {
		this.assessment5 = assessment5;
	}

	@Column(name = "ASSESSMENT_7")
	public String getAssessment7() {
		return this.assessment7;
	}

	public void setAssessment7(String assessment7) {
		this.assessment7 = assessment7;
	}

	@Column(name = "BARRIER_FREE_YN")
	public String getBarrierFreeYn() {
		return this.barrierFreeYn;
	}

	public void setBarrierFreeYn(String barrierFreeYn) {
		this.barrierFreeYn = barrierFreeYn;
	}

	@Column(name = "BLOOD_TYPE_ABO")
	public String getBloodTypeAbo() {
		return this.bloodTypeAbo;
	}

	public void setBloodTypeAbo(String bloodTypeAbo) {
		this.bloodTypeAbo = bloodTypeAbo;
	}
	
	@Column(name = "BLOOD_TYPE_RH")
	public String getBloodTypeRh() {
		return this.bloodTypeRh;
	}

	public void setBloodTypeRh(String bloodTypeRh) {
		this.bloodTypeRh = bloodTypeRh;
	}

	@Column(name = "BRING_DRUG_COMMENT")
	public String getBringDrugComment() {
		return this.bringDrugComment;
	}

	public void setBringDrugComment(String bringDrugComment) {
		this.bringDrugComment = bringDrugComment;
	}

	@Column(name = "BRING_DRUG_YN")
	public String getBringDrugYn() {
		return this.bringDrugYn;
	}

	public void setBringDrugYn(String bringDrugYn) {
		this.bringDrugYn = bringDrugYn;
	}

	@Column(name = "BUNHO")
	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "CARE_OFFICE_COMMENT")
	public String getCareOfficeComment() {
		return this.careOfficeComment;
	}

	public void setCareOfficeComment(String careOfficeComment) {
		this.careOfficeComment = careOfficeComment;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "CATHETER_START_DATE")
	public Date getCatheterStartDate() {
		return this.catheterStartDate;
	}

	public void setCatheterStartDate(Date catheterStartDate) {
		this.catheterStartDate = catheterStartDate;
	}

	@Column(name = "CATHETER_YN")
	public String getCatheterYn() {
		return this.catheterYn;
	}

	public void setCatheterYn(String catheterYn) {
		this.catheterYn = catheterYn;
	}

	@Column(name = "CONTRACTURE_COMMENT")
	public String getContractureComment() {
		return this.contractureComment;
	}

	public void setContractureComment(String contractureComment) {
		this.contractureComment = contractureComment;
	}

	@Column(name = "CONTRACTURE_YN")
	public String getContractureYn() {
		return this.contractureYn;
	}

	public void setContractureYn(String contractureYn) {
		this.contractureYn = contractureYn;
	}

	@Column(name = "DIAGNOSIS_GUBUN")
	public String getDiagnosisGubun() {
		return this.diagnosisGubun;
	}

	public void setDiagnosisGubun(String diagnosisGubun) {
		this.diagnosisGubun = diagnosisGubun;
	}

	@Column(name = "DIAGNOSIS_NAME")
	public String getDiagnosisName() {
		return this.diagnosisName;
	}

	public void setDiagnosisName(String diagnosisName) {
		this.diagnosisName = diagnosisName;
	}

	@Column(name = "DIAPERS_YN")
	public String getDiapersYn() {
		return this.diapersYn;
	}

	public void setDiapersYn(String diapersYn) {
		this.diapersYn = diapersYn;
	}

	@Column(name = "DIZZY_COMMENT")
	public String getDizzyComment() {
		return this.dizzyComment;
	}

	public void setDizzyComment(String dizzyComment) {
		this.dizzyComment = dizzyComment;
	}

	@Column(name = "DIZZY_YN")
	public String getDizzyYn() {
		return this.dizzyYn;
	}

	public void setDizzyYn(String dizzyYn) {
		this.dizzyYn = dizzyYn;
	}

	@Column(name = "DRINKING")
	public String getDrinking() {
		return this.drinking;
	}

	public void setDrinking(String drinking) {
		this.drinking = drinking;
	}

	@Column(name = "DUNG_COUNT")
	public String getDungCount() {
		return this.dungCount;
	}

	public void setDungCount(String dungCount) {
		this.dungCount = dungCount;
	}

	@Column(name = "DUNG_DAY")
	public String getDungDay() {
		return this.dungDay;
	}

	public void setDungDay(String dungDay) {
		this.dungDay = dungDay;
	}

	@Column(name = "DUNG_LAST")
	public String getDungLast() {
		return this.dungLast;
	}

	public void setDungLast(String dungLast) {
		this.dungLast = dungLast;
	}

	@Column(name = "DUNG_STATE")
	public String getDungState() {
		return this.dungState;
	}

	public void setDungState(String dungState) {
		this.dungState = dungState;
	}

	@Column(name = "DUNG_WILL_YN")
	public String getDungWillYn() {
		return this.dungWillYn;
	}

	public void setDungWillYn(String dungWillYn) {
		this.dungWillYn = dungWillYn;
	}

	@Column(name = "DYSPHAGIA_COMMENT")
	public String getDysphagiaComment() {
		return this.dysphagiaComment;
	}

	public void setDysphagiaComment(String dysphagiaComment) {
		this.dysphagiaComment = dysphagiaComment;
	}

	@Column(name = "DYSPHAGIA_YN")
	public String getDysphagiaYn() {
		return this.dysphagiaYn;
	}

	public void setDysphagiaYn(String dysphagiaYn) {
		this.dysphagiaYn = dysphagiaYn;
	}

	@Column(name = "EAR_AID_YN")
	public String getEarAidYn() {
		return this.earAidYn;
	}

	public void setEarAidYn(String earAidYn) {
		this.earAidYn = earAidYn;
	}

	@Column(name = "EAR_LEFT_COMMENT")
	public String getEarLeftComment() {
		return this.earLeftComment;
	}

	public void setEarLeftComment(String earLeftComment) {
		this.earLeftComment = earLeftComment;
	}

	@Column(name = "EAR_LEFT_YN")
	public String getEarLeftYn() {
		return this.earLeftYn;
	}

	public void setEarLeftYn(String earLeftYn) {
		this.earLeftYn = earLeftYn;
	}

	@Column(name = "EAR_RIGHT_COMMENT")
	public String getEarRightComment() {
		return this.earRightComment;
	}

	public void setEarRightComment(String earRightComment) {
		this.earRightComment = earRightComment;
	}

	@Column(name = "EAR_RIGHT_YN")
	public String getEarRightYn() {
		return this.earRightYn;
	}

	public void setEarRightYn(String earRightYn) {
		this.earRightYn = earRightYn;
	}

	@Column(name = "ENEMA_YN")
	public String getEnemaYn() {
		return this.enemaYn;
	}

	public void setEnemaYn(String enemaYn) {
		this.enemaYn = enemaYn;
	}

	@Column(name = "ENTEROKINESIA_YN")
	public String getEnterokinesiaYn() {
		return this.enterokinesiaYn;
	}

	public void setEnterokinesiaYn(String enterokinesiaYn) {
		this.enterokinesiaYn = enterokinesiaYn;
	}

	@Column(name = "EXPLAIN_DOCTOR")
	public String getExplainDoctor() {
		return this.explainDoctor;
	}

	public void setExplainDoctor(String explainDoctor) {
		this.explainDoctor = explainDoctor;
	}

	@Column(name = "EXPLAIN_FAMILY")
	public String getExplainFamily() {
		return this.explainFamily;
	}

	public void setExplainFamily(String explainFamily) {
		this.explainFamily = explainFamily;
	}

	@Column(name = "EXPLAIN_PATIENT")
	public String getExplainPatient() {
		return this.explainPatient;
	}

	public void setExplainPatient(String explainPatient) {
		this.explainPatient = explainPatient;
	}

	@Column(name = "EYE_GLASSES_YN")
	public String getEyeGlassesYn() {
		return this.eyeGlassesYn;
	}

	public void setEyeGlassesYn(String eyeGlassesYn) {
		this.eyeGlassesYn = eyeGlassesYn;
	}

	@Column(name = "EYE_LEFT_COMMENT")
	public String getEyeLeftComment() {
		return this.eyeLeftComment;
	}

	public void setEyeLeftComment(String eyeLeftComment) {
		this.eyeLeftComment = eyeLeftComment;
	}

	@Column(name = "EYE_LEFT_YN")
	public String getEyeLeftYn() {
		return this.eyeLeftYn;
	}

	public void setEyeLeftYn(String eyeLeftYn) {
		this.eyeLeftYn = eyeLeftYn;
	}

	@Column(name = "EYE_LENS_YN")
	public String getEyeLensYn() {
		return this.eyeLensYn;
	}

	public void setEyeLensYn(String eyeLensYn) {
		this.eyeLensYn = eyeLensYn;
	}

	@Column(name = "EYE_RIGHT_COMMENT")
	public String getEyeRightComment() {
		return this.eyeRightComment;
	}

	public void setEyeRightComment(String eyeRightComment) {
		this.eyeRightComment = eyeRightComment;
	}

	@Column(name = "EYE_RIGHT_YN")
	public String getEyeRightYn() {
		return this.eyeRightYn;
	}

	public void setEyeRightYn(String eyeRightYn) {
		this.eyeRightYn = eyeRightYn;
	}

	@Column(name = "FALSE_TEETH_COMMENT")
	public String getFalseTeethComment() {
		return this.falseTeethComment;
	}

	public void setFalseTeethComment(String falseTeethComment) {
		this.falseTeethComment = falseTeethComment;
	}

	@Column(name = "FALSE_TEETH_YN")
	public String getFalseTeethYn() {
		return this.falseTeethYn;
	}

	public void setFalseTeethYn(String falseTeethYn) {
		this.falseTeethYn = falseTeethYn;
	}

	@Column(name = "FAMILY_COMMENT")
	public String getFamilyComment() {
		return this.familyComment;
	}

	public void setFamilyComment(String familyComment) {
		this.familyComment = familyComment;
	}

	@Column(name = "FAMILY_YN")
	public String getFamilyYn() {
		return this.familyYn;
	}

	public void setFamilyYn(String familyYn) {
		this.familyYn = familyYn;
	}

	@Column(name = "FEAR_COMMENT")
	public String getFearComment() {
		return this.fearComment;
	}

	public void setFearComment(String fearComment) {
		this.fearComment = fearComment;
	}

	@Column(name = "FEAR_YN")
	public String getFearYn() {
		return this.fearYn;
	}

	public void setFearYn(String fearYn) {
		this.fearYn = fearYn;
	}

	@Column(name = "FKINP1001")
	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name = "FOOD_DISLIKE_COMMENT")
	public String getFoodDislikeComment() {
		return this.foodDislikeComment;
	}

	public void setFoodDislikeComment(String foodDislikeComment) {
		this.foodDislikeComment = foodDislikeComment;
	}

	@Column(name = "FOOD_DISLIKE_YN")
	public String getFoodDislikeYn() {
		return this.foodDislikeYn;
	}

	public void setFoodDislikeYn(String foodDislikeYn) {
		this.foodDislikeYn = foodDislikeYn;
	}

	@Column(name = "FOOD_LIMIT")
	public String getFoodLimit() {
		return this.foodLimit;
	}

	public void setFoodLimit(String foodLimit) {
		this.foodLimit = foodLimit;
	}

	@Column(name = "HEALTHCARE_COMMENT")
	public String getHealthcareComment() {
		return this.healthcareComment;
	}

	public void setHealthcareComment(String healthcareComment) {
		this.healthcareComment = healthcareComment;
	}

	@Column(name = "HEALTHCARE_YN")
	public String getHealthcareYn() {
		return this.healthcareYn;
	}

	public void setHealthcareYn(String healthcareYn) {
		this.healthcareYn = healthcareYn;
	}

	@Column(name = "HEIGHT")
	public String getHeight() {
		return this.height;
	}

	public void setHeight(String height) {
		this.height = height;
	}

	@Column(name = "HOBBY_COMMENT")
	public String getHobbyComment() {
		return this.hobbyComment;
	}

	public void setHobbyComment(String hobbyComment) {
		this.hobbyComment = hobbyComment;
	}

	@Column(name = "HOBBY_YN")
	public String getHobbyYn() {
		return this.hobbyYn;
	}

	public void setHobbyYn(String hobbyYn) {
		this.hobbyYn = hobbyYn;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "HOUSE_KIND")
	public String getHouseKind() {
		return this.houseKind;
	}

	public void setHouseKind(String houseKind) {
		this.houseKind = houseKind;
	}

	@Column(name = "INFORMANT")
	public String getInformant() {
		return this.informant;
	}

	public void setInformant(String informant) {
		this.informant = informant;
	}

	@Column(name = "INPATIENT_COURSE")
	public String getInpatientCourse() {
		return this.inpatientCourse;
	}

	public void setInpatientCourse(String inpatientCourse) {
		this.inpatientCourse = inpatientCourse;
	}

	@Column(name = "INTAKE_COMMENT")
	public String getIntakeComment() {
		return this.intakeComment;
	}

	public void setIntakeComment(String intakeComment) {
		this.intakeComment = intakeComment;
	}

	@Column(name = "INTAKE_WAY")
	public String getIntakeWay() {
		return this.intakeWay;
	}

	public void setIntakeWay(String intakeWay) {
		this.intakeWay = intakeWay;
	}

	@Column(name = "INTERMITTENT_COMMENT")
	public String getIntermittentComment() {
		return this.intermittentComment;
	}

	public void setIntermittentComment(String intermittentComment) {
		this.intermittentComment = intermittentComment;
	}

	@Column(name = "INTERMITTENT_YN")
	public String getIntermittentYn() {
		return this.intermittentYn;
	}

	public void setIntermittentYn(String intermittentYn) {
		this.intermittentYn = intermittentYn;
	}

	@Column(name = "JOB")
	public String getJob() {
		return this.job;
	}

	public void setJob(String job) {
		this.job = job;
	}

	@Column(name = "JOB_MATE")
	public String getJobMate() {
		return this.jobMate;
	}

	public void setJobMate(String jobMate) {
		this.jobMate = jobMate;
	}

	@Column(name = "KEY_CELL1")
	public String getKeyCell1() {
		return this.keyCell1;
	}

	public void setKeyCell1(String keyCell1) {
		this.keyCell1 = keyCell1;
	}

	@Column(name = "KEY_CELL1_PRI")
	public Double getKeyCell1Pri() {
		return this.keyCell1Pri;
	}

	public void setKeyCell1Pri(Double keyCell1Pri) {
		this.keyCell1Pri = keyCell1Pri;
	}

	@Column(name = "KEY_CELL2")
	public String getKeyCell2() {
		return this.keyCell2;
	}

	public void setKeyCell2(String keyCell2) {
		this.keyCell2 = keyCell2;
	}

	@Column(name = "KEY_CELL2_PRI")
	public Double getKeyCell2Pri() {
		return this.keyCell2Pri;
	}

	public void setKeyCell2Pri(Double keyCell2Pri) {
		this.keyCell2Pri = keyCell2Pri;
	}

	@Column(name = "KEY_COMMENT")
	public String getKeyComment() {
		return this.keyComment;
	}

	public void setKeyComment(String keyComment) {
		this.keyComment = keyComment;
	}

	@Column(name = "KEY_HOME1")
	public String getKeyHome1() {
		return this.keyHome1;
	}

	public void setKeyHome1(String keyHome1) {
		this.keyHome1 = keyHome1;
	}

	@Column(name = "KEY_HOME1_PRI")
	public Double getKeyHome1Pri() {
		return this.keyHome1Pri;
	}

	public void setKeyHome1Pri(Double keyHome1Pri) {
		this.keyHome1Pri = keyHome1Pri;
	}

	@Column(name = "KEY_HOME2")
	public String getKeyHome2() {
		return this.keyHome2;
	}

	public void setKeyHome2(String keyHome2) {
		this.keyHome2 = keyHome2;
	}

	@Column(name = "KEY_HOME2_PRI")
	public Double getKeyHome2Pri() {
		return this.keyHome2Pri;
	}

	public void setKeyHome2Pri(Double keyHome2Pri) {
		this.keyHome2Pri = keyHome2Pri;
	}

	@Column(name = "KEY_NAME1")
	public String getKeyName1() {
		return this.keyName1;
	}

	public void setKeyName1(String keyName1) {
		this.keyName1 = keyName1;
	}

	@Column(name = "KEY_NAME2")
	public String getKeyName2() {
		return this.keyName2;
	}

	public void setKeyName2(String keyName2) {
		this.keyName2 = keyName2;
	}

	@Column(name = "KEY_OFFICE1")
	public String getKeyOffice1() {
		return this.keyOffice1;
	}

	public void setKeyOffice1(String keyOffice1) {
		this.keyOffice1 = keyOffice1;
	}

	@Column(name = "KEY_OFFICE1_PRI")
	public Double getKeyOffice1Pri() {
		return this.keyOffice1Pri;
	}

	public void setKeyOffice1Pri(Double keyOffice1Pri) {
		this.keyOffice1Pri = keyOffice1Pri;
	}

	@Column(name = "KEY_OFFICE2")
	public String getKeyOffice2() {
		return this.keyOffice2;
	}

	public void setKeyOffice2(String keyOffice2) {
		this.keyOffice2 = keyOffice2;
	}

	@Column(name = "KEY_OFFICE2_PRI")
	public Double getKeyOffice2Pri() {
		return this.keyOffice2Pri;
	}

	public void setKeyOffice2Pri(Double keyOffice2Pri) {
		this.keyOffice2Pri = keyOffice2Pri;
	}

	@Column(name = "KEY_RELATION1")
	public String getKeyRelation1() {
		return this.keyRelation1;
	}

	public void setKeyRelation1(String keyRelation1) {
		this.keyRelation1 = keyRelation1;
	}

	@Column(name = "KEY_RELATION2")
	public String getKeyRelation2() {
		return this.keyRelation2;
	}

	public void setKeyRelation2(String keyRelation2) {
		this.keyRelation2 = keyRelation2;
	}

	@Column(name = "LAXATION_COMMENT")
	public String getLaxationComment() {
		return this.laxationComment;
	}

	public void setLaxationComment(String laxationComment) {
		this.laxationComment = laxationComment;
	}

	@Column(name = "LAXATIVE_YN")
	public String getLaxativeYn() {
		return this.laxativeYn;
	}

	public void setLaxativeYn(String laxativeYn) {
		this.laxativeYn = laxativeYn;
	}

	@Column(name = "LOSS_PART_COMMENT")
	public String getLossPartComment() {
		return this.lossPartComment;
	}

	public void setLossPartComment(String lossPartComment) {
		this.lossPartComment = lossPartComment;
	}

	@Column(name = "LOSS_PART_YN")
	public String getLossPartYn() {
		return this.lossPartYn;
	}

	public void setLossPartYn(String lossPartYn) {
		this.lossPartYn = lossPartYn;
	}

	@Column(name = "MAIN_FOOD")
	public String getMainFood() {
		return this.mainFood;
	}

	public void setMainFood(String mainFood) {
		this.mainFood = mainFood;
	}

	@Column(name = "MENSES")
	public String getMenses() {
		return this.menses;
	}

	public void setMenses(String menses) {
		this.menses = menses;
	}

	@Column(name = "MENSES_AGE")
	public String getMensesAge() {
		return this.mensesAge;
	}

	public void setMensesAge(String mensesAge) {
		this.mensesAge = mensesAge;
	}

	@Column(name = "MENSES_PROBLEM_COMMENT")
	public String getMensesProblemComment() {
		return this.mensesProblemComment;
	}

	public void setMensesProblemComment(String mensesProblemComment) {
		this.mensesProblemComment = mensesProblemComment;
	}

	@Column(name = "MENSES_PROBLEM_YN")
	public String getMensesProblemYn() {
		return this.mensesProblemYn;
	}

	public void setMensesProblemYn(String mensesProblemYn) {
		this.mensesProblemYn = mensesProblemYn;
	}

	@Column(name = "MOUTH_COMMENT")
	public String getMouthComment() {
		return this.mouthComment;
	}

	public void setMouthComment(String mouthComment) {
		this.mouthComment = mouthComment;
	}

	@Column(name = "MOUTH_POLLUTION_COMMENT")
	public String getMouthPollutionComment() {
		return this.mouthPollutionComment;
	}

	public void setMouthPollutionComment(String mouthPollutionComment) {
		this.mouthPollutionComment = mouthPollutionComment;
	}

	@Column(name = "MOUTH_POLLUTION_YN")
	public String getMouthPollutionYn() {
		return this.mouthPollutionYn;
	}

	public void setMouthPollutionYn(String mouthPollutionYn) {
		this.mouthPollutionYn = mouthPollutionYn;
	}

	@Column(name = "MOVEMENT_YN")
	public String getMovementYn() {
		return this.movementYn;
	}

	public void setMovementYn(String movementYn) {
		this.movementYn = movementYn;
	}

	@Column(name = "NEED_CARE")
	public String getNeedCare() {
		return this.needCare;
	}

	public void setNeedCare(String needCare) {
		this.needCare = needCare;
	}

	@Column(name = "NEED_SUPPORT")
	public String getNeedSupport() {
		return this.needSupport;
	}

	public void setNeedSupport(String needSupport) {
		this.needSupport = needSupport;
	}

	@Column(name = "NOSE_COMMENT")
	public String getNoseComment() {
		return this.noseComment;
	}

	public void setNoseComment(String noseComment) {
		this.noseComment = noseComment;
	}

	@Column(name = "OBSTACLE_COMMENT")
	public String getObstacleComment() {
		return this.obstacleComment;
	}

	public void setObstacleComment(String obstacleComment) {
		this.obstacleComment = obstacleComment;
	}

	@Column(name = "OBSTACLE_SENSE_YN")
	public String getObstacleSenseYn() {
		return this.obstacleSenseYn;
	}

	public void setObstacleSenseYn(String obstacleSenseYn) {
		this.obstacleSenseYn = obstacleSenseYn;
	}

	@Column(name = "OBSTACLE_SPEECH_YN")
	public String getObstacleSpeechYn() {
		return this.obstacleSpeechYn;
	}

	public void setObstacleSpeechYn(String obstacleSpeechYn) {
		this.obstacleSpeechYn = obstacleSpeechYn;
	}

	@Column(name = "OBSTACLE_YN")
	public String getObstacleYn() {
		return this.obstacleYn;
	}

	public void setObstacleYn(String obstacleYn) {
		this.obstacleYn = obstacleYn;
	}

	@Column(name = "ORTHOTICS_YN")
	public String getOrthoticsYn() {
		return this.orthoticsYn;
	}

	public void setOrthoticsYn(String orthoticsYn) {
		this.orthoticsYn = orthoticsYn;
	}

	@Column(name = "PAIN_COMMENT")
	public String getPainComment() {
		return this.painComment;
	}

	public void setPainComment(String painComment) {
		this.painComment = painComment;
	}

	@Column(name = "PAIN_YN")
	public String getPainYn() {
		return this.painYn;
	}

	public void setPainYn(String painYn) {
		this.painYn = painYn;
	}

	@Column(name = "PARALYSIS_COMMENT")
	public String getParalysisComment() {
		return this.paralysisComment;
	}

	public void setParalysisComment(String paralysisComment) {
		this.paralysisComment = paralysisComment;
	}

	@Column(name = "PARALYSIS_YN")
	public String getParalysisYn() {
		return this.paralysisYn;
	}

	public void setParalysisYn(String paralysisYn) {
		this.paralysisYn = paralysisYn;
	}

	@Column(name = "PAST_HIS")
	public String getPastHis() {
		return this.pastHis;
	}

	public void setPastHis(String pastHis) {
		this.pastHis = pastHis;
	}

	@Column(name = "PERCEPTION_COMMENT")
	public String getPerceptionComment() {
		return this.perceptionComment;
	}

	public void setPerceptionComment(String perceptionComment) {
		this.perceptionComment = perceptionComment;
	}

	@Column(name = "PERCEPTION_YN")
	public String getPerceptionYn() {
		return this.perceptionYn;
	}

	public void setPerceptionYn(String perceptionYn) {
		this.perceptionYn = perceptionYn;
	}

	@Column(name = "PREGNANCY_YN")
	public String getPregnancyYn() {
		return this.pregnancyYn;
	}

	public void setPregnancyYn(String pregnancyYn) {
		this.pregnancyYn = pregnancyYn;
	}

	@Column(name = "PURPOSE")
	public String getPurpose() {
		return this.purpose;
	}

	public void setPurpose(String purpose) {
		this.purpose = purpose;
	}

	@Column(name = "RECOGNITION_COMMENT")
	public String getRecognitionComment() {
		return this.recognitionComment;
	}

	public void setRecognitionComment(String recognitionComment) {
		this.recognitionComment = recognitionComment;
	}

	@Column(name = "RECOGNITION_YN")
	public String getRecognitionYn() {
		return this.recognitionYn;
	}

	public void setRecognitionYn(String recognitionYn) {
		this.recognitionYn = recognitionYn;
	}

	@Column(name = "RELIGION_COMMENT")
	public String getReligionComment() {
		return this.religionComment;
	}

	public void setReligionComment(String religionComment) {
		this.religionComment = religionComment;
	}

	@Column(name = "RELIGION_YN")
	public String getReligionYn() {
		return this.religionYn;
	}

	public void setReligionYn(String religionYn) {
		this.religionYn = religionYn;
	}

	@Column(name = "SENSE_LEVEL")
	public String getSenseLevel() {
		return this.senseLevel;
	}

	public void setSenseLevel(String senseLevel) {
		this.senseLevel = senseLevel;
	}

	@Column(name = "SENSOR_YN")
	public String getSensorYn() {
		return this.sensorYn;
	}

	public void setSensorYn(String sensorYn) {
		this.sensorYn = sensorYn;
	}

	@Column(name = "SERVICE_COMMENT")
	public String getServiceComment() {
		return this.serviceComment;
	}

	public void setServiceComment(String serviceComment) {
		this.serviceComment = serviceComment;
	}

	@Column(name = "SLEEP_END_TIME")
	public String getSleepEndTime() {
		return this.sleepEndTime;
	}

	public void setSleepEndTime(String sleepEndTime) {
		this.sleepEndTime = sleepEndTime;
	}

	@Column(name = "SLEEP_ENOUGH_COMMENT")
	public String getSleepEnoughComment() {
		return this.sleepEnoughComment;
	}

	public void setSleepEnoughComment(String sleepEnoughComment) {
		this.sleepEnoughComment = sleepEnoughComment;
	}

	@Column(name = "SLEEP_ENOUGH_YN")
	public String getSleepEnoughYn() {
		return this.sleepEnoughYn;
	}

	public void setSleepEnoughYn(String sleepEnoughYn) {
		this.sleepEnoughYn = sleepEnoughYn;
	}

	@Column(name = "SLEEP_ETC_COMMENT")
	public String getSleepEtcComment() {
		return this.sleepEtcComment;
	}

	public void setSleepEtcComment(String sleepEtcComment) {
		this.sleepEtcComment = sleepEtcComment;
	}

	@Column(name = "SLEEP_ETC_YN")
	public String getSleepEtcYn() {
		return this.sleepEtcYn;
	}

	public void setSleepEtcYn(String sleepEtcYn) {
		this.sleepEtcYn = sleepEtcYn;
	}

	@Column(name = "SLEEP_START_TIME")
	public String getSleepStartTime() {
		return this.sleepStartTime;
	}

	public void setSleepStartTime(String sleepStartTime) {
		this.sleepStartTime = sleepStartTime;
	}

	@Column(name = "SLEEP_TALK_YN")
	public String getSleepTalkYn() {
		return this.sleepTalkYn;
	}

	public void setSleepTalkYn(String sleepTalkYn) {
		this.sleepTalkYn = sleepTalkYn;
	}

	@Column(name = "SLEEP_TIME")
	public String getSleepTime() {
		return this.sleepTime;
	}

	public void setSleepTime(String sleepTime) {
		this.sleepTime = sleepTime;
	}

	@Column(name = "SLEEPLESS_COMMENT")
	public String getSleeplessComment() {
		return this.sleeplessComment;
	}

	public void setSleeplessComment(String sleeplessComment) {
		this.sleeplessComment = sleeplessComment;
	}

	@Column(name = "SMOKING_DAY")
	public Double getSmokingDay() {
		return this.smokingDay;
	}

	public void setSmokingDay(Double smokingDay) {
		this.smokingDay = smokingDay;
	}

	@Column(name = "SNORING_YN")
	public String getSnoringYn() {
		return this.snoringYn;
	}

	public void setSnoringYn(String snoringYn) {
		this.snoringYn = snoringYn;
	}

	@Column(name = "STAGGER_COMMENT")
	public String getStaggerComment() {
		return this.staggerComment;
	}

	public void setStaggerComment(String staggerComment) {
		this.staggerComment = staggerComment;
	}
	
	@Column(name = "STAGGER_YN")
	public String getStaggerYn() {
		return this.staggerYn;
	}

	public void setStaggerYn(String staggerYn) {
		this.staggerYn = staggerYn;
	}

	@Column(name = "STRESS_COMMENT")
	public String getStressComment() {
		return this.stressComment;
	}

	public void setStressComment(String stressComment) {
		this.stressComment = stressComment;
	}

	@Column(name = "STRESS_MANAGE")
	public String getStressManage() {
		return this.stressManage;
	}

	public void setStressManage(String stressManage) {
		this.stressManage = stressManage;
	}

	@Column(name = "STRESS_YN")
	public String getStressYn() {
		return this.stressYn;
	}

	public void setStressYn(String stressYn) {
		this.stressYn = stressYn;
	}

	@Column(name = "SUB_FOOD")
	public String getSubFood() {
		return this.subFood;
	}

	public void setSubFood(String subFood) {
		this.subFood = subFood;
	}

	@Column(name = "SUPPOSITORY_YN")
	public String getSuppositoryYn() {
		return this.suppositoryYn;
	}

	public void setSuppositoryYn(String suppositoryYn) {
		this.suppositoryYn = suppositoryYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "TEETH_GRINDING_YN")
	public String getTeethGrindingYn() {
		return this.teethGrindingYn;
	}

	public void setTeethGrindingYn(String teethGrindingYn) {
		this.teethGrindingYn = teethGrindingYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "URIN_COUNT")
	public String getUrinCount() {
		return this.urinCount;
	}

	public void setUrinCount(String urinCount) {
		this.urinCount = urinCount;
	}

	@Column(name = "URIN_DAY")
	public String getUrinDay() {
		return this.urinDay;
	}

	public void setUrinDay(String urinDay) {
		this.urinDay = urinDay;
	}

	@Column(name = "URIN_NIGHT_COUNT")
	public String getUrinNightCount() {
		return this.urinNightCount;
	}

	public void setUrinNightCount(String urinNightCount) {
		this.urinNightCount = urinNightCount;
	}

	@Column(name = "URIN_WILL_YN")
	public String getUrinWillYn() {
		return this.urinWillYn;
	}

	public void setUrinWillYn(String urinWillYn) {
		this.urinWillYn = urinWillYn;
	}

	@Column(name = "WEIGHT")
	public String getWeight() {
		return this.weight;
	}

	public void setWeight(String weight) {
		this.weight = weight;
	}

	@Column(name = "WEIGHT_UPDOWN_HOW")
	public String getWeightUpdownHow() {
		return this.weightUpdownHow;
	}

	public void setWeightUpdownHow(String weightUpdownHow) {
		this.weightUpdownHow = weightUpdownHow;
	}

	@Column(name = "WEIGHT_UPDOWN_START")
	public String getWeightUpdownStart() {
		return this.weightUpdownStart;
	}

	public void setWeightUpdownStart(String weightUpdownStart) {
		this.weightUpdownStart = weightUpdownStart;
	}

	@Column(name = "WORRY_COMMENT")
	public String getWorryComment() {
		return this.worryComment;
	}

	public void setWorryComment(String worryComment) {
		this.worryComment = worryComment;
	}

	@Column(name = "WORRY_YN")
	public String getWorryYn() {
		return this.worryYn;
	}

	public void setWorryYn(String worryYn) {
		this.worryYn = worryYn;
	}

	@Column(name = "WRITER")
	public String getWriter() {
		return this.writer;
	}

	public void setWriter(String writer) {
		this.writer = writer;
	}

}
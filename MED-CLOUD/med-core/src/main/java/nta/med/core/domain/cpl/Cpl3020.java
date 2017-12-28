package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL3020 database table.
 * 
 */
@Entity
@Table(name="CPL3020")
public class Cpl3020 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String beforeResult;
	private Date beforeResultDate;
	private Date beforeResultDate2;
	private Date beforeResultDate3;
	private Date beforeResultDate4;
	private Date beforeResultDate5;
	private String beforeResult2;
	private String beforeResult3;
	private String beforeResult4;
	private String beforeResult5;
	private String class_;
	private String code;
	private String comments;
	private Date confirmDate;
	private String confirmYn;
	private String cplResult;
	private String danui;
	private String deltaYn;
	private String displayYn;
	private String emergency;
	private Double fkcpl2010;
	private String fromStandard;
	private String gumsaYn;
	private String gumsaja;
	private String gumsaja1;
	private String hangmogCode;
	private String hospCode;
	private String jagumResult;
	private String jagumYn;
	private String jangbiCode;
	private Date jangbiDate;
	private String jangbiResult1;
	private String jangbiResult1Yn;
	private String jangbiResult2;
	private String jangbiResult2Yn;
	private String jangbiResult3;
	private String jangbiResult3Yn;
	private String jangbiTime;
	private String jangbiYn;
	private String labNo;
	private String medicalJundal;
	private String newLabNo;
	private String panicYn;
	private Double pkcpl3020;
	private String printYn;
	private Date resultDate;
	private String resultForm;
	private String resultSeq;
	private String resultTime;
	private String resultYn;
	private Double seq;
	private String sourceGumsa;
	private String specimenCode;
	private String specimenSer;
	private String standardYn;
	private String suData;
	private Date sysDate;
	private String sysId;
	private String toStandard;
	private Date updDate;
	private String updId;
	private String vitros;

	public Cpl3020() {
	}


	@Column(name="BEFORE_RESULT")
	public String getBeforeResult() {
		return this.beforeResult;
	}

	public void setBeforeResult(String beforeResult) {
		this.beforeResult = beforeResult;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BEFORE_RESULT_DATE")
	public Date getBeforeResultDate() {
		return this.beforeResultDate;
	}

	public void setBeforeResultDate(Date beforeResultDate) {
		this.beforeResultDate = beforeResultDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BEFORE_RESULT_DATE2")
	public Date getBeforeResultDate2() {
		return this.beforeResultDate2;
	}

	public void setBeforeResultDate2(Date beforeResultDate2) {
		this.beforeResultDate2 = beforeResultDate2;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BEFORE_RESULT_DATE3")
	public Date getBeforeResultDate3() {
		return this.beforeResultDate3;
	}

	public void setBeforeResultDate3(Date beforeResultDate3) {
		this.beforeResultDate3 = beforeResultDate3;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BEFORE_RESULT_DATE4")
	public Date getBeforeResultDate4() {
		return this.beforeResultDate4;
	}

	public void setBeforeResultDate4(Date beforeResultDate4) {
		this.beforeResultDate4 = beforeResultDate4;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BEFORE_RESULT_DATE5")
	public Date getBeforeResultDate5() {
		return this.beforeResultDate5;
	}

	public void setBeforeResultDate5(Date beforeResultDate5) {
		this.beforeResultDate5 = beforeResultDate5;
	}


	@Column(name="BEFORE_RESULT2")
	public String getBeforeResult2() {
		return this.beforeResult2;
	}

	public void setBeforeResult2(String beforeResult2) {
		this.beforeResult2 = beforeResult2;
	}


	@Column(name="BEFORE_RESULT3")
	public String getBeforeResult3() {
		return this.beforeResult3;
	}

	public void setBeforeResult3(String beforeResult3) {
		this.beforeResult3 = beforeResult3;
	}


	@Column(name="BEFORE_RESULT4")
	public String getBeforeResult4() {
		return this.beforeResult4;
	}

	public void setBeforeResult4(String beforeResult4) {
		this.beforeResult4 = beforeResult4;
	}


	@Column(name="BEFORE_RESULT5")
	public String getBeforeResult5() {
		return this.beforeResult5;
	}

	public void setBeforeResult5(String beforeResult5) {
		this.beforeResult5 = beforeResult5;
	}


	@Column(name="CLASS")
	public String getClass_() {
		return this.class_;
	}

	public void setClass_(String class_) {
		this.class_ = class_;
	}


	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CONFIRM_DATE")
	public Date getConfirmDate() {
		return this.confirmDate;
	}

	public void setConfirmDate(Date confirmDate) {
		this.confirmDate = confirmDate;
	}


	@Column(name="CONFIRM_YN")
	public String getConfirmYn() {
		return this.confirmYn;
	}

	public void setConfirmYn(String confirmYn) {
		this.confirmYn = confirmYn;
	}


	@Column(name="CPL_RESULT")
	public String getCplResult() {
		return this.cplResult;
	}

	public void setCplResult(String cplResult) {
		this.cplResult = cplResult;
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DELTA_YN")
	public String getDeltaYn() {
		return this.deltaYn;
	}

	public void setDeltaYn(String deltaYn) {
		this.deltaYn = deltaYn;
	}


	@Column(name="DISPLAY_YN")
	public String getDisplayYn() {
		return this.displayYn;
	}

	public void setDisplayYn(String displayYn) {
		this.displayYn = displayYn;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	public Double getFkcpl2010() {
		return this.fkcpl2010;
	}

	public void setFkcpl2010(Double fkcpl2010) {
		this.fkcpl2010 = fkcpl2010;
	}


	@Column(name="FROM_STANDARD")
	public String getFromStandard() {
		return this.fromStandard;
	}

	public void setFromStandard(String fromStandard) {
		this.fromStandard = fromStandard;
	}


	@Column(name="GUMSA_YN")
	public String getGumsaYn() {
		return this.gumsaYn;
	}

	public void setGumsaYn(String gumsaYn) {
		this.gumsaYn = gumsaYn;
	}


	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
	}


	public String getGumsaja1() {
		return this.gumsaja1;
	}

	public void setGumsaja1(String gumsaja1) {
		this.gumsaja1 = gumsaja1;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JAGUM_RESULT")
	public String getJagumResult() {
		return this.jagumResult;
	}

	public void setJagumResult(String jagumResult) {
		this.jagumResult = jagumResult;
	}


	@Column(name="JAGUM_YN")
	public String getJagumYn() {
		return this.jagumYn;
	}

	public void setJagumYn(String jagumYn) {
		this.jagumYn = jagumYn;
	}


	@Column(name="JANGBI_CODE")
	public String getJangbiCode() {
		return this.jangbiCode;
	}

	public void setJangbiCode(String jangbiCode) {
		this.jangbiCode = jangbiCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JANGBI_DATE")
	public Date getJangbiDate() {
		return this.jangbiDate;
	}

	public void setJangbiDate(Date jangbiDate) {
		this.jangbiDate = jangbiDate;
	}


	@Column(name="JANGBI_RESULT_1")
	public String getJangbiResult1() {
		return this.jangbiResult1;
	}

	public void setJangbiResult1(String jangbiResult1) {
		this.jangbiResult1 = jangbiResult1;
	}


	@Column(name="JANGBI_RESULT_1_YN")
	public String getJangbiResult1Yn() {
		return this.jangbiResult1Yn;
	}

	public void setJangbiResult1Yn(String jangbiResult1Yn) {
		this.jangbiResult1Yn = jangbiResult1Yn;
	}


	@Column(name="JANGBI_RESULT_2")
	public String getJangbiResult2() {
		return this.jangbiResult2;
	}

	public void setJangbiResult2(String jangbiResult2) {
		this.jangbiResult2 = jangbiResult2;
	}


	@Column(name="JANGBI_RESULT_2_YN")
	public String getJangbiResult2Yn() {
		return this.jangbiResult2Yn;
	}

	public void setJangbiResult2Yn(String jangbiResult2Yn) {
		this.jangbiResult2Yn = jangbiResult2Yn;
	}


	@Column(name="JANGBI_RESULT_3")
	public String getJangbiResult3() {
		return this.jangbiResult3;
	}

	public void setJangbiResult3(String jangbiResult3) {
		this.jangbiResult3 = jangbiResult3;
	}


	@Column(name="JANGBI_RESULT_3_YN")
	public String getJangbiResult3Yn() {
		return this.jangbiResult3Yn;
	}

	public void setJangbiResult3Yn(String jangbiResult3Yn) {
		this.jangbiResult3Yn = jangbiResult3Yn;
	}


	@Column(name="JANGBI_TIME")
	public String getJangbiTime() {
		return this.jangbiTime;
	}

	public void setJangbiTime(String jangbiTime) {
		this.jangbiTime = jangbiTime;
	}


	@Column(name="JANGBI_YN")
	public String getJangbiYn() {
		return this.jangbiYn;
	}

	public void setJangbiYn(String jangbiYn) {
		this.jangbiYn = jangbiYn;
	}


	@Column(name="LAB_NO")
	public String getLabNo() {
		return this.labNo;
	}

	public void setLabNo(String labNo) {
		this.labNo = labNo;
	}


	@Column(name="MEDICAL_JUNDAL")
	public String getMedicalJundal() {
		return this.medicalJundal;
	}

	public void setMedicalJundal(String medicalJundal) {
		this.medicalJundal = medicalJundal;
	}


	@Column(name="NEW_LAB_NO")
	public String getNewLabNo() {
		return this.newLabNo;
	}

	public void setNewLabNo(String newLabNo) {
		this.newLabNo = newLabNo;
	}


	@Column(name="PANIC_YN")
	public String getPanicYn() {
		return this.panicYn;
	}

	public void setPanicYn(String panicYn) {
		this.panicYn = panicYn;
	}


	public Double getPkcpl3020() {
		return this.pkcpl3020;
	}

	public void setPkcpl3020(Double pkcpl3020) {
		this.pkcpl3020 = pkcpl3020;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	@Column(name="RESULT_FORM")
	public String getResultForm() {
		return this.resultForm;
	}

	public void setResultForm(String resultForm) {
		this.resultForm = resultForm;
	}


	@Column(name="RESULT_SEQ")
	public String getResultSeq() {
		return this.resultSeq;
	}

	public void setResultSeq(String resultSeq) {
		this.resultSeq = resultSeq;
	}


	@Column(name="RESULT_TIME")
	public String getResultTime() {
		return this.resultTime;
	}

	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}


	@Column(name="RESULT_YN")
	public String getResultYn() {
		return this.resultYn;
	}

	public void setResultYn(String resultYn) {
		this.resultYn = resultYn;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	@Column(name="SOURCE_GUMSA")
	public String getSourceGumsa() {
		return this.sourceGumsa;
	}

	public void setSourceGumsa(String sourceGumsa) {
		this.sourceGumsa = sourceGumsa;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}


	@Column(name="STANDARD_YN")
	public String getStandardYn() {
		return this.standardYn;
	}

	public void setStandardYn(String standardYn) {
		this.standardYn = standardYn;
	}


	@Column(name="SU_DATA")
	public String getSuData() {
		return this.suData;
	}

	public void setSuData(String suData) {
		this.suData = suData;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="TO_STANDARD")
	public String getToStandard() {
		return this.toStandard;
	}

	public void setToStandard(String toStandard) {
		this.toStandard = toStandard;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	public String getVitros() {
		return this.vitros;
	}

	public void setVitros(String vitros) {
		this.vitros = vitros;
	}

}
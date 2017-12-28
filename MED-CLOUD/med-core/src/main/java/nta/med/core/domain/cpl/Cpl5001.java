package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL5001 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl5001.findAll", query="SELECT c FROM Cpl5001 c")
public class Cpl5001 extends BaseEntity {
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
	private String bunho;
	private String comments;
	private Date confirmDate;
	private String confirmYn;
	private String cplResult;
	private String danui;
	private String deltaYn;
	private String emergency;
	private double fkcpl3020;
	private String fromStandard;
	private String gumsaja;
	private String hangmogCode;
	private String hospCode;
	private String jangbiCode;
	private String jangbiYn;
	private String jundalGubun;
	private String labNo;
	private Date orderDate;
	private String orderTime;
	private String panicYn;
	private String printYn;
	private Date resultDate;
	private String resultTime;
	private String resultYn;
	private String specimenCode;
	private String specimenSer;
	private String standardYn;
	private String sunane;
	private Date sysDate;
	private String sysId;
	private String toStandard;
	private Date updDate;
	private String updId;

	public Cpl5001() {
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


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	public double getFkcpl3020() {
		return this.fkcpl3020;
	}

	public void setFkcpl3020(double fkcpl3020) {
		this.fkcpl3020 = fkcpl3020;
	}


	@Column(name="FROM_STANDARD")
	public String getFromStandard() {
		return this.fromStandard;
	}

	public void setFromStandard(String fromStandard) {
		this.fromStandard = fromStandard;
	}


	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
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


	@Column(name="JANGBI_CODE")
	public String getJangbiCode() {
		return this.jangbiCode;
	}

	public void setJangbiCode(String jangbiCode) {
		this.jangbiCode = jangbiCode;
	}


	@Column(name="JANGBI_YN")
	public String getJangbiYn() {
		return this.jangbiYn;
	}

	public void setJangbiYn(String jangbiYn) {
		this.jangbiYn = jangbiYn;
	}


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="LAB_NO")
	public String getLabNo() {
		return this.labNo;
	}

	public void setLabNo(String labNo) {
		this.labNo = labNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_TIME")
	public String getOrderTime() {
		return this.orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}


	@Column(name="PANIC_YN")
	public String getPanicYn() {
		return this.panicYn;
	}

	public void setPanicYn(String panicYn) {
		this.panicYn = panicYn;
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


	public String getSunane() {
		return this.sunane;
	}

	public void setSunane(String sunane) {
		this.sunane = sunane;
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

}
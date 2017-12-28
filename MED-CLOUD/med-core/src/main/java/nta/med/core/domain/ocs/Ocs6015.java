package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS6015 database table.
 * 
 */
@Entity
@Table(name = "OCS6015")
public class Ocs6015 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String busikYudong;
	private String continueYn;
	private String cpCode;
	private String cpPathCode;
	private String directCode;
	private String directDetail;
	private String directDetail2;
	private String directGubun;
	private String directText;
	private Double fkocs2005;
	private Double fkocs6010;
	private String hospCode;
	private String inputDoctor;
	private String inputGubun;
	private String inputGwa;
	private String inputId;
	private Double jaewonil;
	private String joriType;
	private String jusikYudong;
	private String kumjisik;
	private Double pkSeq;
	private Double pkocs6015;
	private Date planFromDate;
	private Date planToDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs6015() {
	}

	@Column(name = "BUSIK_YUDONG")
	public String getBusikYudong() {
		return this.busikYudong;
	}

	public void setBusikYudong(String busikYudong) {
		this.busikYudong = busikYudong;
	}

	@Column(name = "CONTINUE_YN")
	public String getContinueYn() {
		return this.continueYn;
	}

	public void setContinueYn(String continueYn) {
		this.continueYn = continueYn;
	}

	@Column(name = "CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}

	@Column(name = "CP_PATH_CODE")
	public String getCpPathCode() {
		return this.cpPathCode;
	}

	public void setCpPathCode(String cpPathCode) {
		this.cpPathCode = cpPathCode;
	}

	@Column(name = "DIRECT_CODE")
	public String getDirectCode() {
		return this.directCode;
	}

	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}

	@Column(name = "DIRECT_DETAIL")
	public String getDirectDetail() {
		return this.directDetail;
	}

	public void setDirectDetail(String directDetail) {
		this.directDetail = directDetail;
	}

	@Column(name = "DIRECT_DETAIL2")
	public String getDirectDetail2() {
		return this.directDetail2;
	}

	public void setDirectDetail2(String directDetail2) {
		this.directDetail2 = directDetail2;
	}

	@Column(name = "DIRECT_GUBUN")
	public String getDirectGubun() {
		return this.directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}

	@Column(name = "DIRECT_TEXT")
	public String getDirectText() {
		return this.directText;
	}

	public void setDirectText(String directText) {
		this.directText = directText;
	}

	public Double getFkocs2005() {
		return this.fkocs2005;
	}

	public void setFkocs2005(Double fkocs2005) {
		this.fkocs2005 = fkocs2005;
	}

	public Double getFkocs6010() {
		return this.fkocs6010;
	}

	public void setFkocs6010(Double fkocs6010) {
		this.fkocs6010 = fkocs6010;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INPUT_DOCTOR")
	public String getInputDoctor() {
		return this.inputDoctor;
	}

	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}

	@Column(name = "INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	@Column(name = "INPUT_GWA")
	public String getInputGwa() {
		return this.inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}

	@Column(name = "INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	public Double getJaewonil() {
		return this.jaewonil;
	}

	public void setJaewonil(Double jaewonil) {
		this.jaewonil = jaewonil;
	}

	@Column(name = "JORI_TYPE")
	public String getJoriType() {
		return this.joriType;
	}

	public void setJoriType(String joriType) {
		this.joriType = joriType;
	}

	@Column(name = "JUSIK_YUDONG")
	public String getJusikYudong() {
		return this.jusikYudong;
	}

	public void setJusikYudong(String jusikYudong) {
		this.jusikYudong = jusikYudong;
	}

	public String getKumjisik() {
		return this.kumjisik;
	}

	public void setKumjisik(String kumjisik) {
		this.kumjisik = kumjisik;
	}

	@Column(name = "PK_SEQ")
	public Double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}

	public Double getPkocs6015() {
		return this.pkocs6015;
	}

	public void setPkocs6015(Double pkocs6015) {
		this.pkocs6015 = pkocs6015;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "PLAN_FROM_DATE")
	public Date getPlanFromDate() {
		return this.planFromDate;
	}

	public void setPlanFromDate(Date planFromDate) {
		this.planFromDate = planFromDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "PLAN_TO_DATE")
	public Date getPlanToDate() {
		return this.planToDate;
	}

	public void setPlanToDate(Date planToDate) {
		this.planToDate = planToDate;
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

}
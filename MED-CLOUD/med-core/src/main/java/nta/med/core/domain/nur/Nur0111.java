package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR0111 database table.
 * 
 */
@Entity
@Table(name = "NUR0111")
public class Nur0111 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actDayYn;
	private String actDq1Yn;
	private String actDq2Yn;
	private String actDq3Yn;
	private String actDq4Yn;
	private String actTimeYn;
	private String actingYn;
	private String cntPerdayYn;
	private String cntPerhourYn;
	private String directContYn;
	private String frenchYn;
	private String hospCode;
	private String jisiContinueYn;
	private String jisiGubun;
	private String jisiOrderGubun;
	private String ment;
	private String nurGrCode;
	private String nurMdCode;
	private String nurMdName;
	private Double sortKey;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;
	private String worklistDispYn;

	public Nur0111() {
	}

	@Column(name = "ACT_DAY_YN")
	public String getActDayYn() {
		return this.actDayYn;
	}

	public void setActDayYn(String actDayYn) {
		this.actDayYn = actDayYn;
	}

	@Column(name = "ACT_DQ1_YN")
	public String getActDq1Yn() {
		return this.actDq1Yn;
	}

	public void setActDq1Yn(String actDq1Yn) {
		this.actDq1Yn = actDq1Yn;
	}

	@Column(name = "ACT_DQ2_YN")
	public String getActDq2Yn() {
		return this.actDq2Yn;
	}

	public void setActDq2Yn(String actDq2Yn) {
		this.actDq2Yn = actDq2Yn;
	}

	@Column(name = "ACT_DQ3_YN")
	public String getActDq3Yn() {
		return this.actDq3Yn;
	}

	public void setActDq3Yn(String actDq3Yn) {
		this.actDq3Yn = actDq3Yn;
	}

	@Column(name = "ACT_DQ4_YN")
	public String getActDq4Yn() {
		return this.actDq4Yn;
	}

	public void setActDq4Yn(String actDq4Yn) {
		this.actDq4Yn = actDq4Yn;
	}

	@Column(name = "ACT_TIME_YN")
	public String getActTimeYn() {
		return this.actTimeYn;
	}

	public void setActTimeYn(String actTimeYn) {
		this.actTimeYn = actTimeYn;
	}

	@Column(name = "ACTING_YN")
	public String getActingYn() {
		return this.actingYn;
	}

	public void setActingYn(String actingYn) {
		this.actingYn = actingYn;
	}

	@Column(name = "CNT_PERDAY_YN")
	public String getCntPerdayYn() {
		return this.cntPerdayYn;
	}

	public void setCntPerdayYn(String cntPerdayYn) {
		this.cntPerdayYn = cntPerdayYn;
	}

	@Column(name = "CNT_PERHOUR_YN")
	public String getCntPerhourYn() {
		return this.cntPerhourYn;
	}

	public void setCntPerhourYn(String cntPerhourYn) {
		this.cntPerhourYn = cntPerhourYn;
	}

	@Column(name = "DIRECT_CONT_YN")
	public String getDirectContYn() {
		return this.directContYn;
	}

	public void setDirectContYn(String directContYn) {
		this.directContYn = directContYn;
	}

	@Column(name = "FRENCH_YN")
	public String getFrenchYn() {
		return this.frenchYn;
	}

	public void setFrenchYn(String frenchYn) {
		this.frenchYn = frenchYn;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "JISI_CONTINUE_YN")
	public String getJisiContinueYn() {
		return this.jisiContinueYn;
	}

	public void setJisiContinueYn(String jisiContinueYn) {
		this.jisiContinueYn = jisiContinueYn;
	}

	@Column(name = "JISI_GUBUN")
	public String getJisiGubun() {
		return this.jisiGubun;
	}

	public void setJisiGubun(String jisiGubun) {
		this.jisiGubun = jisiGubun;
	}

	@Column(name = "JISI_ORDER_GUBUN")
	public String getJisiOrderGubun() {
		return this.jisiOrderGubun;
	}

	public void setJisiOrderGubun(String jisiOrderGubun) {
		this.jisiOrderGubun = jisiOrderGubun;
	}

	public String getMent() {
		return this.ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}

	@Column(name = "NUR_GR_CODE")
	public String getNurGrCode() {
		return this.nurGrCode;
	}

	public void setNurGrCode(String nurGrCode) {
		this.nurGrCode = nurGrCode;
	}

	@Column(name = "NUR_MD_CODE")
	public String getNurMdCode() {
		return this.nurMdCode;
	}

	public void setNurMdCode(String nurMdCode) {
		this.nurMdCode = nurMdCode;
	}

	@Column(name = "NUR_MD_NAME")
	public String getNurMdName() {
		return this.nurMdName;
	}

	public void setNurMdName(String nurMdName) {
		this.nurMdName = nurMdName;
	}

	@Column(name = "SORT_KEY")
	public Double getSortKey() {
		return this.sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
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

	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

	@Column(name = "WORKLIST_DISP_YN")
	public String getWorklistDispYn() {
		return this.worklistDispYn;
	}

	public void setWorklistDispYn(String worklistDispYn) {
		this.worklistDispYn = worklistDispYn;
	}

}
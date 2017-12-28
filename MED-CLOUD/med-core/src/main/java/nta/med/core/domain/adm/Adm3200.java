package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the ADM3200 database table.
 * 
 */
@Entity
@Table(name="ADM3200")
public class Adm3200 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String coId;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String deptCode;
	private String hospCode;
	private String nurseConfirmEnableYn;
	private String postapproveYn;
	private String sysId;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private Date userEndYmd;
	private String userGroup;
	private String userGubun;
	private String userId;
	private Double userLevel;
	private String userNm;
	private String userScrt;
	private String email;
	private Integer clisSmoId;
	private BigDecimal loginFlg;
	private Date certExpired;
	
	public Adm3200() {
	}
	@Column(name="CLIS_SMO_ID")
	public Integer getClisSmoId() {
		return clisSmoId;
	}

	public void setClisSmoId(Integer clisSmoId) {
		this.clisSmoId = clisSmoId;
	}

	@Column(name="EMAIL")
	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}
	
	@Column(name="CO_ID")
	public String getCoId() {
		return this.coId;
	}

	public void setCoId(String coId) {
		this.coId = coId;
	}


	@Column(name="CR_MEMB")
	public String getCrMemb() {
		return this.crMemb;
	}

	public void setCrMemb(String crMemb) {
		this.crMemb = crMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CR_TIME")
	public Date getCrTime() {
		return this.crTime;
	}

	public void setCrTime(Date crTime) {
		this.crTime = crTime;
	}


	@Column(name="CR_TRM")
	public String getCrTrm() {
		return this.crTrm;
	}

	public void setCrTrm(String crTrm) {
		this.crTrm = crTrm;
	}


	@Column(name="DEPT_CODE")
	public String getDeptCode() {
		return this.deptCode;
	}

	public void setDeptCode(String deptCode) {
		this.deptCode = deptCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NURSE_CONFIRM_ENABLE_YN")
	public String getNurseConfirmEnableYn() {
		return this.nurseConfirmEnableYn;
	}

	public void setNurseConfirmEnableYn(String nurseConfirmEnableYn) {
		this.nurseConfirmEnableYn = nurseConfirmEnableYn;
	}


	@Column(name="POSTAPPROVE_YN")
	public String getPostapproveYn() {
		return this.postapproveYn;
	}

	public void setPostapproveYn(String postapproveYn) {
		this.postapproveYn = postapproveYn;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="UP_MEMB")
	public String getUpMemb() {
		return this.upMemb;
	}

	public void setUpMemb(String upMemb) {
		this.upMemb = upMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UP_TIME")
	public Date getUpTime() {
		return this.upTime;
	}

	public void setUpTime(Date upTime) {
		this.upTime = upTime;
	}


	@Column(name="UP_TRM")
	public String getUpTrm() {
		return this.upTrm;
	}

	public void setUpTrm(String upTrm) {
		this.upTrm = upTrm;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="USER_END_YMD")
	public Date getUserEndYmd() {
		return this.userEndYmd;
	}

	public void setUserEndYmd(Date userEndYmd) {
		this.userEndYmd = userEndYmd;
	}


	@Column(name="USER_GROUP")
	public String getUserGroup() {
		return this.userGroup;
	}

	public void setUserGroup(String userGroup) {
		this.userGroup = userGroup;
	}


	@Column(name="USER_GUBUN")
	public String getUserGubun() {
		return this.userGubun;
	}

	public void setUserGubun(String userGubun) {
		this.userGubun = userGubun;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}


	@Column(name="USER_LEVEL")
	public Double getUserLevel() {
		return this.userLevel;
	}

	public void setUserLevel(Double userLevel) {
		this.userLevel = userLevel;
	}


	@Column(name="USER_NM")
	public String getUserNm() {
		return this.userNm;
	}

	public void setUserNm(String userNm) {
		this.userNm = userNm;
	}


	@Column(name="USER_SCRT")
	public String getUserScrt() {
		return this.userScrt;
	}

	public void setUserScrt(String userScrt) {
		this.userScrt = userScrt;
	}
	
	@Column(name="LOGIN_FLG")
	public BigDecimal getLoginFlg() {
		return loginFlg;
	}
	public void setLoginFlg(BigDecimal loginFlg) {
		this.loginFlg = loginFlg;
	}
	
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CERT_EXPIRED")
	public Date getCertExpired() {
		return certExpired;
	}
	public void setCertExpired(Date certExpired) {
		this.certExpired = certExpired;
	}
	
}
package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM3210 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm3210.findAll", query="SELECT a FROM Adm3210 a")
public class Adm3210 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date applyDt;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String deptCode;
	private String hospCode;
	private double seq;
	private String sysId;
	private Date userEndYmd;
	private String userGroup;
	private String userGubun;
	private String userId;
	private double userLevel;
	private String userNm;
	private String userScrt;

	public Adm3210() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="APPLY_DT")
	public Date getApplyDt() {
		return this.applyDt;
	}

	public void setApplyDt(Date applyDt) {
		this.applyDt = applyDt;
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


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
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
	public double getUserLevel() {
		return this.userLevel;
	}

	public void setUserLevel(double userLevel) {
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

}
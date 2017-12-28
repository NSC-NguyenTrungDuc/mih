package nta.med.core.domain.cpl;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the CPL0106 database table.
 * 
 */
@Entity
@Table(name = "CPL0106")
public class Cpl0106 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String continueYn;
	private String emergency;
	private String groupGubun;
	private String hangmogCode;
	private String hospCode;
	private String specimenCode;
	private String subEmergency;
	private String subHangmogCode;
	private String subSpecimenCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String modifyFlg;

	public Cpl0106() {
	}

	@Column(name = "CONTINUE_YN")
	public String getContinueYn() {
		return this.continueYn;
	}

	public void setContinueYn(String continueYn) {
		this.continueYn = continueYn;
	}

	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	@Column(name = "GROUP_GUBUN")
	public String getGroupGubun() {
		return this.groupGubun;
	}

	public void setGroupGubun(String groupGubun) {
		this.groupGubun = groupGubun;
	}

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}

	@Column(name = "SUB_EMERGENCY")
	public String getSubEmergency() {
		return this.subEmergency;
	}

	public void setSubEmergency(String subEmergency) {
		this.subEmergency = subEmergency;
	}

	@Column(name = "SUB_HANGMOG_CODE")
	public String getSubHangmogCode() {
		return this.subHangmogCode;
	}

	public void setSubHangmogCode(String subHangmogCode) {
		this.subHangmogCode = subHangmogCode;
	}

	@Column(name = "SUB_SPECIMEN_CODE")
	public String getSubSpecimenCode() {
		return this.subSpecimenCode;
	}

	public void setSubSpecimenCode(String subSpecimenCode) {
		this.subSpecimenCode = subSpecimenCode;
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

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
}
package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS0116 database table.
 * 
 */
@Entity
@NamedQuery(name = "Ocs0116.findAll", query = "SELECT o FROM Ocs0116 o")
@Table(name = "OCS0116")
public class Ocs0116 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String specimenCode;
	private String specimenGubun;
	private String specimenName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	//private String modifyFlg;

	public Ocs0116() {
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

	@Column(name = "SPECIMEN_GUBUN")
	public String getSpecimenGubun() {
		return this.specimenGubun;
	}

	public void setSpecimenGubun(String specimenGubun) {
		this.specimenGubun = specimenGubun;
	}

	@Column(name = "SPECIMEN_NAME")
	public String getSpecimenName() {
		return this.specimenName;
	}

	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
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

	/*@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}*/
	
}
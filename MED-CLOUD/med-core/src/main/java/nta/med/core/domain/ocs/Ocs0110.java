package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS0110 database table.
 * 
 */
@Entity
@NamedQuery(name = "Ocs0110.findAll", query = "SELECT o FROM Ocs0110 o")
public class Ocs0110 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String genericCodeOrg;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String yakKijunCode;
	private String modifyFlg;

	public Ocs0110() {
	}

	@Column(name = "GENERIC_CODE_ORG")
	public String getGenericCodeOrg() {
		return this.genericCodeOrg;
	}

	public void setGenericCodeOrg(String genericCodeOrg) {
		this.genericCodeOrg = genericCodeOrg;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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

	@Column(name = "YAK_KIJUN_CODE")
	public String getYakKijunCode() {
		return this.yakKijunCode;
	}

	public void setYakKijunCode(String yakKijunCode) {
		this.yakKijunCode = yakKijunCode;
	}

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
}
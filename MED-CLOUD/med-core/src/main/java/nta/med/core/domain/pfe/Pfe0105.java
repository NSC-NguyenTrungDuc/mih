package nta.med.core.domain.pfe;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the PFE0105 database table.
 * 
 */
@Entity
@NamedQuery(name="Pfe0105.findAll", query="SELECT p FROM Pfe0105 p")
public class Pfe0105 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String chiryosa;
	private String chiryosaName;
	private Date endDate;
	private String hospCode;
	private String juChiryosaYn;
	private String jundalPart;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Pfe0105() {
	}


	public String getChiryosa() {
		return this.chiryosa;
	}

	public void setChiryosa(String chiryosa) {
		this.chiryosa = chiryosa;
	}


	@Column(name="CHIRYOSA_NAME")
	public String getChiryosaName() {
		return this.chiryosaName;
	}

	public void setChiryosaName(String chiryosaName) {
		this.chiryosaName = chiryosaName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JU_CHIRYOSA_YN")
	public String getJuChiryosaYn() {
		return this.juChiryosaYn;
	}

	public void setJuChiryosaYn(String juChiryosaYn) {
		this.juChiryosaYn = juChiryosaYn;
	}


	@Column(name="JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
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
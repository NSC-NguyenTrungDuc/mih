package nta.med.core.domain.out;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OUT2016 database table.
 * 
 */
@Entity
@Table(name="OUT2016")
public class Out2016 extends BaseEntity{

	private static final long serialVersionUID = 1L;
	private BigDecimal activeFlg;
	private String bunho;
	private String bunhoLink;
	private Timestamp created;
	private BigDecimal emrLinkFlg;
	private String hospCode;
	private String hospCodeLink;
	private String linkType;
	private String sysId;
	private String updId;
	private Timestamp updated;

	public Out2016() {
	}

	@Column(name="ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="BUNHO_LINK")
	public String getBunhoLink() {
		return this.bunhoLink;
	}

	public void setBunhoLink(String bunhoLink) {
		this.bunhoLink = bunhoLink;
	}



	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}


	@Column(name="EMR_LINK_FLG")
	public BigDecimal getEmrLinkFlg() {
		return this.emrLinkFlg;
	}

	public void setEmrLinkFlg(BigDecimal emrLinkFlg) {
		this.emrLinkFlg = emrLinkFlg;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HOSP_CODE_LINK")
	public String getHospCodeLink() {
		return this.hospCodeLink;
	}

	public void setHospCodeLink(String hospCodeLink) {
		this.hospCodeLink = hospCodeLink;
	}


	@Column(name="LINK_TYPE")
	public String getLinkType() {
		return this.linkType;
	}

	public void setLinkType(String linkType) {
		this.linkType = linkType;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}



	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}

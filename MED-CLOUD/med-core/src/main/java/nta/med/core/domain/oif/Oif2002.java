package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF2002 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif2002.findAll", query="SELECT o FROM Oif2002 o")
public class Oif2002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private double fkoif1001;
	private double fkoif2001;
	private String hospCode;
	private double pkSeq;
	private double priority;
	private String provider;
	private String providerName;
	private double ratio;
	private String ratioType;
	private String recipient;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Oif2002() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	public double getFkoif1001() {
		return this.fkoif1001;
	}

	public void setFkoif1001(double fkoif1001) {
		this.fkoif1001 = fkoif1001;
	}


	public double getFkoif2001() {
		return this.fkoif2001;
	}

	public void setFkoif2001(double fkoif2001) {
		this.fkoif2001 = fkoif2001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
	}


	public double getPriority() {
		return this.priority;
	}

	public void setPriority(double priority) {
		this.priority = priority;
	}


	public String getProvider() {
		return this.provider;
	}

	public void setProvider(String provider) {
		this.provider = provider;
	}


	@Column(name="PROVIDER_NAME")
	public String getProviderName() {
		return this.providerName;
	}

	public void setProviderName(String providerName) {
		this.providerName = providerName;
	}


	public double getRatio() {
		return this.ratio;
	}

	public void setRatio(double ratio) {
		this.ratio = ratio;
	}


	@Column(name="RATIO_TYPE")
	public String getRatioType() {
		return this.ratioType;
	}

	public void setRatioType(String ratioType) {
		this.ratioType = ratioType;
	}


	public String getRecipient() {
		return this.recipient;
	}

	public void setRecipient(String recipient) {
		this.recipient = recipient;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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
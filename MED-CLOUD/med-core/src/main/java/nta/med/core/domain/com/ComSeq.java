package nta.med.core.domain.com;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the COM_SEQ database table.
 * 
 */
@Entity
@Table(name="COM_SEQ")
@NamedQuery(name="ComSeq.findAll", query="SELECT c FROM ComSeq c")
public class ComSeq extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String key;
	private String keyObj;
	private double keySeq;
	private String keyType;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public ComSeq() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="`KEY`")
	public String getKey() {
		return this.key;
	}

	public void setKey(String key) {
		this.key = key;
	}


	@Column(name="KEY_OBJ")
	public String getKeyObj() {
		return this.keyObj;
	}

	public void setKeyObj(String keyObj) {
		this.keyObj = keyObj;
	}


	@Column(name="KEY_SEQ")
	public double getKeySeq() {
		return this.keySeq;
	}

	public void setKeySeq(double keySeq) {
		this.keySeq = keySeq;
	}


	@Column(name="KEY_TYPE")
	public String getKeyType() {
		return this.keyType;
	}

	public void setKeyType(String keyType) {
		this.keyType = keyType;
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
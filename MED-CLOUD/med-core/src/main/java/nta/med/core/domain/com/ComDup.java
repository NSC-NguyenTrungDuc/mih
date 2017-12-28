package nta.med.core.domain.com;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the COM_DUP database table.
 * 
 */
@Entity
@Table(name="COM_DUP")
public class ComDup extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String keyData;
	private String keyObj;
	private String keyVal;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public ComDup() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="KEY_DATA")
	public String getKeyData() {
		return this.keyData;
	}

	public void setKeyData(String keyData) {
		this.keyData = keyData;
	}


	@Column(name="KEY_OBJ")
	public String getKeyObj() {
		return this.keyObj;
	}

	public void setKeyObj(String keyObj) {
		this.keyObj = keyObj;
	}


	@Column(name="KEY_VAL")
	public String getKeyVal() {
		return this.keyVal;
	}

	public void setKeyVal(String keyVal) {
		this.keyVal = keyVal;
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
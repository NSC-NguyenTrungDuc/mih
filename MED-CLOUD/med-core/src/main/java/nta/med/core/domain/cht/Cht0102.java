package nta.med.core.domain.cht;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CHT0102 database table.
 * 
 */
@Entity
@NamedQuery(name="Cht0102.findAll", query="SELECT c FROM Cht0102 c")
public class Cht0102 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String code;
	private String codeName;
	private String codeName2;
	private String codeType;
	private String dummy;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cht0102() {
	}


	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}


	@Column(name="CODE_NAME")
	public String getCodeName() {
		return this.codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}


	@Column(name="CODE_NAME2")
	public String getCodeName2() {
		return this.codeName2;
	}

	public void setCodeName2(String codeName2) {
		this.codeName2 = codeName2;
	}


	@Column(name="CODE_TYPE")
	public String getCodeType() {
		return this.codeType;
	}

	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}


	public String getDummy() {
		return this.dummy;
	}

	public void setDummy(String dummy) {
		this.dummy = dummy;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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
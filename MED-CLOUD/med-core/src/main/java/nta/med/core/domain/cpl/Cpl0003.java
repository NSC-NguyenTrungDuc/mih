package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0003 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0003.findAll", query="SELECT c FROM Cpl0003 c")
public class Cpl0003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String ingredient;
	private String meCode;
	private String meCodeType;
	private String meFullName;
	private String meJangbiCode;
	private String meJangbiOutCode;
	private String meNameRe;
	private String meReCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0003() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getIngredient() {
		return this.ingredient;
	}

	public void setIngredient(String ingredient) {
		this.ingredient = ingredient;
	}


	@Column(name="ME_CODE")
	public String getMeCode() {
		return this.meCode;
	}

	public void setMeCode(String meCode) {
		this.meCode = meCode;
	}


	@Column(name="ME_CODE_TYPE")
	public String getMeCodeType() {
		return this.meCodeType;
	}

	public void setMeCodeType(String meCodeType) {
		this.meCodeType = meCodeType;
	}


	@Column(name="ME_FULL_NAME")
	public String getMeFullName() {
		return this.meFullName;
	}

	public void setMeFullName(String meFullName) {
		this.meFullName = meFullName;
	}


	@Column(name="ME_JANGBI_CODE")
	public String getMeJangbiCode() {
		return this.meJangbiCode;
	}

	public void setMeJangbiCode(String meJangbiCode) {
		this.meJangbiCode = meJangbiCode;
	}


	@Column(name="ME_JANGBI_OUT_CODE")
	public String getMeJangbiOutCode() {
		return this.meJangbiOutCode;
	}

	public void setMeJangbiOutCode(String meJangbiOutCode) {
		this.meJangbiOutCode = meJangbiOutCode;
	}


	@Column(name="ME_NAME_RE")
	public String getMeNameRe() {
		return this.meNameRe;
	}

	public void setMeNameRe(String meNameRe) {
		this.meNameRe = meNameRe;
	}


	@Column(name="ME_RE_CODE")
	public String getMeReCode() {
		return this.meReCode;
	}

	public void setMeReCode(String meReCode) {
		this.meReCode = meReCode;
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
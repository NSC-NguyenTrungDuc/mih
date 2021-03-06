package nta.med.core.domain.out;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OUT0101 database table.
 * 
 */
@Entity
@Table(name = "TMP_PATIENT")
public class TmpPatient extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address1;
	private String address2;
	private Date birth;
	private String bunho;
	private String bunhoExt;
	private String bunhoType;
	private String email;
	private String gubun;
	private String hospCode;
	private String sex;
	private String suname;
	private String suname2;
	private Date sysDate;
	private String sysId;
	private String tel;
	private String telGubun;
	private String telGubun2;
	private String telGubun3;
	private String telHp;
	private String tel1;
	private Date updDate;
	private String updId;
	private String zipCode1;
	private String zipCode2;
	private String pwd;
	private String billingType;
	
	public TmpPatient() {
	}

	public String getAddress1() {
		return this.address1;
	}

	public void setAddress1(String address1) {
		this.address1 = address1;
	}

	public String getAddress2() {
		return this.address2;
	}

	public void setAddress2(String address2) {
		this.address2 = address2;
	}

	@Temporal(TemporalType.TIMESTAMP)
	public Date getBirth() {
		return this.birth;
	}

	public void setBirth(Date birth) {
		this.birth = birth;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "BUNHO_EXT")
	public String getBunhoExt() {
		return bunhoExt;
	}

	public void setBunhoExt(String bunhoExt) {
		this.bunhoExt = bunhoExt;
	}

	@Column(name = "BUNHO_TYPE")
	public String getBunhoType() {
		return this.bunhoType;
	}

	public void setBunhoType(String bunhoType) {
		this.bunhoType = bunhoType;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getSuname2() {
		return this.suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
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

	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	@Column(name = "TEL_GUBUN")
	public String getTelGubun() {
		return this.telGubun;
	}

	public void setTelGubun(String telGubun) {
		this.telGubun = telGubun;
	}

	@Column(name = "TEL_GUBUN2")
	public String getTelGubun2() {
		return this.telGubun2;
	}

	public void setTelGubun2(String telGubun2) {
		this.telGubun2 = telGubun2;
	}

	@Column(name = "TEL_GUBUN3")
	public String getTelGubun3() {
		return this.telGubun3;
	}

	public void setTelGubun3(String telGubun3) {
		this.telGubun3 = telGubun3;
	}

	@Column(name = "TEL_HP")
	public String getTelHp() {
		return this.telHp;
	}

	public void setTelHp(String telHp) {
		this.telHp = telHp;
	}

	public String getTel1() {
		return this.tel1;
	}

	public void setTel1(String tel1) {
		this.tel1 = tel1;
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

	@Column(name = "ZIP_CODE1")
	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}

	@Column(name = "ZIP_CODE2")
	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}

	@Column(name="PWD")
	public String getPwd() {
		return pwd;
	}

	public void setPwd(String pwd) {
		this.pwd = pwd;
	}

	@Column(name="BILLING_TYPE")
	public String getBillingType() {
		return billingType;
	}

	public void setBillingType(String billingType) {
		this.billingType = billingType;
	}
	
}
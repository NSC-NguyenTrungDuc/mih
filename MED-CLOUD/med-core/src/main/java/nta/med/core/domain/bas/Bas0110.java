package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0110 database table.
 * 
 */
@Entity
@Table(name = "BAS0110")
public class Bas0110 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address;
	private String boheomjaNo;
	private String cd;
	private String checkDigitYn;
	private String directReceiptYn;
	private String dodobuhyeunNo;
	private Date endDate;
	private String findCodeType;
	private String giho;
	private String johap;
	private String johapDaepyo;
	private String johapGubun;
	private String johapName;
	private double johapRate;
	private double johapRate1;
	private String lawNo;
	private String newJohap;
	private String remark;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private String tel;
	private Date updDate;
	private String updId;
	private String zipCode1;
	private String zipCode2;
	private String language;
	
	public Bas0110() {
	}


	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}


	@Column(name="BOHEOMJA_NO")
	public String getBoheomjaNo() {
		return this.boheomjaNo;
	}

	public void setBoheomjaNo(String boheomjaNo) {
		this.boheomjaNo = boheomjaNo;
	}


	public String getCd() {
		return this.cd;
	}

	public void setCd(String cd) {
		this.cd = cd;
	}


	@Column(name="CHECK_DIGIT_YN")
	public String getCheckDigitYn() {
		return this.checkDigitYn;
	}

	public void setCheckDigitYn(String checkDigitYn) {
		this.checkDigitYn = checkDigitYn;
	}


	@Column(name="DIRECT_RECEIPT_YN")
	public String getDirectReceiptYn() {
		return this.directReceiptYn;
	}

	public void setDirectReceiptYn(String directReceiptYn) {
		this.directReceiptYn = directReceiptYn;
	}


	@Column(name="DODOBUHYEUN_NO")
	public String getDodobuhyeunNo() {
		return this.dodobuhyeunNo;
	}

	public void setDodobuhyeunNo(String dodobuhyeunNo) {
		this.dodobuhyeunNo = dodobuhyeunNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="FIND_CODE_TYPE")
	public String getFindCodeType() {
		return this.findCodeType;
	}

	public void setFindCodeType(String findCodeType) {
		this.findCodeType = findCodeType;
	}


	public String getGiho() {
		return this.giho;
	}

	public void setGiho(String giho) {
		this.giho = giho;
	}

	public String getJohap() {
		return this.johap;
	}

	public void setJohap(String johap) {
		this.johap = johap;
	}


	@Column(name="JOHAP_DAEPYO")
	public String getJohapDaepyo() {
		return this.johapDaepyo;
	}

	public void setJohapDaepyo(String johapDaepyo) {
		this.johapDaepyo = johapDaepyo;
	}


	@Column(name="JOHAP_GUBUN")
	public String getJohapGubun() {
		return this.johapGubun;
	}

	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}


	@Column(name="JOHAP_NAME")
	public String getJohapName() {
		return this.johapName;
	}

	public void setJohapName(String johapName) {
		this.johapName = johapName;
	}


	@Column(name="JOHAP_RATE")
	public double getJohapRate() {
		return this.johapRate;
	}

	public void setJohapRate(double johapRate) {
		this.johapRate = johapRate;
	}


	@Column(name="JOHAP_RATE1")
	public double getJohapRate1() {
		return this.johapRate1;
	}

	public void setJohapRate1(double johapRate1) {
		this.johapRate1 = johapRate1;
	}


	@Column(name="LAW_NO")
	public String getLawNo() {
		return this.lawNo;
	}

	public void setLawNo(String lawNo) {
		this.lawNo = lawNo;
	}


	@Column(name="NEW_JOHAP")
	public String getNewJohap() {
		return this.newJohap;
	}

	public void setNewJohap(String newJohap) {
		this.newJohap = newJohap;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
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


	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
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


	@Column(name="ZIP_CODE1")
	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}


	@Column(name="ZIP_CODE2")
	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}

	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}
	
}
package nta.med.data.model.ihis.bass;

import java.io.Serializable;
import java.util.Date;

public class BAS0110BAS0110Q00GrdInfo implements Serializable {
	private String johap          ;
	private Date startDate     ;
	private String johapName     ;
	private String johapGubun    ;
	private String zipCode1      ;
	private String zipCode2      ;
	private String address        ;
	private String tel            ;
	private String lawNo         ;
	private String dodobuhyeunNo ;
	private String boheomjaNo    ;
	private String cd             ;
	private String giho           ;
	private String remark         ;
	private String checkDigitYn ;
	private String loadCodeName ;
	public BAS0110BAS0110Q00GrdInfo(String johap, Date startDate,
			String johapName, String johapGubun, String zipCode1,
			String zipCode2, String address, String tel, String lawNo,
			String dodobuhyeunNo, String boheomjaNo, String cd, String giho,
			String remark, String checkDigitYn, String loadCodeName) {
		super();
		this.johap = johap;
		this.startDate = startDate;
		this.johapName = johapName;
		this.johapGubun = johapGubun;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.address = address;
		this.tel = tel;
		this.lawNo = lawNo;
		this.dodobuhyeunNo = dodobuhyeunNo;
		this.boheomjaNo = boheomjaNo;
		this.cd = cd;
		this.giho = giho;
		this.remark = remark;
		this.checkDigitYn = checkDigitYn;
		this.loadCodeName = loadCodeName;
	}
	public String getJohap() {
		return johap;
	}
	public void setJohap(String johap) {
		this.johap = johap;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public String getJohapName() {
		return johapName;
	}
	public void setJohapName(String johapName) {
		this.johapName = johapName;
	}
	public String getJohapGubun() {
		return johapGubun;
	}
	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}
	public String getZipCode1() {
		return zipCode1;
	}
	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}
	public String getZipCode2() {
		return zipCode2;
	}
	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
	}
	public String getLawNo() {
		return lawNo;
	}
	public void setLawNo(String lawNo) {
		this.lawNo = lawNo;
	}
	public String getDodobuhyeunNo() {
		return dodobuhyeunNo;
	}
	public void setDodobuhyeunNo(String dodobuhyeunNo) {
		this.dodobuhyeunNo = dodobuhyeunNo;
	}
	public String getBoheomjaNo() {
		return boheomjaNo;
	}
	public void setBoheomjaNo(String boheomjaNo) {
		this.boheomjaNo = boheomjaNo;
	}
	public String getCd() {
		return cd;
	}
	public void setCd(String cd) {
		this.cd = cd;
	}
	public String getGiho() {
		return giho;
	}
	public void setGiho(String giho) {
		this.giho = giho;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getCheckDigitYn() {
		return checkDigitYn;
	}
	public void setCheckDigitYn(String checkDigitYn) {
		this.checkDigitYn = checkDigitYn;
	}
	public String getLoadCodeName() {
		return loadCodeName;
	}
	public void setLoadCodeName(String loadCodeName) {
		this.loadCodeName = loadCodeName;
	}
	

}

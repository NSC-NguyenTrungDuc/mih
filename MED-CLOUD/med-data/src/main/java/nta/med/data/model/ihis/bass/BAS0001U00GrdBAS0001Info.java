package nta.med.data.model.ihis.bass;

import java.util.Date;

public class BAS0001U00GrdBAS0001Info {
	private Date startDate;
    private Date endDate;
    private String yoyangGiho;
    private String yoyangName;
    private String yoyangName2;
    private String zipCode1;
    private String zipCode2;
    private String zipCode;
    private String address;
    private String address1;
    private String tel;
    private String tel1;
    private String fax;
    private Double totBed;
    private String homepage;
    private String email;
    private String hospJinGubun;
    private String dodobuhyeunNo;
    private String dodobuhyeunName;
    private String jaedanName;
    private String simpleYoyangName;
    private String bankName;
    private String bankJijum;
    private String bankNo;
    private String bankAccName;
    private String presidentName;
    private String orcaGigwanCode;
	private String acctRefId;
	private String vpnYn;
	private Integer timeZone;
	
	public BAS0001U00GrdBAS0001Info(Date startDate, Date endDate,
			String yoyangGiho, String yoyangName, String yoyangName2,
			String zipCode1, String zipCode2, String zipCode, String address,
			String address1, String tel, String tel1, String fax,
			Double totBed, String homepage, String email, String hospJinGubun,
			String dodobuhyeunNo, String dodobuhyeunName, String jaedanName,
			String simpleYoyangName, String bankName, String bankJijum,
			String bankNo, String bankAccName, String presidentName,
			String orcaGigwanCode, String acctRefId, String vpnYn, Integer timeZone) {
		super();
		this.startDate = startDate;
		this.endDate = endDate;
		this.yoyangGiho = yoyangGiho;
		this.yoyangName = yoyangName;
		this.yoyangName2 = yoyangName2;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.zipCode = zipCode;
		this.address = address;
		this.address1 = address1;
		this.tel = tel;
		this.tel1 = tel1;
		this.fax = fax;
		this.totBed = totBed;
		this.homepage = homepage;
		this.email = email;
		this.hospJinGubun = hospJinGubun;
		this.dodobuhyeunNo = dodobuhyeunNo;
		this.dodobuhyeunName = dodobuhyeunName;
		this.jaedanName = jaedanName;
		this.simpleYoyangName = simpleYoyangName;
		this.bankName = bankName;
		this.bankJijum = bankJijum;
		this.bankNo = bankNo;
		this.bankAccName = bankAccName;
		this.presidentName = presidentName;
		this.orcaGigwanCode = orcaGigwanCode;
		this.acctRefId = acctRefId;
		this.vpnYn = vpnYn;
		this.timeZone = timeZone;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getYoyangGiho() {
		return yoyangGiho;
	}
	public void setYoyangGiho(String yoyangGiho) {
		this.yoyangGiho = yoyangGiho;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	public String getYoyangName2() {
		return yoyangName2;
	}
	public void setYoyangName2(String yoyangName2) {
		this.yoyangName2 = yoyangName2;
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
	public String getZipCode() {
		return zipCode;
	}
	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getAddress1() {
		return address1;
	}
	public void setAddress1(String address1) {
		this.address1 = address1;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
	}
	public String getTel1() {
		return tel1;
	}
	public void setTel1(String tel1) {
		this.tel1 = tel1;
	}
	public String getFax() {
		return fax;
	}
	public void setFax(String fax) {
		this.fax = fax;
	}
	public Double getTotBed() {
		return totBed;
	}
	public void setTotBed(Double totBed) {
		this.totBed = totBed;
	}
	public String getHomepage() {
		return homepage;
	}
	public void setHomepage(String homepage) {
		this.homepage = homepage;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getHospJinGubun() {
		return hospJinGubun;
	}
	public void setHospJinGubun(String hospJinGubun) {
		this.hospJinGubun = hospJinGubun;
	}
	public String getDodobuhyeunNo() {
		return dodobuhyeunNo;
	}
	public void setDodobuhyeunNo(String dodobuhyeunNo) {
		this.dodobuhyeunNo = dodobuhyeunNo;
	}
	public String getDodobuhyeunName() {
		return dodobuhyeunName;
	}
	public void setDodobuhyeunName(String dodobuhyeunName) {
		this.dodobuhyeunName = dodobuhyeunName;
	}
	public String getJaedanName() {
		return jaedanName;
	}
	public void setJaedanName(String jaedanName) {
		this.jaedanName = jaedanName;
	}
	public String getSimpleYoyangName() {
		return simpleYoyangName;
	}
	public void setSimpleYoyangName(String simpleYoyangName) {
		this.simpleYoyangName = simpleYoyangName;
	}
	public String getBankName() {
		return bankName;
	}
	public void setBankName(String bankName) {
		this.bankName = bankName;
	}
	public String getBankJijum() {
		return bankJijum;
	}
	public void setBankJijum(String bankJijum) {
		this.bankJijum = bankJijum;
	}
	public String getBankNo() {
		return bankNo;
	}
	public void setBankNo(String bankNo) {
		this.bankNo = bankNo;
	}
	public String getBankAccName() {
		return bankAccName;
	}
	public void setBankAccName(String bankAccName) {
		this.bankAccName = bankAccName;
	}
	public String getPresidentName() {
		return presidentName;
	}
	public void setPresidentName(String presidentName) {
		this.presidentName = presidentName;
	}
	public String getOrcaGigwanCode() {
		return orcaGigwanCode;
	}
	public void setOrcaGigwanCode(String orcaGigwanCode) {
		this.orcaGigwanCode = orcaGigwanCode;
	}

	public String getAcctRefId() {
		return acctRefId;
	}

	public void setAcctRefId(String acctRefId) {
		this.acctRefId = acctRefId;
	}
	public String getVpnYn() {
		return vpnYn;
	}
	public void setVpnYn(String vpnYn) {
		this.vpnYn = vpnYn;
	}
	public Integer getTimeZone() {
		return timeZone;
	}
	public void setTimeZone(Integer timeZone) {
		this.timeZone = timeZone;
	}
	
}

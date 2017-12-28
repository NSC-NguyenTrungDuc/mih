package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class OUT0101Q01GrdPatientListInfo {
	private String bunho ;
	private String suname ;
	private String suname2 ;
	private String sex ;
	private Date birth ;
	private String zipCode1 ;
	private String zipCode2 ;
	private String address1 ;
	private String address2 ;
	private String address ;
	private String tel ;
	private String tel1 ;
	private String gubun ;
	private String jubsuBreak ;
	private String jubsuBreakReason ;
	private String deleteYn ;
	private String remark ;
	private String telHp ;
	private String email ;
	private Date fnOutLoadLastNaewonDate ;        
	private String fnBasLoadCodeName ;
	private String noHeader ;
	private String hoDong ;
	private String contKey ;
	public OUT0101Q01GrdPatientListInfo(String bunho, String suname,
			String suname2, String sex, Date birth, String zipCode1,
			String zipCode2, String address1, String address2, String address,
			String tel, String tel1, String gubun, String jubsuBreak,
			String jubsuBreakReason, String deleteYn, String remark,
			String telHp, String email, Date fnOutLoadLastNaewonDate,
			String fnBasLoadCodeName, String noHeader, String hoDong,
			String contKey) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.sex = sex;
		this.birth = birth;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.address1 = address1;
		this.address2 = address2;
		this.address = address;
		this.tel = tel;
		this.tel1 = tel1;
		this.gubun = gubun;
		this.jubsuBreak = jubsuBreak;
		this.jubsuBreakReason = jubsuBreakReason;
		this.deleteYn = deleteYn;
		this.remark = remark;
		this.telHp = telHp;
		this.email = email;
		this.fnOutLoadLastNaewonDate = fnOutLoadLastNaewonDate;
		this.fnBasLoadCodeName = fnBasLoadCodeName;
		this.noHeader = noHeader;
		this.hoDong = hoDong;
		this.contKey = contKey;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Date getBirth() {
		return birth;
	}
	public void setBirth(Date birth) {
		this.birth = birth;
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
	public String getAddress1() {
		return address1;
	}
	public void setAddress1(String address1) {
		this.address1 = address1;
	}
	public String getAddress2() {
		return address2;
	}
	public void setAddress2(String address2) {
		this.address2 = address2;
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
	public String getTel1() {
		return tel1;
	}
	public void setTel1(String tel1) {
		this.tel1 = tel1;
	}
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}
	public String getJubsuBreak() {
		return jubsuBreak;
	}
	public void setJubsuBreak(String jubsuBreak) {
		this.jubsuBreak = jubsuBreak;
	}
	public String getJubsuBreakReason() {
		return jubsuBreakReason;
	}
	public void setJubsuBreakReason(String jubsuBreakReason) {
		this.jubsuBreakReason = jubsuBreakReason;
	}
	public String getDeleteYn() {
		return deleteYn;
	}
	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getTelHp() {
		return telHp;
	}
	public void setTelHp(String telHp) {
		this.telHp = telHp;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public Date getFnOutLoadLastNaewonDate() {
		return fnOutLoadLastNaewonDate;
	}
	public void setFnOutLoadLastNaewonDate(Date fnOutLoadLastNaewonDate) {
		this.fnOutLoadLastNaewonDate = fnOutLoadLastNaewonDate;
	}
	public String getFnBasLoadCodeName() {
		return fnBasLoadCodeName;
	}
	public void setFnBasLoadCodeName(String fnBasLoadCodeName) {
		this.fnBasLoadCodeName = fnBasLoadCodeName;
	}
	public String getNoHeader() {
		return noHeader;
	}
	public void setNoHeader(String noHeader) {
		this.noHeader = noHeader;
	}
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
}

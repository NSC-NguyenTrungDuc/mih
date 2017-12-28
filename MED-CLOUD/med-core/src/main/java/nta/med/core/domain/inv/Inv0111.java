package nta.med.core.domain.inv;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INV0111 database table.
 * 
 */
@Entity
@NamedQuery(name="Inv0111.findAll", query="SELECT i FROM Inv0111 i")
public class Inv0111 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String add1;
	private String bankCode;
	private String bunryu1;
	private String bunryu10;
	private String bunryu11;
	private String bunryu12;
	private String bunryu13;
	private String bunryu14;
	private String bunryu2;
	private String bunryu3;
	private String bunryu4;
	private String bunryu5;
	private String bunryu6;
	private String bunryu7;
	private String bunryu8;
	private String bunryu9;
	private String companyNo;
	private String custGubun;
	private String custType;
	private String customerCode;
	private String customerName;
	private String damdangja;
	private String depositer;
	private Date endDate;
	private String euptaeGubun;
	private String exponentName;
	private String faxNo;
	private String handPhone1;
	private String hospCode;
	private String jongMok;
	private String passbookId;
	private String pubinNo;
	private String remark;
	private String sabun;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private String tel;
	private Date updDate;
	private String updId;
	private String zipCode1;
	private String zipCode2;

	public Inv0111() {
	}


	@Column(name="ADD_1")
	public String getAdd1() {
		return this.add1;
	}

	public void setAdd1(String add1) {
		this.add1 = add1;
	}


	@Column(name="BANK_CODE")
	public String getBankCode() {
		return this.bankCode;
	}

	public void setBankCode(String bankCode) {
		this.bankCode = bankCode;
	}


	public String getBunryu1() {
		return this.bunryu1;
	}

	public void setBunryu1(String bunryu1) {
		this.bunryu1 = bunryu1;
	}


	public String getBunryu10() {
		return this.bunryu10;
	}

	public void setBunryu10(String bunryu10) {
		this.bunryu10 = bunryu10;
	}


	public String getBunryu11() {
		return this.bunryu11;
	}

	public void setBunryu11(String bunryu11) {
		this.bunryu11 = bunryu11;
	}


	public String getBunryu12() {
		return this.bunryu12;
	}

	public void setBunryu12(String bunryu12) {
		this.bunryu12 = bunryu12;
	}


	public String getBunryu13() {
		return this.bunryu13;
	}

	public void setBunryu13(String bunryu13) {
		this.bunryu13 = bunryu13;
	}


	public String getBunryu14() {
		return this.bunryu14;
	}

	public void setBunryu14(String bunryu14) {
		this.bunryu14 = bunryu14;
	}


	public String getBunryu2() {
		return this.bunryu2;
	}

	public void setBunryu2(String bunryu2) {
		this.bunryu2 = bunryu2;
	}


	public String getBunryu3() {
		return this.bunryu3;
	}

	public void setBunryu3(String bunryu3) {
		this.bunryu3 = bunryu3;
	}


	public String getBunryu4() {
		return this.bunryu4;
	}

	public void setBunryu4(String bunryu4) {
		this.bunryu4 = bunryu4;
	}


	public String getBunryu5() {
		return this.bunryu5;
	}

	public void setBunryu5(String bunryu5) {
		this.bunryu5 = bunryu5;
	}


	public String getBunryu6() {
		return this.bunryu6;
	}

	public void setBunryu6(String bunryu6) {
		this.bunryu6 = bunryu6;
	}


	public String getBunryu7() {
		return this.bunryu7;
	}

	public void setBunryu7(String bunryu7) {
		this.bunryu7 = bunryu7;
	}


	public String getBunryu8() {
		return this.bunryu8;
	}

	public void setBunryu8(String bunryu8) {
		this.bunryu8 = bunryu8;
	}


	public String getBunryu9() {
		return this.bunryu9;
	}

	public void setBunryu9(String bunryu9) {
		this.bunryu9 = bunryu9;
	}


	@Column(name="COMPANY_NO")
	public String getCompanyNo() {
		return this.companyNo;
	}

	public void setCompanyNo(String companyNo) {
		this.companyNo = companyNo;
	}


	@Column(name="CUST_GUBUN")
	public String getCustGubun() {
		return this.custGubun;
	}

	public void setCustGubun(String custGubun) {
		this.custGubun = custGubun;
	}


	@Column(name="CUST_TYPE")
	public String getCustType() {
		return this.custType;
	}

	public void setCustType(String custType) {
		this.custType = custType;
	}


	@Column(name="CUSTOMER_CODE")
	public String getCustomerCode() {
		return this.customerCode;
	}

	public void setCustomerCode(String customerCode) {
		this.customerCode = customerCode;
	}


	@Column(name="CUSTOMER_NAME")
	public String getCustomerName() {
		return this.customerName;
	}

	public void setCustomerName(String customerName) {
		this.customerName = customerName;
	}


	public String getDamdangja() {
		return this.damdangja;
	}

	public void setDamdangja(String damdangja) {
		this.damdangja = damdangja;
	}


	public String getDepositer() {
		return this.depositer;
	}

	public void setDepositer(String depositer) {
		this.depositer = depositer;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="EUPTAE_GUBUN")
	public String getEuptaeGubun() {
		return this.euptaeGubun;
	}

	public void setEuptaeGubun(String euptaeGubun) {
		this.euptaeGubun = euptaeGubun;
	}


	@Column(name="EXPONENT_NAME")
	public String getExponentName() {
		return this.exponentName;
	}

	public void setExponentName(String exponentName) {
		this.exponentName = exponentName;
	}


	@Column(name="FAX_NO")
	public String getFaxNo() {
		return this.faxNo;
	}

	public void setFaxNo(String faxNo) {
		this.faxNo = faxNo;
	}


	@Column(name="HAND_PHONE_1")
	public String getHandPhone1() {
		return this.handPhone1;
	}

	public void setHandPhone1(String handPhone1) {
		this.handPhone1 = handPhone1;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JONG_MOK")
	public String getJongMok() {
		return this.jongMok;
	}

	public void setJongMok(String jongMok) {
		this.jongMok = jongMok;
	}


	@Column(name="PASSBOOK_ID")
	public String getPassbookId() {
		return this.passbookId;
	}

	public void setPassbookId(String passbookId) {
		this.passbookId = passbookId;
	}


	@Column(name="PUBIN_NO")
	public String getPubinNo() {
		return this.pubinNo;
	}

	public void setPubinNo(String pubinNo) {
		this.pubinNo = pubinNo;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getSabun() {
		return this.sabun;
	}

	public void setSabun(String sabun) {
		this.sabun = sabun;
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

}
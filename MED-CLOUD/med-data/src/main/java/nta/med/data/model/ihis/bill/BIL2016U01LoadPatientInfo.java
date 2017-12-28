package nta.med.data.model.ihis.bill;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class BIL2016U01LoadPatientInfo {
	private Timestamp billDate;
	private String billNumber;
	private String bunho;
	private String suname;
	private String address;
	private String sex;
	private Timestamp commingDate;
	private String type;
	private String typeName;
	private Timestamp birth;
	private Double fkout;
	private String phone;
	private String paidName;
	private String typeMoney;
	private BigDecimal sumAmount;
	private BigDecimal sumDiscount;
	private BigDecimal sumPaid;
	private BigDecimal sumDebt;
	private String parentInvoiceno;
	private BigDecimal statusFlg;
	public BIL2016U01LoadPatientInfo(Timestamp billDate, String billNumber, String bunho, String suname, String address,
			String sex, Timestamp commingDate, String type, String typeName, Timestamp birth, Double fkout,
			String phone, String paidName, String typeMoney, BigDecimal sumAmount, BigDecimal sumDiscount,
			BigDecimal sumPaid, BigDecimal sumDebt, String parentInvoiceno, BigDecimal statusFlg) {
		super();
		this.billDate = billDate;
		this.billNumber = billNumber;
		this.bunho = bunho;
		this.suname = suname;
		this.address = address;
		this.sex = sex;
		this.commingDate = commingDate;
		this.type = type;
		this.typeName = typeName;
		this.birth = birth;
		this.fkout = fkout;
		this.phone = phone;
		this.paidName = paidName;
		this.typeMoney = typeMoney;
		this.sumAmount = sumAmount;
		this.sumDiscount = sumDiscount;
		this.sumPaid = sumPaid;
		this.sumDebt = sumDebt;
		this.parentInvoiceno = parentInvoiceno;
		this.statusFlg = statusFlg;
	}
	public Timestamp getBillDate() {
		return billDate;
	}
	public void setBillDate(Timestamp billDate) {
		this.billDate = billDate;
	}
	public String getBillNumber() {
		return billNumber;
	}
	public void setBillNumber(String billNumber) {
		this.billNumber = billNumber;
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
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Timestamp getCommingDate() {
		return commingDate;
	}
	public void setCommingDate(Timestamp commingDate) {
		this.commingDate = commingDate;
	}
	public String getType() {
		return type;
	}
	public void setType(String type) {
		this.type = type;
	}
	public String getTypeName() {
		return typeName;
	}
	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}
	public Timestamp getBirth() {
		return birth;
	}
	public void setBirth(Timestamp birth) {
		this.birth = birth;
	}
	public Double getFkout() {
		return fkout;
	}
	public void setFkout(Double fkout) {
		this.fkout = fkout;
	}
	public String getPhone() {
		return phone;
	}
	public void setPhone(String phone) {
		this.phone = phone;
	}
	public String getPaidName() {
		return paidName;
	}
	public void setPaidName(String paidName) {
		this.paidName = paidName;
	}
	public String getTypeMoney() {
		return typeMoney;
	}
	public void setTypeMoney(String typeMoney) {
		this.typeMoney = typeMoney;
	}
	public BigDecimal getSumAmount() {
		return sumAmount;
	}
	public void setSumAmount(BigDecimal sumAmount) {
		this.sumAmount = sumAmount;
	}
	public BigDecimal getSumDiscount() {
		return sumDiscount;
	}
	public void setSumDiscount(BigDecimal sumDiscount) {
		this.sumDiscount = sumDiscount;
	}
	public BigDecimal getSumPaid() {
		return sumPaid;
	}
	public void setSumPaid(BigDecimal sumPaid) {
		this.sumPaid = sumPaid;
	}
	public BigDecimal getSumDebt() {
		return sumDebt;
	}
	public void setSumDebt(BigDecimal sumDebt) {
		this.sumDebt = sumDebt;
	}
	public String getParentInvoiceno() {
		return parentInvoiceno;
	}
	public void setParentInvoiceno(String parentInvoiceno) {
		this.parentInvoiceno = parentInvoiceno;
	}
	public BigDecimal getStatusFlg() {
		return statusFlg;
	}
	public void setStatusFlg(BigDecimal statusFlg) {
		this.statusFlg = statusFlg;
	}
	
}

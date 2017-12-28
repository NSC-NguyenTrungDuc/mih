package nta.med.data.model.ihis.inps;

import java.util.Date;

public class INP2004Q00grdINP2004Info {
	private Double pkinp1001;
	private String bunho;
	private String suname;
	private String sex;
	private Integer age;
	private Date birth;
	private String bedNo;
	private Date ipwonDate;
	private Date toiwonDate;
	private Date orderDate;
	public INP2004Q00grdINP2004Info(Double pkinp1001, String bunho, String suname, String sex, Integer age, Date birth,
			String bedNo, Date ipwonDate, Date toiwonDate, Date orderDate) {
		super();
		this.pkinp1001 = pkinp1001;
		this.bunho = bunho;
		this.suname = suname;
		this.sex = sex;
		this.age = age;
		this.birth = birth;
		this.bedNo = bedNo;
		this.ipwonDate = ipwonDate;
		this.toiwonDate = toiwonDate;
		this.orderDate = orderDate;
	}
	public Double getPkinp1001() {
		return pkinp1001;
	}
	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
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
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
	public Date getBirth() {
		return birth;
	}
	public void setBirth(Date birth) {
		this.birth = birth;
	}
	public String getBedNo() {
		return bedNo;
	}
	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}
	public Date getIpwonDate() {
		return ipwonDate;
	}
	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}
	public Date getToiwonDate() {
		return toiwonDate;
	}
	public void setToiwonDate(Date toiwonDate) {
		this.toiwonDate = toiwonDate;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	
}

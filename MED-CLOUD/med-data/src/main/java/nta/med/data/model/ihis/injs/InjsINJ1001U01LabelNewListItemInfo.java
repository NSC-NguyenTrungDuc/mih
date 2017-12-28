package nta.med.data.model.ihis.injs;

import java.sql.Timestamp;

public class InjsINJ1001U01LabelNewListItemInfo {
	private String bunho;
	private String suname;
	private String suname2;
	private Integer age;
	private String sex;
	private Timestamp jubsuDate;
	private Double cnt;
	private Double suryang;
	private String danuiName;
	private String bogyongName;
	private String jusaName;
	private String jaeryoName;
	private String orderRemark;
	private String dataGubun;
	private String mixYn;
	
	public InjsINJ1001U01LabelNewListItemInfo(String bunho, String suname,
			String suname2, Integer age, String sex, Timestamp jubsuDate,
			Double cnt, Double suryang, String danuiName, String bogyongName,
			String jusaName, String jaeryoName, String orderRemark,
			String dataGubun, String mixYn) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.age = age;
		this.sex = sex;
		this.jubsuDate = jubsuDate;
		this.cnt = cnt;
		this.suryang = suryang;
		this.danuiName = danuiName;
		this.bogyongName = bogyongName;
		this.jusaName = jusaName;
		this.jaeryoName = jaeryoName;
		this.orderRemark = orderRemark;
		this.dataGubun = dataGubun;
		this.mixYn = mixYn;
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

	public Integer getAge() {
		return age;
	}

	public void setAge(Integer age) {
		this.age = age;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public Timestamp getJubsuDate() {
		return jubsuDate;
	}

	public void setJubsuDate(Timestamp jubsuDate) {
		this.jubsuDate = jubsuDate;
	}

	public Double getCnt() {
		return cnt;
	}

	public void setCnt(Double cnt) {
		this.cnt = cnt;
	}

	public Double getSuryang() {
		return suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}

	public String getDanuiName() {
		return danuiName;
	}

	public void setDanuiName(String danuiName) {
		this.danuiName = danuiName;
	}

	public String getBogyongName() {
		return bogyongName;
	}

	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}

	public String getJusaName() {
		return jusaName;
	}

	public void setJusaName(String jusaName) {
		this.jusaName = jusaName;
	}

	public String getJaeryoName() {
		return jaeryoName;
	}

	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}

	public String getOrderRemark() {
		return orderRemark;
	}

	public void setOrderRemark(String orderRemark) {
		this.orderRemark = orderRemark;
	}

	public String getDataGubun() {
		return dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}

	public String getMixYn() {
		return mixYn;
	}

	public void setMixYn(String mixYn) {
		this.mixYn = mixYn;
	}

	@Override
	public String toString() {
		return "InjsINJ1001U01LabelNewListItemInfo [bunho=" + bunho
				+ ", suname=" + suname + ", suname2=" + suname2 + ", age="
				+ age + ", sex=" + sex + ", jubsuDate=" + jubsuDate + ", cnt="
				+ cnt + ", suryang=" + suryang + ", danuiName=" + danuiName
				+ ", bogyongName=" + bogyongName + ", jusaName=" + jusaName
				+ ", jaeryoName=" + jaeryoName + ", orderRemark=" + orderRemark
				+ ", dataGubun=" + dataGubun + ", mixYn=" + mixYn + "]";
	}
}

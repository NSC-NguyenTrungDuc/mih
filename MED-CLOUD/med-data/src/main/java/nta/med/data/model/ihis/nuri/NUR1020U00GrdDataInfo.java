package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020U00GrdDataInfo {

	private String bunho;
	private Double fkinp1001;
	private Date orderDate;
	private String gubun1;
	private String gubun2;
	private String gubun3;
	private String value;
	private String nutGubn2;
	private String nutValue2;

	public NUR1020U00GrdDataInfo(String bunho, Double fkinp1001, Date orderDate, String gubun1, String gubun2,
			String gubun3, String value, String nutGubn2, String nutValue2) {
		super();
		this.bunho = bunho;
		this.fkinp1001 = fkinp1001;
		this.orderDate = orderDate;
		this.gubun1 = gubun1;
		this.gubun2 = gubun2;
		this.gubun3 = gubun3;
		this.value = value;
		this.nutGubn2 = nutGubn2;
		this.nutValue2 = nutValue2;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Date getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	public String getGubun1() {
		return gubun1;
	}

	public void setGubun1(String gubun1) {
		this.gubun1 = gubun1;
	}

	public String getGubun2() {
		return gubun2;
	}

	public void setGubun2(String gubun2) {
		this.gubun2 = gubun2;
	}

	public String getGubun3() {
		return gubun3;
	}

	public void setGubun3(String gubun3) {
		this.gubun3 = gubun3;
	}

	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

	public String getNutGubn2() {
		return nutGubn2;
	}

	public void setNutGubn2(String nutGubn2) {
		this.nutGubn2 = nutGubn2;
	}

	public String getNutValue2() {
		return nutValue2;
	}

	public void setNutValue2(String nutValue2) {
		this.nutValue2 = nutValue2;
	}

}

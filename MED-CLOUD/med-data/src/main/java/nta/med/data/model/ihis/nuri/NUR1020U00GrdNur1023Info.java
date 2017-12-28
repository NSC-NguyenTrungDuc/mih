package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020U00GrdNur1023Info {

	private Double fkinp1001;
	private String bunho;
	private Date orderDate;
	private String vspatnGubun;

	public NUR1020U00GrdNur1023Info(Double fkinp1001, String bunho, Date orderDate, String vspatnGubun) {
		super();
		this.fkinp1001 = fkinp1001;
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.vspatnGubun = vspatnGubun;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Date getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	public String getVspatnGubun() {
		return vspatnGubun;
	}

	public void setVspatnGubun(String vspatnGubun) {
		this.vspatnGubun = vspatnGubun;
	}

}

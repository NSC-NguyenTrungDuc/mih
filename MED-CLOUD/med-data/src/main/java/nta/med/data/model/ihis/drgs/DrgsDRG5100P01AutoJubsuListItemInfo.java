package nta.med.data.model.ihis.drgs;

import java.sql.Timestamp;

public class DrgsDRG5100P01AutoJubsuListItemInfo {
	private String bunho;
	private Timestamp orderDate;
	private Double drgBunho;
	private String suname;
	private String boryuYn;
	private String orderRemark;
	private String drgRemark;
	public DrgsDRG5100P01AutoJubsuListItemInfo(String bunho,
			Timestamp orderDate, Double drgBunho, String suname,
			String boryuYn, String orderRemark, String drgRemark) {
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.drgBunho = drgBunho;
		this.suname = suname;
		this.boryuYn = boryuYn;
		this.orderRemark = orderRemark;
		this.drgRemark = drgRemark;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Timestamp getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Timestamp orderDate) {
		this.orderDate = orderDate;
	}
	public Double getDrgBunho() {
		return drgBunho;
	}
	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getBoryuYn() {
		return boryuYn;
	}
	public void setBoryuYn(String boryuYn) {
		this.boryuYn = boryuYn;
	}
	public String getOrderRemark() {
		return orderRemark;
	}
	public void setOrderRemark(String orderRemark) {
		this.orderRemark = orderRemark;
	}
	public String getDrgRemark() {
		return drgRemark;
	}
	public void setDrgRemark(String drgRemark) {
		this.drgRemark = drgRemark;
	}
	@Override
	public String toString() {
		return "DrgsDRG5100P01AutoJubsuListItemInfo [bunho=" + bunho
				+ ", orderDate=" + orderDate + ", drgBunho=" + drgBunho
				+ ", suname=" + suname + ", boryuYn=" + boryuYn
				+ ", orderRemark=" + orderRemark + ", drgRemark=" + drgRemark
				+ "]";
	}
	
}

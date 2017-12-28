package nta.med.data.model.ihis.drgs;

import java.math.BigInteger;
import java.sql.Timestamp;

public class DRG0201U00GrdPaidInfo {
	private Double drgBunho;
	private String bunho;
	private Timestamp orderDate;
	private String jojeYn;
	private String suname;
	private String orderRemark;
	private String drgRemark;
	private BigInteger numProtocol;
	public DRG0201U00GrdPaidInfo(Double drgBunho, String bunho,
			Timestamp orderDate, String jojeYn, String suname,
			String orderRemark, String drgRemark, BigInteger numProtocol) {
		super();
		this.drgBunho = drgBunho;
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.jojeYn = jojeYn;
		this.suname = suname;
		this.orderRemark = orderRemark;
		this.drgRemark = drgRemark;
		this.numProtocol = numProtocol;
	}
	public Double getDrgBunho() {
		return drgBunho;
	}
	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
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
	public String getJojeYn() {
		return jojeYn;
	}
	public void setJojeYn(String jojeYn) {
		this.jojeYn = jojeYn;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
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
	public BigInteger getNumProtocol() {
		return numProtocol;
	}
	public void setNumProtocol(BigInteger numProtocol) {
		this.numProtocol = numProtocol;
	}
}

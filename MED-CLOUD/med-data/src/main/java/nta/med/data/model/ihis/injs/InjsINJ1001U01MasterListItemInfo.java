package nta.med.data.model.ihis.injs;

import java.math.BigInteger;

public class InjsINJ1001U01MasterListItemInfo {
	private String reserGubun;
	private String bunho;
	private String suname;
	private String orderDate;
	private String reserDate;
	private BigInteger numProtocol;
	public InjsINJ1001U01MasterListItemInfo(String reserGubun, String bunho,
			String suname, String orderDate, String reserDate,
			BigInteger numProtocol) {
		super();
		this.reserGubun = reserGubun;
		this.bunho = bunho;
		this.suname = suname;
		this.orderDate = orderDate;
		this.reserDate = reserDate;
		this.numProtocol = numProtocol;
	}
	public String getReserGubun() {
		return reserGubun;
	}
	public void setReserGubun(String reserGubun) {
		this.reserGubun = reserGubun;
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
	public String getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}
	public String getReserDate() {
		return reserDate;
	}
	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}
	public BigInteger getNumProtocol() {
		return numProtocol;
	}
	public void setNumProtocol(BigInteger numProtocol) {
		this.numProtocol = numProtocol;
	}
}

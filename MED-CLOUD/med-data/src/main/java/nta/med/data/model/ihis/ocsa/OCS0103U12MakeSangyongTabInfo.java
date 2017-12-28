package nta.med.data.model.ihis.ocsa;

public class OCS0103U12MakeSangyongTabInfo {
	private String orderGubun;
	private String orderGubunName;
	private String memb;
	private String ynValue;
	private String sort;
	public OCS0103U12MakeSangyongTabInfo(String orderGubun,
			String orderGubunName, String memb, String ynValue, String sort) {
		super();
		this.orderGubun = orderGubun;
		this.orderGubunName = orderGubunName;
		this.memb = memb;
		this.ynValue = ynValue;
		this.sort = sort;
	}
	public String getOrderGubun() {
		return orderGubun;
	}
	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}
	public String getOrderGubunName() {
		return orderGubunName;
	}
	public void setOrderGubunName(String orderGubunName) {
		this.orderGubunName = orderGubunName;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public String getYnValue() {
		return ynValue;
	}
	public void setYnValue(String ynValue) {
		this.ynValue = ynValue;
	}
	public String getSort() {
		return sort;
	}
	public void setSort(String sort) {
		this.sort = sort;
	}
}

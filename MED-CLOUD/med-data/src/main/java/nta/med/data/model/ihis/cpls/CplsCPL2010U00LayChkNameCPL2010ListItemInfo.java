package nta.med.data.model.ihis.cpls;

public class CplsCPL2010U00LayChkNameCPL2010ListItemInfo {
	private String suname;
	private String orderDate1;
	private String orderDate2;
	private String codeName;

	public CplsCPL2010U00LayChkNameCPL2010ListItemInfo(String suname,
			String orderDate1, String orderDate2, String codeName) {
		super();
		this.suname = suname;
		this.orderDate1 = orderDate1;
		this.orderDate2 = orderDate2;
		this.codeName = codeName;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getOrderDate1() {
		return orderDate1;
	}

	public void setOrderDate1(String orderDate1) {
		this.orderDate1 = orderDate1;
	}

	public String getOrderDate2() {
		return orderDate2;
	}

	public void setOrderDate2(String orderDate2) {
		this.orderDate2 = orderDate2;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

}

package nta.med.data.model.ihis.ocsa;

public class OCS0103U19TvwJaeryoGubunInfo {
	private String orderGubun;
	private String orderGubunName;
	private Double sortKey;

	public OCS0103U19TvwJaeryoGubunInfo(String orderGubun,
			String orderGubunName, Double sortKey) {
		super();
		this.orderGubun = orderGubun;
		this.orderGubunName = orderGubunName;
		this.sortKey = sortKey;
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

	public Double getSortKey() {
		return sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

}
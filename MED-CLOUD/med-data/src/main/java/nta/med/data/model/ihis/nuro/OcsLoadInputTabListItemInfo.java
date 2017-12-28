package nta.med.data.model.ihis.nuro;

public class OcsLoadInputTabListItemInfo {
	private String inputTab;
	private String orderGubun;
	private String mainYn;
	private String defaultYn;

	public OcsLoadInputTabListItemInfo(String inputTab, String orderGubun,
			String mainYn, String defaultYn) {
		super();
		this.inputTab = inputTab;
		this.orderGubun = orderGubun;
		this.mainYn = mainYn;
		this.defaultYn = defaultYn;
	}

	public String getInputTab() {
		return inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}

	public String getOrderGubun() {
		return orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}

	public String getMainYn() {
		return mainYn;
	}

	public void setMainYn(String mainYn) {
		this.mainYn = mainYn;
	}

	public String getDefaultYn() {
		return defaultYn;
	}

	public void setDefaultYn(String defaultYn) {
		this.defaultYn = defaultYn;
	}

}

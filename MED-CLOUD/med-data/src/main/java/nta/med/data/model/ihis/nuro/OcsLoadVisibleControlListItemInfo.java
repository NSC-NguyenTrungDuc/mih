package nta.med.data.model.ihis.nuro;

public class OcsLoadVisibleControlListItemInfo {
	private String inputTab;
	private String colName;
	private String visibleYn;

	public OcsLoadVisibleControlListItemInfo(String inputTab, String colName,
			String visibleYn) {
		super();
		this.inputTab = inputTab;
		this.colName = colName;
		this.visibleYn = visibleYn;
	}

	public String getInputTab() {
		return inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}

	public String getColName() {
		return colName;
	}

	public void setColName(String colName) {
		this.colName = colName;
	}

	public String getVisibleYn() {
		return visibleYn;
	}

	public void setVisibleYn(String visibleYn) {
		this.visibleYn = visibleYn;
	}

}

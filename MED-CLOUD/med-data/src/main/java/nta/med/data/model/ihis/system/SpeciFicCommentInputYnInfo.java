package nta.med.data.model.ihis.system;

public class SpeciFicCommentInputYnInfo {
	private String tableId;
	private String colId;
	public SpeciFicCommentInputYnInfo(String tableId, String colId) {
		super();
		this.tableId = tableId;
		this.colId = colId;
	}
	public String getTableId() {
		return tableId;
	}
	public void setTableId(String tableId) {
		this.tableId = tableId;
	}
	public String getColId() {
		return colId;
	}
	public void setColId(String colId) {
		this.colId = colId;
	}
	

}

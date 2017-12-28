package nta.med.data.model.ihis.schs;

public class SchsSCH0201Q04PrartListItemInfo {
	private String jundalTable;
	private String jundalPart;
	private String jundalPartName;
	
	public SchsSCH0201Q04PrartListItemInfo(String jundalTable,
			String jundalPart, String jundalPartName) {
		super();
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.jundalPartName = jundalPartName;
	}
	
	public String getJundalTable() {
		return jundalTable;
	}
	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getJundalPartName() {
		return jundalPartName;
	}
	public void setJundalPartName(String jundalPartName) {
		this.jundalPartName = jundalPartName;
	}
	
	

}

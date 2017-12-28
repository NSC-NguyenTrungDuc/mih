package nta.med.data.model.ihis.system;

public class MainMenuInfo {
	private String groupId;
	private String groupName;
	private String systemId;
	private String systemName;
	private String displayGroupId;
	private String displayGroupName;
	private String description;
	
	/*public MainMenuInfo() {
		
	}*/
	
	public MainMenuInfo(String groupId, String groupName, String systemId,
			String systemName, String displayGroupId, String displayGroupName,
			String description) {
		super();
		this.groupId = groupId;
		this.groupName = groupName;
		this.systemId = systemId;
		this.systemName = systemName;
		this.displayGroupId = displayGroupId;
		this.displayGroupName = displayGroupName;
		this.description = description;
	}
	public String getGroupId() {
		return groupId;
	}
	public void setGroupId(String groupId) {
		this.groupId = groupId;
	}
	public String getGroupName() {
		return groupName;
	}
	public void setGroupName(String groupName) {
		this.groupName = groupName;
	}
	public String getSystemId() {
		return systemId;
	}
	public void setSystemId(String systemId) {
		this.systemId = systemId;
	}
	public String getSystemName() {
		return systemName;
	}
	public void setSystemName(String systemName) {
		this.systemName = systemName;
	}
	public String getDisplayGroupId() {
		return displayGroupId;
	}
	public void setDisplayGroupId(String displayGroupId) {
		this.displayGroupId = displayGroupId;
	}
	public String getDisplayGroupName() {
		return displayGroupName;
	}
	public void setDisplayGroupName(String displayGroupName) {
		this.displayGroupName = displayGroupName;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
}

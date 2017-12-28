package nta.med.data.model.ihis.system;

public class CacheRevisionInfo {
	private String tableName;
	private Integer revision;
	public CacheRevisionInfo(String tableName, Integer revision) {
		super();
		this.tableName = tableName;
		this.revision = revision;
	}
	public String getTableName() {
		return tableName;
	}
	public void setTableName(String tableName) {
		this.tableName = tableName;
	}
	public Integer getRevision() {
		return revision;
	}
	public void setRevision(Integer revision) {
		this.revision = revision;
	}

}

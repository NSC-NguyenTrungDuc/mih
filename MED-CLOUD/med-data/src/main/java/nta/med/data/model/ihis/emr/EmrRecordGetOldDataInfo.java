package nta.med.data.model.ihis.emr;

import java.sql.Timestamp;

public class EmrRecordGetOldDataInfo {
	private Integer emrRecordId;
	private String content;
	private Integer version;
	private String sysId;
	private String recordLog;
	private String metadata;
	private Timestamp created;
	
	public Timestamp getCreated() {
		return created;
	}
	public void setCreated(Timestamp created) {
		this.created = created;
	}
	public Integer getEmrRecordId() {
		return emrRecordId;
	}
	public void setEmrRecordId(Integer emrRecordId) {
		this.emrRecordId = emrRecordId;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public Integer getVersion() {
		return version;
	}
	public void setVersion(Integer version) {
		this.version = version;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getRecordLog() {
		return recordLog;
	}
	public void setRecordLog(String recordLog) {
		this.recordLog = recordLog;
	}
	public String getMetadata() {
		return metadata;
	}
	public void setMetadata(String metadata) {
		this.metadata = metadata;
	}
	public EmrRecordGetOldDataInfo(Integer emrRecordId, String content,
			Integer version, String sysId, String recordLog, String metadata, Timestamp created) {
		super();
		this.emrRecordId = emrRecordId;
		this.content = content;
		this.version = version;
		this.sysId = sysId;
		this.recordLog = recordLog;
		this.metadata = metadata;
		this.created = created;
	}
	
}

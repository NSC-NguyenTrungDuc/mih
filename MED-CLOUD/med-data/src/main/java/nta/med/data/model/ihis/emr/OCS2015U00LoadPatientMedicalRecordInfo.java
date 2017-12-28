package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class OCS2015U00LoadPatientMedicalRecordInfo {
	private Integer emrRecordId;
	private String content;
	private String metadata;
	private Integer version;
	private String recordLog;
	private BigDecimal lockFlg;
	private String hospCode;
	private String bunho;
	private String sysId;
	private String updId;
	private Timestamp created;
	private Timestamp updated;
	public OCS2015U00LoadPatientMedicalRecordInfo(Integer emrRecordId,
			String content, String metadata, Integer version, String recordLog,
			BigDecimal lockFlg, String hospCode, String bunho, String sysId,
			String updId, Timestamp created, Timestamp updated) {
		super();
		this.emrRecordId = emrRecordId;
		this.content = content;
		this.metadata = metadata;
		this.version = version;
		this.recordLog = recordLog;
		this.lockFlg = lockFlg;
		this.hospCode = hospCode;
		this.bunho = bunho;
		this.sysId = sysId;
		this.updId = updId;
		this.created = created;
		this.updated = updated;
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
	public String getMetadata() {
		return metadata;
	}
	public void setMetadata(String metadata) {
		this.metadata = metadata;
	}
	public Integer getVersion() {
		return version;
	}
	public void setVersion(Integer version) {
		this.version = version;
	}
	public String getRecordLog() {
		return recordLog;
	}
	public void setRecordLog(String recordLog) {
		this.recordLog = recordLog;
	}
	public BigDecimal getLockFlg() {
		return lockFlg;
	}
	public void setLockFlg(BigDecimal lockFlg) {
		this.lockFlg = lockFlg;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	public Timestamp getCreated() {
		return created;
	}
	public void setCreated(Timestamp created) {
		this.created = created;
	}
	public Timestamp getUpdated() {
		return updated;
	}
	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}
}

package nta.med.core.domain.emr;

import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.Table;


/**
 * The persistent class for the EMR_RECORD database table.
 * 
 */
@Entity
@Table(name="EMR_RECORD")
public class EmrRecord implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="EMR_RECORD_ID")
	private Integer emrRecordId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private String bunho;

	@Lob
	private String content;

	private Timestamp created;

	@Column(name="HOSP_CODE")
	private String hospCode;

	@Column(name="LOCK_FLG")
	private BigDecimal lockFlg;

	@Lob
	private String metadata;

	@Column(name="RECORD_LOG")
	private String recordLog;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	private Integer version;

	public EmrRecord() {
	}

	public Integer getEmrRecordId() {
		return this.emrRecordId;
	}

	public void setEmrRecordId(Integer emrRecordId) {
		this.emrRecordId = emrRecordId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public BigDecimal getLockFlg() {
		return this.lockFlg;
	}

	public void setLockFlag(BigDecimal lockFlg) {
		this.lockFlg = lockFlg;
	}

	public String getMetadata() {
		return this.metadata;
	}

	public void setMetadata(String metadata) {
		this.metadata = metadata;
	}

	public String getRecordLog() {
		return this.recordLog;
	}

	public void setRecordLog(String recordLog) {
		this.recordLog = recordLog;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	public Integer getVersion() {
		return this.version;
	}

	public void setVersion(Integer version) {
		this.version = version;
	}

}
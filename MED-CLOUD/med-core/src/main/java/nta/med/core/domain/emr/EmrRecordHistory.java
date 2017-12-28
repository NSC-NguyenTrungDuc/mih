package nta.med.core.domain.emr;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the EMR_RECORD_HISTORY database table.
 * 
 */
@Entity
@Table(name="EMR_RECORD_HISTORY")
public class EmrRecordHistory implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="EMR_RECORD_HISTORY_ID")
	private int emrRecordHistoryId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	@Lob
	private String content;

	private Timestamp created;

	@Column(name="EMR_RECORD_ID")
	private int emrRecordId;

	@Lob
	private String metadata;

	@Column(name="RECORD_LOG")
	private String recordLog;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	private int version;

	public EmrRecordHistory() {
	}

	public int getEmrRecordHistoryId() {
		return this.emrRecordHistoryId;
	}

	public void setEmrRecordHistoryId(int emrRecordHistoryId) {
		this.emrRecordHistoryId = emrRecordHistoryId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
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

	public int getEmrRecordId() {
		return this.emrRecordId;
	}

	public void setEmrRecordId(int emrRecordId) {
		this.emrRecordId = emrRecordId;
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

	public String getupdId() {
		return this.updId;
	}

	public void setupdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	public int getVersion() {
		return this.version;
	}

	public void setVersion(int version) {
		this.version = version;
	}

}
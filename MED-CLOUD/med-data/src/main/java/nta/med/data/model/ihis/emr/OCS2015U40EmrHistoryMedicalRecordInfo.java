package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.util.Date;

public class OCS2015U40EmrHistoryMedicalRecordInfo {
	private Integer recordId;
	private String sysId;
	private Date created;
	private String memo;
	private BigDecimal activeFlg;
	private Integer version;
	private String author;

	public OCS2015U40EmrHistoryMedicalRecordInfo(Integer recordId,
			String sysId, Date created, String memo, BigDecimal activeFlg,
			Integer version, String author) {
		super();
		this.recordId = recordId;
		this.sysId = sysId;
		this.created = created;
		this.memo = memo;
		this.activeFlg = activeFlg;
		this.version = version;
		this.author = author;
	}

	public Integer getRecordId() {
		return recordId;
	}

	public void setRecordId(Integer recordId) {
		this.recordId = recordId;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Date getCreated() {
		return created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	public String getMemo() {
		return memo;
	}

	public void setMemo(String memo) {
		this.memo = memo;
	}

	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Integer getVersion() {
		return version;
	}

	public void setVersion(Integer version) {
		this.version = version;
	}

	public String getAuthor() {
		return author;
	}

	public void setAuthor(String author) {
		this.author = author;
	}

}
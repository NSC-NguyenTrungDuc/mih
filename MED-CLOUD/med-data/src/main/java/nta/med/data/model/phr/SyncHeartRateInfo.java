/**
 * 
 */
package nta.med.data.model.phr;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;

/**
 * @author DEV-HuanLT
 *
 */
public class SyncHeartRateInfo {

	private BigInteger syncId;
	private String datetimeRecord;
	private BigDecimal heartRate;
	private Date created;
	private Date updated;
	private String vald;

	public SyncHeartRateInfo(BigInteger syncId, String datetimeRecord, BigDecimal heartRate, Date created, Date updated,
			String vald) {
		super();
		this.syncId = syncId;
		this.datetimeRecord = datetimeRecord;
		this.heartRate = heartRate;
		this.created = created;
		this.updated = updated;
		this.vald = vald;
	}

	public String getVald() {
		return vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

	public BigInteger getSyncId() {
		return syncId;
	}

	public void setSyncId(BigInteger syncId) {
		this.syncId = syncId;
	}

	public String getDatetimeRecord() {
		return datetimeRecord;
	}

	public void setDatetimeRecord(String datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}

	public BigDecimal getHeartRate() {
		return heartRate;
	}

	public void setHeartRate(BigDecimal heartRate) {
		this.heartRate = heartRate;
	}

	public Date getCreated() {
		return created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	public Date getUpdated() {
		return updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}
}

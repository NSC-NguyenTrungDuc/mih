/**
 * 
 */
package nta.med.data.model.phr;

import java.math.BigInteger;
import java.util.Date;

/**
 * @author DEV-HuanLT
 *
 */
public class SyncTemperatureInfo {
	
	private BigInteger syncId;
	private String datetimeRecord;
	private Double temperature;
	private Date created;
	private Date updated;
	private String vald;
	
	public SyncTemperatureInfo(BigInteger syncId, String datetimeRecord, Double temperature, Date created, Date updated, String vald) {
		super();
		this.syncId = syncId;
		this.datetimeRecord = datetimeRecord;
		this.temperature = temperature;
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

	public Double getTemperature() {
		return temperature;
	}

	public void setTemperature(Double temperature) {
		this.temperature = temperature;
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

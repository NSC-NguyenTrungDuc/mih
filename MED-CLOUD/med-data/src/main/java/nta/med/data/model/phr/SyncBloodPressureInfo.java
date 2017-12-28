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
public class SyncBloodPressureInfo {

	private BigInteger syncId;
	private String datetimeRecord;
	private Double lowBloodPressure;
	private Double highBloodPressure;
	private Date created;
	private Date updated;
	private String vald;

	public SyncBloodPressureInfo(BigInteger syncId, String datetimeRecord, Double lowBloodPressure,
			Double highBloodPressure, Date created, Date updated, String vald) {
		super();
		this.syncId = syncId;
		this.datetimeRecord = datetimeRecord;
		this.lowBloodPressure = lowBloodPressure;
		this.highBloodPressure = highBloodPressure;
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

	public Double getLowBloodPressure() {
		return lowBloodPressure;
	}

	public void setLowBloodPressure(Double lowBloodPressure) {
		this.lowBloodPressure = lowBloodPressure;
	}

	public Double getHighBloodPressure() {
		return highBloodPressure;
	}

	public void setHighBloodPressure(Double highBloodPressure) {
		this.highBloodPressure = highBloodPressure;
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

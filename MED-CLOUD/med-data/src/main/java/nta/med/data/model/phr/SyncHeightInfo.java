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
public class SyncHeightInfo {
	
	private BigInteger syncId;
	private String datetimeRecord;
	private Double height;
	private Date created;
	private Date updated;
	private String vald;
	
	public SyncHeightInfo(BigInteger syncId, String datetimeRecord, Double height, Date created, Date updated,
			String vald) {
		super();
		this.syncId = syncId;
		this.datetimeRecord = datetimeRecord;
		this.height = height;
		this.created = created;
		this.updated = updated;
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
	public Double getHeight() {
		return height;
	}
	public void setHeight(Double height) {
		this.height = height;
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
	public String getVald() {
		return vald;
	}
	public void setVald(String vald) {
		this.vald = vald;
	}

}

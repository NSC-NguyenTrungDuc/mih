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
public class SyncDiseaseInfo {
	
	private Date datetimeRecord;
	private Date diseaseStartDate;
	private Date diseaseEndDate;					
	private String diseaseOutcome;						
	private BigInteger syncId;			
	private String disease;
	private String hospName;				
	private Date created;		
	private Date updated;
	
	public SyncDiseaseInfo(Date datetimeRecord, Date diseaseStartDate, Date diseaseEndDate, String diseaseOutcome,
			BigInteger syncId, String disease, String hospName, Date created, Date updated) {
		super();
		this.datetimeRecord = datetimeRecord;
		this.diseaseStartDate = diseaseStartDate;
		this.diseaseEndDate = diseaseEndDate;
		this.diseaseOutcome = diseaseOutcome;
		this.syncId = syncId;
		this.disease = disease;
		this.hospName = hospName;
		this.created = created;
		this.updated = updated;
	}
	public Date getDatetimeRecord() {
		return datetimeRecord;
	}
	public void setDatetimeRecord(Date datetimeRecord) {
		this.datetimeRecord = datetimeRecord;
	}
	public Date getDiseaseStartDate() {
		return diseaseStartDate;
	}
	public void setDiseaseStartDate(Date diseaseStartDate) {
		this.diseaseStartDate = diseaseStartDate;
	}
	public Date getDiseaseEndDate() {
		return diseaseEndDate;
	}
	public void setDiseaseEndDate(Date diseaseEndDate) {
		this.diseaseEndDate = diseaseEndDate;
	}
	public String getDiseaseOutcome() {
		return diseaseOutcome;
	}
	public void setDiseaseOutcome(String diseaseOutcome) {
		this.diseaseOutcome = diseaseOutcome;
	}
	public BigInteger getSyncId() {
		return syncId;
	}
	public void setSyncId(BigInteger syncId) {
		this.syncId = syncId;
	}
	public String getDisease() {
		return disease;
	}
	public void setDisease(String disease) {
		this.disease = disease;
	}
	public String getHospName() {
		return hospName;
	}
	public void setHospName(String hospName) {
		this.hospName = hospName;
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

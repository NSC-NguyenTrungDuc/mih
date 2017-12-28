package nta.med.data.model.ihis.emr;

import java.util.Date;

public class PatientEmailInfo {
	private Date created;
	private String recordLog;
	public PatientEmailInfo(Date created, String recordLog) {
		super();
		this.created = created;
		this.recordLog = recordLog;
	}
	public Date getCreated() {
		return created;
	}
	public void setCreated(Date created) {
		this.created = created;
	}
	public String getRecordLog() {
		return recordLog;
	}
	public void setRecordLog(String recordLog) {
		this.recordLog = recordLog;
	}
	
}

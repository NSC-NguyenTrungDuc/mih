package nta.mss.entity;

public class MovieTalkHistory {

   private Integer mtHistoryId;	
   private String rowNum; 
   private String department;
   private String examinationDateTime;
   private String mtHistoryUrl;
   private String duration;

	public String getDepartment() {
		return department;
	}

	public void setDepartment(String department) {
		this.department = department;
	}

	public String getExaminationDateTime() {
		return examinationDateTime;
	}

	public void setExaminationDateTime(String examinationDateTime) {
		this.examinationDateTime = examinationDateTime;
	}

	public String getDuration() {
		return duration;
	}

	public void setDuration(String duration) {
		this.duration = duration;
	}

	public String getMtHistoryUrl() {
		return mtHistoryUrl;
	}

	public void setMtHistoryUrl(String mtHistoryUrl) {
		this.mtHistoryUrl = mtHistoryUrl;
	}
	
	

	public String getRowNum() {
		return rowNum;
	}

	public void setRowNum(String rowNum) {
		this.rowNum = rowNum;
	}	

	public Integer getMtHistoryId() {
		return mtHistoryId;
	}

	public void setMtHistoryId(Integer mtHistoryId) {
		this.mtHistoryId = mtHistoryId;
	}

	public MovieTalkHistory(String rowNum , Integer mtHistoryId,String department, String examinationDateTime, String duration,String mtHistoryUrl
			) {
		super();
		this.rowNum = rowNum;
		this.mtHistoryId = mtHistoryId;
		this.department = department;
		this.examinationDateTime = examinationDateTime;
		this.duration = duration;
		this.mtHistoryUrl = mtHistoryUrl;	
	}
   
}

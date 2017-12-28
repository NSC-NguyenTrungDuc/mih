package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class DashboardModel {
	@JsonProperty("department")
	private List<SurveyPatientStatusModel> departmentList;
	@JsonProperty("total_answered")
	private BigDecimal totalHospAnswered;
	@JsonProperty("total_waiting")
	private BigDecimal totalHospWaiting;
	@JsonProperty("type")
	private int type;
	@JsonProperty("records_total")
	private int recordsTotal;
	
	@JsonProperty("records_filtered")
	private int recordsFiltered;
	
	
	
	public int getRecordsTotal() {
		return recordsTotal;
	}
	public void setRecordsTotal(int recordsTotal) {
		this.recordsTotal = recordsTotal;
	}
	public int getRecordsFiltered() {
		return recordsFiltered;
	}
	public void setRecordsFiltered(int recordsFiltered) {
		this.recordsFiltered = recordsFiltered;
	}
	public List<SurveyPatientStatusModel> getDepartmentList() {
		return departmentList;
	}
	public void setDepartmentList(List<SurveyPatientStatusModel> departmentList) {
		this.departmentList = departmentList;
	}
	public BigDecimal getTotalHospAnswered() {
		return totalHospAnswered;
	}
	public void setTotalHospAnswered(BigDecimal totalHospAnswered) {
		this.totalHospAnswered = totalHospAnswered;
	}
	public BigDecimal getTotalHospWaiting() {
		return totalHospWaiting;
	}
	public void setTotalHospWaiting(BigDecimal totalHospWaiting) {
		this.totalHospWaiting = totalHospWaiting;
	}
	public int getType() {
		return type;
	}
	public void setType(int type) {
		this.type = type;
	}
	
}

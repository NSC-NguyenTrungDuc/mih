package nta.med.ext.mss.model;

import java.util.List;

import javax.validation.constraints.Digits;
import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonProperty;

public class SearchDoctorModel {
	
	@JsonProperty("hosp_code")
	@NotNull
    private String hospCode;
	
	@JsonProperty("department_code")
	@NotNull
    private String departmentCode;
	
	@JsonProperty("start_date")
	@NotNull
    private String startDate; //yyyymmdd
	
	@JsonProperty("end_date")
	@NotNull
    private String endDate; //yyyymmdd
    
    @JsonProperty("locale")
    private String locale;
    
    @JsonProperty("reservation_date")
    private String reservationDate; //yyyymmdd
    
    @JsonProperty("reservation_time")
    private String reservationTime; //hhmm
    
	@JsonProperty("page_size") //number required
	@NotNull
	@Digits(integer=6, fraction=2)
	private String pageSize;
	
	@JsonProperty("page_index") //number required
	@NotNull
	@Digits(integer=6, fraction=2)
	private String pageIndex;
	
	@JsonProperty("doctors")
	List<DoctorModel> doctorModels;
	
	@JsonProperty("total_records") //20
	private String totalRecords;

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getStartDate() {
		return startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public String getEndDate() {
		return endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getReservationDate() {
		return reservationDate;
	}

	public void setReservationDate(String reservationDate) {
		this.reservationDate = reservationDate;
	}

	public String getReservationTime() {
		return reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	public String getPageSize() {
		return pageSize;
	}

	public void setPageSize(String pageSize) {
		this.pageSize = pageSize;
	}

	public String getPageIndex() {
		return pageIndex;
	}

	public void setPageIndex(String pageIndex) {
		this.pageIndex = pageIndex;
	}

	public List<DoctorModel> getDoctorModels() {
		return doctorModels;
	}

	public void setDoctorModels(List<DoctorModel> doctorModels) {
		this.doctorModels = doctorModels;
	}

	public String getTotalRecords() {
		return totalRecords;
	}

	public void setTotalRecords(String totalRecords) {
		this.totalRecords = totalRecords;
	}
}

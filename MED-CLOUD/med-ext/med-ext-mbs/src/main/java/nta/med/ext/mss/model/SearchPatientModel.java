package nta.med.ext.mss.model;

import java.util.List;

import javax.validation.constraints.Digits;
import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public class SearchPatientModel {
	
	@JsonProperty("hosp_code") //string
	private String hospCode;
	
	@JsonProperty("disease_name") //string
	private String diseaseName;

	@JsonProperty("status_of_disease") //string
	private String statusOfDisease;
		
	@JsonProperty("from_lastest_go_hospital") //string
	private String fromLastestGoHospital;
	
	@JsonProperty("to_lastest_go_hospital") //string
	private String toLastestGoHospital;
	
	@JsonProperty("from_patient_age") //number
	@Digits(integer=6, fraction=2)
	private Integer fromPatientAge;
	
	@JsonProperty("to_patient_age") //number
	@Digits(integer=6, fraction=2)
	private Integer toPatientAge;
	
	@JsonProperty("patient_sex") //string (F or M)
	private String patientSex;
	
	@JsonProperty("patient_contact")
	private String patientContact;

	@JsonProperty("order_field") //column order by
	private String orderField;
	
	@JsonProperty("order_value") //string (ASC or DESC) optional (required if order field != null)
	private String orderValue;
	
	@JsonProperty("page_size") //number required
	@NotNull
	@Digits(integer=6, fraction=2)
	private Integer pageSize;
	
	@JsonProperty("page_index") //number required
	@NotNull
	@Digits(integer=6, fraction=2)
	private Integer pageIndex;
	
	@JsonProperty("total_records") //20
	private Long totalRecords;
	
	@JsonProperty("patients")
	private List<PatientModel> patientModels;

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getDiseaseName() {
		return diseaseName;
	}

	public void setDiseaseName(String diseaseName) {
		this.diseaseName = diseaseName;
	}

	public String getPatientSex() {
		return patientSex;
	}

	public void setPatientSex(String patientSex) {
		this.patientSex = patientSex;
	}

	public Integer getPageSize() {
		return pageSize;
	}

	public void setPageSize(Integer pageSize) {
		this.pageSize = pageSize;
	}

	public Integer getPageIndex() {
		return pageIndex;
	}

	public void setPageIndex(Integer pageIndex) {
		this.pageIndex = pageIndex;
	}

	public List<PatientModel> getPatientModels() {
		return patientModels;
	}

	public void setPatientModels(List<PatientModel> patientModels) {
		this.patientModels = patientModels;
	}

	public Long getTotalRecords() {
		return totalRecords;
	}

	public void setTotalRecords(Long totalRecords) {
		this.totalRecords = totalRecords;
	}

	public String getStatusOfDisease() {
		return statusOfDisease;
	}

	public void setStatusOfDisease(String statusOfDisease) {
		this.statusOfDisease = statusOfDisease;
	}
	
	public String getOrderField() {
		return orderField;
	}

	public void setOrderField(String orderField) {
		this.orderField = orderField;
	}

	public String getOrderValue() {
		return orderValue;
	}

	public void setOrderValue(String orderValue) {
		this.orderValue = orderValue;
	}

	public String getFromLastestGoHospital() {
		return fromLastestGoHospital;
	}

	public void setFromLastestGoHospital(String fromLastestGoHospital) {
		this.fromLastestGoHospital = fromLastestGoHospital;
	}

	public String getToLastestGoHospital() {
		return toLastestGoHospital;
	}

	public void setToLastestGoHospital(String toLastestGoHospital) {
		this.toLastestGoHospital = toLastestGoHospital;
	}

	public Integer getFromPatientAge() {
		return fromPatientAge;
	}

	public void setFromPatientAge(Integer fromPatientAge) {
		this.fromPatientAge = fromPatientAge;
	}

	public Integer getToPatientAge() {
		return toPatientAge;
	}

	public void setToPatientAge(Integer toPatientAge) {
		this.toPatientAge = toPatientAge;
	}

	public String getPatientContact() {
		return patientContact;
	}

	public void setPatientContact(String patientContact) {
		this.patientContact = patientContact;
	}

	@Override
	public String toString() {
		return "SearchPatientModel [hospCode=" + hospCode + ", diseaseName=" + diseaseName + ", statusOfDisease="
				+ statusOfDisease + ", fromLastestGoHospital=" + fromLastestGoHospital + ", toLastestGoHospital="
				+ toLastestGoHospital + ", fromPatientAge=" + fromPatientAge + ", toPatientAge=" + toPatientAge
				+ ", patientSex=" + patientSex + ", orderField=" + orderField + ", orderValue=" + orderValue
				+ ", pageSize=" + pageSize + ", pageIndex=" + pageIndex + ", patientModels=" + patientModels
				+ ", totalRecords=" + totalRecords + ", patientContact=" + patientContact + "]";
	}
}

package nta.mss.model;

import java.util.List;

public class CrmModel {

	private String hospCode;
	private String patientName;
	private String diseaseName;
	private String statusOfDisease;
	private String fromLastestGoHospital;
	private String toLastestGoHospital;
	private Integer fromPatientAge;
	private Integer toPatientAge;
	private String patientSex;
	private String patientContact;
	private String patientEmail;
	private String orderField;
	private String orderValue;
	private Integer pageSize;
	private Integer pageIndex;
	private Long totalRecords;
	private String lastestGoHospital;
	private Integer PatientAge;
	
	private List<CrmPatientModel> listCrmPatientModel;
	
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
	public String getStatusOfDisease() {
		return statusOfDisease;
	}
	public void setStatusOfDisease(String statusOfDisease) {
		this.statusOfDisease = statusOfDisease;
	}
	
	public String getPatientSex() {
		return patientSex;
	}
	public void setPatientSex(String patientSex) {
		this.patientSex = patientSex;
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
	public Long getTotalRecords() {
		return totalRecords;
	}
	public void setTotalRecords(Long totalRecords) {
		this.totalRecords = totalRecords;
	}
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getPatientEmail() {
		return patientEmail;
	}
	public void setPatientEmail(String patientEmail) {
		this.patientEmail = patientEmail;
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
	public String getLastestGoHospital() {
		return lastestGoHospital;
	}
	public void setLastestGoHospital(String lastestGoHospital) {
		this.lastestGoHospital = lastestGoHospital;
	}
	public Integer getPatientAge() {
		return PatientAge;
	}
	public void setPatientAge(Integer patientAge) {
		PatientAge = patientAge;
	}
	@Override
	public String toString() {
		return "CrmModel [hospCode=" + hospCode + ", patientName=" + patientName + ", diseaseName=" + diseaseName
				+ ", statusOfDisease=" + statusOfDisease + ", fromLastestGoHospital=" + fromLastestGoHospital
				+ ", toLastestGoHospital=" + toLastestGoHospital + ", fromPatientAge=" + fromPatientAge
				+ ", toPatientAge=" + toPatientAge + ", patientSex=" + patientSex + ", patientEmail=" + patientEmail
				+ ", orderField=" + orderField + ", orderValue=" + orderValue + ", pageSize=" + pageSize
				+ ", pageIndex=" + pageIndex + ", totalRecords=" + totalRecords + "]";
	}
	public List<CrmPatientModel> getListCrmPatientModel() {
		return listCrmPatientModel;
	}
	public void setListCrmPatientModel(List<CrmPatientModel> listCrmPatientModel) {
		this.listCrmPatientModel = listCrmPatientModel;
	}
}

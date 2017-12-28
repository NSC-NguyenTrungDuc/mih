package nta.kcck.model;

import java.util.List;

public class KcckCrmModel {

	private String hosp_code;
	private String disease_name;
	private String status_of_disease;
	private String from_lastest_go_hospital;
	private String to_lastest_go_hospital;
	private Integer from_patient_age;
	private Integer to_patient_age;
	private String patient_sex;
	private String patient_contact;
	private String order_field;
	private String order_value;
	private Integer page_size;
	private Integer page_index;
	private Long total_records;
	private List<KcckCrmPatientModel> patients;
	
	public String getHosp_code() {
		return hosp_code;
	}
	public void setHosp_code(String hosp_code) {
		this.hosp_code = hosp_code;
	}
	public String getDisease_name() {
		return disease_name;
	}
	public void setDisease_name(String disease_name) {
		this.disease_name = disease_name;
	}
	public String getStatus_of_disease() {
		return status_of_disease;
	}
	public void setStatus_of_disease(String status_of_disease) {
		this.status_of_disease = status_of_disease;
	}
	
	public String getFrom_lastest_go_hospital() {
		return from_lastest_go_hospital;
	}
	public void setFrom_lastest_go_hospital(String from_lastest_go_hospital) {
		this.from_lastest_go_hospital = from_lastest_go_hospital;
	}
	public String getTo_lastest_go_hospital() {
		return to_lastest_go_hospital;
	}
	public void setTo_lastest_go_hospital(String to_lastest_go_hospital) {
		this.to_lastest_go_hospital = to_lastest_go_hospital;
	}
	public Integer getFrom_patient_age() {
		return from_patient_age;
	}
	public void setFrom_patient_age(Integer from_patient_age) {
		this.from_patient_age = from_patient_age;
	}
	public Integer getTo_patient_age() {
		return to_patient_age;
	}
	public void setTo_patient_age(Integer to_patient_age) {
		this.to_patient_age = to_patient_age;
	}
	public String getPatient_sex() {
		return patient_sex;
	}
	public void setPatient_sex(String patient_sex) {
		this.patient_sex = patient_sex;
	}
	public String getPatient_contact() {
		return patient_contact;
	}
	public void setPatient_contact(String patient_contact) {
		this.patient_contact = patient_contact;
	}
	public String getOrder_field() {
		return order_field;
	}
	public void setOrder_field(String order_field) {
		this.order_field = order_field;
	}
	public String getOrder_value() {
		return order_value;
	}
	public void setOrder_value(String order_value) {
		this.order_value = order_value;
	}
	
	public Integer getPage_size() {
		return page_size;
	}
	public void setPage_size(Integer page_size) {
		this.page_size = page_size;
	}
	public Integer getPage_index() {
		return page_index;
	}
	public void setPage_index(Integer page_index) {
		this.page_index = page_index;
	}
	public Long getTotal_records() {
		return total_records;
	}
	public void setTotal_records(Long total_records) {
		this.total_records = total_records;
	}
	public List<KcckCrmPatientModel> getPatients() {
		return patients;
	}
	public void setPatients(List<KcckCrmPatientModel> patients) {
		this.patients = patients;
	}
	
	@Override
	public String toString() {
		return "KcckCrmModel [hosp_code=" + hosp_code + ", disease_name=" + disease_name + ", status_of_disease="
				+ status_of_disease + ", from_lastest_go_hospital=" + from_lastest_go_hospital
				+ ", to_lastest_go_hospital=" + to_lastest_go_hospital + ", from_patient_age=" + from_patient_age
				+ ", to_patient_age=" + to_patient_age + ", patient_sex=" + patient_sex + ", order_field=" + order_field
				+ ", order_value=" + order_value + ", page_size=" + page_size + ", page_index=" + page_index
				+ ", total_records=" + total_records + ", patients=" + patients + "]";
	}
}

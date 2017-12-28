package nta.med.data.model.mss;

/**
 * The Class PatientInfo.
 */
public class PatientInfo {
	
	private Integer patientId;  
	private String cardNumber;
	private Integer hospitalId;
	private String hospitalCode;
	
	public PatientInfo(Integer patientId, String cardNumber, Integer hospitalId, String hospitalCode) {
		super();
		this.patientId = patientId;
		this.cardNumber = cardNumber;
		this.hospitalId = hospitalId;
		this.hospitalCode = hospitalCode;
	}
	
	public Integer getPatientId() {
		return patientId;
	}
	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}
	public String getCardNumber() {
		return cardNumber;
	}
	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
	}
	public Integer getHospitalId() {
		return hospitalId;
	}
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
	public String getHospitalCode() {
		return hospitalCode;
	}
	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}
	
}


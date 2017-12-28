package nta.med.data.model.ihis.nuro;

public class NuroOUT0101U02LayDupPatientInfo {
	 private String patientCode;
	 private String patientName;
	 private String birth;
	 private String codeName;
	 
	public NuroOUT0101U02LayDupPatientInfo(String patientCode,
			String patientName, String birth, String codeName) {
		super();
		this.patientCode = patientCode;
		this.patientName = patientName;
		this.birth = birth;
		this.codeName = codeName;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getBirth() {
		return birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	  
}

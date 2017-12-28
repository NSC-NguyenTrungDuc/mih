package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class PatientInformation {
	private String patientId;
	private String wholeName;
	private String wholeNameInkana;
	private String birthDate;
	private String sex;

	private String createDate;
	private String updateDate;
	private String testPatientFlag;

	@JacksonXmlProperty(localName = "Patient_ID")
	public String getPatientId() {
		return patientId;
	}

	public void setPatientId(String patientId) {
		this.patientId = patientId;
	}

	@JacksonXmlProperty(localName = "WholeName")
	public String getWholeName() {
		return wholeName;
	}

	public void setWholeName(String wholeName) {
		this.wholeName = wholeName;
	}

	@JacksonXmlProperty(localName = "WholeName_inKana")
	public String getWholeNameInkana() {
		return wholeNameInkana;
	}

	public void setWholeNameInkana(String wholeNameInkana) {
		this.wholeNameInkana = wholeNameInkana;
	}

	@JacksonXmlProperty(localName = "BirthDate")
	public String getBirthDate() {
		return birthDate;
	}

	public void setBirthDate(String birthDate) {
		this.birthDate = birthDate;
	}

	@JacksonXmlProperty(localName = "Sex")
	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	@JacksonXmlProperty(localName = "CreateDate")
	public String getCreateDate() {
		return createDate;
	}

	public void setCreateDate(String createDate) {
		this.createDate = createDate;
	}

	@JacksonXmlProperty(localName = "UpdateDate")
	public String getUpdateDate() {
		return updateDate;
	}

	public void setUpdateDate(String updateDate) {
		this.updateDate = updateDate;
	}

	@JacksonXmlProperty(localName = "TestPatient_Flag")
	public String getTestPatientFlag() {
		return testPatientFlag;
	}

	public void setTestPatientFlag(String testPatientFlag) {
		this.testPatientFlag = testPatientFlag;
	}

}

package nta.med.orca.gw.api.contracts.message;

import java.util.List;
import java.util.Objects;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class PatientInfo {

	private String patientId;
	private String wholeName;
	private String wholeNameInKana;
	private String birthDate;
	private String sex;
	private String patientType;

	private String houseHolderWholeName;
	private HomeAddressInformation homeAddressInformation;
	private String communityCidAgree;
	private List<HealthInsuranceInfo> healthInsuranceInformation;
	private WorkPlaceInformation workPlaceInformation;
	
	@JacksonXmlProperty(localName = "Patient_ID")
	public String getPatientId() {
		return patientId;
	}

	public void setPatientID(String patientID) {
		this.patientId = patientID;
	}

	@JacksonXmlProperty(localName = "WholeName")
	public String getWholeName() {
		return wholeName;
	}

	public void setWholeName(String wholeName) {
		this.wholeName = wholeName;
	}

	@JacksonXmlProperty(localName = "WholeName_inKana")
	public String getWholeNameInKana() {
		return wholeNameInKana;
	}

	public void setWholeNameInKana(String wholeNameInKana) {
		this.wholeNameInKana = wholeNameInKana;
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

	@JacksonXmlProperty(localName = "HouseHolder_WholeName")
	public String getHouseHolderWholeName() {
		return houseHolderWholeName;
	}

	public void setHouseHolderWholeName(String houseHolderWholeName) {
		this.houseHolderWholeName = houseHolderWholeName;
	}

	@JacksonXmlProperty(localName = "Home_Address_Information")
	public HomeAddressInformation getHomeAddressInformation() {
		return homeAddressInformation;
	}

	public void setHomeAddressInformation(HomeAddressInformation homeAddressInformation) {
		this.homeAddressInformation = homeAddressInformation;
	}

	@JacksonXmlProperty(localName = "Community_Cid_Agree")
	public String getCommunityCidAgree() {
		return communityCidAgree;
	}

	public void setCommunityCidAgree(String communityCidAgree) {
		this.communityCidAgree = communityCidAgree;
	}

	@JacksonXmlProperty(localName = "HealthInsurance_Information")
	public List<HealthInsuranceInfo> getHealthInsuranceInformation() {
		return healthInsuranceInformation;
	}

	public void setHealthInsuranceInformation(List<HealthInsuranceInfo> healthInsuranceInformation) {
		this.healthInsuranceInformation = healthInsuranceInformation;
	}

	public String getPatientType() {
		return patientType;
	}

	public void setPatientType(String patientType) {
		this.patientType = patientType;
	}
	
	
	@JacksonXmlProperty(localName = "WorkPlace_Information")
	public WorkPlaceInformation getWorkPlaceInformation() {
		return workPlaceInformation;
	}

	public void setWorkPlaceInformation(WorkPlaceInformation workPlaceInformation) {
		this.workPlaceInformation = workPlaceInformation;
	}

	@Override
	public int hashCode() {
		return Objects.hash(patientId, wholeName, wholeNameInKana, birthDate, sex, patientType, houseHolderWholeName,
				homeAddressInformation, communityCidAgree, healthInsuranceInformation, workPlaceInformation);
	}
	
}

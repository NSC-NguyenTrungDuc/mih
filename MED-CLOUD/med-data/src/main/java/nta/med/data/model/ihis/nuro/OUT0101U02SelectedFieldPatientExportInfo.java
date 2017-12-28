package nta.med.data.model.ihis.nuro;

import java.util.Arrays;

import nta.med.data.model.ihis.system.ExportCsvInterface;

public class OUT0101U02SelectedFieldPatientExportInfo implements ExportCsvInterface{
	private String createdDate   			   ;
	private String createdAdmin  			   ;
	private String updateDate    			   ;
	private String updateAdmin   			   ;
	private String hospitalCode  			   ;
	private String patientCode   			   ;
	private String suname         			   ;
	private String suname2        			   ;
	private String sex            			   ;
	private String birthday       			   ;
	private String postalCode    			   ;
	private String address1       			   ;
	private String address2       			   ;
	private String phoneNumber   			   ;
	private String phoneNumber2  			   ;
	private String phoneNumber3  			   ;
	private String phoneType1    			   ;
	private String phoneType2    			   ;
	private String phoneType3    			   ;
	private String insuranceType 			   ;
	private String interuptedReception        ;
	private String interuptedReceptionReason ;
	private String detete                      ;
	private String patientNote                ;
	private String emailAddress               ;
	private String paceMakerYn               ;
	private String selfPaceMaker             ;
	private String password                    ;
	private String patientType                ;
	
	public OUT0101U02SelectedFieldPatientExportInfo() {
	}

	public OUT0101U02SelectedFieldPatientExportInfo(String createdDate, String createdAdmin, String updateDate, String updateAdmin,
			String hospitalCode, String patientCode, String suname, String suname2, String sex, String birthday,
			String postalCode, String address1, String address2, String phoneNumber, String phoneNumber2,
			String phoneNumber3, String phoneType1, String phoneType2, String phoneType3, String insuranceType,
			String interuptedReception, String interuptedReceptionReason, String detete, String patientNote,
			String emailAddress, String paceMakerYn, String selfPaceMaker, String password, String patientType) {
		super();
		this.createdDate = createdDate;
		this.createdAdmin = createdAdmin;
		this.updateDate = updateDate;
		this.updateAdmin = updateAdmin;
		this.hospitalCode = hospitalCode;
		this.patientCode = patientCode;
		this.suname = suname;
		this.suname2 = suname2;
		this.sex = sex;
		this.birthday = birthday;
		this.postalCode = postalCode;
		this.address1 = address1;
		this.address2 = address2;
		this.phoneNumber = phoneNumber;
		this.phoneNumber2 = phoneNumber2;
		this.phoneNumber3 = phoneNumber3;
		this.phoneType1 = phoneType1;
		this.phoneType2 = phoneType2;
		this.phoneType3 = phoneType3;
		this.insuranceType = insuranceType;
		this.interuptedReception = interuptedReception;
		this.interuptedReceptionReason = interuptedReceptionReason;
		this.detete = detete;
		this.patientNote = patientNote;
		this.emailAddress = emailAddress;
		this.paceMakerYn = paceMakerYn;
		this.selfPaceMaker = selfPaceMaker;
		this.password = password;
		this.patientType = patientType;
	}

	public String getCreatedDate() {
		return createdDate;
	}

	public void setCreatedDate(String createdDate) {
		this.createdDate = createdDate;
	}

	public String getCreatedAdmin() {
		return createdAdmin;
	}

	public void setCreatedAdmin(String createdAdmin) {
		this.createdAdmin = createdAdmin;
	}

	public String getUpdateDate() {
		return updateDate;
	}

	public void setUpdateDate(String updateDate) {
		this.updateDate = updateDate;
	}

	public String getUpdateAdmin() {
		return updateAdmin;
	}

	public void setUpdateAdmin(String updateAdmin) {
		this.updateAdmin = updateAdmin;
	}

	public String getHospitalCode() {
		return hospitalCode;
	}

	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getSuname2() {
		return suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}

	public String getPostalCode() {
		return postalCode;
	}

	public void setPostalCode(String postalCode) {
		this.postalCode = postalCode;
	}

	public String getAddress1() {
		return address1;
	}

	public void setAddress1(String address1) {
		this.address1 = address1;
	}

	public String getAddress2() {
		return address2;
	}

	public void setAddress2(String address2) {
		this.address2 = address2;
	}

	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getPhoneNumber2() {
		return phoneNumber2;
	}

	public void setPhoneNumber2(String phoneNumber2) {
		this.phoneNumber2 = phoneNumber2;
	}

	public String getPhoneNumber3() {
		return phoneNumber3;
	}

	public void setPhoneNumber3(String phoneNumber3) {
		this.phoneNumber3 = phoneNumber3;
	}

	public String getPhoneType1() {
		return phoneType1;
	}

	public void setPhoneType1(String phoneType1) {
		this.phoneType1 = phoneType1;
	}

	public String getPhoneType2() {
		return phoneType2;
	}

	public void setPhoneType2(String phoneType2) {
		this.phoneType2 = phoneType2;
	}

	public String getPhoneType3() {
		return phoneType3;
	}

	public void setPhoneType3(String phoneType3) {
		this.phoneType3 = phoneType3;
	}

	public String getInsuranceType() {
		return insuranceType;
	}

	public void setInsuranceType(String insuranceType) {
		this.insuranceType = insuranceType;
	}

	public String getInteruptedReception() {
		return interuptedReception;
	}

	public void setInteruptedReception(String interuptedReception) {
		this.interuptedReception = interuptedReception;
	}

	public String getInteruptedReceptionReason() {
		return interuptedReceptionReason;
	}

	public void setInteruptedReceptionReason(String interuptedReceptionReason) {
		this.interuptedReceptionReason = interuptedReceptionReason;
	}

	public String getDetete() {
		return detete;
	}

	public void setDetete(String detete) {
		this.detete = detete;
	}

	public String getPatientNote() {
		return patientNote;
	}

	public void setPatientNote(String patientNote) {
		this.patientNote = patientNote;
	}

	public String getEmailAddress() {
		return emailAddress;
	}

	public void setEmailAddress(String emailAddress) {
		this.emailAddress = emailAddress;
	}

	public String getPaceMakerYn() {
		return paceMakerYn;
	}

	public void setPaceMakerYn(String paceMakerYn) {
		this.paceMakerYn = paceMakerYn;
	}

	public String getSelfPaceMaker() {
		return selfPaceMaker;
	}

	public void setSelfPaceMaker(String selfPaceMaker) {
		this.selfPaceMaker = selfPaceMaker;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getPatientType() {
		return patientType;
	}

	public void setPatientType(String patientType) {
		this.patientType = patientType;
	}

	@Override
	public String[] convertItemToArray() {
		
		String[] firstArray = new String[]{createdDate, createdAdmin, updateDate, updateAdmin, hospitalCode,
				patientCode, suname, suname2, sex, birthday, postalCode, address1, address2,
				phoneNumber, phoneNumber2, phoneNumber3, phoneType1, phoneType2, phoneType3,
				insuranceType, interuptedReception, interuptedReceptionReason, detete,
				patientNote, emailAddress, paceMakerYn, selfPaceMaker, password, patientType};
		
		firstArray = Arrays.stream(firstArray)
                .filter(s -> (s != null))
                .toArray(String[]::new);
		return firstArray;
//		return (new String[]{createdDate, createdAdmin, updateDate, updateAdmin, hospitalCode,
//				patientCode, suname, suname2, sex, birthday, postalCode, address1, address2,
//				phoneNumber, phoneNumber2, phoneNumber3, phoneType1, phoneType2, phoneType3,
//				insuranceType, interuptedReception, interuptedReceptionReason, detete,
//				patientNote, emailAddress, paceMakerYn, selfPaceMaker, password, patientType});
	}

}

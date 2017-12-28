package nta.med.orca.gw.api.contracts.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.OrcaApiConfig;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.OrcaUtils;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.ext.support.proto.PatientModelProto.PatientProfile;
import nta.med.ext.support.proto.PatientModelProto.PrivateInsurance;
import nta.med.ext.support.proto.PatientModelProto.PublicInsurance;
import nta.med.orca.gw.api.contracts.message.HealthInsuranceInfo;
import nta.med.orca.gw.api.contracts.message.HomeAddressInformation;
import nta.med.orca.gw.api.contracts.message.PublicInsuranceInfo;
import nta.med.orca.gw.api.contracts.message.WorkPlaceInformation;

public class PatientModRequest extends AbstractRequest {

	private String modKey;
	private String patientID;
	private String wholeName;
	private String wholeNameInKana;
	private String birthDate;
	private String sex;
	private String houseHolderWholeName;
	private String relationship;
	private String occupation;
	private String cellularNumber;
	private String faxNumber;
	private String emailAddress;
	private HomeAddressInformation homeAddressInformation;
	private WorkPlaceInformation workPlaceInformation;
	private String contraindication1;
	private String contraindication2;
	private String allergy1;
	private String allergy2;
	private String infection1;
	private String infection2;
	private String comment1;
	private String comment2;
	private HealthInsuranceInfo healthInsuranceInformation;
	
	private String rqType;
	
	public String getModKey() {
		return modKey;
	}

	public void setModKey(String modKey) {
		this.modKey = modKey;
	}

	public String getPatientID() {
		return patientID;
	}

	public void setPatientID(String patientID) {
		this.patientID = patientID;
	}

	public String getWholeName() {
		return wholeName;
	}

	public void setWholeName(String wholeName) {
		this.wholeName = wholeName;
	}

	public String getWholeNameInKana() {
		return wholeNameInKana;
	}

	public void setWholeNameInKana(String wholeNameInKana) {
		this.wholeNameInKana = wholeNameInKana;
	}

	public String getBirthDate() {
		return birthDate;
	}

	public void setBirthDate(String birthDate) {
		this.birthDate = birthDate;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getHouseHolderWholeName() {
		return houseHolderWholeName;
	}

	public void setHouseHolderWholeName(String houseHolderWholeName) {
		this.houseHolderWholeName = houseHolderWholeName;
	}

	public String getRelationship() {
		return relationship;
	}

	public void setRelationship(String relationship) {
		this.relationship = relationship;
	}

	public String getOccupation() {
		return occupation;
	}

	public void setOccupation(String occupation) {
		this.occupation = occupation;
	}

	public String getCellularNumber() {
		return cellularNumber;
	}

	public void setCellularNumber(String cellularNumber) {
		this.cellularNumber = cellularNumber;
	}

	public String getFaxNumber() {
		return faxNumber;
	}

	public void setFaxNumber(String faxNumber) {
		this.faxNumber = faxNumber;
	}

	public String getEmailAddress() {
		return emailAddress;
	}

	public void setEmailAddress(String emailAddress) {
		this.emailAddress = emailAddress;
	}

	public HomeAddressInformation getHomeAddressInformation() {
		return homeAddressInformation;
	}

	public void setHomeAddressInformation(HomeAddressInformation homeAddressInformation) {
		this.homeAddressInformation = homeAddressInformation;
	}

	public WorkPlaceInformation getWorkPlaceInformation() {
		return workPlaceInformation;
	}

	public void setWorkPlaceInformation(WorkPlaceInformation workPlaceInformation) {
		this.workPlaceInformation = workPlaceInformation;
	}

	public String getContraindication1() {
		return contraindication1;
	}

	public void setContraindication1(String contraindication1) {
		this.contraindication1 = contraindication1;
	}

	public String getContraindication2() {
		return contraindication2;
	}

	public void setContraindication2(String contraindication2) {
		this.contraindication2 = contraindication2;
	}

	public String getAllergy1() {
		return allergy1;
	}

	public void setAllergy1(String allergy1) {
		this.allergy1 = allergy1;
	}

	public String getAllergy2() {
		return allergy2;
	}

	public void setAllergy2(String allergy2) {
		this.allergy2 = allergy2;
	}

	public String getInfection1() {
		return infection1;
	}

	public void setInfection1(String infection1) {
		this.infection1 = infection1;
	}

	public String getInfection2() {
		return infection2;
	}

	public void setInfection2(String infection2) {
		this.infection2 = infection2;
	}

	public String getComment1() {
		return comment1;
	}

	public void setComment1(String comment1) {
		this.comment1 = comment1;
	}

	public String getComment2() {
		return comment2;
	}

	public void setComment2(String comment2) {
		this.comment2 = comment2;
	}

	public HealthInsuranceInfo getHealthInsuranceInformation() {
		return healthInsuranceInformation;
	}

	public void setHealthInsuranceInformation(HealthInsuranceInfo healthInsuranceInformation) {
		this.healthInsuranceInformation = healthInsuranceInformation;
	}

	public String getRqType() {
		return rqType;
	}

	public void setRqType(String rqType) {
		this.rqType = rqType;
	}

	public void toRequest(String patientCode, 
			PatientProfile profile,
			List<PatientModelProto.PublicInsurance> publicInsList,
			List<PatientModelProto.PrivateInsurance> privateInsList,
			String modKey){
		
		String orcaPatientCode = patientCode.contains("*") ? "*" : String.valueOf(CommonUtils.parseInteger(patientCode));
		
		// setting request type
		boolean isUpdateProfile = true;
		if(!CollectionUtils.isEmpty(publicInsList)){
			for (PublicInsurance item : publicInsList) {
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())){
					isUpdateProfile = false;
					break;
				}
			}
		}
		
		if(!CollectionUtils.isEmpty(privateInsList)){
			for (PrivateInsurance item : privateInsList) {
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())){
					isUpdateProfile = false;
					break;
				}
			}
		}
		
		if(OrcaApiConfig.PATIENT_CODE_DEFAULT.getValue().equals(patientCode)){
			patientCode = OrcaApiConfig.PATIENT_CODE_CREATE_NEW.getValue();
			this.setRqType(OrcaApiConfig.PATIENT_MOD_NEW.getValue());
		} else if(isUpdateProfile){
			this.setRqType(OrcaApiConfig.PATIENT_MOD_UPDATE_INFO.getValue());
		}else {
			this.setRqType(OrcaApiConfig.PATIENT_MOD_UPDATE_INS.getValue());
		}
		
		// setting patient info
		this.setModKey(StringUtils.isEmpty(modKey) ? "2" : modKey);
		this.setPatientID(orcaPatientCode);
		this.setWholeName(profile.getSuname());
		this.setWholeNameInKana(profile.getSuname2());
		this.setBirthDate(profile.getBirth().replace("/", "-"));
		this.setSex(profile.getSex().equals("M") ? OrcaApiConfig.SEX_MALE.getValue() : OrcaApiConfig.SEX_FEMALE.getValue());
		this.setEmailAddress(profile.hasEmail()? profile.getEmail() : "");
		
		String phoneNumber1 = "";
		String phoneNumber2 = "";
		String phoneNumber = "";
		
		// check tel_type
		switch (profile.getTelType()) {
		case "1":
			phoneNumber1 = profile.hasTel()? profile.getTel() : "";
			break;
		case "2":
			//phoneNumber = profile.hasTel()? profile.getTel() : "";
			break;
		case "3":
			//cellularNumber = profile.hasTel()? profile.getTel() : "";
			break;
		case "4":
			//faxNumber = profile.hasTel()? profile.getTel() : "";
			break;
		case "7":
			phoneNumber2 = profile.hasTel()? profile.getTel() : "";
			break;
		default:
			break;
		}
		
		// check tel_type2
		switch (profile.getTelType2()) {
		case "1":
			phoneNumber1 = profile.hasTel1()? profile.getTel1() : phoneNumber1;
			break;
		case "2":
			//phoneNumber = profile.hasTel1()? profile.getTel1() : phoneNumber;
			break;
		case "3":
			//cellularNumber = profile.hasTel1()? profile.getTel1() : cellularNumber;
			break;
		case "4":
			//faxNumber = profile.hasTel1()? profile.getTel1() : faxNumber;
			break;
		case "7":
			phoneNumber2 = profile.hasTel1()? profile.getTel1() : phoneNumber2;
			break;
		default:
			break;
		}
		
		// check tel_type3
		switch (profile.getTelType3()) {
		case "1":
			phoneNumber1 = profile.hasTelHp()? profile.getTelHp() : phoneNumber1;
			break;
		case "2":
			//phoneNumber = profile.hasTelHp()? profile.getTelHp() : phoneNumber;
			break;
		case "3":
			//cellularNumber = profile.hasTelHp()? profile.getTelHp() : cellularNumber;
			break;
		case "4":
			//faxNumber = profile.hasTelHp()? profile.getTelHp() : faxNumber;
			break;
		case "7":
			phoneNumber2 = profile.hasTelHp()? profile.getTelHp() : phoneNumber2;
			break;
		default:
			break;
		}
		
		HomeAddressInformation homeAddressInformation = new HomeAddressInformation();
		homeAddressInformation.setAddressZipCode(profile.getZipCode1() + profile.getZipCode2());
		homeAddressInformation.setWholeAddress1(profile.getAddress1());
		homeAddressInformation.setWholeAddress2(profile.getAddress2());
		homeAddressInformation.setPhoneNumber1(phoneNumber1);
		homeAddressInformation.setPhoneNumber2(phoneNumber2);
		this.setHomeAddressInformation(homeAddressInformation);
		
		WorkPlaceInformation workPlaceInformation = new WorkPlaceInformation();
		workPlaceInformation.setPhoneNumber(phoneNumber);
		this.setWorkPlaceInformation(workPlaceInformation);
		
		// setting public ins info
		healthInsuranceInformation = new HealthInsuranceInfo();
		if(!CollectionUtils.isEmpty(publicInsList)){
			PatientModelProto.PublicInsurance publicIns = publicInsList.get(0);
			if(DataRowState.ADDED.getValue().equals(publicIns.getDataRowState())){
				healthInsuranceInformation.setInsuranceProviderClass(OrcaUtils.getClassCodeByInsurCode(publicIns.getGubun1()));
				healthInsuranceInformation.setInsuranceProviderNumber(publicIns.getJohap());
				healthInsuranceInformation.setHealthInsuredPersonSymbol(publicIns.getGaein());
				healthInsuranceInformation.setHealthInsuredPersonNumber(publicIns.getGaeinNo());
				healthInsuranceInformation.setCertificateStartDate(publicIns.getStartDate().replace("/", "-"));
				healthInsuranceInformation.setCertificateExpiredDate(publicIns.getEndDate().replace("/", "-"));
				
				String relationToInsuredPerson = "";
				if("0".equals(publicIns.getBoninGubun())){
					relationToInsuredPerson = "1";
				} else if("1".equals(publicIns.getBoninGubun())){
					relationToInsuredPerson = "2";
				}
				
				healthInsuranceInformation.setRelationToInsuredPerson(relationToInsuredPerson);
				healthInsuranceInformation.setHealthInsuredPersonWholeName(publicIns.getPiname());
			}
		}
		
		// setting private ins info
		if(!CollectionUtils.isEmpty(privateInsList)){
			List<PublicInsuranceInfo> piList = new ArrayList<>(); 
			for (PatientModelProto.PrivateInsurance info : privateInsList) {
				if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
					PublicInsuranceInfo publicIns = new PublicInsuranceInfo();
					publicIns.setPublicInsuranceClass(info.getGongbiCode());
					publicIns.setPublicInsuranceName("");
					publicIns.setPublicInsurerNumber(info.getSugubjaBunho());
					publicIns.setPublicInsuredPersonNumber("");
					publicIns.setCertificateIssuedDate(info.getStartDate().replace("/", "-"));
					publicIns.setCertificateExpiredDate(info.getEndDate().replace("/", "-"));
					piList.add(publicIns);
				}
			}
			
			healthInsuranceInformation.setPublicInsuranceInformation(piList);
		}
	}
	
}

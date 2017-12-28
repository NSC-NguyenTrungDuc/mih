package nta.med.orca.gw.api.contracts.service;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import nta.med.orca.gw.api.contracts.message.DiseaseMessageInformation;
import nta.med.orca.gw.api.contracts.message.MedicalMessageInformation;
import nta.med.orca.gw.api.contracts.message.PatientInformation;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class MedicalModResponse {

    private String informationDate;
    private String informationTime;
    private String apiResult;
    private String apiResultMessage;
    private String reskey;
    private String performDate;
    private String performTime;
    private String medicalUid;
    private String departmentCode ;
    private String departmentName;
    private String physicianCode;
    private String physicianWholeName;
    private PatientInformation patientInformation;
    private MedicalMessageInformation medicalMessageInformation;
    private DiseaseMessageInformation diseaseMessageInformation;


    public MedicalModResponse() {
    }

    @JacksonXmlProperty(localName = "Information_Date")
    public String getInformationDate() {
        return informationDate;
    }

    public void setInformationDate(String informationDate) {
        this.informationDate = informationDate;
    }

    @JacksonXmlProperty(localName = "Information_Time")
    public String getInformationTime() {
        return informationTime;
    }

    public void setInformationTime(String informationTime) {
        this.informationTime = informationTime;
    }

    @JacksonXmlProperty(localName = "Api_Result")
    public String getApiResult() {
        return apiResult;
    }

    public void setApiResult(String apiResult) {
        this.apiResult = apiResult;
    }

    @JacksonXmlProperty(localName = "Api_Result_Message")
    public String getApiResultMessage() {
        return apiResultMessage;
    }

    public void setApiResultMessage(String apiResultMessage) {
        this.apiResultMessage = apiResultMessage;
    }

    @JacksonXmlProperty(localName = "Patient_Information")
    public PatientInformation getPatientInformation() {
        return patientInformation;
    }

    public void setPatientInformation(PatientInformation patientInformation) {
        this.patientInformation = patientInformation;
    }

    @JacksonXmlProperty(localName = "Reskey")
    public String getReskey() {
        return reskey;
    }

    public void setReskey(String reskey) {
        this.reskey = reskey;
    }

    @JacksonXmlProperty(localName = "Perform_Date")
    public String getPerformDate() {
        return performDate;
    }

    public void setPerformDate(String performDate) {
        this.performDate = performDate;
    }

    @JacksonXmlProperty(localName = "Perform_Time")
    public String getPerformTime() {
        return performTime;
    }

    public void setPerformTime(String performTime) {
        this.performTime = performTime;
    }

    @JacksonXmlProperty(localName = "Medical_Uid")
    public String getMedicalUid() {
        return medicalUid;
    }

    public void setMedicalUid(String medicalUid) {
        this.medicalUid = medicalUid;
    }

    @JacksonXmlProperty(localName = "Department_Code")
    public String getDepartmentCode() {
        return departmentCode;
    }

    public void setDepartmentCode(String departmentCode) {
        this.departmentCode = departmentCode;
    }

    @JacksonXmlProperty(localName = "Department_Name")
    public String getDepartmentName() {
        return departmentName;
    }

    public void setDepartmentName(String departmentName) {
        this.departmentName = departmentName;
    }

    @JacksonXmlProperty(localName = "Physician_Code")
    public String getPhysicianCode() {
        return physicianCode;
    }

    public void setPhysicianCode(String physicianCode) {
        this.physicianCode = physicianCode;
    }

    @JacksonXmlProperty(localName = "Physician_WholeName")
    public String getPhysicianWholeName() {
        return physicianWholeName;
    }

    public void setPhysicianWholeName(String physicianWholeName) {
        this.physicianWholeName = physicianWholeName;
    }

    @JacksonXmlProperty(localName = "Medical_Message_Information")
    public MedicalMessageInformation getMedicalMessageInformation() {
        return medicalMessageInformation;
    }

    public void setMedicalMessageInformation(MedicalMessageInformation medicalMessageInformation) {
        this.medicalMessageInformation = medicalMessageInformation;
    }

    @JacksonXmlProperty(localName = "Disease_Message_Information")
    public DiseaseMessageInformation getDiseaseMessageInformation() {
        return diseaseMessageInformation;
    }

    public void setDiseaseMessageInformation(DiseaseMessageInformation diseaseMessageInformation) {
        this.diseaseMessageInformation = diseaseMessageInformation;
    }
}

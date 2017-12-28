package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import java.util.List;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class DiagnosisInformation {

    private String departmentCode;
    private String physicianCode;
    private HealthInsuranceInfo healthInsuranceInfo;
    private List<MedicalInformation> medicalInformation;
    private List<DiseaseInformation> diseaseInformation;

    @JacksonXmlProperty(localName = "Department_Code")
    public String getDepartmentCode() {
        return departmentCode;
    }

    public void setDepartmentCode(String departmentCode) {
        this.departmentCode = departmentCode;
    }

    @JacksonXmlProperty(localName = "Physician_Code")
    public String getPhysicianCode() {
        return physicianCode;
    }

    public void setPhysicianCode(String physicianCode) {
        this.physicianCode = physicianCode;
    }

    @JacksonXmlProperty(localName = "HealthInsurance_Information")
    public HealthInsuranceInfo getHealthInsuranceInfo() {
        return healthInsuranceInfo;
    }

    public void setHealthInsuranceInfo(HealthInsuranceInfo healthInsuranceInfo) {
        this.healthInsuranceInfo = healthInsuranceInfo;
    }

    @JacksonXmlProperty(localName = "Medical_Information")
    public List<MedicalInformation> getMedicalInformation() {
        return medicalInformation;
    }

    public void setMedicalInformation(List<MedicalInformation> medicalInformation) {
        this.medicalInformation = medicalInformation;
    }

    @JacksonXmlProperty(localName = "Disease_Information")
    public List<DiseaseInformation> getDiseaseInformation() {
        return diseaseInformation;
    }

    public void setDiseaseInformation(List<DiseaseInformation> diseaseInformation) {
        this.diseaseInformation = diseaseInformation;
    }
}

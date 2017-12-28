package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import java.util.List;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class MedicalInformation {

    private String medicalClass;
    private String medicalClassName;
    private String medicalClassNumber;
    private List<MedicationInfo> medicationInfos;

    @JacksonXmlProperty(localName = "Medical_Class")
    public String getMedicalClass() {
        return medicalClass;
    }

    public void setMedicalClass(String medicalClass) {
        this.medicalClass = medicalClass;
    }

    @JacksonXmlProperty(localName = "Medical_Class_Name")
    public String getMedicalClassName() {
        return medicalClassName;
    }

    public void setMedicalClassName(String medicalClassName) {
        this.medicalClassName = medicalClassName;
    }

    @JacksonXmlProperty(localName = "Medical_Class_Number")
    public String getMedicalClassNumber() {
        return medicalClassNumber;
    }

    public void setMedicalClassNumber(String medicalClassNumber) {
        this.medicalClassNumber = medicalClassNumber;
    }

    @JacksonXmlProperty(localName = "Medication_info")
    public List<MedicationInfo> getMedicationInfos() {
        return medicationInfos;
    }

    public void setMedicationInfos(List<MedicationInfo> medicationInfos) {
        this.medicationInfos = medicationInfos;
    }
}

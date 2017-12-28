package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class MedicalWarningInf {

    private String medicalWarning;
    private String medicalWarningMessage;
    private String medicalWarningPosition;
    private String medicalWarningItemPosition;
    private String medicalWarningCode;

    @JacksonXmlProperty(localName = "Medical_Warning")
    public String getMedicalWarning() {
        return medicalWarning;
    }

    public void setMedicalWarning(String medicalWarning) {
        this.medicalWarning = medicalWarning;
    }

    @JacksonXmlProperty(localName = "Medical_Warning_Message")
    public String getMedicalWarningMessage() {
        return medicalWarningMessage;
    }

    public void setMedicalWarningMessage(String medicalWarningMessage) {
        this.medicalWarningMessage = medicalWarningMessage;
    }

    @JacksonXmlProperty(localName = "Medical_Warning_Position")
    public String getMedicalWarningPosition() {
        return medicalWarningPosition;
    }

    public void setMedicalWarningPosition(String medicalWarningPosition) {
        this.medicalWarningPosition = medicalWarningPosition;
    }

    @JacksonXmlProperty(localName = "Medical_Warning_Item_Position")
    public String getMedicalWarningItemPosition() {
        return medicalWarningItemPosition;
    }

    public void setMedicalWarningItemPosition(String medicalWarningItemPosition) {
        this.medicalWarningItemPosition = medicalWarningItemPosition;
    }

    @JacksonXmlProperty(localName = "Medical_Warning_Code")
    public String getMedicalWarningCode() {
        return medicalWarningCode;
    }

    public void setMedicalWarningCode(String medicalWarningCode) {
        this.medicalWarningCode = medicalWarningCode;
    }
}

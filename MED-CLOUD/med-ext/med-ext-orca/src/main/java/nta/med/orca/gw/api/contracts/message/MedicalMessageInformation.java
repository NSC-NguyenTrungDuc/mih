package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import java.util.List;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class MedicalMessageInformation {

    private String medicalResult;
    private String medicalResultMessage;
    private List<MedicalWarningInf> medicalWarningInf;

    @JacksonXmlProperty(localName = "Medical_Result")
    public String getMedicalResult() {
        return medicalResult;
    }

    public void setMedicalResult(String medicalResult) {
        this.medicalResult = medicalResult;
    }

    @JacksonXmlProperty(localName = "Medical_Result_Message")
    public String getMedicalResultMessage() {
        return medicalResultMessage;
    }

    public void setMedicalResultMessage(String medicalResultMessage) {
        this.medicalResultMessage = medicalResultMessage;
    }

    @JacksonXmlProperty(localName = "Medical_Warning_Inf")
    public List<MedicalWarningInf> getMedicalWarningInf() {
        return medicalWarningInf;
    }

    public void setMedicalWarningInf(List<MedicalWarningInf> medicalWarningInf) {
        this.medicalWarningInf = medicalWarningInf;
    }
}

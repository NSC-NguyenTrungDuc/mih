package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class DiseaseMessageInformation {

    private String diseaseResult;
    private String diseaseResultMessage;
    private DiseaseWarningInf diseaseWarningInf;

    @JacksonXmlProperty(localName = "Disease_Result")
    public String getDiseaseResult() {
        return diseaseResult;
    }

    public void setDiseaseResult(String diseaseResult) {
        this.diseaseResult = diseaseResult;
    }

    @JacksonXmlProperty(localName = "Disease_Result_Message")
    public String getDiseaseResultMessage() {
        return diseaseResultMessage;
    }

    public void setDiseaseResultMessage(String diseaseResultMessage) {
        this.diseaseResultMessage = diseaseResultMessage;
    }

    @JacksonXmlProperty(localName = "Disease_Warning_Inf")
    public DiseaseWarningInf getDiseaseWarningInf() {
        return diseaseWarningInf;
    }

    public void setDiseaseWarningInf(DiseaseWarningInf diseaseWarningInf) {
        this.diseaseWarningInf = diseaseWarningInf;
    }
}

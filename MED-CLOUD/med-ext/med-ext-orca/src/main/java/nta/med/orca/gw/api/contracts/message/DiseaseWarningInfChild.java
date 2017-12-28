package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class DiseaseWarningInfChild {

    private String diseaseWarning;
    private String diseaseWarningMessage;
    private String diseaseWarningItemPosition;
    private String diseaseWarningName;
    private String diseaseWarningCode;
    private String diseaseWarningChange;

    @JacksonXmlProperty(localName = "Disease_Warning")
    public String getDiseaseWarning() {
        return diseaseWarning;
    }

    public void setDiseaseWarning(String diseaseWarning) {
        this.diseaseWarning = diseaseWarning;
    }

    @JacksonXmlProperty(localName = "Disease_Warning_Message")
    public String getDiseaseWarningMessage() {
        return diseaseWarningMessage;
    }

    public void setDiseaseWarningMessage(String diseaseWarningMessage) {
        this.diseaseWarningMessage = diseaseWarningMessage;
    }

    @JacksonXmlProperty(localName = "Disease_Warning_Item_Position")
    public String getDiseaseWarningItemPosition() {
        return diseaseWarningItemPosition;
    }

    public void setDiseaseWarningItemPosition(String diseaseWarningItemPosition) {
        this.diseaseWarningItemPosition = diseaseWarningItemPosition;
    }

    @JacksonXmlProperty(localName = "Disease_Warning_Name")
    public String getDiseaseWarningName() {
        return diseaseWarningName;
    }

    public void setDiseaseWarningName(String diseaseWarningName) {
        this.diseaseWarningName = diseaseWarningName;
    }

    @JacksonXmlProperty(localName = "Disease_Warning_Code")
    public String getDiseaseWarningCode() {
        return diseaseWarningCode;
    }

    public void setDiseaseWarningCode(String diseaseWarningCode) {
        this.diseaseWarningCode = diseaseWarningCode;
    }

    @JacksonXmlProperty(localName = "Disease_Warning_Change")
    public String getDiseaseWarningChange() {
        return diseaseWarningChange;
    }

    public void setDiseaseWarningChange(String diseaseWarningChange) {
        this.diseaseWarningChange = diseaseWarningChange;
    }
}

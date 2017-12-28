package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class DiseaseSingle {

    private String diseaseSingleCode;
    private String diseaseSingleName;

    @JacksonXmlProperty(localName = "Disease_Single_Code")
    public String getDiseaseSingleCode() {
        return diseaseSingleCode;
    }

    public void setDiseaseSingleCode(String diseaseSingleCode) {
        this.diseaseSingleCode = diseaseSingleCode;
    }

    @JacksonXmlProperty(localName = "Disease_Single_Name")
    public String getDiseaseSingleName() {
        return diseaseSingleName;
    }

    public void setDiseaseSingleName(String diseaseSingleName) {
        this.diseaseSingleName = diseaseSingleName;
    }
}

package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlElementWrapper;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import java.util.List;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class DiseaseWarningInf {

    private String type = "array";
    private List<DiseaseWarningInfChild> warnings;

    @JacksonXmlProperty(localName = "type", isAttribute = true)
    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    @JacksonXmlElementWrapper(useWrapping=false)
    @JacksonXmlProperty(localName = "Disease_Warning_Inf_child")
    public List<DiseaseWarningInfChild> getWarnings() {
        return warnings;
    }

    public void setWarnings(List<DiseaseWarningInfChild> warnings) {
        this.warnings = warnings;
    }
}

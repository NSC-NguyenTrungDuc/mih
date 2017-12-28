package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import java.util.List;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class AcPointInformation {
    private String acTtlPoint;
    private List<AcPointDetail> acPointDetails;

    @JacksonXmlProperty(localName = "Ac_Ttl_Point")
    public String getAcTtlPoint() {
        return acTtlPoint;
    }

    public void setAcTtlPoint(String acTtlPoint) {
        this.acTtlPoint = acTtlPoint;
    }

    //TODO
    @JacksonXmlProperty(localName = "Ac_Point_Detail")
    public List<AcPointDetail> getAcPointDetails() {
        return acPointDetails;
    }

    public void setAcPointDetails(List<AcPointDetail> acPointDetails) {
        this.acPointDetails = acPointDetails;
    }
}

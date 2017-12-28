package nta.med.orca.gw.api.contracts.message;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
public class AcPointDetail {
    private String acPointCode;
    private String acPointName;
    private String acPoint;

    @JacksonXmlProperty(localName = "AC_Point_Code")
    public String getAcPointCode() {
        return acPointCode;
    }

    public void setAcPointCode(String acPointCode) {
        this.acPointCode = acPointCode;
    }

    @JacksonXmlProperty(localName = "AC_Point_Name")
    public String getAcPointName() {
        return acPointName;
    }

    public void setAcPointName(String acPointName) {
        this.acPointName = acPointName;
    }

    @JacksonXmlProperty(localName = "AC_Point")
    public String getAcPoint() {
        return acPoint;
    }

    public void setAcPoint(String acPoint) {
        this.acPoint = acPoint;
    }
}

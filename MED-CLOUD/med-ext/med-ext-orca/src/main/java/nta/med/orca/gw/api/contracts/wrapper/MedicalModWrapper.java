package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;
import nta.med.orca.gw.api.contracts.service.MedicalModResponse;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class MedicalModWrapper {

    private MedicalModResponse response;

    @JacksonXmlProperty(localName = "medicalres")
    public MedicalModResponse getResponse() {
        return response;
    }

    public void setResponse(MedicalModResponse response) {
        this.response = response;
    }
}

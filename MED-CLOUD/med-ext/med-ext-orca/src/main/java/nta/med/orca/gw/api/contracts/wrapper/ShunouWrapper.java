package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;
import nta.med.orca.gw.api.contracts.service.ShunouResponse;

/**
 * @author dainguyen.
 */
@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class ShunouWrapper<T> {
    private ShunouResponse response;

    @JacksonXmlProperty(localName = "private_objects")
    public ShunouResponse getResponse() {
        return response;
    }

    public void setResponse(ShunouResponse response) {
        this.response = response;
    }
}

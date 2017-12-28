package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

import nta.med.orca.gw.api.contracts.service.AcceptModResponse;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class AcceptModWrapper {

	private AcceptModResponse response;

	@JacksonXmlProperty(localName = "acceptres")
	public AcceptModResponse getResponse() {
		return response;
	}

	public void setResponse(AcceptModResponse response) {
		this.response = response;
	}

}

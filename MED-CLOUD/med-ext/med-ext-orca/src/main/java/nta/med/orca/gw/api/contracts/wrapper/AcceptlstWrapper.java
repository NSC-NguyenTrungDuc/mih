package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

import nta.med.orca.gw.api.contracts.service.AcceptlstResponse;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class AcceptlstWrapper {

	private AcceptlstResponse response;

	@JacksonXmlProperty(localName = "acceptlstres")
	public AcceptlstResponse getResponse() {
		return response;
	}

	public void setResponse(AcceptlstResponse response) {
		this.response = response;
	}

}

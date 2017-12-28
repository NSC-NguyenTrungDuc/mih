package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

import nta.med.orca.gw.api.contracts.service.AppointListResponse;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class AppointListWrapper {

	private AppointListResponse response;

	@JacksonXmlProperty(localName = "appointlstres")
	public AppointListResponse getResponse() {
		return response;
	}

	public void setResponse(AppointListResponse response) {
		this.response = response;
	}

}

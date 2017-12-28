package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

import nta.med.orca.gw.api.contracts.service.AppointmentResponse;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class AppointmentWrapper {

	private AppointmentResponse response;

	@JacksonXmlProperty(localName = "appointres")
	public AppointmentResponse getResponse() {
		return response;
	}

	public void setResponse(AppointmentResponse response) {
		this.response = response;
	}

}

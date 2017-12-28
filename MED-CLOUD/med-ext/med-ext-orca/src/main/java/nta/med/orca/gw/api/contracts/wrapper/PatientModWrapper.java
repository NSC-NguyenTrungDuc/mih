package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

import nta.med.orca.gw.api.contracts.service.PatientModResponse;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class PatientModWrapper {

	private PatientModResponse response;

	@JacksonXmlProperty(localName = "patientmodres")
	public PatientModResponse getResponse() {
		return response;
	}

	public void setResponse(PatientModResponse response) {
		this.response = response;
	}
}

package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

import nta.med.orca.gw.api.contracts.service.PatientInfoResponse;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class PatientInfoWrapper {

	private PatientInfoResponse response;

	@JacksonXmlProperty(localName = "patientinfores")
	public PatientInfoResponse getResponse() {
		return response;
	}

	public void setResponse(PatientInfoResponse response) {
		this.response = response;
	}

}

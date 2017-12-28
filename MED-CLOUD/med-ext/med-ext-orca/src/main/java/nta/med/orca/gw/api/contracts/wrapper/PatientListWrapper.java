package nta.med.orca.gw.api.contracts.wrapper;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

import nta.med.orca.gw.api.contracts.service.PatientListResponse;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "xmlio2")
public class PatientListWrapper {

	private PatientListResponse response;

	@JacksonXmlProperty(localName = "patientlst1res")
	public PatientListResponse getResponse() {
		return response;
	}

	public void setResponse(PatientListResponse response) {
		this.response = response;
	}

}

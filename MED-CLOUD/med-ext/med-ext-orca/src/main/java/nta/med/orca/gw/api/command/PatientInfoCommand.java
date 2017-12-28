package nta.med.orca.gw.api.command;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.glassfish.jersey.internal.util.Base64;
import org.springframework.stereotype.Component;

import nta.med.orca.gw.api.contracts.service.PatientInfoRequest;
import nta.med.orca.gw.api.contracts.service.PatientInfoResponse;
import nta.med.orca.gw.api.contracts.wrapper.PatientInfoWrapper;

@Component("patientInfoCommand")
public class PatientInfoCommand extends AbstractCommand<PatientInfoRequest, PatientInfoResponse> {

	@Override
	public PatientInfoResponse execute(PatientInfoRequest request) throws Exception {
		Client client = ClientBuilder.newClient().register(json).register(xml);
		String strUri = "http://" + request.getOrcaEnvInfo().getOrcaIp() + ":" + request.getOrcaEnvInfo().getOrcaPort()
				+ "/api01rv2/patientgetv2?id=" + request.getPatientCode();
		
		Response response = client
        		.target(strUri)
        		.request(MediaType.APPLICATION_XML_TYPE)
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", request.getOrcaEnvInfo().getOrcaUser(), request.getOrcaEnvInfo().getOrcaPwd()).getBytes()))
                .get();

        if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){
        	PatientInfoWrapper wrapper = response.readEntity(PatientInfoWrapper.class);
        	return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }
        
	}
}

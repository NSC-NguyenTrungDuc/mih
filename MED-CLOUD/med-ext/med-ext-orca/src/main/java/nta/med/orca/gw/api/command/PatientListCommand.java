package nta.med.orca.gw.api.command;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.glassfish.jersey.internal.util.Base64;
import org.springframework.stereotype.Component;

import nta.med.orca.gw.api.contracts.service.PatientListRequest;
import nta.med.orca.gw.api.contracts.service.PatientListResponse;
import nta.med.orca.gw.api.contracts.wrapper.PatientListWrapper;

@Component("patientListCommand")
public class PatientListCommand extends AbstractCommand<PatientListRequest, PatientListResponse>{

	@Override
	public PatientListResponse execute(PatientListRequest request) throws Exception {
		Client client = ClientBuilder.newClient().register(json).register(xml);
        String requestBody = "<data><patientlst1req type=\"record\"><Base_StartDate type=\"string\">" + request.getBaseStartDate() + "</Base_StartDate><Base_EndDate type=\"string\">" + request.getBaseEndDate() + "</Base_EndDate><Contain_TestPatient_Flag type=\"string\"></Contain_TestPatient_Flag></patientlst1req></data>";
        String strUri = "http://" + request.getOrcaEnvInfo().getOrcaIp() + ":" + request.getOrcaEnvInfo().getOrcaPort() + "/api01rv2/patientlst1v2?class=01";
        Response response = client
        		.target(strUri)
        		.request(MediaType.APPLICATION_XML_TYPE)
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", request.getOrcaEnvInfo().getOrcaUser(), request.getOrcaEnvInfo().getOrcaPwd()).getBytes()))
                .post(Entity.entity(requestBody, MediaType.APPLICATION_XML_TYPE));

        if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){
        	PatientListWrapper wrapper = response.readEntity(PatientListWrapper.class);
        	return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }

	}
	
}

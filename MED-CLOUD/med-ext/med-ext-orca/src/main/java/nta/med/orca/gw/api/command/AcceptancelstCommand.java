package nta.med.orca.gw.api.command;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.glassfish.jersey.internal.util.Base64;
import org.springframework.stereotype.Component;

import nta.med.orca.gw.api.contracts.service.AcceptancelstRequest;
import nta.med.orca.gw.api.contracts.service.AcceptlstResponse;
import nta.med.orca.gw.api.contracts.wrapper.AcceptlstWrapper;

@Component("acceptancelstCommand")
public class AcceptancelstCommand extends AbstractCommand<AcceptancelstRequest, AcceptlstResponse> {

	@Override
	public AcceptlstResponse execute(AcceptancelstRequest request) throws Exception {
        Client client = ClientBuilder.newClient().register(json).register(xml);
        String requestBody = "<data><acceptlstreq type=\"record\"><Acceptance_Date type=\"string\">" + request.getAcceptanceDate() + "</Acceptance_Date></acceptlstreq></data>";
        String strUri = "http://" + request.getOrcaEnvInfo().getOrcaIp() + ":" + request.getOrcaEnvInfo().getOrcaPort() + "/api01rv2/acceptlstv2?class=" + request.getReqClass();
        
        Response response = client
        		.target(strUri)
        		.request(MediaType.APPLICATION_XML_TYPE)
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", request.getOrcaEnvInfo().getOrcaUser(), request.getOrcaEnvInfo().getOrcaPwd()).getBytes()))
                .post(Entity.entity(requestBody, MediaType.APPLICATION_XML_TYPE));

        if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){
        	AcceptlstWrapper wrapper = response.readEntity(AcceptlstWrapper.class);
        	return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }
	}
}

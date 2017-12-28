package nta.med.orca.gw.api.command;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.glassfish.jersey.internal.util.Base64;
import org.springframework.stereotype.Component;

import nta.med.orca.gw.api.contracts.service.AppointmentRequest;
import nta.med.orca.gw.api.contracts.service.AppointmentResponse;
import nta.med.orca.gw.api.contracts.wrapper.AppointmentWrapper;

@Component("appointmentCommand")
public class AppointmentCommand extends AbstractCommand<AppointmentRequest, AppointmentResponse>{

	private static final Log LOGGER = LogFactory.getLog(AppointmentCommand.class);
	
	@Override
	public AppointmentResponse execute(AppointmentRequest request) throws Exception {
		Client client = ClientBuilder.newClient().register(json).register(xml);
		String strUri = "http://" + request.getOrcaEnvInfo().getOrcaIp() + ":" + request.getOrcaEnvInfo().getOrcaPort() + "/orca14/appointmodv2?class=" + request.getClazz();
        Response response = client
        		.target(strUri)
        		.request(MediaType.APPLICATION_XML_TYPE)
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", request.getOrcaEnvInfo().getOrcaUser(), request.getOrcaEnvInfo().getOrcaPwd()).getBytes()))
                .post(Entity.entity(request.toXml(), MediaType.APPLICATION_XML_TYPE));

        LOGGER.info("CALL ORCA API URI = " + strUri + " [REQUEST BODY = ] " + request.toXml());
        
        if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){	        
        	AppointmentWrapper wrapper = response.readEntity(AppointmentWrapper.class);
	        return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }
	}
	
}

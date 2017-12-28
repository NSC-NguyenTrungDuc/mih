package nta.med.orca.gw.api.command;

import java.util.HashMap;
import java.util.Map;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.velocity.app.VelocityEngine;
import org.glassfish.jersey.internal.util.Base64;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.ui.velocity.VelocityEngineUtils;

import nta.med.orca.gw.api.contracts.service.AcceptModRequest;
//import nta.med.orca.gw.api.contracts.service.AcceptModRequest;
import nta.med.orca.gw.api.contracts.service.AcceptModResponse;
import nta.med.orca.gw.api.contracts.wrapper.AcceptModWrapper;

@Component("acceptModCommand")
public class AcceptModCommand extends AbstractCommand<AcceptModRequest, AcceptModResponse> {

	private static final Log LOGGER = LogFactory.getLog(AcceptModCommand.class);
	
    @Autowired
    private VelocityEngine velocityEngine;
	
	@Override
	public AcceptModResponse execute(AcceptModRequest request) throws Exception {
		Client client = ClientBuilder.newClient().register(json).register(xml);
		Map<String, Object> hTemplateVariables = new HashMap<String, Object>();
        hTemplateVariables.put("rq", request);
        String requestBody = VelocityEngineUtils.mergeTemplateIntoString(velocityEngine, "./acceptmod_request.vm", "UTF-8", hTemplateVariables);
        
		String strUri = "http://" + request.getOrcaEnvInfo().getOrcaIp() + ":" + request.getOrcaEnvInfo().getOrcaPort() + "/orca11/acceptmodv2?class=" + request.getAcceptType();
        Response response = client
        		.target(strUri)
        		.request(MediaType.APPLICATION_XML_TYPE)
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", request.getOrcaEnvInfo().getOrcaUser(), request.getOrcaEnvInfo().getOrcaPwd()).getBytes()))
                .post(Entity.entity(requestBody, MediaType.APPLICATION_XML_TYPE));

        LOGGER.info("CALL ORCA API URI = " + strUri + " [REQUEST BODY = ] " + requestBody);
        
        if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){	        
	        AcceptModWrapper wrapper = response.readEntity(AcceptModWrapper.class);
	        return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }
	}

}

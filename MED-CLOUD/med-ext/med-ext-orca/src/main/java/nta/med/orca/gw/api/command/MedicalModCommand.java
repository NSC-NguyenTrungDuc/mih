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

import nta.med.orca.gw.api.contracts.service.MedicalModRequest;
import nta.med.orca.gw.api.contracts.service.MedicalModResponse;
import nta.med.orca.gw.api.contracts.wrapper.MedicalModWrapper;

/**
 * @author dainguyen.
 */
@Component("medicalModCommand")
public class MedicalModCommand extends AbstractCommand<MedicalModRequest, MedicalModResponse> {

    private static final Log LOGGER = LogFactory.getLog(MedicalModCommand.class);

    @Autowired
    private VelocityEngine velocityEngine;

    @Override
    public MedicalModResponse execute(MedicalModRequest request) throws Exception {
        Client client = ClientBuilder.newClient().register(json).register(xml);
        Map<String, Object> hTemplateVariables = new HashMap<String, Object>();
        hTemplateVariables.put("rq", request);
        String requestBody = VelocityEngineUtils.mergeTemplateIntoString(velocityEngine, "./medicalmod_request.vm", "UTF-8", hTemplateVariables);

        String strUri = "http://" + request.getOrcaEnvInfo().getOrcaIp() + ":" + request.getOrcaEnvInfo().getOrcaPort() + "/api21/medicalmodv2?class=" + request.getRequestClass();
        Response response = client
                .target(strUri)
                .request(MediaType.APPLICATION_XML_TYPE)
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", request.getOrcaEnvInfo().getOrcaUser(), request.getOrcaEnvInfo().getOrcaPwd()).getBytes()))
                .post(Entity.entity(requestBody, MediaType.APPLICATION_XML_TYPE));
        LOGGER.info(request.getOrcaEnvInfo().getOrcaUser());
        LOGGER.info(request.getOrcaEnvInfo().getOrcaPwd());
        LOGGER.info("CALL ORCA API URI = " + strUri + " [REQUEST BODY = ] " + requestBody);
        
        if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){
            MedicalModWrapper wrapper = response.readEntity(MedicalModWrapper.class);
            return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }
    }
}

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

import com.fasterxml.jackson.dataformat.xml.JacksonXmlModule;
import com.fasterxml.jackson.dataformat.xml.XmlMapper;

import nta.med.orca.gw.api.contracts.service.PatientModRequest;
import nta.med.orca.gw.api.contracts.service.PatientModResponse;
import nta.med.orca.gw.api.contracts.wrapper.PatientModWrapper;

@Component("patientModCommand")
public class PatientModCommand extends AbstractCommand<PatientModRequest, PatientModResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(PatientModCommand.class);

    @Autowired
    private VelocityEngine velocityEngine;
	
	@Override
	public PatientModResponse execute(PatientModRequest request) throws Exception {
		Client client = ClientBuilder.newClient().register(json).register(xml);
		Map<String, Object> hTemplateVariables = new HashMap<String, Object>();
        hTemplateVariables.put("rq", request);
        String requestBody = VelocityEngineUtils.mergeTemplateIntoString(velocityEngine, "./patientmod_request.vm", "UTF-8", hTemplateVariables);
        
		String strUri = "http://" + request.getOrcaEnvInfo().getOrcaIp() + ":" + request.getOrcaEnvInfo().getOrcaPort()
				+ "/orca12/patientmodv2?class=" + request.getRqType();
		Response response = client
        		.target(strUri)
        		.request(MediaType.APPLICATION_XML_TYPE)
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", request.getOrcaEnvInfo().getOrcaUser(), request.getOrcaEnvInfo().getOrcaPwd()).getBytes()))
                .post(Entity.entity(requestBody, MediaType.APPLICATION_XML_TYPE));
		
		LOGGER.info("CALL ORCA API URI = " + strUri + " [REQUEST BODY = ] " + requestBody);
		
		if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){
			// reponse from ORCA: Content-Type=[patientmod/xml] ==> have to use below code to parse response to PatientModWrapper
			String xmlData = response.readEntity(String.class);
			JacksonXmlModule module = new JacksonXmlModule();
	        module.setDefaultUseWrapper(true);
	        XmlMapper xmlMapper = new XmlMapper(module);
	        PatientModWrapper wrapper = xmlMapper.readValue(xmlData, PatientModWrapper.class);
	        return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }
	}
}

package nta.med.orca.gw.api.command;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.TimeUnit;

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

import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.jaxrs.json.JacksonJsonProvider;
import com.fasterxml.jackson.jaxrs.xml.JacksonXMLProvider;

import nta.med.common.glossary.Lifecyclet;
import nta.med.orca.gw.api.contracts.service.ShunouRequest;
import nta.med.orca.gw.api.contracts.service.ShunouResponse;
import nta.med.orca.gw.api.contracts.wrapper.ShunouWrapper;

/**
 * @author dainguyen.
 */
@Component("shunouCommand")
public class ShunouCommand extends Lifecyclet implements GenericCommand<ShunouRequest, ShunouResponse> {

    private Log LOGGER = LogFactory.getLog(ShunouCommand.class);
    
    private Client client;

//    @Autowired
//    private Configuration config;

    @Autowired
    private VelocityEngine velocityEngine;

    @Override
    public ShunouResponse execute(ShunouRequest request) throws Exception {
        Map<String, Object> hTemplateVariables = new HashMap<String, Object>();
        hTemplateVariables.put("rq", request);
        String requestBody = VelocityEngineUtils.mergeTemplateIntoString(velocityEngine, "./shunou_request.vm", "UTF-8", hTemplateVariables);
        Response response = client
        		//.target(config.getOrcaServiceUrl())
        		.target("http://10.1.20.161:8000")
        		.path("/api01rv2/incomeinfv2")
                .request(MediaType.APPLICATION_XML_TYPE)
                //.header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", config.getOrcaUsername(), config.getOrcaPassword()).getBytes()))
                .header("Authorization", "Basic " + Base64.encodeAsString(String.format("%s:%s", "ormaster", "ormaster123").getBytes()))
                .post(Entity.entity(requestBody, MediaType.APPLICATION_XML_TYPE));

        if(Response.Status.Family.SUCCESSFUL.equals(Response.Status.Family.familyOf(response.getStatus())) && response.hasEntity()){
            ShunouWrapper wrapper = response.readEntity(ShunouWrapper.class);
            return wrapper == null ? null : wrapper.getResponse();
        } else {
            String responseText = response.readEntity(String.class);
            throw new Exception(response.getStatus() + ": there was an error on the server. \n" + responseText);
        }
    }

    @Override
    protected void doStart() throws Exception {
        JacksonJsonProvider json = new JacksonJsonProvider().
                configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false).
                configure(SerializationFeature.INDENT_OUTPUT, true);

        JacksonXMLProvider xml = new JacksonXMLProvider().
                configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false).
                configure(SerializationFeature.INDENT_OUTPUT, true);

        client = ClientBuilder.newClient().register(json)
                .register(xml);

    }

    @Override
    protected long doStop(long timeout, TimeUnit unit) throws Exception {
        //NOP
        return timeout;
    }
}

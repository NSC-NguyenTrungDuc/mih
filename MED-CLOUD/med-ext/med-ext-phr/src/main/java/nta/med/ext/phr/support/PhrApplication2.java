package nta.med.ext.phr.support;

import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.jaxrs.json.JacksonJsonProvider;
import com.fasterxml.jackson.jaxrs.xml.JacksonXMLProvider;
import org.glassfish.jersey.server.ResourceConfig;
import org.glassfish.jersey.server.ServerProperties;
import org.glassfish.jersey.server.filter.HttpMethodOverrideFilter;
import org.glassfish.jersey.server.filter.UriConnegFilter;

import javax.ws.rs.core.MediaType;
import java.util.HashMap;

/**
 * @author dainguyen
 */
public class PhrApplication2 extends ResourceConfig {

    public PhrApplication2() {

        JacksonJsonProvider json = new JacksonJsonProvider().
                configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false).
                configure(SerializationFeature.INDENT_OUTPUT, true);

        JacksonXMLProvider xml = new JacksonXMLProvider().
                configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false).
                configure(SerializationFeature.INDENT_OUTPUT, true);

        HashMap<String,MediaType> mappings = new HashMap<String,MediaType>();
        mappings.put("xml",MediaType.APPLICATION_XML_TYPE);
        mappings.put("json",MediaType.APPLICATION_JSON_TYPE);
        UriConnegFilter uriConnegFilter = new UriConnegFilter(mappings, null);

        packages("nta.med.ext.phr");
        
        property(ServerProperties.METAINF_SERVICES_LOOKUP_DISABLE, true);
        property("contextConfigLocation", "classpath:/spring-master-phr.xml");
        register(org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpContainerProvider.class);

        register(json);
        register(xml);
        property(ServerProperties.BV_SEND_ERROR_IN_RESPONSE, true);
        register(HttpMethodOverrideFilter.class);
        register(uriConnegFilter);
    }
}

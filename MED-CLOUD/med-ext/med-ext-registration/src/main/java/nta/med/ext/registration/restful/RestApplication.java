package nta.med.ext.registration.restful;

import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.jaxrs.json.JacksonJsonProvider;
import com.fasterxml.jackson.jaxrs.xml.JacksonXMLProvider;
import nta.med.common.glossary.Lifecyclet;
import nta.med.ext.registration.restful.support.CORSResponseFilter;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.glassfish.grizzly.http.server.HttpServer;
import org.glassfish.grizzly.ssl.SSLContextConfigurator;
import org.glassfish.grizzly.ssl.SSLEngineConfigurator;
import org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpServerFactory;
import org.glassfish.jersey.server.ResourceConfig;
import org.glassfish.jersey.server.ServerProperties;
import org.glassfish.jersey.server.filter.HttpMethodOverrideFilter;
import org.glassfish.jersey.server.filter.UriConnegFilter;

import javax.ws.rs.core.MediaType;
import java.net.URI;
import java.util.HashMap;
import java.util.concurrent.TimeUnit;

/**
 * @author dainguyen.
 */
public class RestApplication extends Lifecyclet {

    private static final Log LOGGER = LogFactory.getLog(RestApplication.class);

    private final String baseUri;
    private final boolean useSsl;
    private final String env;
    private final String sslPassword;
    private HttpServer server;

    public RestApplication(String baseUri, boolean useSsl, String env, String sslPassword) {
        this.baseUri = baseUri;
        this.useSsl = useSsl;
        this.env = env;
        this.sslPassword = sslPassword;
    }

    @Override
    protected void doStart() throws Exception {
        LOGGER.info("Starting restful api server");
        server = startServer();
        LOGGER.info(String.format("Kcckapi restful app started with WADL available at %sapplication.wadl", baseUri));
    }

    @Override
    protected long doStop(long timeout, TimeUnit var3) throws Exception {
        server.shutdownNow();
        return timeout;
    }

    public HttpServer startServer() {
        final ResourceConfig rc = new XResourceConfig();

        SSLContextConfigurator sslCon = new SSLContextConfigurator();

        sslCon.setKeyStoreFile(String.format("%s/cert/kcckapi-%s.jks", System.getProperty("configPath"), env));
        sslCon.setKeyStorePass(sslPassword);

        return GrizzlyHttpServerFactory.createHttpServer(URI.create(baseUri),
                rc, useSsl, new SSLEngineConfigurator(sslCon));
    }

    final class XResourceConfig extends ResourceConfig {

        public XResourceConfig() {
            JacksonJsonProvider json = new JacksonJsonProvider().
                    configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false).
                    configure(SerializationFeature.INDENT_OUTPUT, true);

            JacksonXMLProvider xml = new JacksonXMLProvider().
                    configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false).
                    configure(SerializationFeature.INDENT_OUTPUT, true);

            HashMap<String, MediaType> mappings = new HashMap<String, MediaType>();
            mappings.put("xml", MediaType.APPLICATION_XML_TYPE);
            mappings.put("json", MediaType.APPLICATION_JSON_TYPE);
            UriConnegFilter uriConnegFilter = new UriConnegFilter(mappings, null);

            packages("nta.med.ext.registration.restful");

            property(ServerProperties.METAINF_SERVICES_LOOKUP_DISABLE, true);
            property("contextConfigLocation", "classpath:/META-INF/spring/spring-master-regis.xml");
            register(org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpContainerProvider.class);

            register(json);
            register(xml);
            property(ServerProperties.BV_SEND_ERROR_IN_RESPONSE, true);
            register(HttpMethodOverrideFilter.class);
            register(uriConnegFilter);
            register(CORSResponseFilter.class);
        }
    }
}

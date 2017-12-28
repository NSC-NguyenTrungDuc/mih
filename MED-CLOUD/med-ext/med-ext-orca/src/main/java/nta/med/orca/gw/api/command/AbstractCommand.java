package nta.med.orca.gw.api.command;

import java.util.concurrent.TimeUnit;

import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.jaxrs.json.JacksonJsonProvider;
import com.fasterxml.jackson.jaxrs.xml.JacksonXMLProvider;

import nta.med.common.glossary.Lifecyclet;

/**
 * @author DEV-TiepNM
 */
//public abstract class AbstractCommand<REQ, RES> extends Lifecyclet implements GenericCommand<REQ, RES> {
public abstract class AbstractCommand<REQ, RES> implements GenericCommand<REQ, RES> {

    protected JacksonJsonProvider json = new JacksonJsonProvider()
            .configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false)
            .configure(SerializationFeature.INDENT_OUTPUT, true);
    protected JacksonXMLProvider xml = new JacksonXMLProvider()
            .configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false)
            .configure(SerializationFeature.INDENT_OUTPUT, true);;

//    @Override
//    protected void doStart() throws Exception {
//        //NOP
//    }
//
//    @Override
//    protected long doStop(long timeout, TimeUnit unit) throws Exception {
//        //NOP
//        return timeout;
//    }
}

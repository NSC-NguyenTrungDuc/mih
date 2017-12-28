package nta.med.ext.cms.restful.interceptor;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.ws.rs.WebApplicationException;
import javax.ws.rs.ext.Provider;
import javax.ws.rs.ext.WriterInterceptor;
import javax.ws.rs.ext.WriterInterceptorContext;
import java.io.IOException;

/**
 * @author dainguyen.
 */
@Provider
public class XWriterInterceptor implements WriterInterceptor {

    private static final Log LOGGER = LogFactory.getLog(XWriterInterceptor.class);

    @Override
    public void aroundWriteTo(WriterInterceptorContext writerInterceptorContext) throws IOException, WebApplicationException {
        try{
            writerInterceptorContext.proceed();
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            throw e;
        }
    }
}

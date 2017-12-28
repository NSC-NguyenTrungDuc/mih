package nta.med.ext.cms.restful.interceptor;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.ws.rs.WebApplicationException;
import javax.ws.rs.ext.Provider;
import javax.ws.rs.ext.ReaderInterceptor;
import javax.ws.rs.ext.ReaderInterceptorContext;
import java.io.IOException;

/**
 * @author dainguyen.
 */
@Provider
public class XReaderInterceptor implements ReaderInterceptor {
    private static final Log LOGGER = LogFactory.getLog(XReaderInterceptor.class);

    @Override
    public Object aroundReadFrom(ReaderInterceptorContext readerInterceptorContext) throws IOException, WebApplicationException {
        try{
            return readerInterceptorContext.proceed();
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            throw e;
        }
    }
}

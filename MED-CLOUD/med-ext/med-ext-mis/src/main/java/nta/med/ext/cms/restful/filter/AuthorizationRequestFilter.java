package nta.med.ext.cms.restful.filter;

import java.io.IOException;
import java.lang.annotation.Annotation;
import java.lang.reflect.Method;
import java.util.List;

import javax.ws.rs.container.ContainerRequestContext;
import javax.ws.rs.container.ContainerRequestFilter;
import javax.ws.rs.container.ResourceInfo;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.ext.Provider;

import org.glassfish.jersey.server.ContainerRequest;
import org.glassfish.jersey.server.ManagedAsync;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.util.CollectionUtils;

import nta.med.core.common.annotation.TokenIgnore;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.ext.cms.caching.TokenManager;
import nta.med.ext.cms.glossary.Message;
import nta.med.ext.cms.model.MessageResponse;
import nta.med.ext.cms.model.cms.CmsContext;
import nta.med.ext.cms.model.cms.CmsSession;

@Provider
public class AuthorizationRequestFilter implements ContainerRequestFilter{

	@Context
	private ResourceInfo resourceInfo;
	
    @Autowired
	private TokenManager<CmsSession> cache;
     
    @Override
    @ManagedAsync
    public void filter(ContainerRequestContext requestContext) throws IOException {    	
    	Method method = resourceInfo.getResourceMethod();
        Annotation[] annotations = method.getDeclaredAnnotations();
        boolean checkToken = true;
        for (Annotation annotation : annotations) {
            if (annotation.annotationType().getSimpleName().equals(TokenIgnore.class.getSimpleName())) {
                checkToken = false;
                break;
            }
        }

        if(checkToken){
        	filterClientRequest(requestContext);
        }
    }

    private void filterClientRequest(ContainerRequestContext requestContext) {
    	cache = cache == null ? SpringBeanFactory.beanFactory.getBean(TokenManager.class) : cache; 
    	List<String> headers = ((ContainerRequest) requestContext).getRequestHeader("token");
        if (CollectionUtils.isEmpty(headers)) {
        	unAuthorizedResponse(requestContext);
        } else {
            String token = headers.get(0);
            CmsSession cmsSession = cache.get(token);
            if (cmsSession == null) {
            	unAuthorizedResponse(requestContext);
            } else {
            	CmsContext.init(cmsSession);
                requestContext.setProperty("context", CmsContext.current());
            }
        }
    }

    private void unAuthorizedResponse(ContainerRequestContext requestContext) {
        MessageResponse<String> response = new MessageResponse<String>();
        response.setStatus(Message.FAIL.getValue());
        response.setMessage(Message.MESSAGE_TOKEN_INVALID.getValue());
        requestContext.abortWith(Response
                .status(Response.Status.UNAUTHORIZED)
                .entity(response).type(MediaType.APPLICATION_JSON)
                .build());
    }
}

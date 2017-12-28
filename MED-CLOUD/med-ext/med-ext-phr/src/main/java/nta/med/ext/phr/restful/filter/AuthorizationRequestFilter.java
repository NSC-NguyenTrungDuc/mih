package nta.med.ext.phr.restful.filter;

import java.io.IOException;
import java.lang.annotation.Annotation;
import java.lang.reflect.Method;
import java.util.List;
import java.util.Map;

import javax.ws.rs.container.ContainerRequestContext;
import javax.ws.rs.container.ContainerRequestFilter;
import javax.ws.rs.container.ResourceInfo;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.MultivaluedMap;
import javax.ws.rs.core.Response;
import javax.ws.rs.ext.Provider;

/**
 * @author DEV-TiepNM
 */

import nta.med.common.util.Strings;
import org.apache.commons.collections.CollectionUtils;
import org.glassfish.jersey.server.ContainerRequest;
import org.glassfish.jersey.server.ManagedAsync;

import nta.med.core.common.annotation.TokenIgnore;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.data.dao.phr.ProfileRepository;
import nta.med.ext.phr.caching.TokenManager;
import nta.med.ext.phr.glossary.Constant;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.MessageResponse;
import nta.med.ext.phr.model.PhrContext;
import nta.med.ext.phr.model.UserInfo;

@Provider
public class AuthorizationRequestFilter implements ContainerRequestFilter {

    @Context
    private ResourceInfo resourceInfo;

    private ProfileRepository profileRepository;

    private TokenManager<UserInfo> cache;

    public AuthorizationRequestFilter(){
    	this.profileRepository = SpringBeanFactory.beanFactory.getBean(ProfileRepository.class);
    	this.cache = SpringBeanFactory.beanFactory.getBean(TokenManager.class);
    }
    
    @Override
    @ManagedAsync
    public void filter(ContainerRequestContext requestContext)
            throws IOException {
    	
        Method method = resourceInfo.getResourceMethod();
        Annotation[] annotations = method.getDeclaredAnnotations();
        boolean checkToken = true;
        for (Annotation annotation : annotations) {
            if (annotation.annotationType().getSimpleName().equals(TokenIgnore.class.getSimpleName())) {
                checkToken = false;
                break;
            }
        }
        if (method.getName().equals(Constant.PHR_VERIFY_METHOD)) {
            filterUrlVerifyAccount(requestContext);
        } else if (checkToken) {
            filterClientRequest(requestContext);
        }

    }

    private void filterClientRequest(ContainerRequestContext requestContext) {
        List<String> headers = ((ContainerRequest) requestContext).getRequestHeader("token");
        List<String> queryTokens = ((ContainerRequest) requestContext).getUriInfo().getQueryParameters().get("token");
        if (CollectionUtils.isEmpty(headers) && CollectionUtils.isEmpty(queryTokens)) {
            returnUnAuthorizedResponse(requestContext);

        } else {
            String token ="";
            if(!CollectionUtils.isEmpty(headers))
            {
                token = headers.get(0);
            }
            if(!CollectionUtils.isEmpty(queryTokens))
            {
                token = queryTokens.get(0);
            }

            if (Strings.isEmpty(token)) {
                returnUnAuthorizedResponse(requestContext);

            }
            UserInfo userInfo = cache.get(token);
            filterUserProfile(requestContext, userInfo);
            if (userInfo == null) {
                returnUnAuthorizedResponse(requestContext);
            } else {
                PhrContext.init(userInfo.getUserId(), userInfo.getUserName(), userInfo.getPassword(), userInfo.getDefaultProfileId(), userInfo.getProfileIds());
                requestContext.setProperty("context", PhrContext.current());
            }

        }
    }

    private void filterUrlVerifyAccount(ContainerRequestContext requestContext) {
        String str = ((ContainerRequest) requestContext).getPath(true);
        String[] temp = str.split("/");
        if (temp.length > 3) {
            UserInfo userInfo = cache.get(temp[3]);
            if (userInfo == null) {
                returnUnAuthorizedResponse(requestContext);
            } else {
                PhrContext.init(userInfo.getUserId(), userInfo.getUserName(), userInfo.getPassword(), userInfo.getDefaultProfileId(), userInfo.getProfileIds());
                requestContext.setProperty("context", PhrContext.current());
            }
        }
    }

    private void filterUserProfile(ContainerRequestContext requestContext, UserInfo userInfo) {
        List<String> uris = requestContext.getUriInfo().getMatchedURIs();
        if(hasFilterUserProfile(userInfo, uris))
        {
            MultivaluedMap<String, String> map = requestContext.getUriInfo().getPathParameters();

            for(Map.Entry<String, List<String>> entry : map.entrySet())
            {
                if((entry.getKey().equals("profileId") && !userInfo.getProfileIds().contains(Long.valueOf(entry.getValue().get(0))))
                		|| ((entry.getKey().equals("activeProfileId") && !userInfo.getProfileIds().contains(Long.valueOf(entry.getValue().get(0))))))
                {
                    //check profile in db
                    List<Long> profileIds = profileRepository.getProfileIds(userInfo.getUserId());
                    if(CollectionUtils.isEmpty(profileIds) || !profileIds.contains(Long.valueOf(entry.getValue().get(0))))
                    {
                        returnProfileNotExistResponse(requestContext);
                    }

                }
            }
        }
    }

    private boolean hasFilterUserProfile(UserInfo userInfo, List<String> uris) {
        return userInfo != null && !CollectionUtils.isEmpty(uris) && uris.size() > 1 && uris.get(1).equals("profiles");
    }

    private void returnProfileNotExistResponse(ContainerRequestContext requestContext)
    {
        MessageResponse response = new MessageResponse();
        response.setStatus(Message.FAIL.getValue());
        response.setMessage(Message.MESSAGE_PROFILE_NOT_FOUND.getValue());
        requestContext.abortWith(Response
                .status(Response.Status.UNAUTHORIZED)
                .entity(response).type(MediaType.APPLICATION_JSON)
                .build());
    }
    private void returnUnAuthorizedResponse(ContainerRequestContext requestContext) {
        MessageResponse response = new MessageResponse();
        response.setStatus(Message.FAIL.getValue());
        response.setMessage(Message.MESSAGE_TOKEN_INVALID.getValue());
        requestContext.abortWith(Response
                .status(Response.Status.UNAUTHORIZED)
                .entity(response).type(MediaType.APPLICATION_JSON)
                .build());
    }
}
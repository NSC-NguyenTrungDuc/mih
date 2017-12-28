package nta.mss.custom.authentication;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.security.core.Authentication;
import org.springframework.security.web.authentication.SimpleUrlAuthenticationSuccessHandler;
import org.springframework.security.web.savedrequest.HttpSessionRequestCache;
import org.springframework.security.web.savedrequest.RequestCache;
import org.springframework.security.web.savedrequest.SavedRequest;

/**
 * 
 * @author TungLT
 * Customize hander request
 */

public class ForwardRequestAuthenticationSuccessHandler extends SimpleUrlAuthenticationSuccessHandler {
	 protected final Log logger = LogFactory.getLog(this.getClass());

	    private RequestCache requestCache = new HttpSessionRequestCache();

	    @Override
	    public void onAuthenticationSuccess(HttpServletRequest request, HttpServletResponse response,
	            Authentication authentication) throws ServletException, IOException {
	        SavedRequest savedRequest = requestCache.getRequest(request, response);
	        
	        if (savedRequest == null) {
	            super.onAuthenticationSuccess(request, response, authentication);

	            return;
	        }
	        String targetUrl = savedRequest.getRedirectUrl();
	        if (response.isCommitted()) {
	            logger.debug("Response has already been committed. Unable to redirect to " + targetUrl);
	            return;
	        }
	        clearAuthenticationAttributes(request);

	        // Use the DefaultSavedRequest URL
	        logger.debug("Redirecting to DefaultSavedRequest Url: " + targetUrl);
	        getRedirectStrategy().sendRedirect(request, response, targetUrl);
	    }

	    public void setRequestCache(RequestCache requestCache) {
	        this.requestCache = requestCache;
	    }
}

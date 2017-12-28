package nta.mss.custom.authentication;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.security.core.Authentication;
import org.springframework.security.core.AuthenticationException;

import nta.mss.info.LocalMssContext;
import nta.mss.misc.common.MssContextHolder;

public class UsernamePasswordAuthenticationFilter extends org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter {
	
	public static ThreadLocal<LocalMssContext> localMssContext = new ThreadLocal<>();
//	public static ThreadLocal<String> PASSWORD = new ThreadLocal<>();
	
	@Override
	public Authentication attemptAuthentication(HttpServletRequest request, HttpServletResponse response) throws AuthenticationException {
		LocalMssContext local = new LocalMssContext();
		local.setHospitalId(request.getParameter("j_hospital_id"));
		local.setPassword(request.getParameter("j_password"));
		MssContextHolder.setUserBack(request.getParameter("j_username"));
		localMssContext.set(local);
		return super.attemptAuthentication(request, response);		
	}
	 
}

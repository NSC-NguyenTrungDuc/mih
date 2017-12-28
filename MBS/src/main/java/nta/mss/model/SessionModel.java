package nta.mss.model;

import java.util.Date;

/**
 * SessionModel.java
 *
 * @author DinhNX
 * @CrtDate Aug 21, 2014
 *
 */
public class SessionModel {
	private String sessionId;
	private String accessIp;
	private Date expired;
	
	public String getSessionId() {
		return sessionId;
	}
	
	public void setSessionId(String sessionId) {
		this.sessionId = sessionId;
	}
	
	public String getAccessIp() {
		return accessIp;
	}
	
	public void setAccessIp(String accessIp) {
		this.accessIp = accessIp;
	}
	
	public Date getExpired() {
		return expired;
	}
	
	public void setExpired(Date expired) {
		this.expired = expired;
	}
}

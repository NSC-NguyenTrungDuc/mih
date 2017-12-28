package nta.med.ext.phr.model;

import java.io.Serializable;

/**
 * The persistent class for the PHR_TOKEN database table.
 * 
 */

public class TokenModel implements Serializable {
	private static final long serialVersionUID = 1L;
	private String token;

	public TokenModel() {
	}


	public String getToken() {
		return this.token;
	}

	public void setToken(String token) {
		this.token = token;
	}


}
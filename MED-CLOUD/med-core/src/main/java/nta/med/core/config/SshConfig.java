package nta.med.core.config;

public class SshConfig {
	private final String host;
	private final String user;
	private final String pass;
	private final Integer port;
	private final String scriptPath;
	private final String certPath;
	public SshConfig(String host, String user, String pass, Integer port, String scriptPath, String certPath) {
		super();
		this.host = host;
		this.user = user;
		this.pass = pass;
		this.port = port;
		this.scriptPath = scriptPath;
		this.certPath = certPath;
	}
	public String getHost() {
		return host;
	}
	public String getUser() {
		return user;
	}
	public String getPass() {
		return pass;
	}
	public Integer getPort() {
		return port;
	}
	public String getScriptPath() {
		return scriptPath;
	}
	public String getCertPath() {
		return certPath;
	}
}

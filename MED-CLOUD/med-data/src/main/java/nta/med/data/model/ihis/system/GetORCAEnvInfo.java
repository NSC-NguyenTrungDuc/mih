package nta.med.data.model.ihis.system;

public class GetORCAEnvInfo {
	private String orcaIp;
	private String orcaPort;
	private String orcaUser;
	private String orcaPwd;

	public GetORCAEnvInfo(String orcaIp, String orcaPort, String orcaUser, String orcaPwd) {
		super();
		this.orcaIp = orcaIp;
		this.orcaPort = orcaPort;
		this.orcaUser = orcaUser;
		this.orcaPwd = orcaPwd;
	}

	public String getOrcaIp() {
		return orcaIp;
	}

	public void setOrcaIp(String orcaIp) {
		this.orcaIp = orcaIp;
	}

	public String getOrcaPort() {
		return orcaPort;
	}

	public void setOrcaPort(String orcaPort) {
		this.orcaPort = orcaPort;
	}

	public String getOrcaUser() {
		return orcaUser;
	}

	public void setOrcaUser(String orcaUser) {
		this.orcaUser = orcaUser;
	}

	public String getOrcaPwd() {
		return orcaPwd;
	}

	public void setOrcaPwd(String orcaPwd) {
		this.orcaPwd = orcaPwd;
	}

}

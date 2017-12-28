package nta.med.orca.gw.api.contracts.message;

public class OrcaEnvInfo {

	private String hospCode;
	private String orcaIp;
	private String orcaPort;
	private String orcaUser;
	private String orcaPwd;

	public OrcaEnvInfo() {
		super();
	}

	public OrcaEnvInfo(String hospCode, String orcaIp, String orcaPort, String orcaUser, String orcaPwd) {
		super();
		this.hospCode = hospCode;
		this.orcaIp = orcaIp;
		this.orcaPort = orcaPort;
		this.orcaUser = orcaUser;
		this.orcaPwd = orcaPwd;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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

package nta.med.core.config;

public class MailInfoConfig {
	private final String misBackEndLink;
	private final String misFrontEndLink;
	private final String mbsBackEndLink;
	private final String mbsFrontEndLink;
	private final String portalLink;
	private final String mbsPassword;
	private final String linkDownloadVpn;
	private final String linkDownloadKcck;
	private final String linkDownloadKcckVn;
	public MailInfoConfig(String misBackEndLink, String misFrontEndLink, String mbsBackEndLink, String mbsFrontEndLink,
			String portalLink, String mbsPassword, String linkDownloadVpn, String linkDownloadKcck,
			String linkDownloadKcckVn) {
		super();
		this.misBackEndLink = misBackEndLink;
		this.misFrontEndLink = misFrontEndLink;
		this.mbsBackEndLink = mbsBackEndLink;
		this.mbsFrontEndLink = mbsFrontEndLink;
		this.portalLink = portalLink;
		this.mbsPassword = mbsPassword;
		this.linkDownloadVpn = linkDownloadVpn;
		this.linkDownloadKcck = linkDownloadKcck;
		this.linkDownloadKcckVn = linkDownloadKcckVn;
	}
	public String getMisBackEndLink() {
		return misBackEndLink;
	}
	public String getMisFrontEndLink() {
		return misFrontEndLink;
	}
	public String getMbsBackEndLink() {
		return mbsBackEndLink;
	}
	public String getMbsFrontEndLink() {
		return mbsFrontEndLink;
	}
	public String getPortalLink() {
		return portalLink;
	}
	public String getMbsPassword() {
		return mbsPassword;
	}
	public String getLinkDownloadVpn() {
		return linkDownloadVpn;
	}
	public String getLinkDownloadKcck() {
		return linkDownloadKcck;
	}
	public String getLinkDownloadKcckVn() {
		return linkDownloadKcckVn;
	}
	
}

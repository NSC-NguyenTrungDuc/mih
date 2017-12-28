package nta.med.data.model.ihis.emr;

public class OCS2015U03AllLinkClinicInfo {
	private String hospCodeLink;
	private String bunhoLink;
	private String linkType;
	public OCS2015U03AllLinkClinicInfo(String hospCodeLink, String bunhoLink, String linkType) {
		super();
		this.hospCodeLink = hospCodeLink;
		this.bunhoLink = bunhoLink;
		this.linkType = linkType;
	}
	public String getHospCodeLink() {
		return hospCodeLink;
	}
	public void setHospCodeLink(String hospCodeLink) {
		this.hospCodeLink = hospCodeLink;
	}
	public String getBunhoLink() {
		return bunhoLink;
	}
	public void setBunhoLink(String bunhoLink) {
		this.bunhoLink = bunhoLink;
	}
	public String getLinkType() {
		return linkType;
	}
	public void setLinkType(String linkType) {
		this.linkType = linkType;
	}
}

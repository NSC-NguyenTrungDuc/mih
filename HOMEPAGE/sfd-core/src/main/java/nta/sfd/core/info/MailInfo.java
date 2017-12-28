package nta.sfd.core.info;

import java.io.Serializable;
import java.util.List;

// TODO: Auto-generated Javadoc
/**
 * The Class MailInfo.
 *
 * @author MinhLS
 * @crtDate 2015/07/02
 */
public class MailInfo implements Serializable{
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = -157511726959290226L;
	
	/** The session id. */
	private String customerName;
	
	private String companyName;
	
	private String hospitalName;
	
	private String email;
	
	private String content;
	
	private String registerName;
	
	private String userId;
	
	private String password;
	
	private String confirmLink;
	
	private String misBackEndUrl;

	private String misFrontEndUrl;
	
	private String mbsBackEndUrl;
	
	private String mbsFrontEndUrl;
	
	private String portalUrl;
	
	private String mbsPassword;
	
	private String linkDownloadVpn;
	
	private String linkDownloadKcck;
	
	private String rejectLink;
	
	private String approveLink;
	
	private String hospRegLink;
	private String phone;
	private boolean additionalAcc;

	/**
	 * Gets the customer name.
	 *
	 * @return the customer name
	 */
	public String getCustomerName() {
		return customerName;
	}

	/**
	 * Sets the customer name.
	 *
	 * @param customerName the new customer name
	 */
	public void setCustomerName(String customerName) {
		this.customerName = customerName;
	}

	public String getCompanyName() {
		return companyName;
	}

	public void setCompanyName(String companyName) {
		this.companyName = companyName;
	}

	public String getHospitalName() {
		return hospitalName;
	}

	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getRegisterName() {
		return registerName;
	}

	public void setRegisterName(String registerName) {
		this.registerName = registerName;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getConfirmLink() {
		return confirmLink;
	}

	public void setConfirmLink(String confirmLink) {
		this.confirmLink = confirmLink;
	}

	public String getMisBackEndUrl() {
		return misBackEndUrl;
	}

	public void setMisBackEndUrl(String misBackEndUrl) {
		this.misBackEndUrl = misBackEndUrl;
	}

	public String getMisFrontEndUrl() {
		return misFrontEndUrl;
	}

	public void setMisFrontEndUrl(String misFrontEndUrl) {
		this.misFrontEndUrl = misFrontEndUrl;
	}

	public String getMbsBackEndUrl() {
		return mbsBackEndUrl;
	}

	public void setMbsBackEndUrl(String mbsBackEndUrl) {
		this.mbsBackEndUrl = mbsBackEndUrl;
	}

	public String getMbsFrontEndUrl() {
		return mbsFrontEndUrl;
	}

	public void setMbsFrontEndUrl(String mbsFrontEndUrl) {
		this.mbsFrontEndUrl = mbsFrontEndUrl;
	}

	public String getPortalUrl() {
		return portalUrl;
	}

	public void setPortalUrl(String portalUrl) {
		this.portalUrl = portalUrl;
	}

	public String getMbsPassword() {
		return mbsPassword;
	}

	public void setMbsPassword(String mbsPassword) {
		this.mbsPassword = mbsPassword;
	}

	public String getLinkDownloadVpn() {
		return linkDownloadVpn;
	}

	public void setLinkDownloadVpn(String linkDownloadVpn) {
		this.linkDownloadVpn = linkDownloadVpn;
	}

	public String getLinkDownloadKcck() {
		return linkDownloadKcck;
	}

	public void setLinkDownloadKcck(String linkDownloadKcck) {
		this.linkDownloadKcck = linkDownloadKcck;
	}

	public String getRejectLink() {
		return rejectLink;
	}

	public void setRejectLink(String rejectLink) {
		this.rejectLink = rejectLink;
	}

	public String getApproveLink() {
		return approveLink;
	}

	public void setApproveLink(String approveLink) {
		this.approveLink = approveLink;
	}

	public String getHospRegLink() {
		return hospRegLink;
	}

	public void setHospRegLink(String hospRegLink) {
		this.hospRegLink = hospRegLink;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	public boolean  getAdditionalAcc() {
		return additionalAcc;
	}

	public void setAdditionalAcc(boolean additionalAcc) {
		this.additionalAcc = additionalAcc;
	}
	
}

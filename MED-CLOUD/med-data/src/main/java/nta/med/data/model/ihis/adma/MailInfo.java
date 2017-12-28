package nta.med.data.model.ihis.adma;

import java.io.Serializable;

public class MailInfo implements Serializable{
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = -157511726959290226L;
	
	/** The session id. */
	private String hospitalCode;
	
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
	private String clinicType;
	private String scale;
	
	// START: send payment
	private String yoyang_name;
	private String addressHosp;
	private String patientName;
	private String telHosp;
	private String emailHosp;
	private String locale;
	private String mailPatient;
	private String mailTemplateIt;
	private String subject;
	private String naewonDate;
	private String jubsuTime;
	private String expectDate;
	private String total;
	private String totalDiscount;
	private String totalPaid;
	private String totalPaying;
	// END: send payment
	
	/**
	 * Gets the customer name.
	 *
	 * @return the customer name
	 */
	public String getHospitalCode() {
		return hospitalCode;
	}

	/**
	 * Sets the customer name.
	 *
	 * @param customerName the new customer name
	 */
	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
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

	public String getClinicType() {
		return clinicType;
	}

	public void setClinicType(String clinicType) {
		this.clinicType = clinicType;
	}

	public String getScale() {
		return scale;
	}

	public void setScale(String scale) {
		this.scale = scale;
	}

	public String getYoyang_name() {
		return yoyang_name;
	}

	public void setYoyang_name(String yoyang_name) {
		this.yoyang_name = yoyang_name;
	}

	public String getAddressHosp() {
		return addressHosp;
	}

	public void setAddressHosp(String addressHosp) {
		this.addressHosp = addressHosp;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getTelHosp() {
		return telHosp;
	}

	public void setTelHosp(String telHosp) {
		this.telHosp = telHosp;
	}

	public String getEmailHosp() {
		return emailHosp;
	}

	public void setEmailHosp(String emailHosp) {
		this.emailHosp = emailHosp;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getMailPatient() {
		return mailPatient;
	}

	public void setMailPatient(String mailPatient) {
		this.mailPatient = mailPatient;
	}

	public String getMailTemplateIt() {
		return mailTemplateIt;
	}

	public void setMailTemplateIt(String mailTemplateIt) {
		this.mailTemplateIt = mailTemplateIt;
	}

	public String getSubject() {
		return subject;
	}

	public void setSubject(String subject) {
		this.subject = subject;
	}

	public String getNaewonDate() {
		return naewonDate;
	}

	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}

	public String getJubsuTime() {
		return jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}

	public String getTotal() {
		return total;
	}

	public void setTotal(String total) {
		this.total = total;
	}

	public String getTotalDiscount() {
		return totalDiscount;
	}

	public void setTotalDiscount(String totalDiscount) {
		this.totalDiscount = totalDiscount;
	}

	public String getTotalPaid() {
		return totalPaid;
	}

	public void setTotalPaid(String totalPaid) {
		this.totalPaid = totalPaid;
	}

	public String getTotalPaying() {
		return totalPaying;
	}

	public void setTotalPaying(String totalPaying) {
		this.totalPaying = totalPaying;
	}

	public String getExpectDate() {
		return expectDate;
	}

	public void setExpectDate(String expectDate) {
		this.expectDate = expectDate;
	}
	
}

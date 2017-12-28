package nta.med.ext.registration.model;


import org.hibernate.validator.constraints.Email;
import org.hibernate.validator.constraints.NotEmpty;

import javax.validation.constraints.Size;

import java.math.BigDecimal;
import java.sql.Timestamp;

/**
 * The persistent class for the HOSPITAL_REGISTER database table.
 *
 * @author MinhLS
 * @crtDate 2015/07/03
 */
public class HospitalRegisterModel {
	
	/** The Constant serialVersionUID. */
	private static final long serialVersionUID = 1L;
	
	/** The hospital register id. */
	private Integer hospitalRegisterId;
	
	/** The expired. */
	private Timestamp expired;
	
	/** The hospital code. */
	private String hospitalCode;
	
	/** The hospital name. */
	@NotEmpty
	@Size(max = 256)
	private String hospitalName;
	
	/** The hospital name furigana. */
	private String hospitalNameFurigana;
	
	/** The session language. */
	private String language;
	
	/** The phone. */
	private String phone;
	
	/** The register date. */
	private Timestamp registerDate;
	
	/** The register email. */
	@NotEmpty
	@Email
	@Size(max = 128)
	private String registerEmail;
	
	/** The register name. */
	@NotEmpty
	@Size(max = 256)
	private String registerName;
	
	/** The register name furigana. */
	private String registerNameFurigana;
	
	/** The register url. */
	private String registerUrl;
	
	/** The session id. */
	private String sessionId;
	
	/** The status. */
	private Integer status;

	/** The status. */
	private String type;
	
	/** The session timeZone. */
	private Integer timeZone;
	
	/** The locale. */
	private String locale;
	
	/** The session vpnYn. */
	private String vpnYn;

	/** The demoFlg. */
	private BigDecimal demoFlg;
	
	private String scale;
	private String clinicType;
	private String clinicPackage;
	
	/**
	 * Instantiates a new hospital register.
	 */


	/**
	 * Gets the hospital register id.
	 *
	 * @return the hospital register id
	 */
	public Integer getHospitalRegisterId() {
		return hospitalRegisterId;
	}

	/**
	 * Sets the hospital register id.
	 *
	 * @param hospitalRegisterId the new hospital register id
	 */
	public void setHospitalRegisterId(Integer hospitalRegisterId) {
		this.hospitalRegisterId = hospitalRegisterId;
	}

	/**
	 * Gets the expired.
	 *
	 * @return the expired
	 */
	public Timestamp getExpired() {
		return expired;
	}

	/**
	 * Sets the expired.
	 *
	 * @param expired the new expired
	 */
	public void setExpired(Timestamp expired) {
		this.expired = expired;
	}

	/**
	 * Gets the hospital code.
	 *
	 * @return the hospital code
	 */
	public String getHospitalCode() {
		return hospitalCode;
	}

	/**
	 * Sets the hospital code.
	 *
	 * @param hospitalCode the new hospital code
	 */
	public void setHospitalCode(String hospitalCode) {
		this.hospitalCode = hospitalCode;
	}

	/**
	 * Gets the hospital name.
	 *
	 * @return the hospital name
	 */
	public String getHospitalName() {
		return hospitalName;
	}

	/**
	 * Sets the hospital name.
	 *
	 * @param hospitalName the new hospital name
	 */
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	/**
	 * Gets the hospital name furigana.
	 *
	 * @return the hospital name furigana
	 */
	public String getHospitalNameFurigana() {
		return hospitalNameFurigana;
	}

	/**
	 * Sets the hospital name furigana.
	 *
	 * @param hospitalNameFurigana the new hospital name furigana
	 */
	public void setHospitalNameFurigana(String hospitalNameFurigana) {
		this.hospitalNameFurigana = hospitalNameFurigana;
	}

	/**
	 * Gets the locale.
	 *
	 * @return the locale
	 */
	public String getLocale() {
		return locale;
	}

	/**
	 * Sets the locale.
	 *
	 * @param locale the new locale
	 */
	public void setLocale(String locale) {
		this.locale = locale;
	}

	/**
	 * Gets the phone.
	 *
	 * @return the phone
	 */
	public String getPhone() {
		return phone;
	}

	/**
	 * Sets the phone.
	 *
	 * @param phone the new phone
	 */
	public void setPhone(String phone) {
		this.phone = phone;
	}

	/**
	 * Gets the register date.
	 *
	 * @return the register date
	 */
	public Timestamp getRegisterDate() {
		return registerDate;
	}

	/**
	 * Sets the register date.
	 *
	 * @param registerDate the new register date
	 */
	public void setRegisterDate(Timestamp registerDate) {
		this.registerDate = registerDate;
	}

	/**
	 * Gets the register email.
	 *
	 * @return the register email
	 */
	public String getRegisterEmail() {
		return registerEmail;
	}

	/**
	 * Sets the register email.
	 *
	 * @param registerEmail the new register email
	 */
	public void setRegisterEmail(String registerEmail) {
		this.registerEmail = registerEmail;
	}

	/**
	 * Gets the register name.
	 *
	 * @return the register name
	 */
	public String getRegisterName() {
		return registerName;
	}

	/**
	 * Sets the register name.
	 *
	 * @param registerName the new register name
	 */
	public void setRegisterName(String registerName) {
		this.registerName = registerName;
	}

	/**
	 * Gets the register name furigana.
	 *
	 * @return the register name furigana
	 */
	public String getRegisterNameFurigana() {
		return registerNameFurigana;
	}

	/**
	 * Sets the register name furigana.
	 *
	 * @param registerNameFurigana the new register name furigana
	 */
	public void setRegisterNameFurigana(String registerNameFurigana) {
		this.registerNameFurigana = registerNameFurigana;
	}

	/**
	 * Gets the register url.
	 *
	 * @return the register url
	 */
	public String getRegisterUrl() {
		return registerUrl;
	}

	/**
	 * Sets the register url.
	 *
	 * @param registerUrl the new register url
	 */
	public void setRegisterUrl(String registerUrl) {
		this.registerUrl = registerUrl;
	}

	/**
	 * Gets the session id.
	 *
	 * @return the session id
	 */
	public String getSessionId() {
		return sessionId;
	}

	/**
	 * Sets the session id.
	 *
	 * @param sessionId the new session id
	 */
	public void setSessionId(String sessionId) {
		this.sessionId = sessionId;
	}

	/**
	 * Gets the status.
	 *
	 * @return the status
	 */
	public Integer getStatus() {
		return status;
	}

	/**
	 * Sets the status.
	 *
	 * @param status the new status
	 */
	public void setStatus(Integer status) {
		this.status = status;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}
	
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

	public Integer getTimeZone() {
		return timeZone;
	}

	public void setTimeZone(Integer timeZone) {
		this.timeZone = timeZone;
	}

	public String getVpnYn() {
		return vpnYn;
	}

	public void setVpnYn(String vpnYn) {
		this.vpnYn = vpnYn;
	}

	public String getScale() {
		return scale;
	}

	public void setScale(String scale) {
		this.scale = scale;
	}

	public String getClinicPackage() {
		return clinicPackage;
	}

	public void setClinicPackage(String clinicPackage) {
		this.clinicPackage = clinicPackage;
	}

	public String getClinicType() {
		return clinicType;
	}

	public void setClinicType(String clinicType) {
		this.clinicType = clinicType;
	}

	public BigDecimal getDemoFlg() {
		return demoFlg;
	}

	public void setDemoFlg(BigDecimal demoFlg) {
		this.demoFlg = demoFlg;
	}

}
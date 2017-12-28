package nta.med.core.domain.hp;


import javax.persistence.*;
import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;


// TODO: Auto-generated Javadoc

/**
 * The persistent class for the HOSPITAL_REGISTER database table.
 *
 * @author MinhLS
 * @crtDate 2015/07/03
 */
@Entity
@Table(name = "HOSPITAL_REGISTER")
public class HospitalRegister implements Serializable {

    /**
     * The Constant serialVersionUID.
     */
    private static final long serialVersionUID = 1L;

    /**
     * The hospital register id.
     */
    private Integer hospitalRegisterId;

    /**
     * The expired.
     */
    private Timestamp expired;

    /**
     * The hospital code.
     */
    private String hospitalCode;

    /**
     * The hospital name.
     */
    private String hospitalName;

    /**
     * The hospital name furigana.
     */
    private String hospitalNameFurigana;

    /**
     * The locale.
     */
    private String locale;

    /**
     * The phone.
     */
    private String phone;

    /**
     * The register date.
     */
    private Timestamp registerDate;

    /**
     * The register email.
     */
    private String registerEmail;

    /**
     * The register name.
     */
    private String registerName;

    /**
     * The register name furigana.
     */
    private String registerNameFurigana;

    /**
     * The register url.
     */
    private String registerUrl;

    /**
     * The session id.
     */
    private String sessionId;

    /**
     * The status.
     */
    private Integer status;

    /**
     * The type.
     */
    private String type;

    /**
     * The session language.
     */
    private String language;

    /**
     * The session timeZone.
     */
    private Integer timeZone;

    /**
     * The session vpnYn.
     */
    private String vpnYn;
    
    /** The demoFlg. */
	private BigDecimal demoFlg;
	
    private Integer activeFlg;

    @Temporal(TemporalType.TIMESTAMP)
    private Date created;

    @Temporal(TemporalType.TIMESTAMP)
    private Date updated;

    private String scale;
    private String clinicType;
    private String clinicPackage;

    /**
     * Instantiates a new hospital register.
     */

    public HospitalRegister() {
    }

    /**
     * Gets the hospital register id.
     *
     * @return the hospital register id
     */
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "HOSPITAL_REGISTER_ID", unique = true, nullable = false)
    public Integer getHospitalRegisterId() {
        return this.hospitalRegisterId;
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
        return this.expired;
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
    @Column(name = "HOSPITAL_CODE")
    public String getHospitalCode() {
        return this.hospitalCode;
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
    @Column(name = "HOSPITAL_NAME")
    public String getHospitalName() {
        return this.hospitalName;
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
    @Column(name = "HOSPITAL_NAME_FURIGANA")
    public String getHospitalNameFurigana() {
        return this.hospitalNameFurigana;
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
        return this.locale;
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
        return this.phone;
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
    @Column(name = "REGISTER_DATE")
    public Timestamp getRegisterDate() {
        return this.registerDate;
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
    @Column(name = "REGISTER_EMAIL")
    public String getRegisterEmail() {
        return this.registerEmail;
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
    @Column(name = "REGISTER_NAME")
    public String getRegisterName() {
        return this.registerName;
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
    @Column(name = "REGISTER_NAME_FURIGANA")
    public String getRegisterNameFurigana() {
        return this.registerNameFurigana;
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
    @Column(name = "REGISTER_URL")
    public String getRegisterUrl() {
        return this.registerUrl;
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
    @Column(name = "SESSION_ID")
    public String getSessionId() {
        return this.sessionId;
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
        return this.status;
    }

    /**
     * Sets the status.
     *
     * @param status the new status
     */
    public void setStatus(Integer status) {
        this.status = status;
    }

    @Column(name = "TYPE")
    public String getType() {
        return type;
    }


    public void setType(String type) {
        this.type = type;
    }

    @Column(name = "VPN_YN")
    public String getVpnYn() {
        return vpnYn;
    }

    public void setVpnYn(String vpnYn) {
        this.vpnYn = vpnYn;
    }

    @Column(name = "LANGUAGE")
    public String getLanguage() {
        return language;
    }


    public void setLanguage(String language) {
        this.language = language;
    }

    @Column(name = "TIME_ZONE")
    public Integer getTimeZone() {
        return timeZone;
    }


    public void setTimeZone(Integer timeZone) {
        this.timeZone = timeZone;
    }


    @Column(name = "ACTIVE_FLG", insertable = false, updatable = true)
    public Integer getActiveFlg() {
        return activeFlg;
    }

    public void setActiveFlg(Integer activeFlg) {
        this.activeFlg = activeFlg;
    }

    public Date getCreated() {
        return created;
    }

    public void setCreated(Date created) {
        this.created = created;
    }

    public Date getUpdated() {
        return updated;
    }

    public void setUpdated(Date updated) {
        this.updated = updated;
    }

    /* (non-Javoc)
         * @see java.lang.Object#toString()
         */
    @Column(name = "SCALE")
    public String getScale() {
        return scale;
    }

    public void setScale(String scale) {
        this.scale = scale;
    }
    @Column(name = "CLINIC_TYPE")
    public String getClinicType() {
        return clinicType;
    }

    public void setClinicType(String clinicType) {
        this.clinicType = clinicType;
    }
    @Column(name = "PACKAGE")
    public String getClinicPackage() {
        return clinicPackage;
    }

    public void setClinicPackage(String clinicPackage) {
        this.clinicPackage = clinicPackage;
    }
    
    @Column(name="DEMO_FLG")
    public BigDecimal getDemoFlg() {
		return demoFlg;
	}

	public void setDemoFlg(BigDecimal demoFlg) {
		this.demoFlg = demoFlg;
	}

	@Override
    public String toString() {
        return "HospitalRegister [hospitalRegisterId=" + hospitalRegisterId
                + ", expired=" + expired + ", hospitalCode=" + hospitalCode
                + ", hospitalName=" + hospitalName + ", hospitalNameFurigana="
                + hospitalNameFurigana + ", locale=" + locale + ", phone="
                + phone + ", registerDate=" + registerDate + ", registerEmail="
                + registerEmail + ", registerName=" + registerName
                + ", registerNameFurigana=" + registerNameFurigana
                + ", registerUrl=" + registerUrl + ", sessionId=" + sessionId
                + ", vpnYn=" + vpnYn + ", language=" + language + ", timeZone=" + timeZone
                + ", status=" + status + ", demoFlg=" + demoFlg +  "]";
    }

}
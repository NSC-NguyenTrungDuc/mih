package nta.med.ext.registration.glosarry;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

/**
 * The Class MedConfiguration.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public class MedConfiguration {
	private static final Logger LOG = LogManager.getLogger(MedConfiguration.class);
	
	/** The Constant CONFIG_PATH. */
	private static final String CONFIG_PATH = "configPath";
	
	/** The Constant CONFIG_FILE. */
	private static final String CONFIG_FILE = "configs.properties";
	
	/** The Constant SECRET_KEY. */
	private static final String SECRET_KEY = "token.secret.key";
	
	/** The Constant MED_SECRET_SPEC. */
	private static final String MED_SECRET_SPEC = "token.med.secret.spec";
	
	private static final String DIR_FILE_UPLOAD = "dir.file.upload";
	private static final String SERVER_ADDRESS = "server.address";
	private static final String MAIL_ADMIN = "mail.admin";
	private static final String COMPANY_NAME = "company.name";
	private static final String PRODUCTION_LINK = "production.link";
	private static final String MAIL_EXPIRED_TIME = "mail.expired.time";
	private static final String WP_EXPIRE_LINK = "wordpress.expire_link";
	private static final String WP_REG_COMPLETED_LINK = "wordpress.register_completed";
	private static final String SECRET_KEY_CAPCHA = "secret_cap_cha";
	private static final String MAIL_MARKETING = "mail.marketing";
	private static final String HOSP_REGISTRATION_LINK = "hosp.registration.link";
	private static final String CONFIRM_REAL_CLINIC_LINK = "confirm.real.clinic.link";
	private static final String REJECT_REG_LINK = "reject.register.link";
	private static final String APPROVE_REG_LINK = "approve.register.link";
	
	private static MedConfiguration instance;
	private static boolean isInitialized = false;
	private String secretKey;
	private String secretSpec;
	private String dirFileUpload;
	private String serverAddress;
	private String mailAdmin;
	private String companyName;
	private String productionLink;
	private String mailExpiredTime;
	private String wpExpireLink;
	private String wpRegCompletedLink;
	private String secretCapcha;
	private String mailMarketing;
	private String hospRegistrationLink;
	private String rejectRegisterLink;
	private String confirmRealClinicLink;
	private String approveRegisterLink;

	/**
	 * Instantiates a new med configuration.
	 */
	private MedConfiguration() {
		
	}
	
	/**
	 * Gets the single instance of MedConfiguration.
	 * 
	 * @return single instance of MedConfiguration
	 * @throws Exception
	 *             the exception
	 */
	public static MedConfiguration getInstance() throws Exception {
		if (instance == null) {
			instance = new MedConfiguration();
		}
		if (!isInitialized) {
			instance.init();
		}
		return instance;
	}
	
	/**
	 * Inits the configuration and get all the values from config files.
	 * 
	 * @throws Exception
	 *             the exception
	 */
	private void init() throws Exception {
		String configPath = System.getProperty(CONFIG_PATH);
        if (StringUtils.isBlank(configPath)) {
        	LOG.error("Config path not found.");
            throw new Exception("Config path not found.");
        }
        Properties props = new Properties();
        FileInputStream fis = null;
        try {
	        fis = new FileInputStream(configPath + System.getProperty("file.separator") + CONFIG_FILE);
	        props.load(fis);
	        // get the properties from properties file
	        secretKey = props.getProperty(SECRET_KEY);
	        secretSpec = props.getProperty(MED_SECRET_SPEC);
	        dirFileUpload = props.getProperty(DIR_FILE_UPLOAD);
	        serverAddress = props.getProperty(SERVER_ADDRESS);
	        mailAdmin = props.getProperty(MAIL_ADMIN);
	        companyName = props.getProperty(COMPANY_NAME);
	        productionLink = props.getProperty(PRODUCTION_LINK);
	        mailExpiredTime = props.getProperty(MAIL_EXPIRED_TIME);
	        wpExpireLink = props.getProperty(WP_EXPIRE_LINK);
	        wpRegCompletedLink = props.getProperty(WP_REG_COMPLETED_LINK);
			secretCapcha = props.getProperty(SECRET_KEY_CAPCHA);
			mailMarketing = props.getProperty(MAIL_MARKETING);
			hospRegistrationLink = props.getProperty(HOSP_REGISTRATION_LINK);
			rejectRegisterLink = props.getProperty(REJECT_REG_LINK);
			confirmRealClinicLink = props.getProperty(CONFIRM_REAL_CLINIC_LINK);
	        approveRegisterLink = props.getProperty(APPROVE_REG_LINK);
        } catch (IOException e) {
			LOG.error("Cannot get config file");
		} finally {
			if (fis != null) {
				try {
					fis.close();
				} catch (IOException e) {
					LOG.error("Cannot close the file input stream", e.getMessage());
				}
			}
		}
	}
	
	/**
	 * Gets the secret key.
	 * 
	 * @return the secret key
	 */
	public String getSecretKey() {
		return secretKey;
	}
	
	/**
	 * Gets the secret spec.
	 * 
	 * @return the secret spec
	 */
	public String getSecretSpec() {
		return secretSpec;
	}
		
	public String getDirFileUpload() {
		return dirFileUpload;
	}

	/**
	 * Gets the server address.
	 *
	 * @return the server address
	 */
	public String getServerAddress() {
		return serverAddress;
	}

	public void setServerAddress(String serverAddress) {
		this.serverAddress = serverAddress;
	}

	public String getMailAdmin() {
		return mailAdmin;
	}

	public String getCompanyName() {
		return companyName;
	}

	public String getProductionLink() {
		return productionLink;
	}

	public String getMailExpiredTime() {
		return mailExpiredTime;
	}

	public String getWpExpireLink() {
		return wpExpireLink;
	}

	public void setWpExpireLink(String wpExpireLink) {
		this.wpExpireLink = wpExpireLink;
	}

	public String getWpRegCompletedLink() {
		return wpRegCompletedLink;
	}

	public void setWpRegCompletedLink(String wpRegCompletedLink) {
		this.wpRegCompletedLink = wpRegCompletedLink;
	}

	public String getSecretCapcha() {
		return secretCapcha;
	}

	public void setSecretCapcha(String secretCapcha) {
		this.secretCapcha = secretCapcha;
	}
	
	public String getMailMarketing() {
		return mailMarketing;
	}

	public void setMailMarketing(String mailMarketing) {
		this.mailMarketing = mailMarketing;
	}

	public String getHospRegistrationLink() {
		return hospRegistrationLink;
	}

	public void setHospRegistrationLink(String hospRegistrationLink) {
		this.hospRegistrationLink = hospRegistrationLink;
	}
	
	public String getRejectRegisterLink() {
		return rejectRegisterLink;
	}

	public void setRejectRegisterLink(String rejectRegisterLink) {
		this.rejectRegisterLink = rejectRegisterLink;
	}

	public String getConfirmRealClinicLink() {
		return confirmRealClinicLink;
	}

	public void setConfirmRealClinicLink(String confirmRealClinicLink) {
		this.confirmRealClinicLink = confirmRealClinicLink;
	}

	public String getApproveRegisterLink() {
		return approveRegisterLink;
	}

	public void setApproveRegisterLink(String approveRegisterLink) {
		this.approveRegisterLink = approveRegisterLink;
	}

}

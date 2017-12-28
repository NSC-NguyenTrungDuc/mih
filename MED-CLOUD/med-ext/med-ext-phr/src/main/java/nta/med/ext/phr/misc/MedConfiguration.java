package nta.med.ext.phr.misc;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

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
}

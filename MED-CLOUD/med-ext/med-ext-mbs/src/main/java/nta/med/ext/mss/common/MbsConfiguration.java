package nta.med.ext.mss.common;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

public class MbsConfiguration {
	
	private static final Logger LOG = LogManager.getLogger(MbsConfiguration.class);
	
	/** The Constant CONFIG_PATH. */
	private static final String CONFIG_PATH = "configPath";
	private static final String CONFIG_FILE = "configs.properties";
	private static final String SERVER_ADDRESS = "server.address";
	private static final String SERVER_ADDRESS_JP = "server.address.jp";
	private static final String LINK_AUTHORIZE_EMAIL = "link.authorize.email";
	private static final String DEFAULT_HOSPITAL_ID = "hospital.default_id";


	private static MbsConfiguration instance;
	private static boolean isInitialized = false;
	private String serverAddress;
	private String serverAddressJp;
	private String linkAuthorizeEmail;
	
	private String defaultHospitalId = "1";
	private String defaultPassWord = "123456";
	/**
	 * Instantiates a new mss configuration.
	 */
	private MbsConfiguration() {
		
	}
	
	/**
	 * Gets the single instance of MssConfiguration.
	 * 
	 * @return single instance of MssConfiguration
	 * @throws Exception
	 *             the exception
	 */
	public static MbsConfiguration getInstance() throws Exception {
		if (instance == null) {
			instance = new MbsConfiguration();
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
			serverAddress = props.getProperty(SERVER_ADDRESS);
			serverAddressJp = props.getProperty(SERVER_ADDRESS_JP);
			linkAuthorizeEmail = props.getProperty(LINK_AUTHORIZE_EMAIL);
			defaultHospitalId = props.getProperty(DEFAULT_HOSPITAL_ID);
			
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

	public String getServerAddress() {
		return serverAddress;
	}

	public void setServerAddress(String serverAddress) {
		this.serverAddress = serverAddress;
	}

	public String getServerAddressJp() {
		return serverAddressJp;
	}

	public void setServerAddressJp(String serverAddressJp) {
		this.serverAddressJp = serverAddressJp;
	}

	public String getLinkAuthorizeEmail() {
		return linkAuthorizeEmail;
	}

	public void setLinkAuthorizeEmail(String linkAuthorizeEmail) {
		this.linkAuthorizeEmail = linkAuthorizeEmail;
	}

	public String getDefaultHospitalId() {
		return defaultHospitalId;
	}

	public void setDefaultHospitalId(String defaultHospitalId) {
		this.defaultHospitalId = defaultHospitalId;
	}

	public String getDefaultPassWord() {
		return defaultPassWord;
	}

	public void setDefaultPassWord(String defaultPassWord) {
		this.defaultPassWord = defaultPassWord;
	}
}

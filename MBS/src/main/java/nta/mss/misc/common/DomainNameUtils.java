package nta.mss.misc.common;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import nta.mss.misc.enums.HospitalLocale;

public class DomainNameUtils {
	/** The Constant LOG. */
	private static final Logger LOG = LogManager.getLogger(DomainNameUtils.class);
	public static String getDomainName(String locale) {
		String domainName = "";
		try {
			domainName = MssConfiguration.getInstance().getServerAddressJp();

			if (HospitalLocale.VI_LOCALE.equals(locale)) {
				domainName = MssConfiguration.getInstance().getServerAddress();
			}

		} catch (Exception ex) {
			LOG.warn("Error when get domain name", ex);
			domainName = null;
		}
		return domainName;
	}
}

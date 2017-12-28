package nta.med.ext.cms.config;

import nta.med.core.config.VertxConfig;

/**
 * @author dainguyen.
 */
public class Configuration extends VertxConfig {

	private final String schema;
	private final String secretKey;
	private final Integer defaultTimeZone;
	private final String mbsFrontEnd;
	private final String mbsBackEnd;
	private final String misFrontEnd;
	private final String misBackEnd;
	private final String portal;
	private String misSurveyLink;

	public Configuration(String vertxClusterHost, Integer vertxClusterPort, Integer vertxInstances, int vertxThreads,
			boolean vertxWorker, boolean vertxVerbose, String schema, boolean loginRequired, boolean shardable,
			int compressThreshold, boolean compressible, String secretKey, boolean exitOnFailDeployment,
			Integer defaultTimeZone, String mbsFrontEnd, String mbsBackEnd, String misFrontEnd, String misBackEnd,
			String portal, String misSurveyLink) {
		super(shardable, vertxClusterHost, loginRequired, vertxInstances, vertxWorker, compressible, vertxVerbose,
				vertxClusterPort, compressThreshold, vertxThreads, exitOnFailDeployment);
		this.schema = schema;
		this.secretKey = secretKey;
		this.defaultTimeZone = defaultTimeZone;
		this.mbsFrontEnd = mbsFrontEnd;
		this.mbsBackEnd = mbsBackEnd;
		this.misFrontEnd = misFrontEnd;
		this.misBackEnd = misBackEnd;
		this.portal = portal;
		this.misSurveyLink = misSurveyLink;
	}

	public String getSchema() {
		return schema;
	}

	public String getSecretKey() {
		return secretKey;
	}

	public Integer getDefaultTimeZone() {
		return defaultTimeZone;
	}

	public String getMbsFrontEnd() {
		return mbsFrontEnd;
	}

	public String getMbsBackEnd() {
		return mbsBackEnd;
	}

	public String getMisFrontEnd() {
		return misFrontEnd;
	}

	public String getMisBackEnd() {
		return misBackEnd;
	}

	public String getPortal() {
		return portal;
	}

	public String getMisSurveyLink() {
		return misSurveyLink;
	}

	public void setMisSurveyLink(String misSurveyLink) {
		this.misSurveyLink = misSurveyLink;
	}

}
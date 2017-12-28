package nta.med.ext.phr.configuration;

public class PhrConfiguration {

	private final String baseUri;

	private final String phrImages;

	private final String confirmAccountUrl;

	private final String confirmPasswordUrl;

	private final String errorConfirmUrl;

	private final String folderUpload;

	private final String urlDownload;

	private final String confirmAccountHasActivedUrl;

	public PhrConfiguration(String baseUri, String phrImages, String confirmAccountUrl, String confirmPasswordUrl,
			String errorConfirmUrl, String folderUpload, String urlDownload, String confirmAccountHasActivedUrl) {
		super();
		this.baseUri = baseUri;
		this.phrImages = phrImages;
		this.confirmAccountUrl = confirmAccountUrl;
		this.confirmPasswordUrl = confirmPasswordUrl;
		this.errorConfirmUrl = errorConfirmUrl;
		this.folderUpload = folderUpload;
		this.urlDownload = urlDownload;
		this.confirmAccountHasActivedUrl  = confirmAccountHasActivedUrl;
	}

	public String getConfirmAccountUrl() {
		return confirmAccountUrl;
	}

	public String getConfirmPasswordUrl() {
		return confirmPasswordUrl;
	}

	public String getErrorConfirmUrl() {
		return errorConfirmUrl;
	}

	public String getBaseUri() {
		return baseUri;
	}

	public String getPhrImages() {
		return phrImages;
	}


	public String getFolderUpload() {
		return folderUpload;
	}

	public String getUrlDownload() {
		return urlDownload;
	}

	public String getConfirmAccountHasActivedUrl() {
		return confirmAccountHasActivedUrl;
	}
}

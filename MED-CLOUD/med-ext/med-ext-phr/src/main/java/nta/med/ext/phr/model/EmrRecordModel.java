package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class EmrRecordModel {

	private String content;
	private String version;

	public EmrRecordModel() {
		super();
	}

	public EmrRecordModel(String content, String version) {
		super();
		this.content = content;
		this.version = version;
	}

	@JsonProperty("content")
	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	@JsonProperty("version")
	public String getVersion() {
		return version;
	}

	public void setVersion(String version) {
		this.version = version;
	}

}

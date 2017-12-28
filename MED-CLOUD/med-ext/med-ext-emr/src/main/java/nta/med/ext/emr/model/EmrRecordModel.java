package nta.med.ext.emr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class EmrRecordModel {

	@JsonProperty("content")
	private String content;

	@JsonProperty("version")
	private String version;

	@JsonProperty("emr_tag")
	private List<EmrTagModel> listEmrTagModel;

	public EmrRecordModel() {
		super();
	}

	public EmrRecordModel(String content, String version) {
		super();
		this.content = content;
		this.version = version;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getVersion() {
		return version;
	}

	public void setVersion(String version) {
		this.version = version;
	}

	public List<EmrTagModel> getListEmrTagModel() {
		return listEmrTagModel;
	}

	public void setListEmrTagModel(List<EmrTagModel> listEmrTagModel) {
		this.listEmrTagModel = listEmrTagModel;
	}
}

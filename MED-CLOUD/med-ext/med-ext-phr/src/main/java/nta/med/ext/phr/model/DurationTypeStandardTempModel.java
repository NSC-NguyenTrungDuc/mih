package nta.med.ext.phr.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class DurationTypeStandardTempModel {
	
	@JsonProperty("profile_id")
	private Long profileId;
	
	@JsonProperty("type")
	private String type;
	
	@JsonProperty("temperature_info")
	private List<StandardTempTemperatureModel> standardTempTemperatureModel;

	@JsonProperty("heartrate_info")
	private List<StandardTempHeartRateChartViewModel> standardTempHeartrateModel;
	
	@JsonProperty("respiration_rate_info")
	private List<StandardTempBreathModel> standardTempBreathModel;
	
	@JsonProperty("blood_pressure_info")
	private List<StandardTempBpChartViewModel> standardTempBpModel;
	
	@JsonIgnore
	private String message;

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public List<StandardTempTemperatureModel> getStandardTempTemperatureModel() {
		return standardTempTemperatureModel;
	}

	public void setStandardTempTemperatureModel(List<StandardTempTemperatureModel> standardTempTemperatureModel) {
		this.standardTempTemperatureModel = standardTempTemperatureModel;
	}

	public List<StandardTempHeartRateChartViewModel> getStandardTempHeartrateModel() {
		return standardTempHeartrateModel;
	}

	public void setStandardTempHeartrateModel(List<StandardTempHeartRateChartViewModel> standardTempHeartrateModel) {
		this.standardTempHeartrateModel = standardTempHeartrateModel;
	}

	public List<StandardTempBreathModel> getStandardTempBreathModel() {
		return standardTempBreathModel;
	}

	public void setStandardTempBreathModel(List<StandardTempBreathModel> standardTempBreathModel) {
		this.standardTempBreathModel = standardTempBreathModel;
	}

	public List<StandardTempBpChartViewModel> getStandardTempBpModel() {
		return standardTempBpModel;
	}

	public void setStandardTempBpModel(List<StandardTempBpChartViewModel> standardTempBpModel) {
		this.standardTempBpModel = standardTempBpModel;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}
}

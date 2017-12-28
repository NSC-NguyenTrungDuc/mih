package nta.med.ext.phr.model;

import java.math.BigDecimal;
import java.sql.Timestamp;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonFormat;

public class BabyDiaperModel {

	@JsonProperty("id")
	private Long id;

	@JsonProperty("alert")
	private BigDecimal alert;

	@JsonProperty("color")
	private String color;

	@JsonProperty("method")
	private String method;

	@JsonProperty("note")
	private String note;

	@JsonProperty("profile_id")
	private Long profileId;

	@JsonProperty("state")
	private String state;

	@JsonProperty("time_pee_poo")
	@JsonFormat(shape=JsonFormat.Shape.STRING, pattern="yyyy-MM-dd'T'HH:mm:ss'Z'", timezone="UTC")
	private Timestamp timePeePoo;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getAlert() {
		return alert;
	}

	public void setAlert(BigDecimal alert) {
		this.alert = alert;
	}

	public String getColor() {
		return color;
	}

	public void setColor(String color) {
		this.color = color;
	}

	public String getMethod() {
		return method;
	}

	public void setMethod(String method) {
		this.method = method;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public Long getProfileId() {
		return profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getState() {
		return state;
	}

	public void setState(String state) {
		this.state = state;
	}

	public Timestamp getTimePeePoo() {
		return timePeePoo;
	}

	public void setTimePeePoo(Timestamp timePeePoo) {
		this.timePeePoo = timePeePoo;
	}
}

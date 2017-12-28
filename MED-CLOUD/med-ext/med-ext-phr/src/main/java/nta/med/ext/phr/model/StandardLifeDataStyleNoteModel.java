package nta.med.ext.phr.model;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

public class StandardLifeDataStyleNoteModel {
	
	@JsonProperty("sleep_id")
	private Long id;
	
	@JsonProperty("sleep_time")
	private BigInteger sleepTime;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigInteger getSleepTime() {
		return sleepTime;
	}

	public void setSleepTime(BigInteger sleepTime) {
		this.sleepTime = sleepTime;
	}
}

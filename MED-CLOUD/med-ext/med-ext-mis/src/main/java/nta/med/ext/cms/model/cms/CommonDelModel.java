package nta.med.ext.cms.model.cms;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CommonDelModel {

	@JsonProperty("id")
	private Long id;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

}

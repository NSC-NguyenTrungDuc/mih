/**
 * 
 */
package nta.med.ext.emr.model;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * @author DEV-HuanLT
 *
 */
public class EmrTagModel {
	
	@JsonProperty("tag_code")
	private String tagCode;
	
	@JsonProperty("tag_name")
	private String tagName;

	public String getTagCode() {
		return tagCode;
	}

	public void setTagCode(String tagCode) {
		this.tagCode = tagCode;
	}

	public String getTagName() {
		return tagName;
	}

	public void setTagName(String tagName) {
		this.tagName = tagName;
	}

	@Override
	public String toString() {
		return "EmrTagModel [tagCode=" + tagCode + ", tagName=" + tagName + "]";
	}
}

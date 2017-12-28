package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;
import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class SurveyAnswerModel {

	@JsonProperty("answer_id")
	private BigInteger id;
	
	@JsonProperty("title")
	private String content;

	@JsonProperty("is_selected")
	private BigDecimal isSelected;

	@JsonProperty("is_correct")
	private BigDecimal correctFlg;

	@JsonProperty("sequence")
	private Integer sequence;

	private BigDecimal activeFlg;

	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public BigDecimal getIsSelected() {
		return isSelected;
	}

	public void setIsSelected(BigDecimal isSelected) {
		this.isSelected = isSelected;
	}

	public BigDecimal getCorrectFlg() {
		return correctFlg;
	}

	public void setCorrectFlg(BigDecimal correctFlg) {
		this.correctFlg = correctFlg;
	}

	public Integer getSequence() {
		return sequence;
	}

	public void setSequence(Integer sequence) {
		this.sequence = sequence;
	}

}

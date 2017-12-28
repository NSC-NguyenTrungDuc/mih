/**
 * 
 */
package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlElementWrapper;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author admin
 *
 */

@JsonIgnoreProperties(ignoreUnknown = true)
public class QuestionStore {
	

	@JacksonXmlProperty(localName = "question_id")
	@JsonProperty("question_id")
	private BigInteger id;
	
	@JacksonXmlProperty(localName = "question_content")
	@JsonProperty("question_content")
	private String content;
	
	@JacksonXmlProperty(localName = "description")
	@JsonProperty("description")
	private String description;


	@JacksonXmlProperty(localName = "has_other_answer")
	@JsonProperty("has_other_answer")
	private BigDecimal allowOtherFlg;

	@JacksonXmlProperty(localName = "required_flg")
	@JsonProperty("required_flg")
	private int requiredFlg;
	
	@JacksonXmlProperty(localName = "has_other_text")
	@JsonProperty("has_other_text")
	private String hasOtherText;
	
	@JacksonXmlProperty(localName = "question_type")
	@JsonProperty("question_type")
	private String questionType;
	
	@JacksonXmlProperty(localName = "question_sequence")
	@JsonProperty("question_sequence")
	private int sequence;

	private List<AnswerStore> answer;
	
	@JacksonXmlProperty(localName = "answer")
    @JacksonXmlElementWrapper(useWrapping = false)
	public List<AnswerStore> getAnswer() {
		return answer;
	}

	public void setAnswer(List<AnswerStore> answer) {
		this.answer = answer;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public BigDecimal getAllowOtherFlg() {
		return allowOtherFlg;
	}

	public void setAllowOtherFlg(BigDecimal allowOtherFlg) {
		this.allowOtherFlg = allowOtherFlg;
	}

	public String getQuestionType() {
		return questionType;
	}

	public void setQuestionType(String questionType) {
		this.questionType = questionType;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public int getSequence() {
		return sequence;
	}

	public void setSequence(int sequence) {
		this.sequence = sequence;
	}

	public String getHasOtherText() {
		return hasOtherText;
	}

	public void setHasOtherText(String hasOtherText) {
		this.hasOtherText = hasOtherText;
	}

	public int getRequiredFlg() {
		return requiredFlg;
	}

	public void setRequiredFlg(int requiredFlg) {
		this.requiredFlg = requiredFlg;
	}
}

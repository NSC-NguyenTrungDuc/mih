/**
 * 
 */
package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author admin
 *
 */

@JsonIgnoreProperties(ignoreUnknown = true)
public class AnswerStore {

	@JacksonXmlProperty(localName = "id")
	private Long id;

	@JacksonXmlProperty(localName = "title")
	private String content;

	@JacksonXmlProperty(localName = "is_selected")
	@JsonProperty("is_selected")
	private BigDecimal activeFlg;
	
	@JacksonXmlProperty(localName = "sequence")
	@JsonProperty("sequence")
	private Integer sequence;
	
	@JacksonXmlProperty(localName = "is_correct")
	@JsonProperty("is_correct")	
	private BigDecimal correctFlg;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Integer getSequence() {
		return sequence;
	}

	public void setSequence(Integer sequence) {
		this.sequence = sequence;
	}

	public BigDecimal getCorrectFlg() {
		return correctFlg;
	}

	public void setCorrectFlg(BigDecimal correctFlg) {
		this.correctFlg = correctFlg;
	}

	public AnswerStore(Long id, String content, BigDecimal activeFlg, Integer sequence, BigDecimal correctFlg) {
		super();
		this.id = id;
		this.content = content;
		this.activeFlg = activeFlg;
		this.sequence = sequence;
		this.correctFlg = correctFlg;
	}

	public AnswerStore() {
		super();
	}
}

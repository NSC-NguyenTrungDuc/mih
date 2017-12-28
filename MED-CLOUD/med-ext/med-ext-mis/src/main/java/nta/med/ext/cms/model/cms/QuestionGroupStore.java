/**
 * 
 */
package nta.med.ext.cms.model.cms;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlElementWrapper;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

/**
 * @author admin
 *
 */

@JsonIgnoreProperties(ignoreUnknown = true)
public class QuestionGroupStore {

	private Long id;
	
	private String title;
	
	private List<QuestionStore> question;
	
	@JacksonXmlProperty(localName = "title")
	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}
	@JacksonXmlProperty(localName = "question")
    @JacksonXmlElementWrapper(useWrapping = false)
	public List<QuestionStore> getQuestion() {
		return question;
	}

	public void setQuestion(List<QuestionStore> question) {
		this.question = question;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}
}

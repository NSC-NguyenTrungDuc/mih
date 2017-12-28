package nta.med.data.model.cms;

import java.math.BigDecimal;

public class CmsAnswerInfo {
	private String content;
	private BigDecimal correctFlg;
	private Integer sequence;
	
	public CmsAnswerInfo(String content, BigDecimal correctFlg, Integer sequence) {
		super();
		this.content = content;
		this.correctFlg = correctFlg;
		this.sequence = sequence;
	}

	public CmsAnswerInfo() {
		super();
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
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

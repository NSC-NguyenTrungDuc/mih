package nta.med.data.model.ihis.ocsa;

import java.math.BigDecimal;

public class OcsaOCS0221U00GrdOCS0221ListInfo {
	private String memb;
    private Double fSeq;
    private String categoryGubun;
    private String categoryName;
    private BigDecimal commentLimit;
	public OcsaOCS0221U00GrdOCS0221ListInfo(String memb, Double fSeq,
			String categoryGubun, String categoryName, BigDecimal commentLimit) {
		super();
		this.memb = memb;
		this.fSeq = fSeq;
		this.categoryGubun = categoryGubun;
		this.categoryName = categoryName;
		this.commentLimit = commentLimit;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public Double getfSeq() {
		return fSeq;
	}
	public void setfSeq(Double fSeq) {
		this.fSeq = fSeq;
	}
	public String getCategoryGubun() {
		return categoryGubun;
	}
	public void setCategoryGubun(String categoryGubun) {
		this.categoryGubun = categoryGubun;
	}
	public String getCategoryName() {
		return categoryName;
	}
	public void setCategoryName(String categoryName) {
		this.categoryName = categoryName;
	}
	public BigDecimal getCommentLimit() {
		return commentLimit;
	}
	public void setCommentLimit(BigDecimal commentLimit) {
		this.commentLimit = commentLimit;
	}
    
}
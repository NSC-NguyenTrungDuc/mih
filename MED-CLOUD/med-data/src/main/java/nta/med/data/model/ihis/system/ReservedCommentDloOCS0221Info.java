package nta.med.data.model.ihis.system;

import java.math.BigDecimal;

public class ReservedCommentDloOCS0221Info {
	private String memb                 ;
	private Double seq                  ;
	private String categoryGubun        ;
	private String categoryName         ;
	private BigDecimal commentLimit         ;
	public ReservedCommentDloOCS0221Info(String memb, Double seq,
			String categoryGubun, String categoryName, BigDecimal commentLimit) {
		super();
		this.memb = memb;
		this.seq = seq;
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
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
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

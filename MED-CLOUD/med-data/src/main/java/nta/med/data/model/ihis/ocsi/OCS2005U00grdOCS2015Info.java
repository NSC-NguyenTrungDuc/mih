package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS2005U00grdOCS2015Info {
	private Double pkocs2015 ;
    private String bunho ;
    private Date orderDate ;
    private Date actDate ;
    private Double pkSeq ;
    private String actId ;
	public OCS2005U00grdOCS2015Info(Double pkocs2015, String bunho, Date orderDate, Date actDate, Double pkSeq,
			String actId) {
		super();
		this.pkocs2015 = pkocs2015;
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.actDate = actDate;
		this.pkSeq = pkSeq;
		this.actId = actId;
	}
	public Double getPkocs2015() {
		return pkocs2015;
	}
	public void setPkocs2015(Double pkocs2015) {
		this.pkocs2015 = pkocs2015;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public Date getActDate() {
		return actDate;
	}
	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}
	public Double getPkSeq() {
		return pkSeq;
	}
	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}
	public String getActId() {
		return actId;
	}
	public void setActId(String actId) {
		this.actId = actId;
	}
    
}

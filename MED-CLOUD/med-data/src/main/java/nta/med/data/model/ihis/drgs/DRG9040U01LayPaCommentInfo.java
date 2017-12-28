package nta.med.data.model.ihis.drgs;

public class DRG9040U01LayPaCommentInfo {
	private String orderRemark;
	private String drgRemark;
	public DRG9040U01LayPaCommentInfo(String orderRemark, String drgRemark) {
		super();
		this.orderRemark = orderRemark;
		this.drgRemark = drgRemark;
	}
	public String getOrderRemark() {
		return orderRemark;
	}
	public void setOrderRemark(String orderRemark) {
		this.orderRemark = orderRemark;
	}
	public String getDrgRemark() {
		return drgRemark;
	}
	public void setDrgRemark(String drgRemark) {
		this.drgRemark = drgRemark;
	}
}

package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10frmARActingOCS2005Info {

	private String hangmogCode;
	private Double suryang;
	private String bomYn;
	private Double bomSourceKey;
	private String hangmogName;
	private Double fkocs2005;
	private Date orderDate;
	private Date drtFromDate;
	private Date drtToDate;

	public OCS6010U10frmARActingOCS2005Info(String hangmogCode, Double suryang, String bomYn, Double bomSourceKey,
			String hangmogName, Double fkocs2005, Date orderDate, Date drtFromDate, Date drtToDate) {
		super();
		this.hangmogCode = hangmogCode;
		this.suryang = suryang;
		this.bomYn = bomYn;
		this.bomSourceKey = bomSourceKey;
		this.hangmogName = hangmogName;
		this.fkocs2005 = fkocs2005;
		this.orderDate = orderDate;
		this.drtFromDate = drtFromDate;
		this.drtToDate = drtToDate;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public Double getSuryang() {
		return suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}

	public String getBomYn() {
		return bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}

	public Double getBomSourceKey() {
		return bomSourceKey;
	}

	public void setBomSourceKey(Double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public Double getFkocs2005() {
		return fkocs2005;
	}

	public void setFkocs2005(Double fkocs2005) {
		this.fkocs2005 = fkocs2005;
	}

	public Date getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	public Date getDrtFromDate() {
		return drtFromDate;
	}

	public void setDrtFromDate(Date drtFromDate) {
		this.drtFromDate = drtFromDate;
	}

	public Date getDrtToDate() {
		return drtToDate;
	}

	public void setDrtToDate(Date drtToDate) {
		this.drtToDate = drtToDate;
	}

}

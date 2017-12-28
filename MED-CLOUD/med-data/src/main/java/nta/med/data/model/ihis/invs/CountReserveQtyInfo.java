package nta.med.data.model.ihis.invs;

public class CountReserveQtyInfo {
	private Double reserveQty;
	private Double fkocs1003;
	public CountReserveQtyInfo(Double reserveQty, Double fkocs1003) {
		super();
		this.reserveQty = reserveQty;
		this.fkocs1003 = fkocs1003;
	}
	public Double getReserveQty() {
		return reserveQty;
	}
	public void setReserveQty(Double reserveQty) {
		this.reserveQty = reserveQty;
	}
	public Double getFkocs1003() {
		return fkocs1003;
	}
	public void setFkocs1003(Double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}
}

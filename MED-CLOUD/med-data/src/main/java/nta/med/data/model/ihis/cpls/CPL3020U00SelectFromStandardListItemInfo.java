package nta.med.data.model.ihis.cpls;

import java.util.Date;

public class CPL3020U00SelectFromStandardListItemInfo {
	private String fromStandard;
	private String toStandard;
	private String specimenCode;
	private String emergency;
	private String orderDate;

	public CPL3020U00SelectFromStandardListItemInfo(String fromStandard,
			String toStandard, String specimenCode, String emergency,
			String orderDate) {
		super();
		this.fromStandard = fromStandard;
		this.toStandard = toStandard;
		this.specimenCode = specimenCode;
		this.emergency = emergency;
		this.orderDate = orderDate;
	}

	public String getFromStandard() {
		return fromStandard;
	}

	public void setFromStandard(String fromStandard) {
		this.fromStandard = fromStandard;
	}

	public String getToStandard() {
		return toStandard;
	}

	public void setToStandard(String toStandard) {
		this.toStandard = toStandard;
	}

	public String getSpecimenCode() {
		return specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}

	public String getEmergency() {
		return emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	public String getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}

}

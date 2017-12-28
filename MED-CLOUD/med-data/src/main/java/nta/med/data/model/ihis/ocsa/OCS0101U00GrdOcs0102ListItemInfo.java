package nta.med.data.model.ihis.ocsa;

public class OCS0101U00GrdOcs0102ListItemInfo {
	private String slipGubun;
	private String slipCode;
	private String slipName;
	private String specimenText;
	private String rowState;

	public OCS0101U00GrdOcs0102ListItemInfo(String slipGubun, String slipCode,
			String slipName, String specimenText, String rowState) {
		super();
		this.slipGubun = slipGubun;
		this.slipCode = slipCode;
		this.slipName = slipName;
		this.specimenText = specimenText;
		this.rowState = rowState;
	}

	public String getSlipGubun() {
		return slipGubun;
	}

	public void setSlipGubun(String slipGubun) {
		this.slipGubun = slipGubun;
	}

	public String getSlipCode() {
		return slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}

	public String getSlipName() {
		return slipName;
	}

	public void setSlipName(String slipName) {
		this.slipName = slipName;
	}

	public String getSpecimenText() {
		return specimenText;
	}

	public void setSpecimenText(String specimenText) {
		this.specimenText = specimenText;
	}

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}

package nta.med.data.model.ihis.ocsa;

import java.io.Serializable;

public class OCS0101U00GrdOcs0101ListItemInfo implements Serializable {
	private String slipGubun;
	private String slipGubunName;
	private String rowState;

	public OCS0101U00GrdOcs0101ListItemInfo(String slipGubun,
			String slipGubunName, String rowState) {
		super();
		this.slipGubun = slipGubun;
		this.slipGubunName = slipGubunName;
		this.rowState = rowState;
	}

	public String getSlipGubun() {
		return slipGubun;
	}

	public void setSlipGubun(String slipGubun) {
		this.slipGubun = slipGubun;
	}

	public String getSlipGubunName() {
		return slipGubunName;
	}

	public void setSlipGubunName(String slipGubunName) {
		this.slipGubunName = slipGubunName;
	}

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}

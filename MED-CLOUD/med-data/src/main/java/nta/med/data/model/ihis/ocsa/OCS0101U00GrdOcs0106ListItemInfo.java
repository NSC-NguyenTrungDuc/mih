package nta.med.data.model.ihis.ocsa;

public class OCS0101U00GrdOcs0106ListItemInfo {
	private String slipCode;
	private String defaultYn;
	private String specimenCode;
	private String specimenName;
	private Double seq;

	public OCS0101U00GrdOcs0106ListItemInfo(String slipCode, String defaultYn,
			String specimenCode, String specimenName, Double seq) {
		super();
		this.slipCode = slipCode;
		this.defaultYn = defaultYn;
		this.specimenCode = specimenCode;
		this.specimenName = specimenName;
		this.seq = seq;
	}

	public String getSlipCode() {
		return slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}

	public String getDefaultYn() {
		return defaultYn;
	}

	public void setDefaultYn(String defaultYn) {
		this.defaultYn = defaultYn;
	}

	public String getSpecimenCode() {
		return specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}

	public String getSpecimenName() {
		return specimenName;
	}

	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

}

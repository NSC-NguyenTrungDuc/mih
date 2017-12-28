package nta.med.data.model.ihis.cpls;

public class CPL0106U00FwkGumsaListItemInfo {
	private String hangmogCode;
	private String specimenCode;
	private String specimenName;
	private String emergency;
	private String gumsaName;

	public CPL0106U00FwkGumsaListItemInfo(String hangmogCode,
			String specimenCode, String specimenName, String emergency,
			String gumsaName) {
		super();
		this.hangmogCode = hangmogCode;
		this.specimenCode = specimenCode;
		this.specimenName = specimenName;
		this.emergency = emergency;
		this.gumsaName = gumsaName;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
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

	public String getEmergency() {
		return emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	public String getGumsaName() {
		return gumsaName;
	}

	public void setGumsaName(String gumsaName) {
		this.gumsaName = gumsaName;
	}

}
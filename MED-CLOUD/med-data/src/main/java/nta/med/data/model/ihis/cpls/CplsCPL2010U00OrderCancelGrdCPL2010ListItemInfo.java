package nta.med.data.model.ihis.cpls;

public class CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo {

	private String fkocs1003;
	private String hangmogCode;
	private String gumsaName;
	private String specimenCode;
	private String specimenName;
	private String specimenSer;
	private String pkcpl2010;

	public CplsCPL2010U00OrderCancelGrdCPL2010ListItemInfo(String fkocs1003,
			String hangmogCode, String gumsaName, String specimenCode,
			String specimenName, String specimenSer, String pkcpl2010) {
		super();
		this.fkocs1003 = fkocs1003;
		this.hangmogCode = hangmogCode;
		this.gumsaName = gumsaName;
		this.specimenCode = specimenCode;
		this.specimenName = specimenName;
		this.specimenSer = specimenSer;
		this.pkcpl2010 = pkcpl2010;
	}

	public String getFkocs1003() {
		return fkocs1003;
	}

	public void setFkocs1003(String fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public String getGumsaName() {
		return gumsaName;
	}

	public void setGumsaName(String gumsaName) {
		this.gumsaName = gumsaName;
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

	public String getSpecimenSer() {
		return specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}

	public String getPkcpl2010() {
		return pkcpl2010;
	}

	public void setPkcpl2010(String pkcpl2010) {
		this.pkcpl2010 = pkcpl2010;
	}

}

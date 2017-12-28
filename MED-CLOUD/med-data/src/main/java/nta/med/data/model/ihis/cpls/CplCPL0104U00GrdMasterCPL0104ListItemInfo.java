package nta.med.data.model.ihis.cpls;

public class CplCPL0104U00GrdMasterCPL0104ListItemInfo {
	private String hangmogCode ;
	private String specimenCode ;
	private String codeName ;
	private String emergency ;
	private String gumsaName ;
	public CplCPL0104U00GrdMasterCPL0104ListItemInfo(String hangmogCode,
			String specimenCode, String codeName, String emergency,
			String gumsaName) {
		super();
		this.hangmogCode = hangmogCode;
		this.specimenCode = specimenCode;
		this.codeName = codeName;
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
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
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

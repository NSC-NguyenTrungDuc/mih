package nta.med.data.model.ihis.cpls;

public class CPL0106U00GrdListItemInfo {
	private String groupGubunA;
	private String hangmogCode;
	private String specimenCode;
	private String emergency;
	private String subHangmogCode;
	private String subSpecimenCode;
	private String specimenName;
	private String subEmergency;
	private String gumsaName;
	private String continueYn;
	private String groupGubunB;
	private String sgCode;
	
	public CPL0106U00GrdListItemInfo(String groupGubunA, String hangmogCode,
			String specimenCode, String emergency, String subHangmogCode,
			String subSpecimenCode, String specimenName, String subEmergency,
			String gumsaName, String continueYn, String groupGubunB,
			String sgCode) {
		super();
		this.groupGubunA = groupGubunA;
		this.hangmogCode = hangmogCode;
		this.specimenCode = specimenCode;
		this.emergency = emergency;
		this.subHangmogCode = subHangmogCode;
		this.subSpecimenCode = subSpecimenCode;
		this.specimenName = specimenName;
		this.subEmergency = subEmergency;
		this.gumsaName = gumsaName;
		this.continueYn = continueYn;
		this.groupGubunB = groupGubunB;
		this.sgCode = sgCode;
	}
	public String getGroupGubunA() {
		return groupGubunA;
	}
	public void setGroupGubunA(String groupGubunA) {
		this.groupGubunA = groupGubunA;
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
	public String getEmergency() {
		return emergency;
	}
	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}
	public String getSubHangmogCode() {
		return subHangmogCode;
	}
	public void setSubHangmogCode(String subHangmogCode) {
		this.subHangmogCode = subHangmogCode;
	}
	public String getSubSpecimenCode() {
		return subSpecimenCode;
	}
	public void setSubSpecimenCode(String subSpecimenCode) {
		this.subSpecimenCode = subSpecimenCode;
	}
	public String getSpecimenName() {
		return specimenName;
	}
	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}
	public String getSubEmergency() {
		return subEmergency;
	}
	public void setSubEmergency(String subEmergency) {
		this.subEmergency = subEmergency;
	}
	public String getGumsaName() {
		return gumsaName;
	}
	public void setGumsaName(String gumsaName) {
		this.gumsaName = gumsaName;
	}
	public String getContinueYn() {
		return continueYn;
	}
	public void setContinueYn(String continueYn) {
		this.continueYn = continueYn;
	}
	public String getGroupGubunB() {
		return groupGubunB;
	}
	public void setGroupGubunB(String groupGubunB) {
		this.groupGubunB = groupGubunB;
	}
	public String getSgCode() {
		return sgCode;
	}
	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}
}

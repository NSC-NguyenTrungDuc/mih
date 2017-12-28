package nta.med.data.model.ihis.cpls;

public class CPL0106U00GrdGroupListItemInfo {
	private String groupGubun;
	private String hangmogCode;
	private String specimenCode;
	private String specimenName;
	private String emergency;
	private String gumsaName;
	private String jundalGubun;
	private String jundalName;
	public CPL0106U00GrdGroupListItemInfo(String groupGubun,
			String hangmogCode, String specimenCode, String specimenName,
			String emergency, String gumsaName, String jundalGubun,
			String jundalName) {
		super();
		this.groupGubun = groupGubun;
		this.hangmogCode = hangmogCode;
		this.specimenCode = specimenCode;
		this.specimenName = specimenName;
		this.emergency = emergency;
		this.gumsaName = gumsaName;
		this.jundalGubun = jundalGubun;
		this.jundalName = jundalName;
	}
	public String getGroupGubun() {
		return groupGubun;
	}
	public void setGroupGubun(String groupGubun) {
		this.groupGubun = groupGubun;
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
	public String getJundalGubun() {
		return jundalGubun;
	}
	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}
	public String getJundalName() {
		return jundalName;
	}
	public void setJundalName(String jundalName) {
		this.jundalName = jundalName;
	}
}
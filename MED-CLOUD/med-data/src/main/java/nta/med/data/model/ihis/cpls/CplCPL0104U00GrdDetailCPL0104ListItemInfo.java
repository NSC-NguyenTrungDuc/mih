package nta.med.data.model.ihis.cpls;

public class CplCPL0104U00GrdDetailCPL0104ListItemInfo {
	private String hangmogCode ;
	private String specimenCode ;
	private String emergency ;
	private String sex ;
	private String naiFrom ;
	private String naiTo ;
	private Double fromAge ;
	private Double toAge ;
	private String fromStandard ;
	private String toStandard ;
	public CplCPL0104U00GrdDetailCPL0104ListItemInfo(String hangmogCode,
			String specimenCode, String emergency, String sex, String naiFrom,
			String naiTo, Double fromAge, Double toAge, String fromStandard,
			String toStandard) {
		super();
		this.hangmogCode = hangmogCode;
		this.specimenCode = specimenCode;
		this.emergency = emergency;
		this.sex = sex;
		this.naiFrom = naiFrom;
		this.naiTo = naiTo;
		this.fromAge = fromAge;
		this.toAge = toAge;
		this.fromStandard = fromStandard;
		this.toStandard = toStandard;
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
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public String getNaiFrom() {
		return naiFrom;
	}
	public void setNaiFrom(String naiFrom) {
		this.naiFrom = naiFrom;
	}
	public String getNaiTo() {
		return naiTo;
	}
	public void setNaiTo(String naiTo) {
		this.naiTo = naiTo;
	}
	public Double getFromAge() {
		return fromAge;
	}
	public void setFromAge(Double fromAge) {
		this.fromAge = fromAge;
	}
	public Double getToAge() {
		return toAge;
	}
	public void setToAge(Double toAge) {
		this.toAge = toAge;
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
	
}

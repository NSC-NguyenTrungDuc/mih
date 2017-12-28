package nta.med.data.model.ihis.cpls;

public class CPL3010U00GrdGumListItemInfo {
	private String specimenSer;
    private Double fkcpl2010;
    private String gumsaName;
    private String jangbiName;
    private String cplResult;
    private String specimenName;
    private String hangmogCode;
    private String partJubsuja;
    private String subJubsuYn;
    private String spcialName;
    private String fkocs;
    private String confirmYn;
	public CPL3010U00GrdGumListItemInfo(String specimenSer, Double fkcpl2010,
			String gumsaName, String jangbiName, String cplResult,
			String specimenName, String hangmogCode, String partJubsuja,
			String subJubsuYn, String spcialName, String fkocs, String confirmYn) {
		super();
		this.specimenSer = specimenSer;
		this.fkcpl2010 = fkcpl2010;
		this.gumsaName = gumsaName;
		this.jangbiName = jangbiName;
		this.cplResult = cplResult;
		this.specimenName = specimenName;
		this.hangmogCode = hangmogCode;
		this.partJubsuja = partJubsuja;
		this.subJubsuYn = subJubsuYn;
		this.spcialName = spcialName;
		this.fkocs = fkocs;
		this.confirmYn = confirmYn;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public Double getFkcpl2010() {
		return fkcpl2010;
	}
	public void setFkcpl2010(Double fkcpl2010) {
		this.fkcpl2010 = fkcpl2010;
	}
	public String getGumsaName() {
		return gumsaName;
	}
	public void setGumsaName(String gumsaName) {
		this.gumsaName = gumsaName;
	}
	public String getJangbiName() {
		return jangbiName;
	}
	public void setJangbiName(String jangbiName) {
		this.jangbiName = jangbiName;
	}
	public String getCplResult() {
		return cplResult;
	}
	public void setCplResult(String cplResult) {
		this.cplResult = cplResult;
	}
	public String getSpecimenName() {
		return specimenName;
	}
	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getPartJubsuja() {
		return partJubsuja;
	}
	public void setPartJubsuja(String partJubsuja) {
		this.partJubsuja = partJubsuja;
	}
	public String getSubJubsuYn() {
		return subJubsuYn;
	}
	public void setSubJubsuYn(String subJubsuYn) {
		this.subJubsuYn = subJubsuYn;
	}
	public String getSpcialName() {
		return spcialName;
	}
	public void setSpcialName(String spcialName) {
		this.spcialName = spcialName;
	}
	public String getFkocs() {
		return fkocs;
	}
	public void setFkocs(String fkocs) {
		this.fkocs = fkocs;
	}
	public String getConfirmYn() {
		return confirmYn;
	}
	public void setConfirmYn(String confirmYn) {
		this.confirmYn = confirmYn;
	}
}

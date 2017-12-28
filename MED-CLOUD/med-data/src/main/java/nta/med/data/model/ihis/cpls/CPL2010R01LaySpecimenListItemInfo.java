package nta.med.data.model.ihis.cpls;

public class CPL2010R01LaySpecimenListItemInfo {
	private String specimenSer;
    private String bunho;
    private String suname;
    private String doctorName;
    private String specimenNo;
    private String specimenName;
    private String tubeName;
    private String tubeCount;
    private String hoDongName;
    private String reserDate;
    private String contKey;
	public CPL2010R01LaySpecimenListItemInfo(String specimenSer, String bunho,
			String suname, String doctorName, String specimenNo,
			String specimenName, String tubeName, String tubeCount,
			String hoDongName, String reserDate, String contKey) {
		super();
		this.specimenSer = specimenSer;
		this.bunho = bunho;
		this.suname = suname;
		this.doctorName = doctorName;
		this.specimenNo = specimenNo;
		this.specimenName = specimenName;
		this.tubeName = tubeName;
		this.tubeCount = tubeCount;
		this.hoDongName = hoDongName;
		this.reserDate = reserDate;
		this.contKey = contKey;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getSpecimenNo() {
		return specimenNo;
	}
	public void setSpecimenNo(String specimenNo) {
		this.specimenNo = specimenNo;
	}
	public String getSpecimenName() {
		return specimenName;
	}
	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}
	public String getTubeName() {
		return tubeName;
	}
	public void setTubeName(String tubeName) {
		this.tubeName = tubeName;
	}
	public String getTubeCount() {
		return tubeCount;
	}
	public void setTubeCount(String tubeCount) {
		this.tubeCount = tubeCount;
	}
	public String getHoDongName() {
		return hoDongName;
	}
	public void setHoDongName(String hoDongName) {
		this.hoDongName = hoDongName;
	}
	public String getReserDate() {
		return reserDate;
	}
	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
}

package nta.med.data.model.ihis.schs;

public class SCH0201U10GrdOrderItemInfo {
	private String pkkey;
	private String gubun;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String hangmogCode;
	private String hangmogName;
	private String reserTime;
	private Double seq;
	private Double sort;
	public SCH0201U10GrdOrderItemInfo(String pkkey, String gubun, String gwa,
			String gwaName, String doctor, String doctorName,
			String hangmogCode, String hangmogName, String reserTime,
			Double seq, Double sort) {
		super();
		this.pkkey = pkkey;
		this.gubun = gubun;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.reserTime = reserTime;
		this.seq = seq;
		this.sort = sort;
	}
	public String getPkkey() {
		return pkkey;
	}
	public void setPkkey(String pkkey) {
		this.pkkey = pkkey;
	}
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getReserTime() {
		return reserTime;
	}
	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public Double getSort() {
		return sort;
	}
	public void setSort(Double sort) {
		this.sort = sort;
	}
	
}

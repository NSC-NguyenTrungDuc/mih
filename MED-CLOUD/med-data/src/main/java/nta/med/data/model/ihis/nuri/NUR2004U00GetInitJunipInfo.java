package nta.med.data.model.ihis.nuri;

public class NUR2004U00GetInitJunipInfo {

    private String toGwa;
    private String gwaName;
    private String toDoctor;
    private String doctorName;
    private String hoDong;
    private String hoCode;
    private String toBedNo;
    private String unconfirmYn;
    
	public NUR2004U00GetInitJunipInfo(String toGwa, String gwaName, String toDoctor, String doctorName, String hoDong,
			String hoCode, String toBedNo, String unconfirmYn) {
		super();
		this.toGwa = toGwa;
		this.gwaName = gwaName;
		this.toDoctor = toDoctor;
		this.doctorName = doctorName;
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.toBedNo = toBedNo;
		this.unconfirmYn = unconfirmYn;
	}
	
	public String getToGwa() {
		return toGwa;
	}
	public void setToGwa(String toGwa) {
		this.toGwa = toGwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getToDoctor() {
		return toDoctor;
	}
	public void setToDoctor(String toDoctor) {
		this.toDoctor = toDoctor;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getHoCode() {
		return hoCode;
	}
	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}
	public String getToBedNo() {
		return toBedNo;
	}
	public void setToBedNo(String toBedNo) {
		this.toBedNo = toBedNo;
	}
	public String getUnconfirmYn() {
		return unconfirmYn;
	}
	public void setUnconfirmYn(String unconfirmYn) {
		this.unconfirmYn = unconfirmYn;
	}
    
}

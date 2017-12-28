package nta.med.data.model.ihis.cpls;

import java.sql.Timestamp;

public class CPL0000Q00LayOrderListItemInfo {
	private Timestamp orderDate;
    private String gwa;
    private String doctor;
    private String gwaName;
    private String doctorName;
    private String inOutGubun;
	public CPL0000Q00LayOrderListItemInfo(Timestamp orderDate, String gwa,
			String doctor, String gwaName, String doctorName, String inOutGubun) {
		super();
		this.orderDate = orderDate;
		this.gwa = gwa;
		this.doctor = doctor;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.inOutGubun = inOutGubun;
	}
	public Timestamp getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Timestamp orderDate) {
		this.orderDate = orderDate;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
    
}

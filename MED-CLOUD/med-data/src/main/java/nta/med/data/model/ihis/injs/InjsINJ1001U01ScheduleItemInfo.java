package nta.med.data.model.ihis.injs;

public class InjsINJ1001U01ScheduleItemInfo {
	private String reserDate;
	private String orderDate;
	private String actingDate;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String ifDataSendYn;
	
	public InjsINJ1001U01ScheduleItemInfo(String reserDate, String orderDate, String actingDate, String gwa,
			String gwaName, String doctor, String doctorName, String ifDataSendYn) {
		super();
		this.reserDate = reserDate;
		this.orderDate = orderDate;
		this.actingDate = actingDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.ifDataSendYn = ifDataSendYn;
	}

	public String getReserDate() {
		return reserDate;
	}

	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}

	public String getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}

	public String getActingDate() {
		return actingDate;
	}

	public void setActingDate(String actingDate) {
		this.actingDate = actingDate;
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

	public String getIfDataSendYn() {
		return ifDataSendYn;
	}

	public void setIfDataSendYn(String ifDataSendYn) {
		this.ifDataSendYn = ifDataSendYn;
	}

	@Override
	public String toString() {
		return "InjsINJ1001U01ScheduleItemInfo [reserDate=" + reserDate
				+ ", orderDate=" + orderDate + ", actingDate=" + actingDate
				+ ", gwa=" + gwa + ", gwaName=" + gwaName + ", doctor="
				+ doctor + ", doctorName=" + doctorName + ", ifDataSendYn=" + ifDataSendYn + "]";
	}
}

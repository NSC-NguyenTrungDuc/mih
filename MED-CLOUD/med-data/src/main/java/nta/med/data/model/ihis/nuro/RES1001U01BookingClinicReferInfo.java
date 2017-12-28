package nta.med.data.model.ihis.nuro;

public class RES1001U01BookingClinicReferInfo {

	private String patientId;
	private String patientName;
	private String birthday;
	private String sex;
	private String bookingClinicId;
	private String bookingClinicName;
	private String tel;
	private String bookingDate;
	private String bookingTime;
	private String outHospCode;
	private String linkEmrInformation;

	public RES1001U01BookingClinicReferInfo(String patientId, String patientName, String birthday, String sex,
			String bookingClinicId, String bookingClinicName, String tel, String bookingDate, String bookingTime, String outHospCode, String linkEmrInformation) {
		super();
		this.patientId = patientId;
		this.patientName = patientName;
		this.birthday = birthday;
		this.sex = sex;
		this.bookingClinicId = bookingClinicId;
		this.bookingClinicName = bookingClinicName;
		this.tel = tel;
		this.bookingDate = bookingDate;
		this.bookingTime = bookingTime;
		this.outHospCode = outHospCode;
		this.linkEmrInformation = linkEmrInformation;
	}

	public String getPatientId() {
		return patientId;
	}

	public void setPatientId(String patientId) {
		this.patientId = patientId;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getBookingClinicId() {
		return bookingClinicId;
	}

	public void setBookingClinicId(String bookingClinicId) {
		this.bookingClinicId = bookingClinicId;
	}

	public String getBookingClinicName() {
		return bookingClinicName;
	}

	public void setBookingClinicName(String bookingClinicName) {
		this.bookingClinicName = bookingClinicName;
	}

	public String getTel() {
		return tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getBookingDate() {
		return bookingDate;
	}

	public void setBookingDate(String bookingDate) {
		this.bookingDate = bookingDate;
	}

	public String getBookingTime() {
		return bookingTime;
	}

	public void setBookingTime(String bookingTime) {
		this.bookingTime = bookingTime;
	}

	public String getOutHospCode() {
		return outHospCode;
	}

	public void setOutHospCode(String outHospCode) {
		this.outHospCode = outHospCode;
	}

	public String getLinkEmrInformation() {
		return linkEmrInformation;
	}

	public void setLinkEmrInformation(String linkEmrInformation) {
		this.linkEmrInformation = linkEmrInformation;
	}

}

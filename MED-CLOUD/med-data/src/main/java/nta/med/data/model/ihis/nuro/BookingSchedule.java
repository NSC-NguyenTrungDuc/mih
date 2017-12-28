package nta.med.data.model.ihis.nuro;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
public class BookingSchedule {

    private String doctorCode;
    private String bookingDate;
    private String totalSlots;
    private String otherSlots;
    private String doctorGrade;
    private String avgTime;
    private String resAmStartHhmm;
	private String resAmEndHhmm;
	private String resPmStartHhmm;
	private String resPmEndHhmm;
	List<BookingScheduleDetail> period;

    public BookingSchedule() {
    }

	public String getDoctorCode() {
		return doctorCode;
	}

	public void setDoctorCode(String doctorCode) {
		this.doctorCode = doctorCode;
	}

	public String getBookingDate() {
		return bookingDate;
	}

	public void setBookingDate(String bookingDate) {
		this.bookingDate = bookingDate;
	}

	public String getTotalSlots() {
		return totalSlots;
	}

	public void setTotalSlots(String totalSlots) {
		this.totalSlots = totalSlots;
	}

	public String getOtherSlots() {
		return otherSlots;
	}

	public void setOtherSlots(String otherSlots) {
		this.otherSlots = otherSlots;
	}

	public String getDoctorGrade() {
		return doctorGrade;
	}

	public void setDoctorGrade(String doctorGrade) {
		this.doctorGrade = doctorGrade;
	}

	public String getAvgTime() {
		return avgTime;
	}

	public void setAvgTime(String avgTime) {
		this.avgTime = avgTime;
	}

	public String getResAmStartHhmm() {
		return resAmStartHhmm;
	}

	public void setResAmStartHhmm(String resAmStartHhmm) {
		this.resAmStartHhmm = resAmStartHhmm;
	}

	public String getResAmEndHhmm() {
		return resAmEndHhmm;
	}

	public void setResAmEndHhmm(String resAmEndHhmm) {
		this.resAmEndHhmm = resAmEndHhmm;
	}

	public String getResPmStartHhmm() {
		return resPmStartHhmm;
	}

	public void setResPmStartHhmm(String resPmStartHhmm) {
		this.resPmStartHhmm = resPmStartHhmm;
	}

	public String getResPmEndHhmm() {
		return resPmEndHhmm;
	}

	public void setResPmEndHhmm(String resPmEndHhmm) {
		this.resPmEndHhmm = resPmEndHhmm;
	}

	public List<BookingScheduleDetail> getPeriod() {
		return period;
	}

	public void setPeriod(List<BookingScheduleDetail> period) {
		this.period = period;
	}
}


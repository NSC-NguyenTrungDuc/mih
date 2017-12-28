package nta.mss.model;

import org.apache.commons.lang.StringUtils;

import nta.mss.entity.MtHistory;
import nta.mss.entity.Reservation;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.DateTimeFormat;

/**
 * 
 * @author TungLT
 *
 */
public class MtHistoryModel extends BaseModel<MtHistory>{
	private static final long serialVersionUID = 1L;
	private Integer mtHistoryId;
	private Integer hospitalId;
	private Integer patientId;
	private Integer doctorId;
	private Integer reservationId;
	private String reservationDate;
	private String reservationTime;
	private String duration;
	private String mtHistoryUrl;
	private Integer activeFlag;
	private String formattedReservationDate;
	private String formattedReservationTime;
	public Integer getMtHistoryId() {
		return mtHistoryId;
	}
	public void setMtHistoryId(Integer mtHistoryId) {
		this.mtHistoryId = mtHistoryId;
	}
	public Integer getHospitalId() {
		return hospitalId;
	}
	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}
	public Integer getPatientId() {
		return patientId;
	}
	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}
	public Integer getDoctorId() {
		return doctorId;
	}
	public void setDoctorId(Integer doctorId) {
		this.doctorId = doctorId;
	}
	public Integer getReservationId() {
		return reservationId;
	}
	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}
	public String getReservationDate() {
		return reservationDate;
	}
	public void setReservationDate(String reservationDate) {
		this.reservationDate = reservationDate;
	}
	public String getReservationTime() {
		return reservationTime;
	}
	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}
	public String getDuration() {
		return duration;
	}
	public void setDuration(String duration) {
		this.duration = duration;
	}
	public String getMtHistoryUrl() {
		return mtHistoryUrl;
	}
	public void setMtHistoryUrl(String mtHistoryUrl) {
		this.mtHistoryUrl = mtHistoryUrl;
	}
	public Integer getActiveFlag() {
		return activeFlag;
	}
	public void setActiveFlag(Integer activeFlag) {
		this.activeFlag = activeFlag;
	}

	/**
	 * Gets the formatted reservation date.
	 * 
	 * @return the formatted reservation date
	 */
	public String getFormattedReservationDate() {
		if (StringUtils.isBlank(formattedReservationDate)) {
			formattedReservationDate = MssDateTimeUtil.convertStringDateByLocale(reservationDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD, MssContextHolder.getLocale());
		}
		return formattedReservationDate;
	}

	public void setFormattedReservationDate(String formattedReservationDate) {
		this.formattedReservationDate = formattedReservationDate;
	}

	/**
	 * Gets the formatted reservation time.
	 * 
	 * @return the formatted reservation time
	 */
	public String getFormattedReservationTime() {
		if (StringUtils.isBlank(formattedReservationTime)) {
			formattedReservationTime = MssDateTimeUtil.convertStringTimeByLocale(reservationTime, DateTimeFormat.TIME_FORMAT_HH_MM, MssContextHolder.getLocale());
		}
		return formattedReservationTime;
	}

	public void setFormattedReservationTime(String formattedReservationTime) {
		this.formattedReservationTime = formattedReservationTime;
	}

	
	@Override
	public String toString() {
		return "MtHistoryModel [mtHistoryId=" + mtHistoryId + ", hospitalId=" + hospitalId + ", patientId=" + patientId
				+ ", doctorId=" + doctorId + ", reservationId=" + reservationId + ", reservationDate=" + reservationDate
				+ ", reservationTime=" + reservationTime + ", duration=" + duration + ", mtHistoryUrl=" + mtHistoryUrl
				+ ", activeFlag=" + activeFlag + ", formattedReservationDate=" + formattedReservationDate
				+ ", formattedReservationTime=" + formattedReservationTime + "]";
	}
	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
	/**
	 * Instantiates a new reservation model.
	 */
	public MtHistoryModel() {
		super(MtHistory.class);
	}
	
	
}

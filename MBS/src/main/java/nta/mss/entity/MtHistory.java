package nta.mss.entity;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.mss.model.MtHistoryModel;
import nta.mss.model.ReservationModel;

/**
 * 
 * @author TungLT
 *
 */
@Entity
@Table(name = "mt_history")
public class MtHistory  implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "mt_history_id", unique = true, nullable = false)
	private Integer mtHistoryId;
		
	// bi-directional many-to-one association to Hospital
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "hospital_id",nullable = false)
	private Hospital hospital;
	
	// bi-directional many-to-one association to Patient
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "patient_id",nullable = false)
	private Patient patient;
	
	// bi-directional many-to-one association to Doctor
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "doctor_id", nullable = false)
	private Doctor doctor;
	
	// bi-directional many-to-one association to Doctor
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "reservation_id", nullable = false)
	private Reservation reservation;
	
	
	@Column(name = "reservation_date", length = 8)
	private String reservationDate;
	
	@Column(name = "reservation_time", length = 6)
	private String reservationTime;
	
	@Column(name = "duration", length = 20)
	private String duration;
	
	@Column(name = "mt_history_url", length = 250)
	private String mtHistoryUrl;
	
	@Column(name = "active_flag")
	private Integer activeFlag;
	
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="created")
	private Date created;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="updated")
	private Date updated;
	/**
	 * Instantiates a new reservation.
	 */
	public MtHistory() {
	}

	public Integer getMtHistoryId() {
		return mtHistoryId;
	}

	public void setMtHistoryId(Integer mtHistoryId) {
		this.mtHistoryId = mtHistoryId;
	}

	public Hospital getHospital() {
		return hospital;
	}

	public void setHospital(Hospital hospital) {
		this.hospital = hospital;
	}

	public Patient getPatient() {
		return patient;
	}

	public void setPatient(Patient patient) {
		this.patient = patient;
	}

	public Doctor getDoctor() {
		return doctor;
	}

	public void setDoctor(Doctor doctor) {
		this.doctor = doctor;
	}

	public Reservation getReservation() {
		return reservation;
	}

	public void setReservation(Reservation reservation) {
		this.reservation = reservation;
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

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

	public Date getCreated() {
		return created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	public Date getUpdated() {
		return updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}
	
}

package nta.mss.entity;

import java.util.Date;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.mss.model.SessionModel;

/**
 * The persistent class for the session database table.
 * 
 */
@Entity
@Table(name = "session")
public class Session extends BaseEntity<SessionModel> {
	private static final long serialVersionUID = -3589834378585456859L;

	@Id
	@Column(name = "session_id", unique = true, nullable = false, length = 128)
	private String sessionId;

	@Column(name = "access_ip", length = 32)
	private String accessIp;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "expired")
	private Date expired;

	// bi-directional many-to-one association to Reservation
	@OneToMany(mappedBy = "session", fetch = FetchType.LAZY)
	private List<Reservation> reservations;

	/**
	 * Instantiates a new session.
	 */
	public Session() {
		super(SessionModel.class);
	}

	public String getSessionId() {
		return this.sessionId;
	}

	public void setSessionId(String sessionId) {
		this.sessionId = sessionId;
	}

	public String getAccessIp() {
		return this.accessIp;
	}

	public void setAccessIp(String accessIp) {
		this.accessIp = accessIp;
	}

	public Date getExpired() {
		return this.expired;
	}

	public void setExpired(Date expired) {
		this.expired = expired;
	}

	public List<Reservation> getReservations() {
		return this.reservations;
	}

	public void setReservations(List<Reservation> reservations) {
		this.reservations = reservations;
	}

}
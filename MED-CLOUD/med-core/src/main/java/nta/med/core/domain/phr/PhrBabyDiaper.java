package nta.med.core.domain.phr;

import java.math.BigDecimal;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQuery;
import javax.persistence.Table;

/**
 * The persistent class for the PHR_BABY_DIAPER database table.
 * 
 */
@Entity
@Table(name = "PHR_BABY_DIAPER")
@NamedQuery(name = "PhrBabyDiaper.findAll", query = "SELECT p FROM PhrBabyDiaper p")
public class PhrBabyDiaper extends PhrBaseEntity implements TimeLineDate {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;
	private BigDecimal alert;

	private String color;

	private String method;

	private String note;

	@Column(name = "PROFILE_ID")
	private Long profileId;

	private String state;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "TIME_PEE_POO")
	private Timestamp timePeePoo;

	@Column(name = "UPD_ID")
	private String updId;

	public PhrBabyDiaper() {
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getAlert() {
		return this.alert;
	}

	public void setAlert(BigDecimal alert) {
		this.alert = alert;
	}

	public String getColor() {
		return this.color;
	}

	public void setColor(String color) {
		this.color = color;
	}

	public String getMethod() {
		return this.method;
	}

	public void setMethod(String method) {
		this.method = method;
	}

	public String getNote() {
		return this.note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public Long getProfileId() {
		return this.profileId;
	}

	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

	public String getState() {
		return this.state;
	}

	public void setState(String state) {
		this.state = state;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Timestamp getTimePeePoo() {
		return this.timePeePoo;
	}

	public void setTimePeePoo(Timestamp timePeePoo) {
		this.timePeePoo = timePeePoo;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Override
	public Timestamp getTimestamp() {
		return timePeePoo;
	}
}
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
 * The persistent class for the PHR_BABY_VACCINES database table.
 * 
 */
@Entity
@Table(name = "PHR_BABY_VACCINES")
@NamedQuery(name = "PhrBabyVaccine.findAll", query = "SELECT p FROM PhrBabyVaccine p")
public class PhrBabyVaccine extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	private BigDecimal alert;

	@Column(name = "DATE_INJECT")
	private Timestamp dateInject;

	@Column(name = "MAX_INJECT_DAY")
	private Timestamp maxInjectDay;

	@Column(name = "MIN_INJECT_DAY")
	private Timestamp minInjectDay;

	private String name;

	@Column(name = "PROFILE_ID")
	private int profileId;

	private BigDecimal status;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "UPD_ID")
	private String updId;

	public PhrBabyVaccine() {
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

	public Timestamp getDateInject() {
		return this.dateInject;
	}

	public void setDateInject(Timestamp dateInject) {
		this.dateInject = dateInject;
	}

	public Timestamp getMaxInjectDay() {
		return this.maxInjectDay;
	}

	public void setMaxInjectDay(Timestamp maxInjectDay) {
		this.maxInjectDay = maxInjectDay;
	}

	public Timestamp getMinInjectDay() {
		return this.minInjectDay;
	}

	public void setMinInjectDay(Timestamp minInjectDay) {
		this.minInjectDay = minInjectDay;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getProfileId() {
		return this.profileId;
	}

	public void setProfileId(int profileId) {
		this.profileId = profileId;
	}

	public BigDecimal getStatus() {
		return this.status;
	}

	public void setStatus(BigDecimal status) {
		this.status = status;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}
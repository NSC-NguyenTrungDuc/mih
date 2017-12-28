package nta.med.core.domain.clis;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;
import java.math.BigDecimal;
import java.sql.Timestamp;



/**
 * The persistent class for the CLIS_PATIENT_STATUS database table.
 * 
 */
@Entity
@Table(name="CLIS_PATIENT_STATUS")
public class ClisPatientStatus implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="PATIENT_STATUS_ID")
	private int patientStatusId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;
	@Column(name="created")
	private Timestamp created;

	private String description;

	@Column(name="PROTOCOL_PATIENT_ID")
	private int protocolPatientId;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;
	
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPDATE_DATE")
	private Date updateDate;
	
	@Column(name="CODE")
	private String code;

	@Column(name="updated")
	private Timestamp updated;

	public ClisPatientStatus() {
	}

	public int getPatientStatusId() {
		return this.patientStatusId;
	}

	public void setPatientStatusId(int patientStatusId) {
		this.patientStatusId = patientStatusId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public int getProtocolPatientId() {
		return this.protocolPatientId;
	}

	public void setProtocolPatientId(int protocolPatientId) {
		this.protocolPatientId = protocolPatientId;
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

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	public Date getUpdateDate() {
		return updateDate;
	}

	public void setUpdateDate(Date updateDate) {
		this.updateDate = updateDate;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}
}
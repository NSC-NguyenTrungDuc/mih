package nta.med.core.domain.clis;

import java.io.Serializable;

import javax.persistence.*;

import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the CLIS_PROTOCOL_PATIENT database table.
 * 
 */
@Entity
@Table(name="CLIS_PROTOCOL_PATIENT")
public class ClisProtocolPatient implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="PROTOCOL_PATIENT_ID")
	private int protocolPatientId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private String bunho;

	@Column(name="CLIS_PROTOCOL_ID")
	private int clisProtocolId;

	private Timestamp created;

	@Column(name="HOSP_CODE")
	private String hospCode;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	public ClisProtocolPatient() {
	}

	public int getProtocolPatientId() {
		return this.protocolPatientId;
	}

	public void setProtocolPatientId(int protocolPatientId) {
		this.protocolPatientId = protocolPatientId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public int getClisProtocolId() {
		return this.clisProtocolId;
	}

	public void setClisProtocolId(int clisProtocolId) {
		this.clisProtocolId = clisProtocolId;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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

}
package nta.med.core.domain.kinki;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the ORCA_MAPPING database table.
 * 
 */
@Entity
@Table(name="ORCA_MAPPING")
@NamedQuery(name="OrcaMapping.findAll", query="SELECT o FROM OrcaMapping o")
public class OrcaMapping implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(name="ORCA_MAPPING_ID")
	private int orcaMappingId;

	@Column(name="ACT_CODE")
	private String actCode;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	@Column(name="CLASS_CODE")
	private String classCode;

	private Timestamp created;

	@Column(name="END_DATE")
	private String endDate;

	@Column(name="START_DATE")
	private String startDate;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	public OrcaMapping() {
	}

	public int getOrcaMappingId() {
		return this.orcaMappingId;
	}

	public void setOrcaMappingId(int orcaMappingId) {
		this.orcaMappingId = orcaMappingId;
	}

	public String getActCode() {
		return this.actCode;
	}

	public void setActCode(String actCode) {
		this.actCode = actCode;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getClassCode() {
		return this.classCode;
	}

	public void setClassCode(String classCode) {
		this.classCode = classCode;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public String getEndDate() {
		return this.endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	public String getStartDate() {
		return this.startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
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
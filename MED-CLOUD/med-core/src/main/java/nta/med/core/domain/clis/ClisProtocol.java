package nta.med.core.domain.clis;

import java.io.Serializable;

import javax.persistence.*;

import java.math.BigDecimal;
import java.util.Date;
import java.sql.Timestamp;


/**
 * The persistent class for the CLIS_PROTOCOL database table.
 * 
 */
@Entity
@Table(name="CLIS_PROTOCOL")
public class ClisProtocol implements Serializable {
	private static final long serialVersionUID = 1L;

	private Long clisProtocolId;

	private BigDecimal activeFlg;

	private Integer clisSmoId;

	private Timestamp created;

	private String description;

	private Date endDate;

	private String hospCode;

	private String protocolCode;

	private String protocolName;

	private String resource;

	private Date startDate;

	private String statusFlg;

	private String sysId;

	private String updId;

	private Timestamp updated;

	public ClisProtocol() {
	}

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="CLIS_PROTOCOL_ID")
	public Long getClisProtocolId() {
		return this.clisProtocolId;
	}

	public void setClisProtocolId(Long clisProtocolId) {
		this.clisProtocolId = clisProtocolId;
	}

	@Column(name="ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Column(name="CLIS_SMO_ID")
	public Integer getClisSmoId() {
		return this.clisSmoId;
	}

	public void setClisSmoId(Integer clisSmoId) {
		this.clisSmoId = clisSmoId;
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

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name="PROTOCOL_CODE")
	public String getProtocolCode() {
		return this.protocolCode;
	}

	public void setProtocolCode(String protocolCode) {
		this.protocolCode = protocolCode;
	}

	@Column(name="PROTOCOL_NAME")
	public String getProtocolName() {
		return this.protocolName;
	}

	public void setProtocolName(String protocolName) {
		this.protocolName = protocolName;
	}

	public String getResource() {
		return this.resource;
	}

	public void setResource(String resource) {
		this.resource = resource;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	@Column(name="STATUS_FLG")
	public String getStatusFlg() {
		return this.statusFlg;
	}

	public void setStatusFlg(String statusFlg) {
		this.statusFlg = statusFlg;
	}

	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name="UPD_ID")
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
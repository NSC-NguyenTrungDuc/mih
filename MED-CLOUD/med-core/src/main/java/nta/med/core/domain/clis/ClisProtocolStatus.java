package nta.med.core.domain.clis;

import java.io.Serializable;

import javax.persistence.*;

import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the CLIS_PROTOCOL_STATUS database table.
 * 
 */
@Entity
@Table(name="CLIS_PROTOCOL_STATUS")
public class ClisProtocolStatus implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="CLIS_PROTOCOL_STATUS_ID")
	private Long clisProtocolStatusId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	@Column(name="CLIS_PROTOCOL_ID")
	private int clisProtocolId;

	private Timestamp created;

	@Column(name="DISPLAY_FLG")
	private String displayFlg;

	@Column(name="SORT_NO")
	private int sortNo;

	@Column(name="CODE")
	private String code;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	public ClisProtocolStatus() {
	}

	public Long getClisProtocolStatusId() {
		return this.clisProtocolStatusId;
	}

	public void setClisProtocolStatusId(Long clisProtocolStatusId) {
		this.clisProtocolStatusId = clisProtocolStatusId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
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

	public String getDisplayFlg() {
		return this.displayFlg;
	}

	public void setDisplayFlg(String displayFlg) {
		this.displayFlg = displayFlg;
	}

	public int getSortNo() {
		return this.sortNo;
	}

	public void setSortNo(int sortNo) {
		this.sortNo = sortNo;
	}

	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
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
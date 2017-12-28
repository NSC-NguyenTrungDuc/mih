package nta.med.core.domain.bas;

import java.io.Serializable;

import javax.persistence.*;

import java.math.BigDecimal;
import java.util.Date;


/**
 * The persistent class for the ACC001 database table.
 * 
 */
@Entity
@NamedQuery(name="Acc001.findAll", query="SELECT a FROM Acc001 a")
@Table(name="ACC001")
public class Acc001 implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private String id;

	@Column(name="ACC_TYPE")
	private BigDecimal accType;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private String code;



	private String locale;

	private String name;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	private Date sysDate;

	@Column(name="SYS_ID")
	private String sysId;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	private Date updDate;

	@Column(name="UPD_ID")
	private String updId;

	public Acc001() {
	}

	public String getId() {
		return this.id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public BigDecimal getAccType() {
		return this.accType;
	}

	public void setAccType(BigDecimal accType) {
		this.accType = accType;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getLocale() {
		return this.locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}
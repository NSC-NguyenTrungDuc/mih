package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM9920 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm9920.findAll", query="SELECT a FROM Adm9920 a")
public class Adm9920 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunCode;
	private String hospCode;
	private String inputControl;
	private String jundalPartInp;
	private String jundalPartOut;
	private String jundalTableInp;
	private String jundalTableOut;
	private String movePart;
	private String orderGubun;
	private String slipCode;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Adm9920() {
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_CONTROL")
	public String getInputControl() {
		return this.inputControl;
	}

	public void setInputControl(String inputControl) {
		this.inputControl = inputControl;
	}


	@Column(name="JUNDAL_PART_INP")
	public String getJundalPartInp() {
		return this.jundalPartInp;
	}

	public void setJundalPartInp(String jundalPartInp) {
		this.jundalPartInp = jundalPartInp;
	}


	@Column(name="JUNDAL_PART_OUT")
	public String getJundalPartOut() {
		return this.jundalPartOut;
	}

	public void setJundalPartOut(String jundalPartOut) {
		this.jundalPartOut = jundalPartOut;
	}


	@Column(name="JUNDAL_TABLE_INP")
	public String getJundalTableInp() {
		return this.jundalTableInp;
	}

	public void setJundalTableInp(String jundalTableInp) {
		this.jundalTableInp = jundalTableInp;
	}


	@Column(name="JUNDAL_TABLE_OUT")
	public String getJundalTableOut() {
		return this.jundalTableOut;
	}

	public void setJundalTableOut(String jundalTableOut) {
		this.jundalTableOut = jundalTableOut;
	}


	@Column(name="MOVE_PART")
	public String getMovePart() {
		return this.movePart;
	}

	public void setMovePart(String movePart) {
		this.movePart = movePart;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}
package nta.med.core.domain.pfe;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the PFE5010 database table.
 * 
 */
@Entity
@NamedQuery(name="Pfe5010.findAll", query="SELECT p FROM Pfe5010 p")
public class Pfe5010 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String dataDubun;
	private double fkinp1001;
	private double fkout1001;
	private String hospCode;
	private String ifSendFlag;
	private String inOutGubun;
	private Date orderDate;
	private double pkpfe5010;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Pfe5010() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DATA_DUBUN")
	public String getDataDubun() {
		return this.dataDubun;
	}

	public void setDataDubun(String dataDubun) {
		this.dataDubun = dataDubun;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IF_SEND_FLAG")
	public String getIfSendFlag() {
		return this.ifSendFlag;
	}

	public void setIfSendFlag(String ifSendFlag) {
		this.ifSendFlag = ifSendFlag;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public double getPkpfe5010() {
		return this.pkpfe5010;
	}

	public void setPkpfe5010(double pkpfe5010) {
		this.pkpfe5010 = pkpfe5010;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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
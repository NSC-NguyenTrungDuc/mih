package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2020 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2020.findAll", query="SELECT o FROM Ocs2020 o")
public class Ocs2020 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actDate;
	private String actId;
	private String bunho;
	private double changeQty;
	private double dv;
	private Date endDate;
	private String endTime;
	private double fio2;
	private double fkinp1001;
	private double fkocs2003Act1;
	private double fkocs2003Act2;
	private double fkocs2003Act3;
	private double fkocs2003Act4;
	private String hangmogCode;
	private String hospCode;
	private String inputGubun;
	private Date orderDate;
	private double pkSeq;
	private double seq;
	private String startTime;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs2020() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACT_DATE")
	public Date getActDate() {
		return this.actDate;
	}

	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}


	@Column(name="ACT_ID")
	public String getActId() {
		return this.actId;
	}

	public void setActId(String actId) {
		this.actId = actId;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHANGE_QTY")
	public double getChangeQty() {
		return this.changeQty;
	}

	public void setChangeQty(double changeQty) {
		this.changeQty = changeQty;
	}


	public double getDv() {
		return this.dv;
	}

	public void setDv(double dv) {
		this.dv = dv;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="END_TIME")
	public String getEndTime() {
		return this.endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}


	public double getFio2() {
		return this.fio2;
	}

	public void setFio2(double fio2) {
		this.fio2 = fio2;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="FKOCS2003_ACT1")
	public double getFkocs2003Act1() {
		return this.fkocs2003Act1;
	}

	public void setFkocs2003Act1(double fkocs2003Act1) {
		this.fkocs2003Act1 = fkocs2003Act1;
	}


	@Column(name="FKOCS2003_ACT2")
	public double getFkocs2003Act2() {
		return this.fkocs2003Act2;
	}

	public void setFkocs2003Act2(double fkocs2003Act2) {
		this.fkocs2003Act2 = fkocs2003Act2;
	}


	@Column(name="FKOCS2003_ACT3")
	public double getFkocs2003Act3() {
		return this.fkocs2003Act3;
	}

	public void setFkocs2003Act3(double fkocs2003Act3) {
		this.fkocs2003Act3 = fkocs2003Act3;
	}


	@Column(name="FKOCS2003_ACT4")
	public double getFkocs2003Act4() {
		return this.fkocs2003Act4;
	}

	public void setFkocs2003Act4(double fkocs2003Act4) {
		this.fkocs2003Act4 = fkocs2003Act4;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}


	@Column(name="START_TIME")
	public String getStartTime() {
		return this.startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
		this.suryang = suryang;
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
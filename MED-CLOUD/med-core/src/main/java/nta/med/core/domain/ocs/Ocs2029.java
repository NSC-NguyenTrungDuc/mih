package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2029 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2029.findAll", query="SELECT o FROM Ocs2029 o")
public class Ocs2029 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actingTime;
	private double bpFrom1;
	private double bpFrom2;
	private double bstValue;
	private String bunho;
	private double fkinp1001;
	private String hospCode;
	private double hospDays;
	private double inBlood;
	private double inOral;
	private double inParenteral;
	private double ioGroupSer;
	private String nurseJisiGubun;
	private Date orderDate;
	private double outDrainage;
	private double outStool;
	private double outSuction;
	private double outUrine;
	private double outVromitus;
	private double postopDays;
	private double pulse;
	private double respiration;
	private double seq;
	private Date sysDate;
	private String sysId;
	private double temperature;
	private String txName1;
	private String txName2;
	private String txName3;
	private String txName4;
	private double txValue;
	private Date updDate;
	private String updId;
	private double weight;

	public Ocs2029() {
	}


	@Column(name="ACTING_TIME")
	public String getActingTime() {
		return this.actingTime;
	}

	public void setActingTime(String actingTime) {
		this.actingTime = actingTime;
	}


	@Column(name="BP_FROM1")
	public double getBpFrom1() {
		return this.bpFrom1;
	}

	public void setBpFrom1(double bpFrom1) {
		this.bpFrom1 = bpFrom1;
	}


	@Column(name="BP_FROM2")
	public double getBpFrom2() {
		return this.bpFrom2;
	}

	public void setBpFrom2(double bpFrom2) {
		this.bpFrom2 = bpFrom2;
	}


	@Column(name="BST_VALUE")
	public double getBstValue() {
		return this.bstValue;
	}

	public void setBstValue(double bstValue) {
		this.bstValue = bstValue;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="HOSP_DAYS")
	public double getHospDays() {
		return this.hospDays;
	}

	public void setHospDays(double hospDays) {
		this.hospDays = hospDays;
	}


	@Column(name="IN_BLOOD")
	public double getInBlood() {
		return this.inBlood;
	}

	public void setInBlood(double inBlood) {
		this.inBlood = inBlood;
	}


	@Column(name="IN_ORAL")
	public double getInOral() {
		return this.inOral;
	}

	public void setInOral(double inOral) {
		this.inOral = inOral;
	}


	@Column(name="IN_PARENTERAL")
	public double getInParenteral() {
		return this.inParenteral;
	}

	public void setInParenteral(double inParenteral) {
		this.inParenteral = inParenteral;
	}


	@Column(name="IO_GROUP_SER")
	public double getIoGroupSer() {
		return this.ioGroupSer;
	}

	public void setIoGroupSer(double ioGroupSer) {
		this.ioGroupSer = ioGroupSer;
	}


	@Column(name="NURSE_JISI_GUBUN")
	public String getNurseJisiGubun() {
		return this.nurseJisiGubun;
	}

	public void setNurseJisiGubun(String nurseJisiGubun) {
		this.nurseJisiGubun = nurseJisiGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="OUT_DRAINAGE")
	public double getOutDrainage() {
		return this.outDrainage;
	}

	public void setOutDrainage(double outDrainage) {
		this.outDrainage = outDrainage;
	}


	@Column(name="OUT_STOOL")
	public double getOutStool() {
		return this.outStool;
	}

	public void setOutStool(double outStool) {
		this.outStool = outStool;
	}


	@Column(name="OUT_SUCTION")
	public double getOutSuction() {
		return this.outSuction;
	}

	public void setOutSuction(double outSuction) {
		this.outSuction = outSuction;
	}


	@Column(name="OUT_URINE")
	public double getOutUrine() {
		return this.outUrine;
	}

	public void setOutUrine(double outUrine) {
		this.outUrine = outUrine;
	}


	@Column(name="OUT_VROMITUS")
	public double getOutVromitus() {
		return this.outVromitus;
	}

	public void setOutVromitus(double outVromitus) {
		this.outVromitus = outVromitus;
	}


	@Column(name="POSTOP_DAYS")
	public double getPostopDays() {
		return this.postopDays;
	}

	public void setPostopDays(double postopDays) {
		this.postopDays = postopDays;
	}


	public double getPulse() {
		return this.pulse;
	}

	public void setPulse(double pulse) {
		this.pulse = pulse;
	}


	public double getRespiration() {
		return this.respiration;
	}

	public void setRespiration(double respiration) {
		this.respiration = respiration;
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


	public double getTemperature() {
		return this.temperature;
	}

	public void setTemperature(double temperature) {
		this.temperature = temperature;
	}


	@Column(name="TX_NAME1")
	public String getTxName1() {
		return this.txName1;
	}

	public void setTxName1(String txName1) {
		this.txName1 = txName1;
	}


	@Column(name="TX_NAME2")
	public String getTxName2() {
		return this.txName2;
	}

	public void setTxName2(String txName2) {
		this.txName2 = txName2;
	}


	@Column(name="TX_NAME3")
	public String getTxName3() {
		return this.txName3;
	}

	public void setTxName3(String txName3) {
		this.txName3 = txName3;
	}


	@Column(name="TX_NAME4")
	public String getTxName4() {
		return this.txName4;
	}

	public void setTxName4(String txName4) {
		this.txName4 = txName4;
	}


	@Column(name="TX_VALUE")
	public double getTxValue() {
		return this.txValue;
	}

	public void setTxValue(double txValue) {
		this.txValue = txValue;
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


	public double getWeight() {
		return this.weight;
	}

	public void setWeight(double weight) {
		this.weight = weight;
	}

}
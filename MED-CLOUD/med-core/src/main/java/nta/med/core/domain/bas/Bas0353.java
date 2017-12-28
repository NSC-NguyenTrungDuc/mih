package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0353 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0353.findAll", query="SELECT b FROM Bas0353 b")
public class Bas0353 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date fromJyDate;
	private double gasanRate;
	private String gasanYn;
	private double gijunAmt;
	private String handoGubunName;
	private double hoisu;
	private String hospCode;
	private double inHando;
	private double inOutHando;
	private double outHando;
	private String receiptName;
	private String selfHandoGubun;
	private String siksaBonGubun;
	private Date sysDate;
	private String sysId;
	private Date toJyDate;
	private Date updDate;
	private String updId;

	public Bas0353() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_JY_DATE")
	public Date getFromJyDate() {
		return this.fromJyDate;
	}

	public void setFromJyDate(Date fromJyDate) {
		this.fromJyDate = fromJyDate;
	}


	@Column(name="GASAN_RATE")
	public double getGasanRate() {
		return this.gasanRate;
	}

	public void setGasanRate(double gasanRate) {
		this.gasanRate = gasanRate;
	}


	@Column(name="GASAN_YN")
	public String getGasanYn() {
		return this.gasanYn;
	}

	public void setGasanYn(String gasanYn) {
		this.gasanYn = gasanYn;
	}


	@Column(name="GIJUN_AMT")
	public double getGijunAmt() {
		return this.gijunAmt;
	}

	public void setGijunAmt(double gijunAmt) {
		this.gijunAmt = gijunAmt;
	}


	@Column(name="HANDO_GUBUN_NAME")
	public String getHandoGubunName() {
		return this.handoGubunName;
	}

	public void setHandoGubunName(String handoGubunName) {
		this.handoGubunName = handoGubunName;
	}


	public double getHoisu() {
		return this.hoisu;
	}

	public void setHoisu(double hoisu) {
		this.hoisu = hoisu;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IN_HANDO")
	public double getInHando() {
		return this.inHando;
	}

	public void setInHando(double inHando) {
		this.inHando = inHando;
	}


	@Column(name="IN_OUT_HANDO")
	public double getInOutHando() {
		return this.inOutHando;
	}

	public void setInOutHando(double inOutHando) {
		this.inOutHando = inOutHando;
	}


	@Column(name="OUT_HANDO")
	public double getOutHando() {
		return this.outHando;
	}

	public void setOutHando(double outHando) {
		this.outHando = outHando;
	}


	@Column(name="RECEIPT_NAME")
	public String getReceiptName() {
		return this.receiptName;
	}

	public void setReceiptName(String receiptName) {
		this.receiptName = receiptName;
	}


	@Column(name="SELF_HANDO_GUBUN")
	public String getSelfHandoGubun() {
		return this.selfHandoGubun;
	}

	public void setSelfHandoGubun(String selfHandoGubun) {
		this.selfHandoGubun = selfHandoGubun;
	}


	@Column(name="SIKSA_BON_GUBUN")
	public String getSiksaBonGubun() {
		return this.siksaBonGubun;
	}

	public void setSiksaBonGubun(String siksaBonGubun) {
		this.siksaBonGubun = siksaBonGubun;
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
	@Column(name="TO_JY_DATE")
	public Date getToJyDate() {
		return this.toJyDate;
	}

	public void setToJyDate(Date toJyDate) {
		this.toJyDate = toJyDate;
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
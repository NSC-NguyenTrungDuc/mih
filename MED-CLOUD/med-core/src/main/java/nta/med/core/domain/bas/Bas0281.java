package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0281 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0281.findAll", query="SELECT b FROM Bas0281 b")
public class Bas0281 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunCode;
	private String disGubun;
	private String disGubunName;
	private Date disGubunYmd;
	private String disMethod;
	private String disMethodSpe;
	private String gubun;
	private String hospCode;
	private double inpNonPay;
	private double inpPay;
	private double inpSpecial;
	private double outNonPay;
	private double outPay;
	private double outSpecial;
	private String sgCode;
	private Date sysDate;
	private String sysId;
	private String tableFindYn;
	private Date updDate;
	private String updId;

	public Bas0281() {
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	@Column(name="DIS_GUBUN")
	public String getDisGubun() {
		return this.disGubun;
	}

	public void setDisGubun(String disGubun) {
		this.disGubun = disGubun;
	}


	@Column(name="DIS_GUBUN_NAME")
	public String getDisGubunName() {
		return this.disGubunName;
	}

	public void setDisGubunName(String disGubunName) {
		this.disGubunName = disGubunName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DIS_GUBUN_YMD")
	public Date getDisGubunYmd() {
		return this.disGubunYmd;
	}

	public void setDisGubunYmd(Date disGubunYmd) {
		this.disGubunYmd = disGubunYmd;
	}


	@Column(name="DIS_METHOD")
	public String getDisMethod() {
		return this.disMethod;
	}

	public void setDisMethod(String disMethod) {
		this.disMethod = disMethod;
	}


	@Column(name="DIS_METHOD_SPE")
	public String getDisMethodSpe() {
		return this.disMethodSpe;
	}

	public void setDisMethodSpe(String disMethodSpe) {
		this.disMethodSpe = disMethodSpe;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INP_NON_PAY")
	public double getInpNonPay() {
		return this.inpNonPay;
	}

	public void setInpNonPay(double inpNonPay) {
		this.inpNonPay = inpNonPay;
	}


	@Column(name="INP_PAY")
	public double getInpPay() {
		return this.inpPay;
	}

	public void setInpPay(double inpPay) {
		this.inpPay = inpPay;
	}


	@Column(name="INP_SPECIAL")
	public double getInpSpecial() {
		return this.inpSpecial;
	}

	public void setInpSpecial(double inpSpecial) {
		this.inpSpecial = inpSpecial;
	}


	@Column(name="OUT_NON_PAY")
	public double getOutNonPay() {
		return this.outNonPay;
	}

	public void setOutNonPay(double outNonPay) {
		this.outNonPay = outNonPay;
	}


	@Column(name="OUT_PAY")
	public double getOutPay() {
		return this.outPay;
	}

	public void setOutPay(double outPay) {
		this.outPay = outPay;
	}


	@Column(name="OUT_SPECIAL")
	public double getOutSpecial() {
		return this.outSpecial;
	}

	public void setOutSpecial(double outSpecial) {
		this.outSpecial = outSpecial;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
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


	@Column(name="TABLE_FIND_YN")
	public String getTableFindYn() {
		return this.tableFindYn;
	}

	public void setTableFindYn(String tableFindYn) {
		this.tableFindYn = tableFindYn;
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
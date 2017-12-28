package nta.med.core.domain.hpc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the HPC0109 database table.
 * 
 */
@Entity
@NamedQuery(name="Hpc0109.findAll", query="SELECT h FROM Hpc0109 h")
public class Hpc0109 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double bonAmt;
	private double comAmt;
	private double com2Amt;
	private double com3Amt;
	private String companyCode;
	private Date gaeyakDate;
	private String gumsaGubun;
	private String gumsaItem;
	private String gumsaYn;
	private String hangmogCode;
	private String hospCode;
	private Date jukyongDate;
	private String mfGubun;
	private String resultChoose;
	private double suntakAmt;
	private String suntakGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Hpc0109() {
	}


	@Column(name="BON_AMT")
	public double getBonAmt() {
		return this.bonAmt;
	}

	public void setBonAmt(double bonAmt) {
		this.bonAmt = bonAmt;
	}


	@Column(name="COM_AMT")
	public double getComAmt() {
		return this.comAmt;
	}

	public void setComAmt(double comAmt) {
		this.comAmt = comAmt;
	}


	@Column(name="COM2_AMT")
	public double getCom2Amt() {
		return this.com2Amt;
	}

	public void setCom2Amt(double com2Amt) {
		this.com2Amt = com2Amt;
	}


	@Column(name="COM3_AMT")
	public double getCom3Amt() {
		return this.com3Amt;
	}

	public void setCom3Amt(double com3Amt) {
		this.com3Amt = com3Amt;
	}


	@Column(name="COMPANY_CODE")
	public String getCompanyCode() {
		return this.companyCode;
	}

	public void setCompanyCode(String companyCode) {
		this.companyCode = companyCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GAEYAK_DATE")
	public Date getGaeyakDate() {
		return this.gaeyakDate;
	}

	public void setGaeyakDate(Date gaeyakDate) {
		this.gaeyakDate = gaeyakDate;
	}


	@Column(name="GUMSA_GUBUN")
	public String getGumsaGubun() {
		return this.gumsaGubun;
	}

	public void setGumsaGubun(String gumsaGubun) {
		this.gumsaGubun = gumsaGubun;
	}


	@Column(name="GUMSA_ITEM")
	public String getGumsaItem() {
		return this.gumsaItem;
	}

	public void setGumsaItem(String gumsaItem) {
		this.gumsaItem = gumsaItem;
	}


	@Column(name="GUMSA_YN")
	public String getGumsaYn() {
		return this.gumsaYn;
	}

	public void setGumsaYn(String gumsaYn) {
		this.gumsaYn = gumsaYn;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUKYONG_DATE")
	public Date getJukyongDate() {
		return this.jukyongDate;
	}

	public void setJukyongDate(Date jukyongDate) {
		this.jukyongDate = jukyongDate;
	}


	@Column(name="MF_GUBUN")
	public String getMfGubun() {
		return this.mfGubun;
	}

	public void setMfGubun(String mfGubun) {
		this.mfGubun = mfGubun;
	}


	@Column(name="RESULT_CHOOSE")
	public String getResultChoose() {
		return this.resultChoose;
	}

	public void setResultChoose(String resultChoose) {
		this.resultChoose = resultChoose;
	}


	@Column(name="SUNTAK_AMT")
	public double getSuntakAmt() {
		return this.suntakAmt;
	}

	public void setSuntakAmt(double suntakAmt) {
		this.suntakAmt = suntakAmt;
	}


	@Column(name="SUNTAK_GUBUN")
	public String getSuntakGubun() {
		return this.suntakGubun;
	}

	public void setSuntakGubun(String suntakGubun) {
		this.suntakGubun = suntakGubun;
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
package nta.med.core.domain.hpc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the HPC3002 database table.
 * 
 */
@Entity
@NamedQuery(name="Hpc3002.findAll", query="SELECT h FROM Hpc3002 h")
public class Hpc3002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double amt;
	private double bonAmt;
	private String bunho;
	private double comAmt;
	private String comYn;
	private double com2Amt;
	private double com3Amt;
	private String companyCode;
	private String danui;
	private String doctorPanjung;
	private String endYn;
	private double fkocs1003;
	private String fromStandard;
	private Date gaeyakDate;
	private Date gumjinDate;
	private String gumjinGubun;
	private String gumsaCode;
	private String gumsaComment;
	private String gumsaGubun;
	private double gumsaInt;
	private String gumsaItem;
	private String gumsaText;
	private String hangmogCode;
	private String hospCode;
	private Date jukyongDate;
	private String mfGubun;
	private String panjung1;
	private String panjung2;
	private String panjungCode;
	private String printYn;
	private Date result01Date;
	private String result01Panjung;
	private String result01Text;
	private String result01User;
	private Date result02Date;
	private String result02Panjung;
	private String result02Text;
	private String result02User;
	private Date result03Date;
	private String result03Panjung;
	private String result03Text;
	private String result03User;
	private String resultChoose;
	private String resultCode;
	private String resultOutCode;
	private String resultText;
	private String standardText;
	private String standardYn;
	private String sunabYn;
	private String suntakGubun;
	private Date sysDate;
	private String sysId;
	private String toStandard;
	private double tonggyeCode;
	private Date updDate;
	private String updId;
	private String xrayNo;

	public Hpc3002() {
	}


	public double getAmt() {
		return this.amt;
	}

	public void setAmt(double amt) {
		this.amt = amt;
	}


	@Column(name="BON_AMT")
	public double getBonAmt() {
		return this.bonAmt;
	}

	public void setBonAmt(double bonAmt) {
		this.bonAmt = bonAmt;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="COM_AMT")
	public double getComAmt() {
		return this.comAmt;
	}

	public void setComAmt(double comAmt) {
		this.comAmt = comAmt;
	}


	@Column(name="COM_YN")
	public String getComYn() {
		return this.comYn;
	}

	public void setComYn(String comYn) {
		this.comYn = comYn;
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


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	@Column(name="DOCTOR_PANJUNG")
	public String getDoctorPanjung() {
		return this.doctorPanjung;
	}

	public void setDoctorPanjung(String doctorPanjung) {
		this.doctorPanjung = doctorPanjung;
	}


	@Column(name="END_YN")
	public String getEndYn() {
		return this.endYn;
	}

	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}


	public double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	@Column(name="FROM_STANDARD")
	public String getFromStandard() {
		return this.fromStandard;
	}

	public void setFromStandard(String fromStandard) {
		this.fromStandard = fromStandard;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GAEYAK_DATE")
	public Date getGaeyakDate() {
		return this.gaeyakDate;
	}

	public void setGaeyakDate(Date gaeyakDate) {
		this.gaeyakDate = gaeyakDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUMJIN_DATE")
	public Date getGumjinDate() {
		return this.gumjinDate;
	}

	public void setGumjinDate(Date gumjinDate) {
		this.gumjinDate = gumjinDate;
	}


	@Column(name="GUMJIN_GUBUN")
	public String getGumjinGubun() {
		return this.gumjinGubun;
	}

	public void setGumjinGubun(String gumjinGubun) {
		this.gumjinGubun = gumjinGubun;
	}


	@Column(name="GUMSA_CODE")
	public String getGumsaCode() {
		return this.gumsaCode;
	}

	public void setGumsaCode(String gumsaCode) {
		this.gumsaCode = gumsaCode;
	}


	@Column(name="GUMSA_COMMENT")
	public String getGumsaComment() {
		return this.gumsaComment;
	}

	public void setGumsaComment(String gumsaComment) {
		this.gumsaComment = gumsaComment;
	}


	@Column(name="GUMSA_GUBUN")
	public String getGumsaGubun() {
		return this.gumsaGubun;
	}

	public void setGumsaGubun(String gumsaGubun) {
		this.gumsaGubun = gumsaGubun;
	}


	@Column(name="GUMSA_INT")
	public double getGumsaInt() {
		return this.gumsaInt;
	}

	public void setGumsaInt(double gumsaInt) {
		this.gumsaInt = gumsaInt;
	}


	@Column(name="GUMSA_ITEM")
	public String getGumsaItem() {
		return this.gumsaItem;
	}

	public void setGumsaItem(String gumsaItem) {
		this.gumsaItem = gumsaItem;
	}


	@Column(name="GUMSA_TEXT")
	public String getGumsaText() {
		return this.gumsaText;
	}

	public void setGumsaText(String gumsaText) {
		this.gumsaText = gumsaText;
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


	@Column(name="PANJUNG_1")
	public String getPanjung1() {
		return this.panjung1;
	}

	public void setPanjung1(String panjung1) {
		this.panjung1 = panjung1;
	}


	@Column(name="PANJUNG_2")
	public String getPanjung2() {
		return this.panjung2;
	}

	public void setPanjung2(String panjung2) {
		this.panjung2 = panjung2;
	}


	@Column(name="PANJUNG_CODE")
	public String getPanjungCode() {
		return this.panjungCode;
	}

	public void setPanjungCode(String panjungCode) {
		this.panjungCode = panjungCode;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_01_DATE")
	public Date getResult01Date() {
		return this.result01Date;
	}

	public void setResult01Date(Date result01Date) {
		this.result01Date = result01Date;
	}


	@Column(name="RESULT_01_PANJUNG")
	public String getResult01Panjung() {
		return this.result01Panjung;
	}

	public void setResult01Panjung(String result01Panjung) {
		this.result01Panjung = result01Panjung;
	}


	@Column(name="RESULT_01_TEXT")
	public String getResult01Text() {
		return this.result01Text;
	}

	public void setResult01Text(String result01Text) {
		this.result01Text = result01Text;
	}


	@Column(name="RESULT_01_USER")
	public String getResult01User() {
		return this.result01User;
	}

	public void setResult01User(String result01User) {
		this.result01User = result01User;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_02_DATE")
	public Date getResult02Date() {
		return this.result02Date;
	}

	public void setResult02Date(Date result02Date) {
		this.result02Date = result02Date;
	}


	@Column(name="RESULT_02_PANJUNG")
	public String getResult02Panjung() {
		return this.result02Panjung;
	}

	public void setResult02Panjung(String result02Panjung) {
		this.result02Panjung = result02Panjung;
	}


	@Column(name="RESULT_02_TEXT")
	public String getResult02Text() {
		return this.result02Text;
	}

	public void setResult02Text(String result02Text) {
		this.result02Text = result02Text;
	}


	@Column(name="RESULT_02_USER")
	public String getResult02User() {
		return this.result02User;
	}

	public void setResult02User(String result02User) {
		this.result02User = result02User;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_03_DATE")
	public Date getResult03Date() {
		return this.result03Date;
	}

	public void setResult03Date(Date result03Date) {
		this.result03Date = result03Date;
	}


	@Column(name="RESULT_03_PANJUNG")
	public String getResult03Panjung() {
		return this.result03Panjung;
	}

	public void setResult03Panjung(String result03Panjung) {
		this.result03Panjung = result03Panjung;
	}


	@Column(name="RESULT_03_TEXT")
	public String getResult03Text() {
		return this.result03Text;
	}

	public void setResult03Text(String result03Text) {
		this.result03Text = result03Text;
	}


	@Column(name="RESULT_03_USER")
	public String getResult03User() {
		return this.result03User;
	}

	public void setResult03User(String result03User) {
		this.result03User = result03User;
	}


	@Column(name="RESULT_CHOOSE")
	public String getResultChoose() {
		return this.resultChoose;
	}

	public void setResultChoose(String resultChoose) {
		this.resultChoose = resultChoose;
	}


	@Column(name="RESULT_CODE")
	public String getResultCode() {
		return this.resultCode;
	}

	public void setResultCode(String resultCode) {
		this.resultCode = resultCode;
	}


	@Column(name="RESULT_OUT_CODE")
	public String getResultOutCode() {
		return this.resultOutCode;
	}

	public void setResultOutCode(String resultOutCode) {
		this.resultOutCode = resultOutCode;
	}


	@Column(name="RESULT_TEXT")
	public String getResultText() {
		return this.resultText;
	}

	public void setResultText(String resultText) {
		this.resultText = resultText;
	}


	@Column(name="STANDARD_TEXT")
	public String getStandardText() {
		return this.standardText;
	}

	public void setStandardText(String standardText) {
		this.standardText = standardText;
	}


	@Column(name="STANDARD_YN")
	public String getStandardYn() {
		return this.standardYn;
	}

	public void setStandardYn(String standardYn) {
		this.standardYn = standardYn;
	}


	@Column(name="SUNAB_YN")
	public String getSunabYn() {
		return this.sunabYn;
	}

	public void setSunabYn(String sunabYn) {
		this.sunabYn = sunabYn;
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


	@Column(name="TO_STANDARD")
	public String getToStandard() {
		return this.toStandard;
	}

	public void setToStandard(String toStandard) {
		this.toStandard = toStandard;
	}


	@Column(name="TONGGYE_CODE")
	public double getTonggyeCode() {
		return this.tonggyeCode;
	}

	public void setTonggyeCode(double tonggyeCode) {
		this.tonggyeCode = tonggyeCode;
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


	@Column(name="XRAY_NO")
	public String getXrayNo() {
		return this.xrayNo;
	}

	public void setXrayNo(String xrayNo) {
		this.xrayNo = xrayNo;
	}

}
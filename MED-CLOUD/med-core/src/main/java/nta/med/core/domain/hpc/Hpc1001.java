package nta.med.core.domain.hpc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the HPC1001 database table.
 * 
 */
@Entity
@NamedQuery(name="Hpc1001.findAll", query="SELECT h FROM Hpc1001 h")
public class Hpc1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String amtMemo;
	private String balsongYn;
	private String bigo;
	private String bunho;
	private String changgu;
	private Date checkDate;
	private String checkYn;
	private String chojae;
	private String company;
	private String companyCode;
	private String deleteYn;
	private String disGubun;
	private String endFlag;
	private Date firstGumjinDate;
	private double fkhpc2001;
	private String fkout1001;
	private String gaein;
	private String gaeinGubun;
	private String gaeinNo;
	private Date gaeyakDate;
	private String gubun;
	private Date gumjinDate;
	private String gumjinGubun;
	private String gumjinSeq;
	private String hospCode;
	private String insertYn;
	private String johap;
	private Date jubsuDate;
	private double jubsuNo;
	private String jubsuTime;
	private Date junpyoDate;
	private String memo;
	private double pkhpc1001;
	private Date printDate;
	private String printFlag;
	private String printUser;
	private String reserBunho;
	private Date reserDate;
	private double reserNo;
	private Date resultDate;
	private String sabun;
	private Date sangdamDate;
	private String sangdamTime;
	private String sangdamUser;
	private String sex;
	private String siksaYn;
	private String sogae;
	private Date sysDate;
	private String sysId;
	private double tempBDisAmt;
	private double tempJohabAmt;
	private Date updDate;
	private String updId;

	public Hpc1001() {
	}


	@Column(name="AMT_MEMO")
	public String getAmtMemo() {
		return this.amtMemo;
	}

	public void setAmtMemo(String amtMemo) {
		this.amtMemo = amtMemo;
	}


	@Column(name="BALSONG_YN")
	public String getBalsongYn() {
		return this.balsongYn;
	}

	public void setBalsongYn(String balsongYn) {
		this.balsongYn = balsongYn;
	}


	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getChanggu() {
		return this.changgu;
	}

	public void setChanggu(String changgu) {
		this.changgu = changgu;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHECK_DATE")
	public Date getCheckDate() {
		return this.checkDate;
	}

	public void setCheckDate(Date checkDate) {
		this.checkDate = checkDate;
	}


	@Column(name="CHECK_YN")
	public String getCheckYn() {
		return this.checkYn;
	}

	public void setCheckYn(String checkYn) {
		this.checkYn = checkYn;
	}


	public String getChojae() {
		return this.chojae;
	}

	public void setChojae(String chojae) {
		this.chojae = chojae;
	}


	public String getCompany() {
		return this.company;
	}

	public void setCompany(String company) {
		this.company = company;
	}


	@Column(name="COMPANY_CODE")
	public String getCompanyCode() {
		return this.companyCode;
	}

	public void setCompanyCode(String companyCode) {
		this.companyCode = companyCode;
	}


	@Column(name="DELETE_YN")
	public String getDeleteYn() {
		return this.deleteYn;
	}

	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}


	@Column(name="DIS_GUBUN")
	public String getDisGubun() {
		return this.disGubun;
	}

	public void setDisGubun(String disGubun) {
		this.disGubun = disGubun;
	}


	@Column(name="END_FLAG")
	public String getEndFlag() {
		return this.endFlag;
	}

	public void setEndFlag(String endFlag) {
		this.endFlag = endFlag;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FIRST_GUMJIN_DATE")
	public Date getFirstGumjinDate() {
		return this.firstGumjinDate;
	}

	public void setFirstGumjinDate(Date firstGumjinDate) {
		this.firstGumjinDate = firstGumjinDate;
	}


	public double getFkhpc2001() {
		return this.fkhpc2001;
	}

	public void setFkhpc2001(double fkhpc2001) {
		this.fkhpc2001 = fkhpc2001;
	}


	public String getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(String fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public String getGaein() {
		return this.gaein;
	}

	public void setGaein(String gaein) {
		this.gaein = gaein;
	}


	@Column(name="GAEIN_GUBUN")
	public String getGaeinGubun() {
		return this.gaeinGubun;
	}

	public void setGaeinGubun(String gaeinGubun) {
		this.gaeinGubun = gaeinGubun;
	}


	@Column(name="GAEIN_NO")
	public String getGaeinNo() {
		return this.gaeinNo;
	}

	public void setGaeinNo(String gaeinNo) {
		this.gaeinNo = gaeinNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GAEYAK_DATE")
	public Date getGaeyakDate() {
		return this.gaeyakDate;
	}

	public void setGaeyakDate(Date gaeyakDate) {
		this.gaeyakDate = gaeyakDate;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
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


	@Column(name="GUMJIN_SEQ")
	public String getGumjinSeq() {
		return this.gumjinSeq;
	}

	public void setGumjinSeq(String gumjinSeq) {
		this.gumjinSeq = gumjinSeq;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INSERT_YN")
	public String getInsertYn() {
		return this.insertYn;
	}

	public void setInsertYn(String insertYn) {
		this.insertYn = insertYn;
	}


	public String getJohap() {
		return this.johap;
	}

	public void setJohap(String johap) {
		this.johap = johap;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_NO")
	public double getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUNPYO_DATE")
	public Date getJunpyoDate() {
		return this.junpyoDate;
	}

	public void setJunpyoDate(Date junpyoDate) {
		this.junpyoDate = junpyoDate;
	}


	public String getMemo() {
		return this.memo;
	}

	public void setMemo(String memo) {
		this.memo = memo;
	}


	public double getPkhpc1001() {
		return this.pkhpc1001;
	}

	public void setPkhpc1001(double pkhpc1001) {
		this.pkhpc1001 = pkhpc1001;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PRINT_DATE")
	public Date getPrintDate() {
		return this.printDate;
	}

	public void setPrintDate(Date printDate) {
		this.printDate = printDate;
	}


	@Column(name="PRINT_FLAG")
	public String getPrintFlag() {
		return this.printFlag;
	}

	public void setPrintFlag(String printFlag) {
		this.printFlag = printFlag;
	}


	@Column(name="PRINT_USER")
	public String getPrintUser() {
		return this.printUser;
	}

	public void setPrintUser(String printUser) {
		this.printUser = printUser;
	}


	@Column(name="RESER_BUNHO")
	public String getReserBunho() {
		return this.reserBunho;
	}

	public void setReserBunho(String reserBunho) {
		this.reserBunho = reserBunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}


	@Column(name="RESER_NO")
	public double getReserNo() {
		return this.reserNo;
	}

	public void setReserNo(double reserNo) {
		this.reserNo = reserNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	public String getSabun() {
		return this.sabun;
	}

	public void setSabun(String sabun) {
		this.sabun = sabun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SANGDAM_DATE")
	public Date getSangdamDate() {
		return this.sangdamDate;
	}

	public void setSangdamDate(Date sangdamDate) {
		this.sangdamDate = sangdamDate;
	}


	@Column(name="SANGDAM_TIME")
	public String getSangdamTime() {
		return this.sangdamTime;
	}

	public void setSangdamTime(String sangdamTime) {
		this.sangdamTime = sangdamTime;
	}


	@Column(name="SANGDAM_USER")
	public String getSangdamUser() {
		return this.sangdamUser;
	}

	public void setSangdamUser(String sangdamUser) {
		this.sangdamUser = sangdamUser;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	@Column(name="SIKSA_YN")
	public String getSiksaYn() {
		return this.siksaYn;
	}

	public void setSiksaYn(String siksaYn) {
		this.siksaYn = siksaYn;
	}


	public String getSogae() {
		return this.sogae;
	}

	public void setSogae(String sogae) {
		this.sogae = sogae;
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


	@Column(name="TEMP_B_DIS_AMT")
	public double getTempBDisAmt() {
		return this.tempBDisAmt;
	}

	public void setTempBDisAmt(double tempBDisAmt) {
		this.tempBDisAmt = tempBDisAmt;
	}


	@Column(name="TEMP_JOHAB_AMT")
	public double getTempJohabAmt() {
		return this.tempJohabAmt;
	}

	public void setTempJohabAmt(double tempJohabAmt) {
		this.tempJohabAmt = tempJohabAmt;
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
package nta.med.core.domain.drg;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DRG2035 database table.
 * 
 */
@Entity
@NamedQuery(name="Drg2035.findAll", query="SELECT d FROM Drg2035 d")
public class Drg2035 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String atcYn;
	private String bogyongCode;
	private String bogyongGubun;
	private String bunriYn;
	private String bunryu1;
	private String cautionCode;
	private String danui;
	private String divide;
	private double drgBunho;
	private String drgGrp;
	private String drgPackYn;
	private double fkocs2003;
	private String hospCode;
	private String jojePlace;
	private Date jubsuDate;
	private String jundalPartRun;
	private String magamGubun;
	private String mayakYn;
	private double nalsu;
	private String pharmacy;
	private String powderYn;
	private String print;
	private String printBogyong;
	private String printYn;
	private String serialV;
	private Date sysDate;
	private String sysId;
	private String title;
	private Date updDate;
	private String updId;

	public Drg2035() {
	}


	@Column(name="ATC_YN")
	public String getAtcYn() {
		return this.atcYn;
	}

	public void setAtcYn(String atcYn) {
		this.atcYn = atcYn;
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="BOGYONG_GUBUN")
	public String getBogyongGubun() {
		return this.bogyongGubun;
	}

	public void setBogyongGubun(String bogyongGubun) {
		this.bogyongGubun = bogyongGubun;
	}


	@Column(name="BUNRI_YN")
	public String getBunriYn() {
		return this.bunriYn;
	}

	public void setBunriYn(String bunriYn) {
		this.bunriYn = bunriYn;
	}


	public String getBunryu1() {
		return this.bunryu1;
	}

	public void setBunryu1(String bunryu1) {
		this.bunryu1 = bunryu1;
	}


	@Column(name="CAUTION_CODE")
	public String getCautionCode() {
		return this.cautionCode;
	}

	public void setCautionCode(String cautionCode) {
		this.cautionCode = cautionCode;
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	public String getDivide() {
		return this.divide;
	}

	public void setDivide(String divide) {
		this.divide = divide;
	}


	@Column(name="DRG_BUNHO")
	public double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(double drgBunho) {
		this.drgBunho = drgBunho;
	}


	@Column(name="DRG_GRP")
	public String getDrgGrp() {
		return this.drgGrp;
	}

	public void setDrgGrp(String drgGrp) {
		this.drgGrp = drgGrp;
	}


	@Column(name="DRG_PACK_YN")
	public String getDrgPackYn() {
		return this.drgPackYn;
	}

	public void setDrgPackYn(String drgPackYn) {
		this.drgPackYn = drgPackYn;
	}


	public double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JOJE_PLACE")
	public String getJojePlace() {
		return this.jojePlace;
	}

	public void setJojePlace(String jojePlace) {
		this.jojePlace = jojePlace;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUNDAL_PART_RUN")
	public String getJundalPartRun() {
		return this.jundalPartRun;
	}

	public void setJundalPartRun(String jundalPartRun) {
		this.jundalPartRun = jundalPartRun;
	}


	@Column(name="MAGAM_GUBUN")
	public String getMagamGubun() {
		return this.magamGubun;
	}

	public void setMagamGubun(String magamGubun) {
		this.magamGubun = magamGubun;
	}


	@Column(name="MAYAK_YN")
	public String getMayakYn() {
		return this.mayakYn;
	}

	public void setMayakYn(String mayakYn) {
		this.mayakYn = mayakYn;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	public String getPharmacy() {
		return this.pharmacy;
	}

	public void setPharmacy(String pharmacy) {
		this.pharmacy = pharmacy;
	}


	@Column(name="POWDER_YN")
	public String getPowderYn() {
		return this.powderYn;
	}

	public void setPowderYn(String powderYn) {
		this.powderYn = powderYn;
	}


	public String getPrint() {
		return this.print;
	}

	public void setPrint(String print) {
		this.print = print;
	}


	@Column(name="PRINT_BOGYONG")
	public String getPrintBogyong() {
		return this.printBogyong;
	}

	public void setPrintBogyong(String printBogyong) {
		this.printBogyong = printBogyong;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Column(name="SERIAL_V")
	public String getSerialV() {
		return this.serialV;
	}

	public void setSerialV(String serialV) {
		this.serialV = serialV;
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


	public String getTitle() {
		return this.title;
	}

	public void setTitle(String title) {
		this.title = title;
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
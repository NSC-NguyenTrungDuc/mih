package nta.med.core.domain.xrt;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the XRT0100 database table.
 * 
 */
@Entity
@NamedQuery(name="Xrt0100.findAll", query="SELECT x FROM Xrt0100 x")
public class Xrt0100 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String aPosition;
	private String aSojeji;
	private String bunho;
	private String ctPosition;
	private String ctSojeji;
	private String filmIoFlag;
	private String genPosition;
	private String genSojeji;
	private String hospCode;
	private String mriPosition;
	private String mriSojeji;
	private String riPosition;
	private String riSojeji;
	private String sPosition;
	private String sSojeji;
	private String sonoPosition;
	private String sonoSojeji;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Xrt0100() {
	}


	@Column(name="A_POSITION")
	public String getAPosition() {
		return this.aPosition;
	}

	public void setAPosition(String aPosition) {
		this.aPosition = aPosition;
	}


	@Column(name="A_SOJEJI")
	public String getASojeji() {
		return this.aSojeji;
	}

	public void setASojeji(String aSojeji) {
		this.aSojeji = aSojeji;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CT_POSITION")
	public String getCtPosition() {
		return this.ctPosition;
	}

	public void setCtPosition(String ctPosition) {
		this.ctPosition = ctPosition;
	}


	@Column(name="CT_SOJEJI")
	public String getCtSojeji() {
		return this.ctSojeji;
	}

	public void setCtSojeji(String ctSojeji) {
		this.ctSojeji = ctSojeji;
	}


	@Column(name="FILM_IO_FLAG")
	public String getFilmIoFlag() {
		return this.filmIoFlag;
	}

	public void setFilmIoFlag(String filmIoFlag) {
		this.filmIoFlag = filmIoFlag;
	}


	@Column(name="GEN_POSITION")
	public String getGenPosition() {
		return this.genPosition;
	}

	public void setGenPosition(String genPosition) {
		this.genPosition = genPosition;
	}


	@Column(name="GEN_SOJEJI")
	public String getGenSojeji() {
		return this.genSojeji;
	}

	public void setGenSojeji(String genSojeji) {
		this.genSojeji = genSojeji;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MRI_POSITION")
	public String getMriPosition() {
		return this.mriPosition;
	}

	public void setMriPosition(String mriPosition) {
		this.mriPosition = mriPosition;
	}


	@Column(name="MRI_SOJEJI")
	public String getMriSojeji() {
		return this.mriSojeji;
	}

	public void setMriSojeji(String mriSojeji) {
		this.mriSojeji = mriSojeji;
	}


	@Column(name="RI_POSITION")
	public String getRiPosition() {
		return this.riPosition;
	}

	public void setRiPosition(String riPosition) {
		this.riPosition = riPosition;
	}


	@Column(name="RI_SOJEJI")
	public String getRiSojeji() {
		return this.riSojeji;
	}

	public void setRiSojeji(String riSojeji) {
		this.riSojeji = riSojeji;
	}


	@Column(name="S_POSITION")
	public String getSPosition() {
		return this.sPosition;
	}

	public void setSPosition(String sPosition) {
		this.sPosition = sPosition;
	}


	@Column(name="S_SOJEJI")
	public String getSSojeji() {
		return this.sSojeji;
	}

	public void setSSojeji(String sSojeji) {
		this.sSojeji = sSojeji;
	}


	@Column(name="SONO_POSITION")
	public String getSonoPosition() {
		return this.sonoPosition;
	}

	public void setSonoPosition(String sonoPosition) {
		this.sonoPosition = sonoPosition;
	}


	@Column(name="SONO_SOJEJI")
	public String getSonoSojeji() {
		return this.sonoSojeji;
	}

	public void setSonoSojeji(String sonoSojeji) {
		this.sonoSojeji = sonoSojeji;
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
package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0307 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0307.findAll", query="SELECT c FROM Cpl0307 c")
public class Cpl0307 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String culture1;
	private String culture2;
	private String culture3;
	private String culture4;
	private String culture5;
	private String culture6;
	private String culture7;
	private String culture8;
	private String culture9;
	private String hospCode;
	private String mic1;
	private String mic2;
	private String mic3;
	private String mic4;
	private String mic5;
	private String mic6;
	private Date partJubsuDate;
	private String partJubsuTime;
	private String specimenCode;
	private String specimenSer;
	private String stainAs;
	private String stainGs;
	private String stainIs;
	private String stainKs;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0307() {
	}


	@Column(name="CULTURE_1")
	public String getCulture1() {
		return this.culture1;
	}

	public void setCulture1(String culture1) {
		this.culture1 = culture1;
	}


	@Column(name="CULTURE_2")
	public String getCulture2() {
		return this.culture2;
	}

	public void setCulture2(String culture2) {
		this.culture2 = culture2;
	}


	@Column(name="CULTURE_3")
	public String getCulture3() {
		return this.culture3;
	}

	public void setCulture3(String culture3) {
		this.culture3 = culture3;
	}


	@Column(name="CULTURE_4")
	public String getCulture4() {
		return this.culture4;
	}

	public void setCulture4(String culture4) {
		this.culture4 = culture4;
	}


	@Column(name="CULTURE_5")
	public String getCulture5() {
		return this.culture5;
	}

	public void setCulture5(String culture5) {
		this.culture5 = culture5;
	}


	@Column(name="CULTURE_6")
	public String getCulture6() {
		return this.culture6;
	}

	public void setCulture6(String culture6) {
		this.culture6 = culture6;
	}


	@Column(name="CULTURE_7")
	public String getCulture7() {
		return this.culture7;
	}

	public void setCulture7(String culture7) {
		this.culture7 = culture7;
	}


	@Column(name="CULTURE_8")
	public String getCulture8() {
		return this.culture8;
	}

	public void setCulture8(String culture8) {
		this.culture8 = culture8;
	}


	@Column(name="CULTURE_9")
	public String getCulture9() {
		return this.culture9;
	}

	public void setCulture9(String culture9) {
		this.culture9 = culture9;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MIC_1")
	public String getMic1() {
		return this.mic1;
	}

	public void setMic1(String mic1) {
		this.mic1 = mic1;
	}


	@Column(name="MIC_2")
	public String getMic2() {
		return this.mic2;
	}

	public void setMic2(String mic2) {
		this.mic2 = mic2;
	}


	@Column(name="MIC_3")
	public String getMic3() {
		return this.mic3;
	}

	public void setMic3(String mic3) {
		this.mic3 = mic3;
	}


	@Column(name="MIC_4")
	public String getMic4() {
		return this.mic4;
	}

	public void setMic4(String mic4) {
		this.mic4 = mic4;
	}


	@Column(name="MIC_5")
	public String getMic5() {
		return this.mic5;
	}

	public void setMic5(String mic5) {
		this.mic5 = mic5;
	}


	@Column(name="MIC_6")
	public String getMic6() {
		return this.mic6;
	}

	public void setMic6(String mic6) {
		this.mic6 = mic6;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PART_JUBSU_DATE")
	public Date getPartJubsuDate() {
		return this.partJubsuDate;
	}

	public void setPartJubsuDate(Date partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}


	@Column(name="PART_JUBSU_TIME")
	public String getPartJubsuTime() {
		return this.partJubsuTime;
	}

	public void setPartJubsuTime(String partJubsuTime) {
		this.partJubsuTime = partJubsuTime;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}


	@Column(name="STAIN_AS")
	public String getStainAs() {
		return this.stainAs;
	}

	public void setStainAs(String stainAs) {
		this.stainAs = stainAs;
	}


	@Column(name="STAIN_GS")
	public String getStainGs() {
		return this.stainGs;
	}

	public void setStainGs(String stainGs) {
		this.stainGs = stainGs;
	}


	@Column(name="STAIN_IS")
	public String getStainIs() {
		return this.stainIs;
	}

	public void setStainIs(String stainIs) {
		this.stainIs = stainIs;
	}


	@Column(name="STAIN_KS")
	public String getStainKs() {
		return this.stainKs;
	}

	public void setStainKs(String stainKs) {
		this.stainKs = stainKs;
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
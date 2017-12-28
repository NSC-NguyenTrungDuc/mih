package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL3021 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl3021.findAll", query="SELECT c FROM Cpl3021 c")
public class Cpl3021 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String comment2;
	private String comments;
	private String emergency;
	private double fkcpl2010;
	private String gumsaja;
	private String hangmogCode;
	private String hospCode;
	private String jindanText;
	private String jindanText1;
	private String jindanText2;
	private String labNo;
	private Date resultDate;
	private String resultTime;
	private String sourceGumsa;
	private String specimenCode;
	private String specimenSer;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl3021() {
	}


	public String getComment2() {
		return this.comment2;
	}

	public void setComment2(String comment2) {
		this.comment2 = comment2;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	public double getFkcpl2010() {
		return this.fkcpl2010;
	}

	public void setFkcpl2010(double fkcpl2010) {
		this.fkcpl2010 = fkcpl2010;
	}


	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
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


	@Column(name="JINDAN_TEXT")
	public String getJindanText() {
		return this.jindanText;
	}

	public void setJindanText(String jindanText) {
		this.jindanText = jindanText;
	}


	@Column(name="JINDAN_TEXT1")
	public String getJindanText1() {
		return this.jindanText1;
	}

	public void setJindanText1(String jindanText1) {
		this.jindanText1 = jindanText1;
	}


	@Column(name="JINDAN_TEXT2")
	public String getJindanText2() {
		return this.jindanText2;
	}

	public void setJindanText2(String jindanText2) {
		this.jindanText2 = jindanText2;
	}


	@Column(name="LAB_NO")
	public String getLabNo() {
		return this.labNo;
	}

	public void setLabNo(String labNo) {
		this.labNo = labNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	@Column(name="RESULT_TIME")
	public String getResultTime() {
		return this.resultTime;
	}

	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}


	@Column(name="SOURCE_GUMSA")
	public String getSourceGumsa() {
		return this.sourceGumsa;
	}

	public void setSourceGumsa(String sourceGumsa) {
		this.sourceGumsa = sourceGumsa;
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
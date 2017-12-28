package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS6005 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs6005.findAll", query="SELECT o FROM Ocs6005 o")
public class Ocs6005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String busikYudong;
	private String continueYn;
	private String cpCode;
	private String cpPathCode;
	private String directCode;
	private String directCont1;
	private String directCont2;
	private String directGubun;
	private String directText;
	private String hospCode;
	private String inputDoctor;
	private String inputGubun;
	private String inputGwa;
	private double jaewonil;
	private double jaewonilFrom;
	private double jaewonilTo;
	private String joriType;
	private String jusikYudong;
	private String kumjisik;
	private String memb;
	private String membGubun;
	private double pkSeq;
	private double pkocs6005;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs6005() {
	}


	@Column(name="BUSIK_YUDONG")
	public String getBusikYudong() {
		return this.busikYudong;
	}

	public void setBusikYudong(String busikYudong) {
		this.busikYudong = busikYudong;
	}


	@Column(name="CONTINUE_YN")
	public String getContinueYn() {
		return this.continueYn;
	}

	public void setContinueYn(String continueYn) {
		this.continueYn = continueYn;
	}


	@Column(name="CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}


	@Column(name="CP_PATH_CODE")
	public String getCpPathCode() {
		return this.cpPathCode;
	}

	public void setCpPathCode(String cpPathCode) {
		this.cpPathCode = cpPathCode;
	}


	@Column(name="DIRECT_CODE")
	public String getDirectCode() {
		return this.directCode;
	}

	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}


	@Column(name="DIRECT_CONT1")
	public String getDirectCont1() {
		return this.directCont1;
	}

	public void setDirectCont1(String directCont1) {
		this.directCont1 = directCont1;
	}


	@Column(name="DIRECT_CONT2")
	public String getDirectCont2() {
		return this.directCont2;
	}

	public void setDirectCont2(String directCont2) {
		this.directCont2 = directCont2;
	}


	@Column(name="DIRECT_GUBUN")
	public String getDirectGubun() {
		return this.directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}


	@Column(name="DIRECT_TEXT")
	public String getDirectText() {
		return this.directText;
	}

	public void setDirectText(String directText) {
		this.directText = directText;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_DOCTOR")
	public String getInputDoctor() {
		return this.inputDoctor;
	}

	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}


	@Column(name="INPUT_GWA")
	public String getInputGwa() {
		return this.inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}


	public double getJaewonil() {
		return this.jaewonil;
	}

	public void setJaewonil(double jaewonil) {
		this.jaewonil = jaewonil;
	}


	@Column(name="JAEWONIL_FROM")
	public double getJaewonilFrom() {
		return this.jaewonilFrom;
	}

	public void setJaewonilFrom(double jaewonilFrom) {
		this.jaewonilFrom = jaewonilFrom;
	}


	@Column(name="JAEWONIL_TO")
	public double getJaewonilTo() {
		return this.jaewonilTo;
	}

	public void setJaewonilTo(double jaewonilTo) {
		this.jaewonilTo = jaewonilTo;
	}


	@Column(name="JORI_TYPE")
	public String getJoriType() {
		return this.joriType;
	}

	public void setJoriType(String joriType) {
		this.joriType = joriType;
	}


	@Column(name="JUSIK_YUDONG")
	public String getJusikYudong() {
		return this.jusikYudong;
	}

	public void setJusikYudong(String jusikYudong) {
		this.jusikYudong = jusikYudong;
	}


	public String getKumjisik() {
		return this.kumjisik;
	}

	public void setKumjisik(String kumjisik) {
		this.kumjisik = kumjisik;
	}


	public String getMemb() {
		return this.memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}


	@Column(name="MEMB_GUBUN")
	public String getMembGubun() {
		return this.membGubun;
	}

	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
	}


	public double getPkocs6005() {
		return this.pkocs6005;
	}

	public void setPkocs6005(double pkocs6005) {
		this.pkocs6005 = pkocs6005;
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
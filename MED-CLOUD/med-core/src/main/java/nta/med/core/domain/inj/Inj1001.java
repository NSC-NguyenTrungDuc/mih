package nta.med.core.domain.inj;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INJ1001 database table.
 * 
 */
@Entity
@NamedQuery(name="Inj1001.findAll", query="SELECT i FROM Inj1001 i")
@Table(name  = "INJ1001")
public class Inj1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actDate;
	private String actJangso;
	private String antiCancerYn;
	private String bannabConfirm;
	private double bulchulPreSeq;
	private String bunho;
	private String chulgoBuseo;
	private Date chulgoDate;
	private double chulgoSeq;
	private String chungguBuseo;
	private Date chungguDate;
	private String chungguGubun;
	private double chungguSeq;
	private String dcYn;
	private String doctor;
	private double fkocs1003;
	private String gwa;
	private String hospCode;
	private Date jubsuDate;
	private String jubsuFlag;
	private String jundalPart;
	private double nalsu;
	private Date orderDate;
	private double pkinj1001;
	private String printYn;
	private double sourceFkocs1003;
	private double subulSuryang;
	private Date sunabDate;
	private double sunabNalsu;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inj1001() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACT_DATE")
	public Date getActDate() {
		return this.actDate;
	}

	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}


	@Column(name="ACT_JANGSO")
	public String getActJangso() {
		return this.actJangso;
	}

	public void setActJangso(String actJangso) {
		this.actJangso = actJangso;
	}


	@Column(name="ANTI_CANCER_YN")
	public String getAntiCancerYn() {
		return this.antiCancerYn;
	}

	public void setAntiCancerYn(String antiCancerYn) {
		this.antiCancerYn = antiCancerYn;
	}


	@Column(name="BANNAB_CONFIRM")
	public String getBannabConfirm() {
		return this.bannabConfirm;
	}

	public void setBannabConfirm(String bannabConfirm) {
		this.bannabConfirm = bannabConfirm;
	}


	@Column(name="BULCHUL_PRE_SEQ")
	public double getBulchulPreSeq() {
		return this.bulchulPreSeq;
	}

	public void setBulchulPreSeq(double bulchulPreSeq) {
		this.bulchulPreSeq = bulchulPreSeq;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHULGO_BUSEO")
	public String getChulgoBuseo() {
		return this.chulgoBuseo;
	}

	public void setChulgoBuseo(String chulgoBuseo) {
		this.chulgoBuseo = chulgoBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHULGO_DATE")
	public Date getChulgoDate() {
		return this.chulgoDate;
	}

	public void setChulgoDate(Date chulgoDate) {
		this.chulgoDate = chulgoDate;
	}


	@Column(name="CHULGO_SEQ")
	public double getChulgoSeq() {
		return this.chulgoSeq;
	}

	public void setChulgoSeq(double chulgoSeq) {
		this.chulgoSeq = chulgoSeq;
	}


	@Column(name="CHUNGGU_BUSEO")
	public String getChungguBuseo() {
		return this.chungguBuseo;
	}

	public void setChungguBuseo(String chungguBuseo) {
		this.chungguBuseo = chungguBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHUNGGU_DATE")
	public Date getChungguDate() {
		return this.chungguDate;
	}

	public void setChungguDate(Date chungguDate) {
		this.chungguDate = chungguDate;
	}


	@Column(name="CHUNGGU_GUBUN")
	public String getChungguGubun() {
		return this.chungguGubun;
	}

	public void setChungguGubun(String chungguGubun) {
		this.chungguGubun = chungguGubun;
	}


	@Column(name="CHUNGGU_SEQ")
	public double getChungguSeq() {
		return this.chungguSeq;
	}

	public void setChungguSeq(double chungguSeq) {
		this.chungguSeq = chungguSeq;
	}


	@Column(name="DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_FLAG")
	public String getJubsuFlag() {
		return this.jubsuFlag;
	}

	public void setJubsuFlag(String jubsuFlag) {
		this.jubsuFlag = jubsuFlag;
	}


	@Column(name="JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public double getPkinj1001() {
		return this.pkinj1001;
	}

	public void setPkinj1001(double pkinj1001) {
		this.pkinj1001 = pkinj1001;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Column(name="SOURCE_FKOCS1003")
	public double getSourceFkocs1003() {
		return this.sourceFkocs1003;
	}

	public void setSourceFkocs1003(double sourceFkocs1003) {
		this.sourceFkocs1003 = sourceFkocs1003;
	}


	@Column(name="SUBUL_SURYANG")
	public double getSubulSuryang() {
		return this.subulSuryang;
	}

	public void setSubulSuryang(double subulSuryang) {
		this.subulSuryang = subulSuryang;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SUNAB_DATE")
	public Date getSunabDate() {
		return this.sunabDate;
	}

	public void setSunabDate(Date sunabDate) {
		this.sunabDate = sunabDate;
	}


	@Column(name="SUNAB_NALSU")
	public double getSunabNalsu() {
		return this.sunabNalsu;
	}

	public void setSunabNalsu(double sunabNalsu) {
		this.sunabNalsu = sunabNalsu;
	}


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
		this.suryang = suryang;
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
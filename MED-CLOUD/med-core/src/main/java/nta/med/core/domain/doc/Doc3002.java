package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;


/**
 * The persistent class for the DOC3002 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc3002.findAll", query="SELECT d FROM Doc3002 d")
public class Doc3002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String an;
	private String binyogi;
	private String byunggwa;
	private String c01;
	private String chia;
	private String chungryukJwa;
	private String chungryukU;
	private String examGigwan;
	private double fkdoc1001;
	private String gan;
	private String ganyumYn;
	private String gisaengchung;
	private String gunbeon;
	private String gunbyul;
	private String gyoChungryukJwa;
	private String gyoChungryukU;
	private double gyoSiryukJwa;
	private double gyoSiryukU;
	private String habgyukYn;
	private String hbsAb;
	private String hbsAg;
	private double height;
	private double hgb;
	private String hoheubgi;
	private String hospCode;
	private String hyulab;
	private String hyulachyung;
	private BigDecimal hyungwi;
	private String ibiinhu;
	private String jaeExamGigwan;
	private String jaeYeungsiNo;
	private String jaeYeungsijik;
	private String juksungYn;
	private String jungsin;
	private String junyukDate;
	private String maedok;
	private String pibu;
	private double plt;
	private String rh;
	private String saeksin;
	private String simjundo;
	private String singyung;
	private double siryukJwa;
	private double siryukU;
	private String sohwagi;
	private String sunameHanja;
	private String sunhwangi;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private double wbc;
	private double weight;
	private String xRay;
	private String yeungsiNo;
	private String yeungsijik;
	private String yeusahang;
	private String youngyang;

	public Doc3002() {
	}


	public String getAn() {
		return this.an;
	}

	public void setAn(String an) {
		this.an = an;
	}


	public String getBinyogi() {
		return this.binyogi;
	}

	public void setBinyogi(String binyogi) {
		this.binyogi = binyogi;
	}


	public String getByunggwa() {
		return this.byunggwa;
	}

	public void setByunggwa(String byunggwa) {
		this.byunggwa = byunggwa;
	}


	public String getC01() {
		return this.c01;
	}

	public void setC01(String c01) {
		this.c01 = c01;
	}


	public String getChia() {
		return this.chia;
	}

	public void setChia(String chia) {
		this.chia = chia;
	}


	@Column(name="CHUNGRYUK_JWA")
	public String getChungryukJwa() {
		return this.chungryukJwa;
	}

	public void setChungryukJwa(String chungryukJwa) {
		this.chungryukJwa = chungryukJwa;
	}


	@Column(name="CHUNGRYUK_U")
	public String getChungryukU() {
		return this.chungryukU;
	}

	public void setChungryukU(String chungryukU) {
		this.chungryukU = chungryukU;
	}


	@Column(name="EXAM_GIGWAN")
	public String getExamGigwan() {
		return this.examGigwan;
	}

	public void setExamGigwan(String examGigwan) {
		this.examGigwan = examGigwan;
	}


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	public String getGan() {
		return this.gan;
	}

	public void setGan(String gan) {
		this.gan = gan;
	}


	@Column(name="GANYUM_YN")
	public String getGanyumYn() {
		return this.ganyumYn;
	}

	public void setGanyumYn(String ganyumYn) {
		this.ganyumYn = ganyumYn;
	}


	public String getGisaengchung() {
		return this.gisaengchung;
	}

	public void setGisaengchung(String gisaengchung) {
		this.gisaengchung = gisaengchung;
	}


	public String getGunbeon() {
		return this.gunbeon;
	}

	public void setGunbeon(String gunbeon) {
		this.gunbeon = gunbeon;
	}


	public String getGunbyul() {
		return this.gunbyul;
	}

	public void setGunbyul(String gunbyul) {
		this.gunbyul = gunbyul;
	}


	@Column(name="GYO_CHUNGRYUK_JWA")
	public String getGyoChungryukJwa() {
		return this.gyoChungryukJwa;
	}

	public void setGyoChungryukJwa(String gyoChungryukJwa) {
		this.gyoChungryukJwa = gyoChungryukJwa;
	}


	@Column(name="GYO_CHUNGRYUK_U")
	public String getGyoChungryukU() {
		return this.gyoChungryukU;
	}

	public void setGyoChungryukU(String gyoChungryukU) {
		this.gyoChungryukU = gyoChungryukU;
	}


	@Column(name="GYO_SIRYUK_JWA")
	public double getGyoSiryukJwa() {
		return this.gyoSiryukJwa;
	}

	public void setGyoSiryukJwa(double gyoSiryukJwa) {
		this.gyoSiryukJwa = gyoSiryukJwa;
	}


	@Column(name="GYO_SIRYUK_U")
	public double getGyoSiryukU() {
		return this.gyoSiryukU;
	}

	public void setGyoSiryukU(double gyoSiryukU) {
		this.gyoSiryukU = gyoSiryukU;
	}


	@Column(name="HABGYUK_YN")
	public String getHabgyukYn() {
		return this.habgyukYn;
	}

	public void setHabgyukYn(String habgyukYn) {
		this.habgyukYn = habgyukYn;
	}


	@Column(name="HBS_AB")
	public String getHbsAb() {
		return this.hbsAb;
	}

	public void setHbsAb(String hbsAb) {
		this.hbsAb = hbsAb;
	}


	@Column(name="HBS_AG")
	public String getHbsAg() {
		return this.hbsAg;
	}

	public void setHbsAg(String hbsAg) {
		this.hbsAg = hbsAg;
	}


	public double getHeight() {
		return this.height;
	}

	public void setHeight(double height) {
		this.height = height;
	}


	public double getHgb() {
		return this.hgb;
	}

	public void setHgb(double hgb) {
		this.hgb = hgb;
	}


	public String getHoheubgi() {
		return this.hoheubgi;
	}

	public void setHoheubgi(String hoheubgi) {
		this.hoheubgi = hoheubgi;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getHyulab() {
		return this.hyulab;
	}

	public void setHyulab(String hyulab) {
		this.hyulab = hyulab;
	}


	public String getHyulachyung() {
		return this.hyulachyung;
	}

	public void setHyulachyung(String hyulachyung) {
		this.hyulachyung = hyulachyung;
	}


	public BigDecimal getHyungwi() {
		return this.hyungwi;
	}

	public void setHyungwi(BigDecimal hyungwi) {
		this.hyungwi = hyungwi;
	}


	public String getIbiinhu() {
		return this.ibiinhu;
	}

	public void setIbiinhu(String ibiinhu) {
		this.ibiinhu = ibiinhu;
	}


	@Column(name="JAE_EXAM_GIGWAN")
	public String getJaeExamGigwan() {
		return this.jaeExamGigwan;
	}

	public void setJaeExamGigwan(String jaeExamGigwan) {
		this.jaeExamGigwan = jaeExamGigwan;
	}


	@Column(name="JAE_YEUNGSI_NO")
	public String getJaeYeungsiNo() {
		return this.jaeYeungsiNo;
	}

	public void setJaeYeungsiNo(String jaeYeungsiNo) {
		this.jaeYeungsiNo = jaeYeungsiNo;
	}


	@Column(name="JAE_YEUNGSIJIK")
	public String getJaeYeungsijik() {
		return this.jaeYeungsijik;
	}

	public void setJaeYeungsijik(String jaeYeungsijik) {
		this.jaeYeungsijik = jaeYeungsijik;
	}


	@Column(name="JUKSUNG_YN")
	public String getJuksungYn() {
		return this.juksungYn;
	}

	public void setJuksungYn(String juksungYn) {
		this.juksungYn = juksungYn;
	}


	public String getJungsin() {
		return this.jungsin;
	}

	public void setJungsin(String jungsin) {
		this.jungsin = jungsin;
	}


	@Column(name="JUNYUK_DATE")
	public String getJunyukDate() {
		return this.junyukDate;
	}

	public void setJunyukDate(String junyukDate) {
		this.junyukDate = junyukDate;
	}


	public String getMaedok() {
		return this.maedok;
	}

	public void setMaedok(String maedok) {
		this.maedok = maedok;
	}


	public String getPibu() {
		return this.pibu;
	}

	public void setPibu(String pibu) {
		this.pibu = pibu;
	}


	public double getPlt() {
		return this.plt;
	}

	public void setPlt(double plt) {
		this.plt = plt;
	}


	public String getRh() {
		return this.rh;
	}

	public void setRh(String rh) {
		this.rh = rh;
	}


	public String getSaeksin() {
		return this.saeksin;
	}

	public void setSaeksin(String saeksin) {
		this.saeksin = saeksin;
	}


	public String getSimjundo() {
		return this.simjundo;
	}

	public void setSimjundo(String simjundo) {
		this.simjundo = simjundo;
	}


	public String getSingyung() {
		return this.singyung;
	}

	public void setSingyung(String singyung) {
		this.singyung = singyung;
	}


	@Column(name="SIRYUK_JWA")
	public double getSiryukJwa() {
		return this.siryukJwa;
	}

	public void setSiryukJwa(double siryukJwa) {
		this.siryukJwa = siryukJwa;
	}


	@Column(name="SIRYUK_U")
	public double getSiryukU() {
		return this.siryukU;
	}

	public void setSiryukU(double siryukU) {
		this.siryukU = siryukU;
	}


	public String getSohwagi() {
		return this.sohwagi;
	}

	public void setSohwagi(String sohwagi) {
		this.sohwagi = sohwagi;
	}


	@Column(name="SUNAME_HANJA")
	public String getSunameHanja() {
		return this.sunameHanja;
	}

	public void setSunameHanja(String sunameHanja) {
		this.sunameHanja = sunameHanja;
	}


	public String getSunhwangi() {
		return this.sunhwangi;
	}

	public void setSunhwangi(String sunhwangi) {
		this.sunhwangi = sunhwangi;
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


	public double getWbc() {
		return this.wbc;
	}

	public void setWbc(double wbc) {
		this.wbc = wbc;
	}


	public double getWeight() {
		return this.weight;
	}

	public void setWeight(double weight) {
		this.weight = weight;
	}


	@Column(name="X_RAY")
	public String getXRay() {
		return this.xRay;
	}

	public void setXRay(String xRay) {
		this.xRay = xRay;
	}


	@Column(name="YEUNGSI_NO")
	public String getYeungsiNo() {
		return this.yeungsiNo;
	}

	public void setYeungsiNo(String yeungsiNo) {
		this.yeungsiNo = yeungsiNo;
	}


	public String getYeungsijik() {
		return this.yeungsijik;
	}

	public void setYeungsijik(String yeungsijik) {
		this.yeungsijik = yeungsijik;
	}


	public String getYeusahang() {
		return this.yeusahang;
	}

	public void setYeusahang(String yeusahang) {
		this.yeusahang = yeusahang;
	}


	public String getYoungyang() {
		return this.youngyang;
	}

	public void setYoungyang(String youngyang) {
		this.youngyang = youngyang;
	}

}
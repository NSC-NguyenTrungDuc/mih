package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC3001 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc3001.findAll", query="SELECT d FROM Doc3001 d")
public class Doc3001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bokbuSo;
	private String chungryukJwa;
	private String chungryukU;
	private double fkdoc1001;
	private String gangineung;
	private String gita;
	private double gyoSiryukJwa;
	private double gyoSiryukU;
	private String hbsAb;
	private String hbsAg;
	private double height;
	private String hospCode;
	private String hyulab;
	private String hyulachyung;
	private String hyuldok;
	private String hyulsaekso;
	private String hyungbuSo;
	private String jaeculchu;
	private String jonghabSo;
	private String jungsin;
	private String junyumsung;
	private String rh;
	private String saekmeng;
	private String saji;
	private String singyung;
	private double siryukJwa;
	private double siryukU;
	private String sobyun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private double weight;
	private String xGubun;
	private String xSogyun;

	public Doc3001() {
	}


	@Column(name="BOKBU_SO")
	public String getBokbuSo() {
		return this.bokbuSo;
	}

	public void setBokbuSo(String bokbuSo) {
		this.bokbuSo = bokbuSo;
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


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	public String getGangineung() {
		return this.gangineung;
	}

	public void setGangineung(String gangineung) {
		this.gangineung = gangineung;
	}


	public String getGita() {
		return this.gita;
	}

	public void setGita(String gita) {
		this.gita = gita;
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


	public String getHyuldok() {
		return this.hyuldok;
	}

	public void setHyuldok(String hyuldok) {
		this.hyuldok = hyuldok;
	}


	public String getHyulsaekso() {
		return this.hyulsaekso;
	}

	public void setHyulsaekso(String hyulsaekso) {
		this.hyulsaekso = hyulsaekso;
	}


	@Column(name="HYUNGBU_SO")
	public String getHyungbuSo() {
		return this.hyungbuSo;
	}

	public void setHyungbuSo(String hyungbuSo) {
		this.hyungbuSo = hyungbuSo;
	}


	public String getJaeculchu() {
		return this.jaeculchu;
	}

	public void setJaeculchu(String jaeculchu) {
		this.jaeculchu = jaeculchu;
	}


	@Column(name="JONGHAB_SO")
	public String getJonghabSo() {
		return this.jonghabSo;
	}

	public void setJonghabSo(String jonghabSo) {
		this.jonghabSo = jonghabSo;
	}


	public String getJungsin() {
		return this.jungsin;
	}

	public void setJungsin(String jungsin) {
		this.jungsin = jungsin;
	}


	public String getJunyumsung() {
		return this.junyumsung;
	}

	public void setJunyumsung(String junyumsung) {
		this.junyumsung = junyumsung;
	}


	public String getRh() {
		return this.rh;
	}

	public void setRh(String rh) {
		this.rh = rh;
	}


	public String getSaekmeng() {
		return this.saekmeng;
	}

	public void setSaekmeng(String saekmeng) {
		this.saekmeng = saekmeng;
	}


	public String getSaji() {
		return this.saji;
	}

	public void setSaji(String saji) {
		this.saji = saji;
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


	public String getSobyun() {
		return this.sobyun;
	}

	public void setSobyun(String sobyun) {
		this.sobyun = sobyun;
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


	public double getWeight() {
		return this.weight;
	}

	public void setWeight(double weight) {
		this.weight = weight;
	}


	@Column(name="X_GUBUN")
	public String getXGubun() {
		return this.xGubun;
	}

	public void setXGubun(String xGubun) {
		this.xGubun = xGubun;
	}


	@Column(name="X_SOGYUN")
	public String getXSogyun() {
		return this.xSogyun;
	}

	public void setXSogyun(String xSogyun) {
		this.xSogyun = xSogyun;
	}

}
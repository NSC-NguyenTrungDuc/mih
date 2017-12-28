package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC3012 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc3012.findAll", query="SELECT d FROM Doc3012 d")
public class Doc3012 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String aids;
	private String aidsCheck;
	private String alt;
	private String anemiaCheck;
	private String aptt;
	private String apttCheck;
	private String ast;
	private String biman;
	private String bimanCheck;
	private String bloodSugar;
	private String dmCheck;
	private double fkdoc1001;
	private String hbsAb;
	private String hbsAg;
	private String hbsResult;
	private double hct;
	private String hcv;
	private String hcvCheck;
	private double height;
	private String hepatitis;
	private double hgb;
	private String hospCode;
	private String hyulab;
	private String hyulabCheck;
	private String hyulachyung;
	private String igg;
	private String igm;
	private String kyulhak;
	private String kyulhakCheck;
	private String maedok;
	private String maedokCheck;
	private String panjung1;
	private String panjung2;
	private String panjung3;
	private String panjung4;
	private String panjung5;
	private String poongjinCheck;
	private String pyejilhwan;
	private String pyejilhwanCheck;
	private String recommend;
	private String rh;
	private String sobyun;
	private String sobyunCheck;
	private Date sysDate;
	private String sysId;
	private String unineSugar;
	private Date updDate;
	private String updId;
	private double weight;

	public Doc3012() {
	}


	public String getAids() {
		return this.aids;
	}

	public void setAids(String aids) {
		this.aids = aids;
	}


	@Column(name="AIDS_CHECK")
	public String getAidsCheck() {
		return this.aidsCheck;
	}

	public void setAidsCheck(String aidsCheck) {
		this.aidsCheck = aidsCheck;
	}


	public String getAlt() {
		return this.alt;
	}

	public void setAlt(String alt) {
		this.alt = alt;
	}


	@Column(name="ANEMIA_CHECK")
	public String getAnemiaCheck() {
		return this.anemiaCheck;
	}

	public void setAnemiaCheck(String anemiaCheck) {
		this.anemiaCheck = anemiaCheck;
	}


	public String getAptt() {
		return this.aptt;
	}

	public void setAptt(String aptt) {
		this.aptt = aptt;
	}


	@Column(name="APTT_CHECK")
	public String getApttCheck() {
		return this.apttCheck;
	}

	public void setApttCheck(String apttCheck) {
		this.apttCheck = apttCheck;
	}


	public String getAst() {
		return this.ast;
	}

	public void setAst(String ast) {
		this.ast = ast;
	}


	public String getBiman() {
		return this.biman;
	}

	public void setBiman(String biman) {
		this.biman = biman;
	}


	@Column(name="BIMAN_CHECK")
	public String getBimanCheck() {
		return this.bimanCheck;
	}

	public void setBimanCheck(String bimanCheck) {
		this.bimanCheck = bimanCheck;
	}


	@Column(name="BLOOD_SUGAR")
	public String getBloodSugar() {
		return this.bloodSugar;
	}

	public void setBloodSugar(String bloodSugar) {
		this.bloodSugar = bloodSugar;
	}


	@Column(name="DM_CHECK")
	public String getDmCheck() {
		return this.dmCheck;
	}

	public void setDmCheck(String dmCheck) {
		this.dmCheck = dmCheck;
	}


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
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


	@Column(name="HBS_RESULT")
	public String getHbsResult() {
		return this.hbsResult;
	}

	public void setHbsResult(String hbsResult) {
		this.hbsResult = hbsResult;
	}


	public double getHct() {
		return this.hct;
	}

	public void setHct(double hct) {
		this.hct = hct;
	}


	public String getHcv() {
		return this.hcv;
	}

	public void setHcv(String hcv) {
		this.hcv = hcv;
	}


	@Column(name="HCV_CHECK")
	public String getHcvCheck() {
		return this.hcvCheck;
	}

	public void setHcvCheck(String hcvCheck) {
		this.hcvCheck = hcvCheck;
	}


	public double getHeight() {
		return this.height;
	}

	public void setHeight(double height) {
		this.height = height;
	}


	public String getHepatitis() {
		return this.hepatitis;
	}

	public void setHepatitis(String hepatitis) {
		this.hepatitis = hepatitis;
	}


	public double getHgb() {
		return this.hgb;
	}

	public void setHgb(double hgb) {
		this.hgb = hgb;
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


	@Column(name="HYULAB_CHECK")
	public String getHyulabCheck() {
		return this.hyulabCheck;
	}

	public void setHyulabCheck(String hyulabCheck) {
		this.hyulabCheck = hyulabCheck;
	}


	public String getHyulachyung() {
		return this.hyulachyung;
	}

	public void setHyulachyung(String hyulachyung) {
		this.hyulachyung = hyulachyung;
	}


	public String getIgg() {
		return this.igg;
	}

	public void setIgg(String igg) {
		this.igg = igg;
	}


	public String getIgm() {
		return this.igm;
	}

	public void setIgm(String igm) {
		this.igm = igm;
	}


	public String getKyulhak() {
		return this.kyulhak;
	}

	public void setKyulhak(String kyulhak) {
		this.kyulhak = kyulhak;
	}


	@Column(name="KYULHAK_CHECK")
	public String getKyulhakCheck() {
		return this.kyulhakCheck;
	}

	public void setKyulhakCheck(String kyulhakCheck) {
		this.kyulhakCheck = kyulhakCheck;
	}


	public String getMaedok() {
		return this.maedok;
	}

	public void setMaedok(String maedok) {
		this.maedok = maedok;
	}


	@Column(name="MAEDOK_CHECK")
	public String getMaedokCheck() {
		return this.maedokCheck;
	}

	public void setMaedokCheck(String maedokCheck) {
		this.maedokCheck = maedokCheck;
	}


	public String getPanjung1() {
		return this.panjung1;
	}

	public void setPanjung1(String panjung1) {
		this.panjung1 = panjung1;
	}


	public String getPanjung2() {
		return this.panjung2;
	}

	public void setPanjung2(String panjung2) {
		this.panjung2 = panjung2;
	}


	public String getPanjung3() {
		return this.panjung3;
	}

	public void setPanjung3(String panjung3) {
		this.panjung3 = panjung3;
	}


	public String getPanjung4() {
		return this.panjung4;
	}

	public void setPanjung4(String panjung4) {
		this.panjung4 = panjung4;
	}


	public String getPanjung5() {
		return this.panjung5;
	}

	public void setPanjung5(String panjung5) {
		this.panjung5 = panjung5;
	}


	@Column(name="POONGJIN_CHECK")
	public String getPoongjinCheck() {
		return this.poongjinCheck;
	}

	public void setPoongjinCheck(String poongjinCheck) {
		this.poongjinCheck = poongjinCheck;
	}


	public String getPyejilhwan() {
		return this.pyejilhwan;
	}

	public void setPyejilhwan(String pyejilhwan) {
		this.pyejilhwan = pyejilhwan;
	}


	@Column(name="PYEJILHWAN_CHECK")
	public String getPyejilhwanCheck() {
		return this.pyejilhwanCheck;
	}

	public void setPyejilhwanCheck(String pyejilhwanCheck) {
		this.pyejilhwanCheck = pyejilhwanCheck;
	}


	public String getRecommend() {
		return this.recommend;
	}

	public void setRecommend(String recommend) {
		this.recommend = recommend;
	}


	public String getRh() {
		return this.rh;
	}

	public void setRh(String rh) {
		this.rh = rh;
	}


	public String getSobyun() {
		return this.sobyun;
	}

	public void setSobyun(String sobyun) {
		this.sobyun = sobyun;
	}


	@Column(name="SOBYUN_CHECK")
	public String getSobyunCheck() {
		return this.sobyunCheck;
	}

	public void setSobyunCheck(String sobyunCheck) {
		this.sobyunCheck = sobyunCheck;
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


	@Column(name="UNINE_SUGAR")
	public String getUnineSugar() {
		return this.unineSugar;
	}

	public void setUnineSugar(String unineSugar) {
		this.unineSugar = unineSugar;
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

}
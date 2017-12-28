package nta.med.core.domain.nut;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the NUT0001 database table.
 * 
 */
@Entity
@Table(name="NUT0001")
public class Nut0001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double a1c;
	private Date actingDate;
	private Double alb;
	private Double altGpt;
	private Double astGot;
	private Double bmi;
	private String bp;
	private String bpTemp;
	private Double bun;
	private Double cre;
	private String dataKubun;
	private String drinkYn;
	private Double energy;
	private Double fat;
	private Double fbs;
	private Double fkOcs;
	private Double gammagt;
	private String hangmogCode;
	private String hangmogName;
	private Double hb;
	private Double hdl;
	private Double height;
	private String hospCode;
	private String ioKubun;
	private Date iraiDate;
	private String kanjaNo;
	private Double ldl;
	private String nutritionObject;
	private String nutritionist;
	private String nutritionistName;
	private Double pknut0001;
	private Double protein;
	private Double ps;
	private String remark;
	private Date reserDate;
	private Double salt;
	private String sijijikou;
	private String sindanisi;
	private String sinryouka;
	private String sportYn;
	private Double sugar;
	private String syokaiGubun;
	private Date sysDate;
	private Double targetweight;
	private Double tch;
	private Double tg;
	private Date updDate;
	private String userId;
	private Double water;
	private Double weight;

	public Nut0001() {
	}


	public Double getA1c() {
		return this.a1c;
	}

	public void setA1c(Double a1c) {
		this.a1c = a1c;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}


	public Double getAlb() {
		return this.alb;
	}

	public void setAlb(Double alb) {
		this.alb = alb;
	}


	@Column(name="ALT_GPT")
	public Double getAltGpt() {
		return this.altGpt;
	}

	public void setAltGpt(Double altGpt) {
		this.altGpt = altGpt;
	}


	@Column(name="AST_GOT")
	public Double getAstGot() {
		return this.astGot;
	}

	public void setAstGot(Double astGot) {
		this.astGot = astGot;
	}


	public Double getBmi() {
		return this.bmi;
	}

	public void setBmi(Double bmi) {
		this.bmi = bmi;
	}


	public String getBp() {
		return this.bp;
	}

	public void setBp(String bp) {
		this.bp = bp;
	}


	@Column(name="BP_TEMP")
	public String getBpTemp() {
		return this.bpTemp;
	}

	public void setBpTemp(String bpTemp) {
		this.bpTemp = bpTemp;
	}


	public Double getBun() {
		return this.bun;
	}

	public void setBun(Double bun) {
		this.bun = bun;
	}


	public Double getCre() {
		return this.cre;
	}

	public void setCre(Double cre) {
		this.cre = cre;
	}


	@Column(name="DATA_KUBUN")
	public String getDataKubun() {
		return this.dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
	}


	@Column(name="DRINK_YN")
	public String getDrinkYn() {
		return this.drinkYn;
	}

	public void setDrinkYn(String drinkYn) {
		this.drinkYn = drinkYn;
	}


	public Double getEnergy() {
		return this.energy;
	}

	public void setEnergy(Double energy) {
		this.energy = energy;
	}


	public Double getFat() {
		return this.fat;
	}

	public void setFat(Double fat) {
		this.fat = fat;
	}


	public Double getFbs() {
		return this.fbs;
	}

	public void setFbs(Double fbs) {
		this.fbs = fbs;
	}


	@Column(name="FK_OCS")
	public Double getFkOcs() {
		return this.fkOcs;
	}

	public void setFkOcs(Double fkOcs) {
		this.fkOcs = fkOcs;
	}


	public Double getGammagt() {
		return this.gammagt;
	}

	public void setGammagt(Double gammagt) {
		this.gammagt = gammagt;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HANGMOG_NAME")
	public String getHangmogName() {
		return this.hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}


	public Double getHb() {
		return this.hb;
	}

	public void setHb(Double hb) {
		this.hb = hb;
	}


	public Double getHdl() {
		return this.hdl;
	}

	public void setHdl(Double hdl) {
		this.hdl = hdl;
	}


	public Double getHeight() {
		return this.height;
	}

	public void setHeight(Double height) {
		this.height = height;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IO_KUBUN")
	public String getIoKubun() {
		return this.ioKubun;
	}

	public void setIoKubun(String ioKubun) {
		this.ioKubun = ioKubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IRAI_DATE")
	public Date getIraiDate() {
		return this.iraiDate;
	}

	public void setIraiDate(Date iraiDate) {
		this.iraiDate = iraiDate;
	}


	@Column(name="KANJA_NO")
	public String getKanjaNo() {
		return this.kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}


	public Double getLdl() {
		return this.ldl;
	}

	public void setLdl(Double ldl) {
		this.ldl = ldl;
	}


	@Column(name="NUTRITION_OBJECT")
	public String getNutritionObject() {
		return this.nutritionObject;
	}

	public void setNutritionObject(String nutritionObject) {
		this.nutritionObject = nutritionObject;
	}


	public String getNutritionist() {
		return this.nutritionist;
	}

	public void setNutritionist(String nutritionist) {
		this.nutritionist = nutritionist;
	}


	@Column(name="NUTRITIONIST_NAME")
	public String getNutritionistName() {
		return this.nutritionistName;
	}

	public void setNutritionistName(String nutritionistName) {
		this.nutritionistName = nutritionistName;
	}


	public Double getPknut0001() {
		return this.pknut0001;
	}

	public void setPknut0001(Double pknut0001) {
		this.pknut0001 = pknut0001;
	}


	public Double getProtein() {
		return this.protein;
	}

	public void setProtein(Double protein) {
		this.protein = protein;
	}


	public Double getPs() {
		return this.ps;
	}

	public void setPs(Double ps) {
		this.ps = ps;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}


	public Double getSalt() {
		return this.salt;
	}

	public void setSalt(Double salt) {
		this.salt = salt;
	}


	public String getSijijikou() {
		return this.sijijikou;
	}

	public void setSijijikou(String sijijikou) {
		this.sijijikou = sijijikou;
	}


	public String getSindanisi() {
		return this.sindanisi;
	}

	public void setSindanisi(String sindanisi) {
		this.sindanisi = sindanisi;
	}


	public String getSinryouka() {
		return this.sinryouka;
	}

	public void setSinryouka(String sinryouka) {
		this.sinryouka = sinryouka;
	}


	@Column(name="SPORT_YN")
	public String getSportYn() {
		return this.sportYn;
	}

	public void setSportYn(String sportYn) {
		this.sportYn = sportYn;
	}


	public Double getSugar() {
		return this.sugar;
	}

	public void setSugar(Double sugar) {
		this.sugar = sugar;
	}


	@Column(name="SYOKAI_GUBUN")
	public String getSyokaiGubun() {
		return this.syokaiGubun;
	}

	public void setSyokaiGubun(String syokaiGubun) {
		this.syokaiGubun = syokaiGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	public Double getTargetweight() {
		return this.targetweight;
	}

	public void setTargetweight(Double targetweight) {
		this.targetweight = targetweight;
	}


	public Double getTch() {
		return this.tch;
	}

	public void setTch(Double tch) {
		this.tch = tch;
	}


	public Double getTg() {
		return this.tg;
	}

	public void setTg(Double tg) {
		this.tg = tg;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}


	public Double getWater() {
		return this.water;
	}

	public void setWater(Double water) {
		this.water = water;
	}


	public Double getWeight() {
		return this.weight;
	}

	public void setWeight(Double weight) {
		this.weight = weight;
	}

}
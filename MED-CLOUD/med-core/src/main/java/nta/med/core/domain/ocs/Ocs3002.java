package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS3002 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs3002.findAll", query="SELECT o FROM Ocs3002 o")
public class Ocs3002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String afterSikYn;
	private double albumin;
	private String bohojasikYn;
	private String bohosikYn;
	private String bunCode1;
	private String bunCode2;
	private String bunCode3;
	private String bunCode4;
	private String bunho;
	private double calory;
	private String cc;
	private String chooseGubun;
	private double fat;
	private double fkinp1001;
	private String gansikYn;
	private String gumgi1;
	private String gumgi2;
	private String gumgi3;
	private String gumgi4;
	private double hoisu;
	private String hospCode;
	private String juibMethod;
	private String juibRoad;
	private Date jyDate;
	private double kal;
	private String kiCopy;
	private String kiGubun;
	private String kumsigGubun;
	private double na;
	private String nutAddCode;
	private String nutCode;
	private String nutComment;
	private String nutGihoCode;
	private String nutGihoCode2;
	private String nutGihoCode3;
	private String nutGubun;
	private double protein;
	private String remark;
	private double salt;
	private String sigiMagamYn;
	private String sodoksikYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs3002() {
	}


	@Column(name="AFTER_SIK_YN")
	public String getAfterSikYn() {
		return this.afterSikYn;
	}

	public void setAfterSikYn(String afterSikYn) {
		this.afterSikYn = afterSikYn;
	}


	public double getAlbumin() {
		return this.albumin;
	}

	public void setAlbumin(double albumin) {
		this.albumin = albumin;
	}


	@Column(name="BOHOJASIK_YN")
	public String getBohojasikYn() {
		return this.bohojasikYn;
	}

	public void setBohojasikYn(String bohojasikYn) {
		this.bohojasikYn = bohojasikYn;
	}


	@Column(name="BOHOSIK_YN")
	public String getBohosikYn() {
		return this.bohosikYn;
	}

	public void setBohosikYn(String bohosikYn) {
		this.bohosikYn = bohosikYn;
	}


	@Column(name="BUN_CODE1")
	public String getBunCode1() {
		return this.bunCode1;
	}

	public void setBunCode1(String bunCode1) {
		this.bunCode1 = bunCode1;
	}


	@Column(name="BUN_CODE2")
	public String getBunCode2() {
		return this.bunCode2;
	}

	public void setBunCode2(String bunCode2) {
		this.bunCode2 = bunCode2;
	}


	@Column(name="BUN_CODE3")
	public String getBunCode3() {
		return this.bunCode3;
	}

	public void setBunCode3(String bunCode3) {
		this.bunCode3 = bunCode3;
	}


	@Column(name="BUN_CODE4")
	public String getBunCode4() {
		return this.bunCode4;
	}

	public void setBunCode4(String bunCode4) {
		this.bunCode4 = bunCode4;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getCalory() {
		return this.calory;
	}

	public void setCalory(double calory) {
		this.calory = calory;
	}


	public String getCc() {
		return this.cc;
	}

	public void setCc(String cc) {
		this.cc = cc;
	}


	@Column(name="CHOOSE_GUBUN")
	public String getChooseGubun() {
		return this.chooseGubun;
	}

	public void setChooseGubun(String chooseGubun) {
		this.chooseGubun = chooseGubun;
	}


	public double getFat() {
		return this.fat;
	}

	public void setFat(double fat) {
		this.fat = fat;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="GANSIK_YN")
	public String getGansikYn() {
		return this.gansikYn;
	}

	public void setGansikYn(String gansikYn) {
		this.gansikYn = gansikYn;
	}


	public String getGumgi1() {
		return this.gumgi1;
	}

	public void setGumgi1(String gumgi1) {
		this.gumgi1 = gumgi1;
	}


	public String getGumgi2() {
		return this.gumgi2;
	}

	public void setGumgi2(String gumgi2) {
		this.gumgi2 = gumgi2;
	}


	public String getGumgi3() {
		return this.gumgi3;
	}

	public void setGumgi3(String gumgi3) {
		this.gumgi3 = gumgi3;
	}


	public String getGumgi4() {
		return this.gumgi4;
	}

	public void setGumgi4(String gumgi4) {
		this.gumgi4 = gumgi4;
	}


	public double getHoisu() {
		return this.hoisu;
	}

	public void setHoisu(double hoisu) {
		this.hoisu = hoisu;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUIB_METHOD")
	public String getJuibMethod() {
		return this.juibMethod;
	}

	public void setJuibMethod(String juibMethod) {
		this.juibMethod = juibMethod;
	}


	@Column(name="JUIB_ROAD")
	public String getJuibRoad() {
		return this.juibRoad;
	}

	public void setJuibRoad(String juibRoad) {
		this.juibRoad = juibRoad;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JY_DATE")
	public Date getJyDate() {
		return this.jyDate;
	}

	public void setJyDate(Date jyDate) {
		this.jyDate = jyDate;
	}


	public double getKal() {
		return this.kal;
	}

	public void setKal(double kal) {
		this.kal = kal;
	}


	@Column(name="KI_COPY")
	public String getKiCopy() {
		return this.kiCopy;
	}

	public void setKiCopy(String kiCopy) {
		this.kiCopy = kiCopy;
	}


	@Column(name="KI_GUBUN")
	public String getKiGubun() {
		return this.kiGubun;
	}

	public void setKiGubun(String kiGubun) {
		this.kiGubun = kiGubun;
	}


	@Column(name="KUMSIG_GUBUN")
	public String getKumsigGubun() {
		return this.kumsigGubun;
	}

	public void setKumsigGubun(String kumsigGubun) {
		this.kumsigGubun = kumsigGubun;
	}


	public double getNa() {
		return this.na;
	}

	public void setNa(double na) {
		this.na = na;
	}


	@Column(name="NUT_ADD_CODE")
	public String getNutAddCode() {
		return this.nutAddCode;
	}

	public void setNutAddCode(String nutAddCode) {
		this.nutAddCode = nutAddCode;
	}


	@Column(name="NUT_CODE")
	public String getNutCode() {
		return this.nutCode;
	}

	public void setNutCode(String nutCode) {
		this.nutCode = nutCode;
	}


	@Column(name="NUT_COMMENT")
	public String getNutComment() {
		return this.nutComment;
	}

	public void setNutComment(String nutComment) {
		this.nutComment = nutComment;
	}


	@Column(name="NUT_GIHO_CODE")
	public String getNutGihoCode() {
		return this.nutGihoCode;
	}

	public void setNutGihoCode(String nutGihoCode) {
		this.nutGihoCode = nutGihoCode;
	}


	@Column(name="NUT_GIHO_CODE2")
	public String getNutGihoCode2() {
		return this.nutGihoCode2;
	}

	public void setNutGihoCode2(String nutGihoCode2) {
		this.nutGihoCode2 = nutGihoCode2;
	}


	@Column(name="NUT_GIHO_CODE3")
	public String getNutGihoCode3() {
		return this.nutGihoCode3;
	}

	public void setNutGihoCode3(String nutGihoCode3) {
		this.nutGihoCode3 = nutGihoCode3;
	}


	@Column(name="NUT_GUBUN")
	public String getNutGubun() {
		return this.nutGubun;
	}

	public void setNutGubun(String nutGubun) {
		this.nutGubun = nutGubun;
	}


	public double getProtein() {
		return this.protein;
	}

	public void setProtein(double protein) {
		this.protein = protein;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public double getSalt() {
		return this.salt;
	}

	public void setSalt(double salt) {
		this.salt = salt;
	}


	@Column(name="SIGI_MAGAM_YN")
	public String getSigiMagamYn() {
		return this.sigiMagamYn;
	}

	public void setSigiMagamYn(String sigiMagamYn) {
		this.sigiMagamYn = sigiMagamYn;
	}


	@Column(name="SODOKSIK_YN")
	public String getSodoksikYn() {
		return this.sodoksikYn;
	}

	public void setSodoksikYn(String sodoksikYn) {
		this.sodoksikYn = sodoksikYn;
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
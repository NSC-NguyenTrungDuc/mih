package nta.med.core.domain.drg;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the DRG0129 database table.
 * 
 */
@Entity
@NamedQuery(name="Drg0129.findAll", query="SELECT d FROM Drg0129 d")
public class Drg0129 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String banghyang;
	private String blockGubun;
	private String bogyongCode;
	private String bogyongCodeFull;
	private String bogyongGubun;
	private String bogyongGubunDefault;
	private String bogyongJoFlag;
	private String bogyongJuFlag;
	private String bogyongName;
	private String bogyongName2;
	private String bogyongSeokFlag;
	private String bogyongTime1Flag;
	private String bogyongTime2Flag;
	private String bogyongTime3Flag;
	private String bogyongTime4Flag;
	private String bogyongTime5Flag;
	private String bogyongTime6Flag;
	private String bogyongTime7Flag;
	private String bunryu1;
	private String chiryoGubun;
	private String donbogYn;
	private String drgGrp;
	private String hospCode;
	private String pattern;
	private String prtGubun;
	private String sakuraCode;
	private double soryKey;
	private String spBogyongYn;
	private String updId;

	public Drg0129() {
	}


	public String getBanghyang() {
		return this.banghyang;
	}

	public void setBanghyang(String banghyang) {
		this.banghyang = banghyang;
	}


	@Column(name="BLOCK_GUBUN")
	public String getBlockGubun() {
		return this.blockGubun;
	}

	public void setBlockGubun(String blockGubun) {
		this.blockGubun = blockGubun;
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="BOGYONG_CODE_FULL")
	public String getBogyongCodeFull() {
		return this.bogyongCodeFull;
	}

	public void setBogyongCodeFull(String bogyongCodeFull) {
		this.bogyongCodeFull = bogyongCodeFull;
	}


	@Column(name="BOGYONG_GUBUN")
	public String getBogyongGubun() {
		return this.bogyongGubun;
	}

	public void setBogyongGubun(String bogyongGubun) {
		this.bogyongGubun = bogyongGubun;
	}


	@Column(name="BOGYONG_GUBUN_DEFAULT")
	public String getBogyongGubunDefault() {
		return this.bogyongGubunDefault;
	}

	public void setBogyongGubunDefault(String bogyongGubunDefault) {
		this.bogyongGubunDefault = bogyongGubunDefault;
	}


	@Column(name="BOGYONG_JO_FLAG")
	public String getBogyongJoFlag() {
		return this.bogyongJoFlag;
	}

	public void setBogyongJoFlag(String bogyongJoFlag) {
		this.bogyongJoFlag = bogyongJoFlag;
	}


	@Column(name="BOGYONG_JU_FLAG")
	public String getBogyongJuFlag() {
		return this.bogyongJuFlag;
	}

	public void setBogyongJuFlag(String bogyongJuFlag) {
		this.bogyongJuFlag = bogyongJuFlag;
	}


	@Column(name="BOGYONG_NAME")
	public String getBogyongName() {
		return this.bogyongName;
	}

	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}


	@Column(name="BOGYONG_NAME_2")
	public String getBogyongName2() {
		return this.bogyongName2;
	}

	public void setBogyongName2(String bogyongName2) {
		this.bogyongName2 = bogyongName2;
	}


	@Column(name="BOGYONG_SEOK_FLAG")
	public String getBogyongSeokFlag() {
		return this.bogyongSeokFlag;
	}

	public void setBogyongSeokFlag(String bogyongSeokFlag) {
		this.bogyongSeokFlag = bogyongSeokFlag;
	}


	@Column(name="BOGYONG_TIME1_FLAG")
	public String getBogyongTime1Flag() {
		return this.bogyongTime1Flag;
	}

	public void setBogyongTime1Flag(String bogyongTime1Flag) {
		this.bogyongTime1Flag = bogyongTime1Flag;
	}


	@Column(name="BOGYONG_TIME2_FLAG")
	public String getBogyongTime2Flag() {
		return this.bogyongTime2Flag;
	}

	public void setBogyongTime2Flag(String bogyongTime2Flag) {
		this.bogyongTime2Flag = bogyongTime2Flag;
	}


	@Column(name="BOGYONG_TIME3_FLAG")
	public String getBogyongTime3Flag() {
		return this.bogyongTime3Flag;
	}

	public void setBogyongTime3Flag(String bogyongTime3Flag) {
		this.bogyongTime3Flag = bogyongTime3Flag;
	}


	@Column(name="BOGYONG_TIME4_FLAG")
	public String getBogyongTime4Flag() {
		return this.bogyongTime4Flag;
	}

	public void setBogyongTime4Flag(String bogyongTime4Flag) {
		this.bogyongTime4Flag = bogyongTime4Flag;
	}


	@Column(name="BOGYONG_TIME5_FLAG")
	public String getBogyongTime5Flag() {
		return this.bogyongTime5Flag;
	}

	public void setBogyongTime5Flag(String bogyongTime5Flag) {
		this.bogyongTime5Flag = bogyongTime5Flag;
	}


	@Column(name="BOGYONG_TIME6_FLAG")
	public String getBogyongTime6Flag() {
		return this.bogyongTime6Flag;
	}

	public void setBogyongTime6Flag(String bogyongTime6Flag) {
		this.bogyongTime6Flag = bogyongTime6Flag;
	}


	@Column(name="BOGYONG_TIME7_FLAG")
	public String getBogyongTime7Flag() {
		return this.bogyongTime7Flag;
	}

	public void setBogyongTime7Flag(String bogyongTime7Flag) {
		this.bogyongTime7Flag = bogyongTime7Flag;
	}


	public String getBunryu1() {
		return this.bunryu1;
	}

	public void setBunryu1(String bunryu1) {
		this.bunryu1 = bunryu1;
	}


	@Column(name="CHIRYO_GUBUN")
	public String getChiryoGubun() {
		return this.chiryoGubun;
	}

	public void setChiryoGubun(String chiryoGubun) {
		this.chiryoGubun = chiryoGubun;
	}


	@Column(name="DONBOG_YN")
	public String getDonbogYn() {
		return this.donbogYn;
	}

	public void setDonbogYn(String donbogYn) {
		this.donbogYn = donbogYn;
	}


	@Column(name="DRG_GRP")
	public String getDrgGrp() {
		return this.drgGrp;
	}

	public void setDrgGrp(String drgGrp) {
		this.drgGrp = drgGrp;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getPattern() {
		return this.pattern;
	}

	public void setPattern(String pattern) {
		this.pattern = pattern;
	}


	@Column(name="PRT_GUBUN")
	public String getPrtGubun() {
		return this.prtGubun;
	}

	public void setPrtGubun(String prtGubun) {
		this.prtGubun = prtGubun;
	}


	@Column(name="SAKURA_CODE")
	public String getSakuraCode() {
		return this.sakuraCode;
	}

	public void setSakuraCode(String sakuraCode) {
		this.sakuraCode = sakuraCode;
	}


	@Column(name="SORY_KEY")
	public double getSoryKey() {
		return this.soryKey;
	}

	public void setSoryKey(double soryKey) {
		this.soryKey = soryKey;
	}


	@Column(name="SP_BOGYONG_YN")
	public String getSpBogyongYn() {
		return this.spBogyongYn;
	}

	public void setSpBogyongYn(String spBogyongYn) {
		this.spBogyongYn = spBogyongYn;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}
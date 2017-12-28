package nta.med.core.domain.phy;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the PHY8003 database table.
 * 
 */
@Entity
@Table(name="PHY8003")
public class Phy8003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dataKubun;
	private Double fkOcsIrai;
	private Double fkoutsang;
	private String hassyoubi;
	private String hospCode;
	private String ioKubun;
	private String iraiDate;
	private String kanjaNo;
	private Date ocsSaveDate;
	private String ocsSaveYn;
	private Double pkPhySyoubyou;
	private String postModifierName;
	private String postModifier1;
	private String postModifier10;
	private String postModifier2;
	private String postModifier3;
	private String postModifier4;
	private String postModifier5;
	private String postModifier6;
	private String postModifier7;
	private String postModifier8;
	private String postModifier9;
	private String preModifierName;
	private String preModifier1;
	private String preModifier10;
	private String preModifier2;
	private String preModifier3;
	private String preModifier4;
	private String preModifier5;
	private String preModifier6;
	private String preModifier7;
	private String preModifier8;
	private String preModifier9;
	private String sindanbi;
	private String sinryouka;
	private String syoubyoumei;
	private String syoubyoumeiCode;
	private Date sysDate;
	private Date updDate;
	private String userId;

	public Phy8003() {
	}


	@Column(name="DATA_KUBUN")
	public String getDataKubun() {
		return this.dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
	}


	@Column(name="FK_OCS_IRAI")
	public Double getFkOcsIrai() {
		return this.fkOcsIrai;
	}

	public void setFkOcsIrai(Double fkOcsIrai) {
		this.fkOcsIrai = fkOcsIrai;
	}


	public Double getFkoutsang() {
		return this.fkoutsang;
	}

	public void setFkoutsang(Double fkoutsang) {
		this.fkoutsang = fkoutsang;
	}


	public String getHassyoubi() {
		return this.hassyoubi;
	}

	public void setHassyoubi(String hassyoubi) {
		this.hassyoubi = hassyoubi;
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


	@Column(name="IRAI_DATE")
	public String getIraiDate() {
		return this.iraiDate;
	}

	public void setIraiDate(String iraiDate) {
		this.iraiDate = iraiDate;
	}


	@Column(name="KANJA_NO")
	public String getKanjaNo() {
		return this.kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="OCS_SAVE_DATE")
	public Date getOcsSaveDate() {
		return this.ocsSaveDate;
	}

	public void setOcsSaveDate(Date ocsSaveDate) {
		this.ocsSaveDate = ocsSaveDate;
	}


	@Column(name="OCS_SAVE_YN")
	public String getOcsSaveYn() {
		return this.ocsSaveYn;
	}

	public void setOcsSaveYn(String ocsSaveYn) {
		this.ocsSaveYn = ocsSaveYn;
	}


	@Column(name="PK_PHY_SYOUBYOU")
	public Double getPkPhySyoubyou() {
		return this.pkPhySyoubyou;
	}

	public void setPkPhySyoubyou(Double pkPhySyoubyou) {
		this.pkPhySyoubyou = pkPhySyoubyou;
	}


	@Column(name="POST_MODIFIER_NAME")
	public String getPostModifierName() {
		return this.postModifierName;
	}

	public void setPostModifierName(String postModifierName) {
		this.postModifierName = postModifierName;
	}


	@Column(name="POST_MODIFIER1")
	public String getPostModifier1() {
		return this.postModifier1;
	}

	public void setPostModifier1(String postModifier1) {
		this.postModifier1 = postModifier1;
	}


	@Column(name="POST_MODIFIER10")
	public String getPostModifier10() {
		return this.postModifier10;
	}

	public void setPostModifier10(String postModifier10) {
		this.postModifier10 = postModifier10;
	}


	@Column(name="POST_MODIFIER2")
	public String getPostModifier2() {
		return this.postModifier2;
	}

	public void setPostModifier2(String postModifier2) {
		this.postModifier2 = postModifier2;
	}


	@Column(name="POST_MODIFIER3")
	public String getPostModifier3() {
		return this.postModifier3;
	}

	public void setPostModifier3(String postModifier3) {
		this.postModifier3 = postModifier3;
	}


	@Column(name="POST_MODIFIER4")
	public String getPostModifier4() {
		return this.postModifier4;
	}

	public void setPostModifier4(String postModifier4) {
		this.postModifier4 = postModifier4;
	}


	@Column(name="POST_MODIFIER5")
	public String getPostModifier5() {
		return this.postModifier5;
	}

	public void setPostModifier5(String postModifier5) {
		this.postModifier5 = postModifier5;
	}


	@Column(name="POST_MODIFIER6")
	public String getPostModifier6() {
		return this.postModifier6;
	}

	public void setPostModifier6(String postModifier6) {
		this.postModifier6 = postModifier6;
	}


	@Column(name="POST_MODIFIER7")
	public String getPostModifier7() {
		return this.postModifier7;
	}

	public void setPostModifier7(String postModifier7) {
		this.postModifier7 = postModifier7;
	}


	@Column(name="POST_MODIFIER8")
	public String getPostModifier8() {
		return this.postModifier8;
	}

	public void setPostModifier8(String postModifier8) {
		this.postModifier8 = postModifier8;
	}


	@Column(name="POST_MODIFIER9")
	public String getPostModifier9() {
		return this.postModifier9;
	}

	public void setPostModifier9(String postModifier9) {
		this.postModifier9 = postModifier9;
	}


	@Column(name="PRE_MODIFIER_NAME")
	public String getPreModifierName() {
		return this.preModifierName;
	}

	public void setPreModifierName(String preModifierName) {
		this.preModifierName = preModifierName;
	}


	@Column(name="PRE_MODIFIER1")
	public String getPreModifier1() {
		return this.preModifier1;
	}

	public void setPreModifier1(String preModifier1) {
		this.preModifier1 = preModifier1;
	}


	@Column(name="PRE_MODIFIER10")
	public String getPreModifier10() {
		return this.preModifier10;
	}

	public void setPreModifier10(String preModifier10) {
		this.preModifier10 = preModifier10;
	}


	@Column(name="PRE_MODIFIER2")
	public String getPreModifier2() {
		return this.preModifier2;
	}

	public void setPreModifier2(String preModifier2) {
		this.preModifier2 = preModifier2;
	}


	@Column(name="PRE_MODIFIER3")
	public String getPreModifier3() {
		return this.preModifier3;
	}

	public void setPreModifier3(String preModifier3) {
		this.preModifier3 = preModifier3;
	}


	@Column(name="PRE_MODIFIER4")
	public String getPreModifier4() {
		return this.preModifier4;
	}

	public void setPreModifier4(String preModifier4) {
		this.preModifier4 = preModifier4;
	}


	@Column(name="PRE_MODIFIER5")
	public String getPreModifier5() {
		return this.preModifier5;
	}

	public void setPreModifier5(String preModifier5) {
		this.preModifier5 = preModifier5;
	}


	@Column(name="PRE_MODIFIER6")
	public String getPreModifier6() {
		return this.preModifier6;
	}

	public void setPreModifier6(String preModifier6) {
		this.preModifier6 = preModifier6;
	}


	@Column(name="PRE_MODIFIER7")
	public String getPreModifier7() {
		return this.preModifier7;
	}

	public void setPreModifier7(String preModifier7) {
		this.preModifier7 = preModifier7;
	}


	@Column(name="PRE_MODIFIER8")
	public String getPreModifier8() {
		return this.preModifier8;
	}

	public void setPreModifier8(String preModifier8) {
		this.preModifier8 = preModifier8;
	}


	@Column(name="PRE_MODIFIER9")
	public String getPreModifier9() {
		return this.preModifier9;
	}

	public void setPreModifier9(String preModifier9) {
		this.preModifier9 = preModifier9;
	}


	public String getSindanbi() {
		return this.sindanbi;
	}

	public void setSindanbi(String sindanbi) {
		this.sindanbi = sindanbi;
	}


	public String getSinryouka() {
		return this.sinryouka;
	}

	public void setSinryouka(String sinryouka) {
		this.sinryouka = sinryouka;
	}


	public String getSyoubyoumei() {
		return this.syoubyoumei;
	}

	public void setSyoubyoumei(String syoubyoumei) {
		this.syoubyoumei = syoubyoumei;
	}


	@Column(name="SYOUBYOUMEI_CODE")
	public String getSyoubyoumeiCode() {
		return this.syoubyoumeiCode;
	}

	public void setSyoubyoumeiCode(String syoubyoumeiCode) {
		this.syoubyoumeiCode = syoubyoumeiCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
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

}
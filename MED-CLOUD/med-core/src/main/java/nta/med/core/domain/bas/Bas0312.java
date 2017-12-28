package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0312 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0312.findAll", query="SELECT b FROM Bas0312 b")
@Table(name="BAS0312")
public class Bas0312 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double carSuryang;
	private String defaultJyYn;
	private Double fromMonth;
	private String nalsuJyYn;
	private String pay;
	private Double seq;
	private String sgBoheomPay;
	private String sgBohoPay;
	private String sgCarPay;
	private String sgCode;
	private String sgIlbanPay;
	private String sgSanPay;
	private Date sgYmd;
	private String subGroupCode;
	private String subGubun;
	private String subSgCode;
	private String sugaGijun;
	private Double suryang;
	private String suryangJyYn;
	private String suryangYn;
	private Date sysDate;
	private String sysId;
	private Double toMonth;
	private String tusiYn;
	private Date updDate;
	private String updId;

	public Bas0312() {
	}


	@Column(name="CAR_SURYANG")
	public Double getCarSuryang() {
		return this.carSuryang;
	}

	public void setCarSuryang(Double carSuryang) {
		this.carSuryang = carSuryang;
	}


	@Column(name="DEFAULT_JY_YN")
	public String getDefaultJyYn() {
		return this.defaultJyYn;
	}

	public void setDefaultJyYn(String defaultJyYn) {
		this.defaultJyYn = defaultJyYn;
	}


	@Column(name="FROM_MONTH")
	public Double getFromMonth() {
		return this.fromMonth;
	}

	public void setFromMonth(Double fromMonth) {
		this.fromMonth = fromMonth;
	}


	@Column(name="NALSU_JY_YN")
	public String getNalsuJyYn() {
		return this.nalsuJyYn;
	}

	public void setNalsuJyYn(String nalsuJyYn) {
		this.nalsuJyYn = nalsuJyYn;
	}


	public String getPay() {
		return this.pay;
	}

	public void setPay(String pay) {
		this.pay = pay;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	@Column(name="SG_BOHEOM_PAY")
	public String getSgBoheomPay() {
		return this.sgBoheomPay;
	}

	public void setSgBoheomPay(String sgBoheomPay) {
		this.sgBoheomPay = sgBoheomPay;
	}


	@Column(name="SG_BOHO_PAY")
	public String getSgBohoPay() {
		return this.sgBohoPay;
	}

	public void setSgBohoPay(String sgBohoPay) {
		this.sgBohoPay = sgBohoPay;
	}


	@Column(name="SG_CAR_PAY")
	public String getSgCarPay() {
		return this.sgCarPay;
	}

	public void setSgCarPay(String sgCarPay) {
		this.sgCarPay = sgCarPay;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SG_ILBAN_PAY")
	public String getSgIlbanPay() {
		return this.sgIlbanPay;
	}

	public void setSgIlbanPay(String sgIlbanPay) {
		this.sgIlbanPay = sgIlbanPay;
	}


	@Column(name="SG_SAN_PAY")
	public String getSgSanPay() {
		return this.sgSanPay;
	}

	public void setSgSanPay(String sgSanPay) {
		this.sgSanPay = sgSanPay;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SG_YMD")
	public Date getSgYmd() {
		return this.sgYmd;
	}

	public void setSgYmd(Date sgYmd) {
		this.sgYmd = sgYmd;
	}


	@Column(name="SUB_GROUP_CODE")
	public String getSubGroupCode() {
		return this.subGroupCode;
	}

	public void setSubGroupCode(String subGroupCode) {
		this.subGroupCode = subGroupCode;
	}


	@Column(name="SUB_GUBUN")
	public String getSubGubun() {
		return this.subGubun;
	}

	public void setSubGubun(String subGubun) {
		this.subGubun = subGubun;
	}


	@Column(name="SUB_SG_CODE")
	public String getSubSgCode() {
		return this.subSgCode;
	}

	public void setSubSgCode(String subSgCode) {
		this.subSgCode = subSgCode;
	}


	@Column(name="SUGA_GIJUN")
	public String getSugaGijun() {
		return this.sugaGijun;
	}

	public void setSugaGijun(String sugaGijun) {
		this.sugaGijun = sugaGijun;
	}


	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}


	@Column(name="SURYANG_JY_YN")
	public String getSuryangJyYn() {
		return this.suryangJyYn;
	}

	public void setSuryangJyYn(String suryangJyYn) {
		this.suryangJyYn = suryangJyYn;
	}


	@Column(name="SURYANG_YN")
	public String getSuryangYn() {
		return this.suryangYn;
	}

	public void setSuryangYn(String suryangYn) {
		this.suryangYn = suryangYn;
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


	@Column(name="TO_MONTH")
	public Double getToMonth() {
		return this.toMonth;
	}

	public void setToMonth(Double toMonth) {
		this.toMonth = toMonth;
	}


	@Column(name="TUSI_YN")
	public String getTusiYn() {
		return this.tusiYn;
	}

	public void setTusiYn(String tusiYn) {
		this.tusiYn = tusiYn;
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
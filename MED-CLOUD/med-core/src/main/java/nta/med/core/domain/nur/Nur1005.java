package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1005 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1005.findAll", query="SELECT n FROM Nur1005 n")
public class Nur1005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hoDong;
	private String hospCode;
	private double ipwonNum;
	private double jaewonNum;
	private double junchulNum;
	private double junipNum;
	private String magamYymm;
	private double minusIpwonNum;
	private double minusJaewonNum;
	private double minusJunchulNum;
	private double minusJunipNum;
	private double minusToiwonNum;
	private Date sysDate;
	private String sysId;
	private double toiwonNum;
	private double totalBedNum;
	private Date updDate;
	private String updId;

	public Nur1005() {
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IPWON_NUM")
	public double getIpwonNum() {
		return this.ipwonNum;
	}

	public void setIpwonNum(double ipwonNum) {
		this.ipwonNum = ipwonNum;
	}


	@Column(name="JAEWON_NUM")
	public double getJaewonNum() {
		return this.jaewonNum;
	}

	public void setJaewonNum(double jaewonNum) {
		this.jaewonNum = jaewonNum;
	}


	@Column(name="JUNCHUL_NUM")
	public double getJunchulNum() {
		return this.junchulNum;
	}

	public void setJunchulNum(double junchulNum) {
		this.junchulNum = junchulNum;
	}


	@Column(name="JUNIP_NUM")
	public double getJunipNum() {
		return this.junipNum;
	}

	public void setJunipNum(double junipNum) {
		this.junipNum = junipNum;
	}


	@Column(name="MAGAM_YYMM")
	public String getMagamYymm() {
		return this.magamYymm;
	}

	public void setMagamYymm(String magamYymm) {
		this.magamYymm = magamYymm;
	}


	@Column(name="MINUS_IPWON_NUM")
	public double getMinusIpwonNum() {
		return this.minusIpwonNum;
	}

	public void setMinusIpwonNum(double minusIpwonNum) {
		this.minusIpwonNum = minusIpwonNum;
	}


	@Column(name="MINUS_JAEWON_NUM")
	public double getMinusJaewonNum() {
		return this.minusJaewonNum;
	}

	public void setMinusJaewonNum(double minusJaewonNum) {
		this.minusJaewonNum = minusJaewonNum;
	}


	@Column(name="MINUS_JUNCHUL_NUM")
	public double getMinusJunchulNum() {
		return this.minusJunchulNum;
	}

	public void setMinusJunchulNum(double minusJunchulNum) {
		this.minusJunchulNum = minusJunchulNum;
	}


	@Column(name="MINUS_JUNIP_NUM")
	public double getMinusJunipNum() {
		return this.minusJunipNum;
	}

	public void setMinusJunipNum(double minusJunipNum) {
		this.minusJunipNum = minusJunipNum;
	}


	@Column(name="MINUS_TOIWON_NUM")
	public double getMinusToiwonNum() {
		return this.minusToiwonNum;
	}

	public void setMinusToiwonNum(double minusToiwonNum) {
		this.minusToiwonNum = minusToiwonNum;
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


	@Column(name="TOIWON_NUM")
	public double getToiwonNum() {
		return this.toiwonNum;
	}

	public void setToiwonNum(double toiwonNum) {
		this.toiwonNum = toiwonNum;
	}


	@Column(name="TOTAL_BED_NUM")
	public double getTotalBedNum() {
		return this.totalBedNum;
	}

	public void setTotalBedNum(double totalBedNum) {
		this.totalBedNum = totalBedNum;
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
package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;


/**
 * The persistent class for the NUR8001 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur8001.findAll", query="SELECT n FROM Nur8001 n")
public class Nur8001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Date departDate;
	private String departSayu;
	private String departTime;
	private String doctor;
	private double fkinp1001;
	private String gwa;
	private String hoDong;
	private String hospCode;
	private BigDecimal icuIpsilCnt;
	private BigDecimal inputCnt;
	private Date ipsilDate;
	private String ipsilTime;
	private String ipwonHoDong;
	private String ipwonRtn;
	private String moveHospital;
	private String reIpsilSayu;
	private String reIpsilYn;
	private String sangCode1;
	private String sangCode2;
	private String sangName1;
	private String sangName2;
	private String susulCode1;
	private String susulCode2;
	private String susulName1;
	private String susulName2;
	private String susulYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur8001() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="DEPART_DATE")
	public Date getDepartDate() {
		return this.departDate;
	}

	public void setDepartDate(Date departDate) {
		this.departDate = departDate;
	}


	@Column(name="DEPART_SAYU")
	public String getDepartSayu() {
		return this.departSayu;
	}

	public void setDepartSayu(String departSayu) {
		this.departSayu = departSayu;
	}


	@Column(name="DEPART_TIME")
	public String getDepartTime() {
		return this.departTime;
	}

	public void setDepartTime(String departTime) {
		this.departTime = departTime;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
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


	@Column(name="ICU_IPSIL_CNT")
	public BigDecimal getIcuIpsilCnt() {
		return this.icuIpsilCnt;
	}

	public void setIcuIpsilCnt(BigDecimal icuIpsilCnt) {
		this.icuIpsilCnt = icuIpsilCnt;
	}


	@Column(name="INPUT_CNT")
	public BigDecimal getInputCnt() {
		return this.inputCnt;
	}

	public void setInputCnt(BigDecimal inputCnt) {
		this.inputCnt = inputCnt;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IPSIL_DATE")
	public Date getIpsilDate() {
		return this.ipsilDate;
	}

	public void setIpsilDate(Date ipsilDate) {
		this.ipsilDate = ipsilDate;
	}


	@Column(name="IPSIL_TIME")
	public String getIpsilTime() {
		return this.ipsilTime;
	}

	public void setIpsilTime(String ipsilTime) {
		this.ipsilTime = ipsilTime;
	}


	@Column(name="IPWON_HO_DONG")
	public String getIpwonHoDong() {
		return this.ipwonHoDong;
	}

	public void setIpwonHoDong(String ipwonHoDong) {
		this.ipwonHoDong = ipwonHoDong;
	}


	@Column(name="IPWON_RTN")
	public String getIpwonRtn() {
		return this.ipwonRtn;
	}

	public void setIpwonRtn(String ipwonRtn) {
		this.ipwonRtn = ipwonRtn;
	}


	@Column(name="MOVE_HOSPITAL")
	public String getMoveHospital() {
		return this.moveHospital;
	}

	public void setMoveHospital(String moveHospital) {
		this.moveHospital = moveHospital;
	}


	@Column(name="RE_IPSIL_SAYU")
	public String getReIpsilSayu() {
		return this.reIpsilSayu;
	}

	public void setReIpsilSayu(String reIpsilSayu) {
		this.reIpsilSayu = reIpsilSayu;
	}


	@Column(name="RE_IPSIL_YN")
	public String getReIpsilYn() {
		return this.reIpsilYn;
	}

	public void setReIpsilYn(String reIpsilYn) {
		this.reIpsilYn = reIpsilYn;
	}


	@Column(name="SANG_CODE1")
	public String getSangCode1() {
		return this.sangCode1;
	}

	public void setSangCode1(String sangCode1) {
		this.sangCode1 = sangCode1;
	}


	@Column(name="SANG_CODE2")
	public String getSangCode2() {
		return this.sangCode2;
	}

	public void setSangCode2(String sangCode2) {
		this.sangCode2 = sangCode2;
	}


	@Column(name="SANG_NAME1")
	public String getSangName1() {
		return this.sangName1;
	}

	public void setSangName1(String sangName1) {
		this.sangName1 = sangName1;
	}


	@Column(name="SANG_NAME2")
	public String getSangName2() {
		return this.sangName2;
	}

	public void setSangName2(String sangName2) {
		this.sangName2 = sangName2;
	}


	@Column(name="SUSUL_CODE1")
	public String getSusulCode1() {
		return this.susulCode1;
	}

	public void setSusulCode1(String susulCode1) {
		this.susulCode1 = susulCode1;
	}


	@Column(name="SUSUL_CODE2")
	public String getSusulCode2() {
		return this.susulCode2;
	}

	public void setSusulCode2(String susulCode2) {
		this.susulCode2 = susulCode2;
	}


	@Column(name="SUSUL_NAME1")
	public String getSusulName1() {
		return this.susulName1;
	}

	public void setSusulName1(String susulName1) {
		this.susulName1 = susulName1;
	}


	@Column(name="SUSUL_NAME2")
	public String getSusulName2() {
		return this.susulName2;
	}

	public void setSusulName2(String susulName2) {
		this.susulName2 = susulName2;
	}


	@Column(name="SUSUL_YN")
	public String getSusulYn() {
		return this.susulYn;
	}

	public void setSusulYn(String susulYn) {
		this.susulYn = susulYn;
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
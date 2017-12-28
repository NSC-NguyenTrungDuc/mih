package nta.med.core.domain.inp;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INP1002 database table.
 * 
 */
@Entity
//@NamedQuery(name="Inp1002.findAll", query="SELECT i FROM Inp1002 i")
@Table(name="INP1002")
public class Inp1002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double billNo;
	private String bunho;
	private Double fkinp1001;
	private String gubun;
	private Date gubunIpwonDate;
	private Date gubunToiwonDate;
	private Double gubunTransCnt;
	private Date gubunTransDate;
	private String gubunTransYn;
	private String hospCode;
	private String pkinp1002;
	private Double seq;
	private String simsaMagamYn;
	private String simsaja;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inp1002() {
	}


	@Column(name="BILL_NO")
	public Double getBillNo() {
		return this.billNo;
	}

	public void setBillNo(Double billNo) {
		this.billNo = billNo;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUBUN_IPWON_DATE")
	public Date getGubunIpwonDate() {
		return this.gubunIpwonDate;
	}

	public void setGubunIpwonDate(Date gubunIpwonDate) {
		this.gubunIpwonDate = gubunIpwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUBUN_TOIWON_DATE")
	public Date getGubunToiwonDate() {
		return this.gubunToiwonDate;
	}

	public void setGubunToiwonDate(Date gubunToiwonDate) {
		this.gubunToiwonDate = gubunToiwonDate;
	}


	@Column(name="GUBUN_TRANS_CNT")
	public Double getGubunTransCnt() {
		return this.gubunTransCnt;
	}

	public void setGubunTransCnt(Double gubunTransCnt) {
		this.gubunTransCnt = gubunTransCnt;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUBUN_TRANS_DATE")
	public Date getGubunTransDate() {
		return this.gubunTransDate;
	}

	public void setGubunTransDate(Date gubunTransDate) {
		this.gubunTransDate = gubunTransDate;
	}


	@Column(name="GUBUN_TRANS_YN")
	public String getGubunTransYn() {
		return this.gubunTransYn;
	}

	public void setGubunTransYn(String gubunTransYn) {
		this.gubunTransYn = gubunTransYn;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getPkinp1002() {
		return this.pkinp1002;
	}

	public void setPkinp1002(String pkinp1002) {
		this.pkinp1002 = pkinp1002;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}


	@Column(name="SIMSA_MAGAM_YN")
	public String getSimsaMagamYn() {
		return this.simsaMagamYn;
	}

	public void setSimsaMagamYn(String simsaMagamYn) {
		this.simsaMagamYn = simsaMagamYn;
	}


	public String getSimsaja() {
		return this.simsaja;
	}

	public void setSimsaja(String simsaja) {
		this.simsaja = simsaja;
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
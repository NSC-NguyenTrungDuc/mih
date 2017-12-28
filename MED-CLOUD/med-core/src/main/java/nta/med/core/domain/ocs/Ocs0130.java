package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0130 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0130.findAll", query="SELECT o FROM Ocs0130 o")
@Table(name="OCS0130")
public class Ocs0130 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String cpComId;
	private String cpOpenId;
	private String hospCode;
	private String memb;
	private String membGubun;
	private String membName;
	private Date membYmd;
	private String oftenUseComId;
	private String oftenUseOpenId;
	private String sangComId;
	private String sangOpenId;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yaksokComId;
	private String yaksokOpenId;

	public Ocs0130() {
	}


	@Column(name="CP_COM_ID")
	public String getCpComId() {
		return this.cpComId;
	}

	public void setCpComId(String cpComId) {
		this.cpComId = cpComId;
	}


	@Column(name="CP_OPEN_ID")
	public String getCpOpenId() {
		return this.cpOpenId;
	}

	public void setCpOpenId(String cpOpenId) {
		this.cpOpenId = cpOpenId;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getMemb() {
		return this.memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}


	@Column(name="MEMB_GUBUN")
	public String getMembGubun() {
		return this.membGubun;
	}

	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}


	@Column(name="MEMB_NAME")
	public String getMembName() {
		return this.membName;
	}

	public void setMembName(String membName) {
		this.membName = membName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MEMB_YMD")
	public Date getMembYmd() {
		return this.membYmd;
	}

	public void setMembYmd(Date membYmd) {
		this.membYmd = membYmd;
	}


	@Column(name="OFTEN_USE_COM_ID")
	public String getOftenUseComId() {
		return this.oftenUseComId;
	}

	public void setOftenUseComId(String oftenUseComId) {
		this.oftenUseComId = oftenUseComId;
	}


	@Column(name="OFTEN_USE_OPEN_ID")
	public String getOftenUseOpenId() {
		return this.oftenUseOpenId;
	}

	public void setOftenUseOpenId(String oftenUseOpenId) {
		this.oftenUseOpenId = oftenUseOpenId;
	}


	@Column(name="SANG_COM_ID")
	public String getSangComId() {
		return this.sangComId;
	}

	public void setSangComId(String sangComId) {
		this.sangComId = sangComId;
	}


	@Column(name="SANG_OPEN_ID")
	public String getSangOpenId() {
		return this.sangOpenId;
	}

	public void setSangOpenId(String sangOpenId) {
		this.sangOpenId = sangOpenId;
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


	@Column(name="YAKSOK_COM_ID")
	public String getYaksokComId() {
		return this.yaksokComId;
	}

	public void setYaksokComId(String yaksokComId) {
		this.yaksokComId = yaksokComId;
	}


	@Column(name="YAKSOK_OPEN_ID")
	public String getYaksokOpenId() {
		return this.yaksokOpenId;
	}

	public void setYaksokOpenId(String yaksokOpenId) {
		this.yaksokOpenId = yaksokOpenId;
	}

}
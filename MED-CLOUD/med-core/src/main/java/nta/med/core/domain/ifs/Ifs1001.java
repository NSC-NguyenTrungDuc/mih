package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS1001 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs1001.findAll", query="SELECT i FROM Ifs1001 i")
public class Ifs1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String chuchiFlag;
	private String cplFlag;
	private String doctor;
	private String drgFlag;
	private String etcFlag;
	private String gwa;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifHospCode;
	private String ifTime;
	private String jubsuDate;
	private String jubsuNo;
	private String jubsuTime;
	private String jusaFlag;
	private double pkifs1001;
	private String procGubun;
	private String procGubunSub;
	private String reserFlag;
	private String reserGubun;
	private String reserItem;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs1001() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHUCHI_FLAG")
	public String getChuchiFlag() {
		return this.chuchiFlag;
	}

	public void setChuchiFlag(String chuchiFlag) {
		this.chuchiFlag = chuchiFlag;
	}


	@Column(name="CPL_FLAG")
	public String getCplFlag() {
		return this.cplFlag;
	}

	public void setCplFlag(String cplFlag) {
		this.cplFlag = cplFlag;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DRG_FLAG")
	public String getDrgFlag() {
		return this.drgFlag;
	}

	public void setDrgFlag(String drgFlag) {
		this.drgFlag = drgFlag;
	}


	@Column(name="ETC_FLAG")
	public String getEtcFlag() {
		return this.etcFlag;
	}

	public void setEtcFlag(String etcFlag) {
		this.etcFlag = etcFlag;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="IF_HOSP_CODE")
	public String getIfHospCode() {
		return this.ifHospCode;
	}

	public void setIfHospCode(String ifHospCode) {
		this.ifHospCode = ifHospCode;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="JUBSU_DATE")
	public String getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(String jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_NO")
	public String getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(String jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Column(name="JUSA_FLAG")
	public String getJusaFlag() {
		return this.jusaFlag;
	}

	public void setJusaFlag(String jusaFlag) {
		this.jusaFlag = jusaFlag;
	}


	public double getPkifs1001() {
		return this.pkifs1001;
	}

	public void setPkifs1001(double pkifs1001) {
		this.pkifs1001 = pkifs1001;
	}


	@Column(name="PROC_GUBUN")
	public String getProcGubun() {
		return this.procGubun;
	}

	public void setProcGubun(String procGubun) {
		this.procGubun = procGubun;
	}


	@Column(name="PROC_GUBUN_SUB")
	public String getProcGubunSub() {
		return this.procGubunSub;
	}

	public void setProcGubunSub(String procGubunSub) {
		this.procGubunSub = procGubunSub;
	}


	@Column(name="RESER_FLAG")
	public String getReserFlag() {
		return this.reserFlag;
	}

	public void setReserFlag(String reserFlag) {
		this.reserFlag = reserFlag;
	}


	@Column(name="RESER_GUBUN")
	public String getReserGubun() {
		return this.reserGubun;
	}

	public void setReserGubun(String reserGubun) {
		this.reserGubun = reserGubun;
	}


	@Column(name="RESER_ITEM")
	public String getReserItem() {
		return this.reserItem;
	}

	public void setReserItem(String reserItem) {
		this.reserItem = reserItem;
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
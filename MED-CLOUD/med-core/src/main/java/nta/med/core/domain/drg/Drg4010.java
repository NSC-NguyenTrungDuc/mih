package nta.med.core.domain.drg;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the DRG4010 database table.
 * 
 */
@Entity
@NamedQuery(name = "Drg4010.findAll", query = "SELECT d FROM Drg4010 d")
@Table(name = "DRG4010")
public class Drg4010 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String dataDubun;
	private Double drgBunho;
	private Double fkinp1001;
	private Double fkout1001;
	private String hospCode;
	private String ifSendFlag;
	private String inOutGubun;
	private Date jubsuDate;
	private Double pkdrg4010;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Drg4010() {
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "DATA_DUBUN")
	public String getDataDubun() {
		return this.dataDubun;
	}

	public void setDataDubun(String dataDubun) {
		this.dataDubun = dataDubun;
	}

	@Column(name = "DRG_BUNHO")
	public double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(double drgBunho) {
		this.drgBunho = drgBunho;
	}

	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "IF_SEND_FLAG")
	public String getIfSendFlag() {
		return this.ifSendFlag;
	}

	public void setIfSendFlag(String ifSendFlag) {
		this.ifSendFlag = ifSendFlag;
	}

	@Column(name = "IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}

	public double getPkdrg4010() {
		return this.pkdrg4010;
	}

	public void setPkdrg4010(double pkdrg4010) {
		this.pkdrg4010 = pkdrg4010;
	}

	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}
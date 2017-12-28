package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OUT0108 database table.
 * 
 */
@Entity
@NamedQuery(name="Out0108.findAll", query="SELECT o FROM Out0108 o")
public class Out0108 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String checkGijun;
	private Date endDate;
	private String gongbiCode;
	private String hanBonGubun;
	private String hospCode;
	private double inpGongAmt;
	private double outGongAmt;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Out0108() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CHECK_GIJUN")
	public String getCheckGijun() {
		return this.checkGijun;
	}

	public void setCheckGijun(String checkGijun) {
		this.checkGijun = checkGijun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="GONGBI_CODE")
	public String getGongbiCode() {
		return this.gongbiCode;
	}

	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}


	@Column(name="HAN_BON_GUBUN")
	public String getHanBonGubun() {
		return this.hanBonGubun;
	}

	public void setHanBonGubun(String hanBonGubun) {
		this.hanBonGubun = hanBonGubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INP_GONG_AMT")
	public double getInpGongAmt() {
		return this.inpGongAmt;
	}

	public void setInpGongAmt(double inpGongAmt) {
		this.inpGongAmt = inpGongAmt;
	}


	@Column(name="OUT_GONG_AMT")
	public double getOutGongAmt() {
		return this.outGongAmt;
	}

	public void setOutGongAmt(double outGongAmt) {
		this.outGongAmt = outGongAmt;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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
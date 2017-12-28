package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0302 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0302.findAll", query="SELECT o FROM Ocs0302 o")
public class Ocs0302 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String memb;
	private String nurRemark1;
	private String nurRemark2;
	private String nurRemark3;
	private String nurRemark4;
	private String ordRemark1;
	private String ordRemark2;
	private String ordRemark3;
	private String ordRemark4;
	private double pkocs0303;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yaksokCode;

	public Ocs0302() {
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


	@Column(name="NUR_REMARK1")
	public String getNurRemark1() {
		return this.nurRemark1;
	}

	public void setNurRemark1(String nurRemark1) {
		this.nurRemark1 = nurRemark1;
	}


	@Column(name="NUR_REMARK2")
	public String getNurRemark2() {
		return this.nurRemark2;
	}

	public void setNurRemark2(String nurRemark2) {
		this.nurRemark2 = nurRemark2;
	}


	@Column(name="NUR_REMARK3")
	public String getNurRemark3() {
		return this.nurRemark3;
	}

	public void setNurRemark3(String nurRemark3) {
		this.nurRemark3 = nurRemark3;
	}


	@Column(name="NUR_REMARK4")
	public String getNurRemark4() {
		return this.nurRemark4;
	}

	public void setNurRemark4(String nurRemark4) {
		this.nurRemark4 = nurRemark4;
	}


	@Column(name="ORD_REMARK1")
	public String getOrdRemark1() {
		return this.ordRemark1;
	}

	public void setOrdRemark1(String ordRemark1) {
		this.ordRemark1 = ordRemark1;
	}


	@Column(name="ORD_REMARK2")
	public String getOrdRemark2() {
		return this.ordRemark2;
	}

	public void setOrdRemark2(String ordRemark2) {
		this.ordRemark2 = ordRemark2;
	}


	@Column(name="ORD_REMARK3")
	public String getOrdRemark3() {
		return this.ordRemark3;
	}

	public void setOrdRemark3(String ordRemark3) {
		this.ordRemark3 = ordRemark3;
	}


	@Column(name="ORD_REMARK4")
	public String getOrdRemark4() {
		return this.ordRemark4;
	}

	public void setOrdRemark4(String ordRemark4) {
		this.ordRemark4 = ordRemark4;
	}


	public double getPkocs0303() {
		return this.pkocs0303;
	}

	public void setPkocs0303(double pkocs0303) {
		this.pkocs0303 = pkocs0303;
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


	@Column(name="YAKSOK_CODE")
	public String getYaksokCode() {
		return this.yaksokCode;
	}

	public void setYaksokCode(String yaksokCode) {
		this.yaksokCode = yaksokCode;
	}

}
package nta.med.core.domain.xrt;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;



/**
 * The persistent class for the XRT1001 database table.
 * 
 */
@Entity
@Table(name="XRT1001")
public class Xrt1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fkocs;
	private double fkxrt0201;
	private String hangmogCode;
	private String hospCode;
	private String inOutGubun;
	private String jaeryoCode;
	private String remark;
	private String sideEffectText;
	private String sideEffect1;
	private String sideEffect2;
	private String sideEffect3;
	private String sideEffect4;
	private String sideEffect5;
	private String sideEffect6;
	private String sideEffect7;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private Date xrayDate;

	public Xrt1001() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(double fkocs) {
		this.fkocs = fkocs;
	}


	public double getFkxrt0201() {
		return this.fkxrt0201;
	}

	public void setFkxrt0201(double fkxrt0201) {
		this.fkxrt0201 = fkxrt0201;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="SIDE_EFFECT_TEXT")
	public String getSideEffectText() {
		return this.sideEffectText;
	}

	public void setSideEffectText(String sideEffectText) {
		this.sideEffectText = sideEffectText;
	}


	@Column(name="SIDE_EFFECT1")
	public String getSideEffect1() {
		return this.sideEffect1;
	}

	public void setSideEffect1(String sideEffect1) {
		this.sideEffect1 = sideEffect1;
	}


	@Column(name="SIDE_EFFECT2")
	public String getSideEffect2() {
		return this.sideEffect2;
	}

	public void setSideEffect2(String sideEffect2) {
		this.sideEffect2 = sideEffect2;
	}


	@Column(name="SIDE_EFFECT3")
	public String getSideEffect3() {
		return this.sideEffect3;
	}

	public void setSideEffect3(String sideEffect3) {
		this.sideEffect3 = sideEffect3;
	}


	@Column(name="SIDE_EFFECT4")
	public String getSideEffect4() {
		return this.sideEffect4;
	}

	public void setSideEffect4(String sideEffect4) {
		this.sideEffect4 = sideEffect4;
	}


	@Column(name="SIDE_EFFECT5")
	public String getSideEffect5() {
		return this.sideEffect5;
	}

	public void setSideEffect5(String sideEffect5) {
		this.sideEffect5 = sideEffect5;
	}


	@Column(name="SIDE_EFFECT6")
	public String getSideEffect6() {
		return this.sideEffect6;
	}

	public void setSideEffect6(String sideEffect6) {
		this.sideEffect6 = sideEffect6;
	}


	@Column(name="SIDE_EFFECT7")
	public String getSideEffect7() {
		return this.sideEffect7;
	}

	public void setSideEffect7(String sideEffect7) {
		this.sideEffect7 = sideEffect7;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="XRAY_DATE")
	public Date getXrayDate() {
		return this.xrayDate;
	}

	public void setXrayDate(Date xrayDate) {
		this.xrayDate = xrayDate;
	}

}
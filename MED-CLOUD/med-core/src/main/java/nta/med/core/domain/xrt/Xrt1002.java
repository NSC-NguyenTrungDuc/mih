package nta.med.core.domain.xrt;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the XRT1002 database table.
 * 
 */
@Entity
@Table(name="XRT1002")
public class Xrt1002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buhaGubun;
	private String bunho;
	private Double fkocs;
	private String gumsaMokjuk;
	private String hangmogCode;
	private String hospCode;
	private String inOutGubun;
	private String pandokRequestYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String xrayMethod;

	public Xrt1002() {
	}


	@Column(name="BUHA_GUBUN")
	public String getBuhaGubun() {
		return this.buhaGubun;
	}

	public void setBuhaGubun(String buhaGubun) {
		this.buhaGubun = buhaGubun;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public Double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(Double fkocs) {
		this.fkocs = fkocs;
	}


	@Column(name="GUMSA_MOKJUK")
	public String getGumsaMokjuk() {
		return this.gumsaMokjuk;
	}

	public void setGumsaMokjuk(String gumsaMokjuk) {
		this.gumsaMokjuk = gumsaMokjuk;
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


	@Column(name="PANDOK_REQUEST_YN")
	public String getPandokRequestYn() {
		return this.pandokRequestYn;
	}

	public void setPandokRequestYn(String pandokRequestYn) {
		this.pandokRequestYn = pandokRequestYn;
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


	@Column(name="XRAY_METHOD")
	public String getXrayMethod() {
		return this.xrayMethod;
	}

	public void setXrayMethod(String xrayMethod) {
		this.xrayMethod = xrayMethod;
	}

}
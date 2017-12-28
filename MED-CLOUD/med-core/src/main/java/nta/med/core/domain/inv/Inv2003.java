package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the INV2003 database table.
 * 
 */
@Entity
@Table(name = "INV2003")
public class Inv2003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String chulgoType;
	private String churiBuseo;
	private Date churiDate;
	private Double churiSeq;
	private String hospCode;
	private String inOutGubun;
	private String ipchulType;
	private String jaeryoGubun;
	private Double pkinv2003;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String exportCode;
	private String churiTime;

	public Inv2003() {
	}

	@Column(name = "CHULGO_TYPE")
	public String getChulgoType() {
		return this.chulgoType;
	}

	public void setChulgoType(String chulgoType) {
		this.chulgoType = chulgoType;
	}

	@Column(name = "CHURI_BUSEO")
	public String getChuriBuseo() {
		return this.churiBuseo;
	}

	public void setChuriBuseo(String churiBuseo) {
		this.churiBuseo = churiBuseo;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "CHURI_DATE")
	public Date getChuriDate() {
		return this.churiDate;
	}

	public void setChuriDate(Date churiDate) {
		this.churiDate = churiDate;
	}

	@Column(name = "CHURI_SEQ")
	public Double getChuriSeq() {
		return this.churiSeq;
	}

	public void setChuriSeq(Double churiSeq) {
		this.churiSeq = churiSeq;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}

	@Column(name = "IPCHUL_TYPE")
	public String getIpchulType() {
		return this.ipchulType;
	}

	public void setIpchulType(String ipchulType) {
		this.ipchulType = ipchulType;
	}

	@Column(name = "JAERYO_GUBUN")
	public String getJaeryoGubun() {
		return this.jaeryoGubun;
	}

	public void setJaeryoGubun(String jaeryoGubun) {
		this.jaeryoGubun = jaeryoGubun;
	}

	public Double getPkinv2003() {
		return this.pkinv2003;
	}

	public void setPkinv2003(Double pkinv2003) {
		this.pkinv2003 = pkinv2003;
	}

	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID", length = 10)
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

	@Column(name = "UPD_ID", length = 10)
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "EXPORT_CODE")
	public String getExportCode() {
		return exportCode;
	}

	public void setExportCode(String exportCode) {
		this.exportCode = exportCode;
	}

	@Column(name = "CHURI_TIME")
	public String getChuriTime() {
		return churiTime;
	}

	public void setChuriTime(String churiTime) {
		this.churiTime = churiTime;
	}

}
package nta.med.core.domain.inv;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INV4001 database table.
 * 
 */
@Entity
@Table(name = "INV4001")
public class Inv4001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String churiBuseo;
	private Date churiDate;
	private Double churiSeq;
	private String hospCode;
	private String inOutGubun;
	private String ipchulType;
	private String ipgoType;
	private String jaeryoGubun;
	private Double pkinv4001;
	private String remark;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String importCode;
	private String churiTime;

	public Inv4001() {
	}


	@Column(name="CHURI_BUSEO")
	public String getChuriBuseo() {
		return this.churiBuseo;
	}

	public void setChuriBuseo(String churiBuseo) {
		this.churiBuseo = churiBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHURI_DATE")
	public Date getChuriDate() {
		return this.churiDate;
	}

	public void setChuriDate(Date churiDate) {
		this.churiDate = churiDate;
	}


	@Column(name="CHURI_SEQ")
	public Double getChuriSeq() {
		return this.churiSeq;
	}

	public void setChuriSeq(Double churiSeq) {
		this.churiSeq = churiSeq;
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


	@Column(name="IPCHUL_TYPE")
	public String getIpchulType() {
		return this.ipchulType;
	}

	public void setIpchulType(String ipchulType) {
		this.ipchulType = ipchulType;
	}


	@Column(name="IPGO_TYPE")
	public String getIpgoType() {
		return this.ipgoType;
	}

	public void setIpgoType(String ipgoType) {
		this.ipgoType = ipgoType;
	}


	@Column(name="JAERYO_GUBUN")
	public String getJaeryoGubun() {
		return this.jaeryoGubun;
	}

	public void setJaeryoGubun(String jaeryoGubun) {
		this.jaeryoGubun = jaeryoGubun;
	}


	public Double getPkinv4001() {
		return this.pkinv4001;
	}

	public void setPkinv4001(Double pkinv4001) {
		this.pkinv4001 = pkinv4001;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
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

	@Column(name="IMPORT_CODE")
	public String getImportCode() {
		return importCode;
	}

	public void setImportCode(String importCode) {
		this.importCode = importCode;
	}

	@Column(name="CHURI_TIME")
	public String getChuriTime() {
		return churiTime;
	}

	public void setChuriTime(String churiTime) {
		this.churiTime = churiTime;
	}
	
}
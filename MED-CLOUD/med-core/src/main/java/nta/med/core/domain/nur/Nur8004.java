package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR8004 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur8004.findAll", query="SELECT n FROM Nur8004 n")
public class Nur8004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String cancelYn;
	private String dataCode;
	private String dataCodeName;
	private String dataGubun;
	private double fkinp1001;
	private String hospCode;
	private double inputCnt;
	private double pknur8004;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur8004() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CANCEL_YN")
	public String getCancelYn() {
		return this.cancelYn;
	}

	public void setCancelYn(String cancelYn) {
		this.cancelYn = cancelYn;
	}


	@Column(name="DATA_CODE")
	public String getDataCode() {
		return this.dataCode;
	}

	public void setDataCode(String dataCode) {
		this.dataCode = dataCode;
	}


	@Column(name="DATA_CODE_NAME")
	public String getDataCodeName() {
		return this.dataCodeName;
	}

	public void setDataCodeName(String dataCodeName) {
		this.dataCodeName = dataCodeName;
	}


	@Column(name="DATA_GUBUN")
	public String getDataGubun() {
		return this.dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_CNT")
	public double getInputCnt() {
		return this.inputCnt;
	}

	public void setInputCnt(double inputCnt) {
		this.inputCnt = inputCnt;
	}


	public double getPknur8004() {
		return this.pknur8004;
	}

	public void setPknur8004(double pknur8004) {
		this.pknur8004 = pknur8004;
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
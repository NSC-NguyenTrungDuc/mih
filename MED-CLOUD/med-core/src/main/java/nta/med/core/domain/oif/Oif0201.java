package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF0201 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif0201.findAll", query="SELECT o FROM Oif0201 o")
public class Oif0201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String codeTab;
	private String codeTabNm;
	private String codeTabTp1;
	private String codeTabTp2;
	private String hospCode;
	private String remark;
	private String remark2;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Oif0201() {
	}


	@Column(name="CODE_TAB")
	public String getCodeTab() {
		return this.codeTab;
	}

	public void setCodeTab(String codeTab) {
		this.codeTab = codeTab;
	}


	@Column(name="CODE_TAB_NM")
	public String getCodeTabNm() {
		return this.codeTabNm;
	}

	public void setCodeTabNm(String codeTabNm) {
		this.codeTabNm = codeTabNm;
	}


	@Column(name="CODE_TAB_TP1")
	public String getCodeTabTp1() {
		return this.codeTabTp1;
	}

	public void setCodeTabTp1(String codeTabTp1) {
		this.codeTabTp1 = codeTabTp1;
	}


	@Column(name="CODE_TAB_TP2")
	public String getCodeTabTp2() {
		return this.codeTabTp2;
	}

	public void setCodeTabTp2(String codeTabTp2) {
		this.codeTabTp2 = codeTabTp2;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getRemark2() {
		return this.remark2;
	}

	public void setRemark2(String remark2) {
		this.remark2 = remark2;
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
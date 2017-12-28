package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0212 database table.
 * 
 */
@Entity
//@NamedQuery(name="Bas0212.findAll", query="SELECT b FROM Bas0212 b")
@Table(name="BAS0212")
public class Bas0212 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private String gongbiCode;
	private String gongbiGubun;
	private String gongbiJiyeok;
	private String gongbiName;
	private String lawNo;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private String totalYn;
	private Date updDate;
	private String updId;
	private String language;
	
	public Bas0212() {
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


	@Column(name="GONGBI_GUBUN")
	public String getGongbiGubun() {
		return this.gongbiGubun;
	}

	public void setGongbiGubun(String gongbiGubun) {
		this.gongbiGubun = gongbiGubun;
	}


	@Column(name="GONGBI_JIYEOK")
	public String getGongbiJiyeok() {
		return this.gongbiJiyeok;
	}

	public void setGongbiJiyeok(String gongbiJiyeok) {
		this.gongbiJiyeok = gongbiJiyeok;
	}


	@Column(name="GONGBI_NAME")
	public String getGongbiName() {
		return this.gongbiName;
	}

	public void setGongbiName(String gongbiName) {
		this.gongbiName = gongbiName;
	}

	@Column(name="LAW_NO")
	public String getLawNo() {
		return this.lawNo;
	}

	public void setLawNo(String lawNo) {
		this.lawNo = lawNo;
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


	@Column(name="TOTAL_YN")
	public String getTotalYn() {
		return this.totalYn;
	}

	public void setTotalYn(String totalYn) {
		this.totalYn = totalYn;
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

	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

}
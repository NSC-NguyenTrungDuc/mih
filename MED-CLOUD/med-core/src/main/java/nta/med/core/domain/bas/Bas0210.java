package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0210 database table.
 * 
 */
@Entity
//@NamedQuery(name="Bas0210.findAll", query="SELECT b FROM Bas0210 b")
@Table(name="BAS0210")
public class Bas0210 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private String gongbiYn;
	private String gubun;
	private String gubunName;
	private String johapGubun;
	private String nursecallGubun;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String language;

	public Bas0210() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="GONGBI_YN")
	public String getGongbiYn() {
		return this.gongbiYn;
	}

	public void setGongbiYn(String gongbiYn) {
		this.gongbiYn = gongbiYn;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="GUBUN_NAME")
	public String getGubunName() {
		return this.gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}

	@Column(name="JOHAP_GUBUN")
	public String getJohapGubun() {
		return this.johapGubun;
	}

	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}


	@Column(name="NURSECALL_GUBUN")
	public String getNursecallGubun() {
		return this.nursecallGubun;
	}

	public void setNursecallGubun(String nursecallGubun) {
		this.nursecallGubun = nursecallGubun;
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

	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}


	public void setLanguage(String language) {
		this.language = language;
	}
	
}
package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM1110 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm1110.findAll", query="SELECT a FROM Adm1110 a")
@Table(name="ADM1110")
public class Adm1110 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String code;
	private String codeNm;
	private String colId;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String language;

	public Adm1110() {
	}


	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}


	@Column(name="CODE_NM")
	public String getCodeNm() {
		return this.codeNm;
	}

	public void setCodeNm(String codeNm) {
		this.codeNm = codeNm;
	}


	@Column(name="COL_ID")
	public String getColId() {
		return this.colId;
	}

	public void setColId(String colId) {
		this.colId = colId;
	}


	@Column(name="CR_MEMB")
	public String getCrMemb() {
		return this.crMemb;
	}

	public void setCrMemb(String crMemb) {
		this.crMemb = crMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CR_TIME")
	public Date getCrTime() {
		return this.crTime;
	}

	public void setCrTime(Date crTime) {
		this.crTime = crTime;
	}


	@Column(name="CR_TRM")
	public String getCrTrm() {
		return this.crTrm;
	}

	public void setCrTrm(String crTrm) {
		this.crTrm = crTrm;
	}


	@Column(name="UP_MEMB")
	public String getUpMemb() {
		return this.upMemb;
	}

	public void setUpMemb(String upMemb) {
		this.upMemb = upMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UP_TIME")
	public Date getUpTime() {
		return this.upTime;
	}

	public void setUpTime(Date upTime) {
		this.upTime = upTime;
	}


	@Column(name="UP_TRM")
	public String getUpTrm() {
		return this.upTrm;
	}

	public void setUpTrm(String upTrm) {
		this.upTrm = upTrm;
	}

	@Column(name="LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}
	
}
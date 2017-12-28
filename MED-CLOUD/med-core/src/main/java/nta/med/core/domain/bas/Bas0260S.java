package nta.med.core.domain.bas;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0260S database table.
 * 
 */
@Entity
//@NamedQuery(name = "Bas0260S.findAll", query = "SELECT b FROM Bas0260S b")
@Table(name="BAS0260S")
public class Bas0260S extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String buseoCode;
	private String buseoName;
	private String buseoName2;
	private String buseoGubun;
	private String parentBuseo;
	private String gwa;
	private String gwaName;
	private String gwaName2;
	private String gwaGubun;
	private String parentGwa;
	private String note;
	private Timestamp created;
	private Timestamp updated;
	private String sysId;
	private String updId;
	private String language;
	private String activeFlg;

	public Bas0260S() {
	}

	@Column(name="BUSEO_CODE")
	public String getBuseoCode() {
		return this.buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}


	@Column(name="BUSEO_NAME")
	public String getBuseoName() {
		return this.buseoName;
	}

	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}


	@Column(name="BUSEO_NAME2")
	public String getBuseoName2() {
		return this.buseoName2;
	}

	public void setBuseoName2(String buseoName2) {
		this.buseoName2 = buseoName2;
	}


	@Column(name="BUSEO_GUBUN")
	public String getBuseoGubun() {
		return this.buseoGubun;
	}

	public void setBuseoGubun(String buseoGubun) {
		this.buseoGubun = buseoGubun;
	}
	
	@Column(name="PARENT_BUSEO")
	public String getParentBuseo() {
		return this.parentBuseo;
	}

	public void setParentBuseo(String parentBuseo) {
		this.parentBuseo = parentBuseo;
	}

	@Column(name="GWA")
	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	
	@Column(name="GWA_NAME")
	public String getGwaName() {
		return this.gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	
	@Column(name="GWA_NAME2")
	public String getGwaName2() {
		return this.gwaName2;
	}

	public void setGwaName2(String gwaName2) {
		this.gwaName2 = gwaName2;
	}
	
	@Column(name="GWA_GUBUN")
	public String getGwaGubun() {
		return this.gwaGubun;
	}

	public void setGwaGubun(String gwaGubun) {
		this.gwaGubun = gwaGubun;
	}

	@Column(name="PARENT_GWA")
	public String getParentGwa() {
		return this.parentGwa;
	}

	public void setParentGwa(String parentGwa) {
		this.parentGwa = parentGwa;
	}

	@Column(name="NOTE")
	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CREATED")
	public Date getCreated() {
		return created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPDATED")
	public Date getUpdated() {
		return updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
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
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
	}
	
	@Column(name="ACTIVE_FLG")
	public String getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(String activeFlg) {
		this.activeFlg = activeFlg;
	}

}
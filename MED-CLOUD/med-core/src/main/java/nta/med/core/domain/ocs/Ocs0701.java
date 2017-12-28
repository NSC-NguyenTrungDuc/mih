package nta.med.core.domain.ocs;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

@Entity
@Table(name = "OCS0701")
public class Ocs0701 extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;

	private String bunho;

	private Date consultDate;

	private String consultDoctor;

	private String consultGwa;

	private String consultHospCode;

	private Date created;

	private String finishFlg;

	private String hospCode;

	private Date reqDate;

	private String reqDoctor;

	private String reqGwa;

	private BigDecimal status;

	private String sysId;

	private String updId;

	private Date updated;

	public Ocs0701() {
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "CONSULT_DATE")
	public Date getConsultDate() {
		return this.consultDate;
	}

	public void setConsultDate(Date consultDate) {
		this.consultDate = consultDate;
	}

	@Column(name = "CONSULT_DOCTOR")
	public String getConsultDoctor() {
		return this.consultDoctor;
	}

	public void setConsultDoctor(String consultDoctor) {
		this.consultDoctor = consultDoctor;
	}

	@Column(name = "CONSULT_GWA")
	public String getConsultGwa() {
		return this.consultGwa;
	}

	public void setConsultGwa(String consultGwa) {
		this.consultGwa = consultGwa;
	}

	@Column(name = "CONSULT_HOSP_CODE")
	public String getConsultHospCode() {
		return this.consultHospCode;
	}

	public void setConsultHospCode(String consultHospCode) {
		this.consultHospCode = consultHospCode;
	}

	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	@Column(name = "FINISH_FLG")
	public String getFinishFlg() {
		return this.finishFlg;
	}

	public void setFinishFlg(String finishFlg) {
		this.finishFlg = finishFlg;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "REQ_DATE")
	public Date getReqDate() {
		return this.reqDate;
	}

	public void setReqDate(Date reqDate) {
		this.reqDate = reqDate;
	}

	@Column(name = "REQ_DOCTOR")
	public String getReqDoctor() {
		return this.reqDoctor;
	}

	public void setReqDoctor(String reqDoctor) {
		this.reqDoctor = reqDoctor;
	}

	@Column(name = "REQ_GWA")
	public String getReqGwa() {
		return this.reqGwa;
	}

	public void setReqGwa(String reqGwa) {
		this.reqGwa = reqGwa;
	}

	public BigDecimal getStatus() {
		return this.status;
	}

	public void setStatus(BigDecimal status) {
		this.status = status;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Date getUpdated() {
		return this.updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}

}

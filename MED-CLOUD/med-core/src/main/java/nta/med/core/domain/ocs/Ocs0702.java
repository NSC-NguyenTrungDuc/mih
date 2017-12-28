package nta.med.core.domain.ocs;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;

@Entity
@Table(name = "OCS0702")
public class Ocs0702 extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private BigDecimal activeFlg;

	private String content;

	private Date created;

	private String doctor;

	private BigDecimal editedFlg;

	private Long grpQuestionId;

	private String hospCode;

	private String sysId;

	private String updId;

	private Date updated;

	public Ocs0702() {
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	@Column(name = "EDITED_FLG")
	public BigDecimal getEditedFlg() {
		return this.editedFlg;
	}

	public void setEditedFlg(BigDecimal editedFlg) {
		this.editedFlg = editedFlg;
	}

	@Column(name = "GRP_QUESTION_ID")
	public Long getGrpQuestionId() {
		return this.grpQuestionId;
	}

	public void setGrpQuestionId(Long grpQuestionId) {
		this.grpQuestionId = grpQuestionId;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
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

package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0170 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0170.findAll", query="SELECT o FROM Ocs0170 o")
@Table(name="OCS0170")
public class Ocs0170 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String ment;
	private String specificComment;
	private String specificCommentColId;
	private String specificCommentName;
	private String specificCommentNotNull;
	private String specificCommentPgmId;
	private String specificCommentSysId;
	private String specificCommentTableId;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ocs0170() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getMent() {
		return this.ment;
	}

	public void setMent(String ment) {
		this.ment = ment;
	}


	@Column(name="SPECIFIC_COMMENT")
	public String getSpecificComment() {
		return this.specificComment;
	}

	public void setSpecificComment(String specificComment) {
		this.specificComment = specificComment;
	}


	@Column(name="SPECIFIC_COMMENT_COL_ID")
	public String getSpecificCommentColId() {
		return this.specificCommentColId;
	}

	public void setSpecificCommentColId(String specificCommentColId) {
		this.specificCommentColId = specificCommentColId;
	}


	@Column(name="SPECIFIC_COMMENT_NAME")
	public String getSpecificCommentName() {
		return this.specificCommentName;
	}

	public void setSpecificCommentName(String specificCommentName) {
		this.specificCommentName = specificCommentName;
	}


	@Column(name="SPECIFIC_COMMENT_NOT_NULL")
	public String getSpecificCommentNotNull() {
		return this.specificCommentNotNull;
	}

	public void setSpecificCommentNotNull(String specificCommentNotNull) {
		this.specificCommentNotNull = specificCommentNotNull;
	}


	@Column(name="SPECIFIC_COMMENT_PGM_ID")
	public String getSpecificCommentPgmId() {
		return this.specificCommentPgmId;
	}

	public void setSpecificCommentPgmId(String specificCommentPgmId) {
		this.specificCommentPgmId = specificCommentPgmId;
	}


	@Column(name="SPECIFIC_COMMENT_SYS_ID")
	public String getSpecificCommentSysId() {
		return this.specificCommentSysId;
	}

	public void setSpecificCommentSysId(String specificCommentSysId) {
		this.specificCommentSysId = specificCommentSysId;
	}


	@Column(name="SPECIFIC_COMMENT_TABLE_ID")
	public String getSpecificCommentTableId() {
		return this.specificCommentTableId;
	}

	public void setSpecificCommentTableId(String specificCommentTableId) {
		this.specificCommentTableId = specificCommentTableId;
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
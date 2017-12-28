package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS2004 database table.
 * 
 */
@Entity
@Table(name = "OCS2004")
public class Ocs2004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String brCode;
	private String brComment;
	private String bstRemark;
	private Double bstTime;
	private String bstYn;
	private String bunho;
	private String bwtYn;
	private Double fkinp1001;
	private String headTitle;
	private String hospCode;
	private String inputGubun;
	private String inputId;
	private String ioRemark;
	private Double ioTime;
	private String ioYn;
	private String nurseConfirmUser;
	private String nutComment;
	private Date orderDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vsRemark;
	private Double vsTime;
	private String vsYn;

	public Ocs2004() {
	}

	@Column(name = "BR_CODE")
	public String getBrCode() {
		return this.brCode;
	}

	public void setBrCode(String brCode) {
		this.brCode = brCode;
	}

	@Column(name = "BR_COMMENT")
	public String getBrComment() {
		return this.brComment;
	}

	public void setBrComment(String brComment) {
		this.brComment = brComment;
	}

	@Column(name = "BST_REMARK")
	public String getBstRemark() {
		return this.bstRemark;
	}

	public void setBstRemark(String bstRemark) {
		this.bstRemark = bstRemark;
	}

	@Column(name = "BST_TIME")
	public Double getBstTime() {
		return this.bstTime;
	}

	public void setBstTime(Double bstTime) {
		this.bstTime = bstTime;
	}

	@Column(name = "BST_YN")
	public String getBstYn() {
		return this.bstYn;
	}

	public void setBstYn(String bstYn) {
		this.bstYn = bstYn;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "BWT_YN")
	public String getBwtYn() {
		return this.bwtYn;
	}

	public void setBwtYn(String bwtYn) {
		this.bwtYn = bwtYn;
	}

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name = "HEAD_TITLE")
	public String getHeadTitle() {
		return this.headTitle;
	}

	public void setHeadTitle(String headTitle) {
		this.headTitle = headTitle;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	@Column(name = "INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	@Column(name = "IO_REMARK")
	public String getIoRemark() {
		return this.ioRemark;
	}

	public void setIoRemark(String ioRemark) {
		this.ioRemark = ioRemark;
	}

	@Column(name = "IO_TIME")
	public Double getIoTime() {
		return this.ioTime;
	}

	public void setIoTime(Double ioTime) {
		this.ioTime = ioTime;
	}

	@Column(name = "IO_YN")
	public String getIoYn() {
		return this.ioYn;
	}

	public void setIoYn(String ioYn) {
		this.ioYn = ioYn;
	}

	@Column(name = "NURSE_CONFIRM_USER")
	public String getNurseConfirmUser() {
		return this.nurseConfirmUser;
	}

	public void setNurseConfirmUser(String nurseConfirmUser) {
		this.nurseConfirmUser = nurseConfirmUser;
	}

	@Column(name = "NUT_COMMENT")
	public String getNutComment() {
		return this.nutComment;
	}

	public void setNutComment(String nutComment) {
		this.nutComment = nutComment;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "VS_REMARK")
	public String getVsRemark() {
		return this.vsRemark;
	}

	public void setVsRemark(String vsRemark) {
		this.vsRemark = vsRemark;
	}

	@Column(name = "VS_TIME")
	public Double getVsTime() {
		return this.vsTime;
	}

	public void setVsTime(Double vsTime) {
		this.vsTime = vsTime;
	}

	@Column(name = "VS_YN")
	public String getVsYn() {
		return this.vsYn;
	}

	public void setVsYn(String vsYn) {
		this.vsYn = vsYn;
	}

}
package nta.med.core.domain.bas;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

@Entity
@Table(name="BAS0501")
public class Bas0501 extends BaseEntity{
	private static final long serialVersionUID = 1L;
	private String tlpCode;
	private String tplType;
	private String tplName;
	private String formatType;
	private String inputContent;
	private String printContent;
	private String hospCode;
	private String sysId;
	private Date sysDate;
	private String updId;
	private Date updDate;
	private BigDecimal activeFlg;
	private String language;
	
	public Bas0501() {		
	}
	
	@Column(name = "TPL_CODE")
	public String getTlpCode() {
		return tlpCode;
	}

	public void setTlpCode(String tlpCode) {
		this.tlpCode = tlpCode;
	}
	
	@Column(name = "TPL_TYPE")
	public String getTplType() {
		return tplType;
	}

	public void setTplType(String tplType) {
		this.tplType = tplType;
	}
	
	@Column(name = "TPL_NAME")
	public String getTplName() {
		return tplName;
	}

	public void setTplName(String tplName) {
		this.tplName = tplName;
	}
	
	@Column(name = "FORMAT_TYPE")
	public String getFormatType() {
		return formatType;
	}

	public void setFormatType(String formatType) {
		this.formatType = formatType;
	}

	@Column(name = "INPUT_CONTENT")
	public String getInputContent() {
		return inputContent;
	}

	public void setInputContent(String inputContent) {
		this.inputContent = inputContent;
	}

	@Column(name = "PRINT_CONTENT")
	public String getPrintContent() {
		return printContent;
	}

	public void setPrintContent(String printContent) {
		this.printContent = printContent;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	@Column(name = "LANGUAGE")
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}
	
}

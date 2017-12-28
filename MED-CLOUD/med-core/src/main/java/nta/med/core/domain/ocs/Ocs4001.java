package nta.med.core.domain.ocs;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Lob;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

@Entity
@Table(name="OCS4001")
public class Ocs4001 extends BaseEntity{
	private static final long serialVersionUID = 1L;
	private String tlpCode;
	private String formatType;
	private String formCode;
	private String formName;
	private String inputContent;
	private String inputValue;
	private String printContent;
	private String bunho;
	private String hospCode;
	private String createDate;
	private Date printDate;
	private String fromDate;
	private String toDate;
	private String sysId;
	private Date sysDate;
	private String updId;
	private Date updDate;
	private BigDecimal activeFlg;
	
	public Ocs4001() {		
	}
	
	@Column(name = "TPL_CODE")
	public String getTlpCode() {
		return tlpCode;
	}

	public void setTlpCode(String tlpCode) {
		this.tlpCode = tlpCode;
	}

	@Column(name = "FORMAT_TYPE")
	public String getFormatType() {
		return formatType;
	}

	public void setFormatType(String formatType) {
		this.formatType = formatType;
	}

	@Column(name = "FORM_CODE")
	public String getFormCode() {
		return formCode;
	}

	public void setFormCode(String formCode) {
		this.formCode = formCode;
	}

	@Column(name = "FORM_NAME")
	public String getFormName() {
		return formName;
	}

	public void setFormName(String formName) {
		this.formName = formName;
	}

	@Column(name = "INPUT_CONTENT")
	public String getInputContent() {
		return inputContent;
	}

	public void setInputContent(String inputContent) {
		this.inputContent = inputContent;
	}

	@Column(name = "INPUT_VALUE")
	@Lob
	public String getInputValue() {
		return inputValue;
	}

	public void setInputValue(String inputValue) {
		this.inputValue = inputValue;
	}

	@Column(name = "PRINT_CONTENT")
	public String getPrintContent() {
		return printContent;
	}

	public void setPrintContent(String printContent) {
		this.printContent = printContent;
	}

	@Column(name = "BUNHO")
	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "CREATE_DATE")
	public String getCreateDate() {
		return createDate;
	}

	public void setCreateDate(String createDate) {
		this.createDate = createDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "PRINT_DATETIME")
	public Date getPrintDate() {
		return printDate;
	}

	public void setPrintDate(Date printDate) {
		this.printDate = printDate;
	}

	@Column(name = "FROM_DATE")
	public String getFromDate() {
		return fromDate;
	}

	public void setFromDate(String fromDate) {
		this.fromDate = fromDate;
	}

	@Column(name = "TO_DATE")
	public String getToDate() {
		return toDate;
	}

	public void setToDate(String toDate) {
		this.toDate = toDate;
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
	
}

package nta.med.data.model.ihis.ocso;

import java.math.BigInteger;

public class OCS4001U00LeftGrdViewInfo {
	private BigInteger        id        ;
	private String        createDate        ;
	private String        inputContent        ;
	private String        formName         ;
	private String        inputValue        ;
    private String        formatType        ;
    private String        printContent        ;
    private String        formCode        ;
	
	public OCS4001U00LeftGrdViewInfo(BigInteger id, String createDate, String inputContent, String formName,
			String inputValue, String formatType, String printContent, String formCode) {
		super();
		this.id = id;
		this.createDate = createDate;
		this.inputContent = inputContent;
		this.formName = formName;
		this.inputValue = inputValue;
		this.formatType = formatType;
		this.printContent = printContent;
		this.formCode = formCode;
	}
	public BigInteger getId() {
		return id;
	}
	public void setId(BigInteger id) {
		this.id = id;
	}
	public String getCreateDate() {
		return createDate;
	}
	public void setCreateDate(String createDate) {
		this.createDate = createDate;
	}
	public String getInputContent() {
		return inputContent;
	}
	public void setInputContent(String inputContent) {
		this.inputContent = inputContent;
	}
	public String getInputValue() {
		return inputValue;
	}
	public void setInputValue(String inputValue) {
		this.inputValue = inputValue;
	}
	public String getFormCode() {
		return formCode;
	}
	public void setFormCode(String formCode) {
		this.formCode = formCode;
	}
	public String getFormName() {
		return formName;
	}
	public void setFormName(String formName) {
		this.formName = formName;
	}
	public String getFormatType() {
		return formatType;
	}
	public void setFormatType(String formatType) {
		this.formatType = formatType;
	}
	public String getPrintContent() {
		return printContent;
	}
	public void setPrintContent(String printContent) {
		this.printContent = printContent;
	}
	
}

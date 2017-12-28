package nta.med.data.model.ihis.bass;

public class BAS0501U00CareFormTemplateInfo {
	private String tplName;
	private String formatType;
	private String inputContent;
	private String printContent;
	public BAS0501U00CareFormTemplateInfo(String tplName, String formatType, String inputContent, String printContent) {
		super();
		this.tplName = tplName;
		this.formatType = formatType;
		this.inputContent = inputContent;
		this.printContent = printContent;
	}
	public String getTplName() {
		return tplName;
	}
	public void setTplName(String tplName) {
		this.tplName = tplName;
	}
	public String getFormatType() {
		return formatType;
	}
	public void setFormatType(String formatType) {
		this.formatType = formatType;
	}
	public String getInputContent() {
		return inputContent;
	}
	public void setInputContent(String inputContent) {
		this.inputContent = inputContent;
	}
	public String getPrintContent() {
		return printContent;
	}
	public void setPrintContent(String printContent) {
		this.printContent = printContent;
	}
	
}

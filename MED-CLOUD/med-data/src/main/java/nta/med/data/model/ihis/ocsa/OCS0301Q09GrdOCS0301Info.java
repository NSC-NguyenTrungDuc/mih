package nta.med.data.model.ihis.ocsa;

public class OCS0301Q09GrdOCS0301Info {
	private String memb              ;
	private Double pkSeq            ;
	private String yaksokGubun      ;
	private String yaksokGubunName ;
	private String yaksokCode       ;
	private String yaksokName       ;
	private String inputTab         ;
	private String pkYaksok         ;
	private String inputTabName    ;
	public OCS0301Q09GrdOCS0301Info(String memb, Double pkSeq,
			String yaksokGubun, String yaksokGubunName, String yaksokCode,
			String yaksokName, String inputTab, String pkYaksok,
			String inputTabName) {
		super();
		this.memb = memb;
		this.pkSeq = pkSeq;
		this.yaksokGubun = yaksokGubun;
		this.yaksokGubunName = yaksokGubunName;
		this.yaksokCode = yaksokCode;
		this.yaksokName = yaksokName;
		this.inputTab = inputTab;
		this.pkYaksok = pkYaksok;
		this.inputTabName = inputTabName;
	}
	public String getMemb() {
		return memb;
	}
	public void setMemb(String memb) {
		this.memb = memb;
	}
	public Double getPkSeq() {
		return pkSeq;
	}
	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}
	public String getYaksokGubun() {
		return yaksokGubun;
	}
	public void setYaksokGubun(String yaksokGubun) {
		this.yaksokGubun = yaksokGubun;
	}
	public String getYaksokGubunName() {
		return yaksokGubunName;
	}
	public void setYaksokGubunName(String yaksokGubunName) {
		this.yaksokGubunName = yaksokGubunName;
	}
	public String getYaksokCode() {
		return yaksokCode;
	}
	public void setYaksokCode(String yaksokCode) {
		this.yaksokCode = yaksokCode;
	}
	public String getYaksokName() {
		return yaksokName;
	}
	public void setYaksokName(String yaksokName) {
		this.yaksokName = yaksokName;
	}
	public String getInputTab() {
		return inputTab;
	}
	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}
	public String getPkYaksok() {
		return pkYaksok;
	}
	public void setPkYaksok(String pkYaksok) {
		this.pkYaksok = pkYaksok;
	}
	public String getInputTabName() {
		return inputTabName;
	}
	public void setInputTabName(String inputTabName) {
		this.inputTabName = inputTabName;
	}
	

}

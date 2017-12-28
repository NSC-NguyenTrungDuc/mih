package nta.med.data.model.ihis.system;

public class OFMakeTreeViewInfo {
	private String memb               ;
	private Double pkSeq             ;
	private String yaksokGubun       ;
	private String yaksokGubunName  ;
	private Double seq                ;
	private String membGubun         ;
	private String inputTab          ;
	private String existData         ;
	public OFMakeTreeViewInfo(String memb, Double pkSeq, String yaksokGubun,
			String yaksokGubunName, Double seq, String membGubun,
			String inputTab, String existData) {
		super();
		this.memb = memb;
		this.pkSeq = pkSeq;
		this.yaksokGubun = yaksokGubun;
		this.yaksokGubunName = yaksokGubunName;
		this.seq = seq;
		this.membGubun = membGubun;
		this.inputTab = inputTab;
		this.existData = existData;
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
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public String getMembGubun() {
		return membGubun;
	}
	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}
	public String getInputTab() {
		return inputTab;
	}
	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}
	public String getExistData() {
		return existData;
	}
	public void setExistData(String existData) {
		this.existData = existData;
	}

}

package nta.med.data.model.ihis.nuri;

public class NUR1001U00GrdINP1001Info {
	private String bunho;
	private String ipwonDate;
	private String toiwonDate;
	private String jaewonFlag;
	private Double pkinp1001;
	private String hoDong;
	private String dataRowState;
	
	public NUR1001U00GrdINP1001Info(String bunho, String ipwonDate, String toiwonDate, String jaewonFlag,
			Double pkinp1001, String hoDong, String dataRowState) {
		super();
		this.bunho = bunho;
		this.ipwonDate = ipwonDate;
		this.toiwonDate = toiwonDate;
		this.jaewonFlag = jaewonFlag;
		this.pkinp1001 = pkinp1001;
		this.hoDong = hoDong;
		this.dataRowState = dataRowState;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(String ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public String getToiwonDate() {
		return toiwonDate;
	}

	public void setToiwonDate(String toiwonDate) {
		this.toiwonDate = toiwonDate;
	}

	public String getJaewonFlag() {
		return jaewonFlag;
	}

	public void setJaewonFlag(String jaewonFlag) {
		this.jaewonFlag = jaewonFlag;
	}

	public Double getPkinp1001() {
		return pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}

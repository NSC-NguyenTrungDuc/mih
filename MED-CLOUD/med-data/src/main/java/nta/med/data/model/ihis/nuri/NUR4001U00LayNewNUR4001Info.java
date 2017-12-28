package nta.med.data.model.ihis.nuri;

public class NUR4001U00LayNewNUR4001Info {
	private Double pknur4001;
	private String jinName;
	private String sortKey;
	
	public NUR4001U00LayNewNUR4001Info(Double pknur4001, String jinName, String sortKey) {
		super();
		this.pknur4001 = pknur4001;
		this.jinName = jinName;
		this.sortKey = sortKey;
	}

	public Double getPknur4001() {
		return pknur4001;
	}

	public void setPknur4001(Double pknur4001) {
		this.pknur4001 = pknur4001;
	}

	public String getJinName() {
		return jinName;
	}

	public void setJinName(String jinName) {
		this.jinName = jinName;
	}

	public String getSortKey() {
		return sortKey;
	}

	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}

}

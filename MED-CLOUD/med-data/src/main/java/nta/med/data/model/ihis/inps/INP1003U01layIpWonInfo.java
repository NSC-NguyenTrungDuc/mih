package nta.med.data.model.ihis.inps;

public class INP1003U01layIpWonInfo {
	
	private String ipwonMokjuk;
	private String ipwonsiOrderYn;
	
	public INP1003U01layIpWonInfo(String ipwonMokjuk, String ipwonsiOrderYn){
		this.ipwonMokjuk = ipwonMokjuk;
		this.ipwonsiOrderYn = ipwonsiOrderYn;
	}

	public String getIpwonMokjuk() {
		return ipwonMokjuk;
	}

	public void setIpwonMokjuk(String ipwonMokjuk) {
		this.ipwonMokjuk = ipwonMokjuk;
	}

	public String getIpwonsiOrderYn() {
		return ipwonsiOrderYn;
	}

	public void setIpwonsiOrderYn(String ipwonsiOrderYn) {
		this.ipwonsiOrderYn = ipwonsiOrderYn;
	}
	
	
	
}

package nta.med.data.model.ihis.nuri;

public class NUR9001U00layBojoListInfo {
	private String soapBun1;
	private String soapBun1Name;
	private String soapBun2;
	private String soapBun2Name;
	private String sortKey;
	private String sortKey2;
	
	public NUR9001U00layBojoListInfo(String soapBun1, String soapBun1Name, String soapBun2, String soapBun2Name,
			String sortKey, String sortKey2) {
		super();
		this.soapBun1 = soapBun1;
		this.soapBun1Name = soapBun1Name;
		this.soapBun2 = soapBun2;
		this.soapBun2Name = soapBun2Name;
		this.sortKey = sortKey;
		this.sortKey2 = sortKey2;
	}

	public String getSoapBun1() {
		return soapBun1;
	}

	public void setSoapBun1(String soapBun1) {
		this.soapBun1 = soapBun1;
	}

	public String getSoapBun1Name() {
		return soapBun1Name;
	}

	public void setSoapBun1Name(String soapBun1Name) {
		this.soapBun1Name = soapBun1Name;
	}

	public String getSoapBun2() {
		return soapBun2;
	}

	public void setSoapBun2(String soapBun2) {
		this.soapBun2 = soapBun2;
	}

	public String getSoapBun2Name() {
		return soapBun2Name;
	}

	public void setSoapBun2Name(String soapBun2Name) {
		this.soapBun2Name = soapBun2Name;
	}

	public String getSortKey() {
		return sortKey;
	}

	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}

	public String getSortKey2() {
		return sortKey2;
	}

	public void setSortKey2(String sortKey2) {
		this.sortKey2 = sortKey2;
	}
	
}

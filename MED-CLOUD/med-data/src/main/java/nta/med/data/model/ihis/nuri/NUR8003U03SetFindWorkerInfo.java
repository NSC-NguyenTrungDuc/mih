package nta.med.data.model.ihis.nuri;

public class NUR8003U03SetFindWorkerInfo {

	private String smCode;
	private String smDetail;
	private String smPoint;

	public NUR8003U03SetFindWorkerInfo(String smCode, String smDetail, String smPoint) {
		super();
		this.smCode = smCode;
		this.smDetail = smDetail;
		this.smPoint = smPoint;
	}

	public String getSmCode() {
		return smCode;
	}

	public void setSmCode(String smCode) {
		this.smCode = smCode;
	}

	public String getSmDetail() {
		return smDetail;
	}

	public void setSmDetail(String smDetail) {
		this.smDetail = smDetail;
	}

	public String getSmPoint() {
		return smPoint;
	}

	public void setSmPoint(String smPoint) {
		this.smPoint = smPoint;
	}

}

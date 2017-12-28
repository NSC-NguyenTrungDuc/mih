package nta.med.data.model.ihis.nuri;

public class NUR8003U03CopyDataInfo {

	private String firstGubun;
	private String grCode;
	private String rsCode;
	private String smCode;
	private String smDetail;
	private String nurPoint;
	private String newSmCode;
	private String newSmDetail;
	private String newNurPoint;

	public NUR8003U03CopyDataInfo(String firstGubun, String grCode, String rsCode, String smCode, String smDetail,
			String nurPoint, String newSmCode, String newSmDetail, String newNurPoint) {
		super();
		this.firstGubun = firstGubun;
		this.grCode = grCode;
		this.rsCode = rsCode;
		this.smCode = smCode;
		this.smDetail = smDetail;
		this.nurPoint = nurPoint;
		this.newSmCode = newSmCode;
		this.newSmDetail = newSmDetail;
		this.newNurPoint = newNurPoint;
	}

	public String getFirstGubun() {
		return firstGubun;
	}

	public void setFirstGubun(String firstGubun) {
		this.firstGubun = firstGubun;
	}

	public String getGrCode() {
		return grCode;
	}

	public void setGrCode(String grCode) {
		this.grCode = grCode;
	}

	public String getRsCode() {
		return rsCode;
	}

	public void setRsCode(String rsCode) {
		this.rsCode = rsCode;
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

	public String getNurPoint() {
		return nurPoint;
	}

	public void setNurPoint(String nurPoint) {
		this.nurPoint = nurPoint;
	}

	public String getNewSmCode() {
		return newSmCode;
	}

	public void setNewSmCode(String newSmCode) {
		this.newSmCode = newSmCode;
	}

	public String getNewSmDetail() {
		return newSmDetail;
	}

	public void setNewSmDetail(String newSmDetail) {
		this.newSmDetail = newSmDetail;
	}

	public String getNewNurPoint() {
		return newNurPoint;
	}

	public void setNewNurPoint(String newNurPoint) {
		this.newNurPoint = newNurPoint;
	}

}

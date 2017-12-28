package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR8003U03GrdAInfo {
	private String firstGubun;
	private String grCode;
	private String grName;
	private String rsCode;
	private String rsName;
	private String smCode;
	private String smDetail;
	private Double nurPoint;
	private String newSmCode;
	private String newSmDetail;
	private Double newNurPoint;
	private Double sortKey;
	private String sumGubun;
	private String globalYn;
	private Date writeDate;

	public NUR8003U03GrdAInfo(String firstGubun, String grCode, String grName, String rsCode, String rsName,
			String smCode, String smDetail, Double nurPoint, String newSmCode, String newSmDetail, Double newNurPoint,
			Double sortKey, String sumGubun, String globalYn, Date writeDate) {
		super();
		this.firstGubun = firstGubun;
		this.grCode = grCode;
		this.grName = grName;
		this.rsCode = rsCode;
		this.rsName = rsName;
		this.smCode = smCode;
		this.smDetail = smDetail;
		this.nurPoint = nurPoint;
		this.newSmCode = newSmCode;
		this.newSmDetail = newSmDetail;
		this.newNurPoint = newNurPoint;
		this.sortKey = sortKey;
		this.sumGubun = sumGubun;
		this.globalYn = globalYn;
		this.writeDate = writeDate;
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

	public String getGrName() {
		return grName;
	}

	public void setGrName(String grName) {
		this.grName = grName;
	}

	public String getRsCode() {
		return rsCode;
	}

	public void setRsCode(String rsCode) {
		this.rsCode = rsCode;
	}

	public String getRsName() {
		return rsName;
	}

	public void setRsName(String rsName) {
		this.rsName = rsName;
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

	public Double getNurPoint() {
		return nurPoint;
	}

	public void setNurPoint(Double nurPoint) {
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

	public Double getNewNurPoint() {
		return newNurPoint;
	}

	public void setNewNurPoint(Double newNurPoint) {
		this.newNurPoint = newNurPoint;
	}

	public Double getSortKey() {
		return sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

	public String getSumGubun() {
		return sumGubun;
	}

	public void setSumGubun(String sumGubun) {
		this.sumGubun = sumGubun;
	}

	public String getGlobalYn() {
		return globalYn;
	}

	public void setGlobalYn(String globalYn) {
		this.globalYn = globalYn;
	}

	public Date getWriteDate() {
		return writeDate;
	}

	public void setWriteDate(Date writeDate) {
		this.writeDate = writeDate;
	}

}

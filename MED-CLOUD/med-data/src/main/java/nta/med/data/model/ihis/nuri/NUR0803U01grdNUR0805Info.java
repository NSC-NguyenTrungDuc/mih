package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR0803U01grdNUR0805Info {

	private String needGubun;
	private String needAsmtCode;
	private String needResultCode;
	private String needSoCode;
	private String needSoName;
	private Double needSoPoint;
	private Double sortKey;
	private Date startDate;
	private String hFileFlag;

	public NUR0803U01grdNUR0805Info(String needGubun, String needAsmtCode, String needResultCode, String needSoCode,
			String needSoName, Double needSoPoint, Double sortKey, Date startDate, String hFileFlag) {
		super();
		this.needGubun = needGubun;
		this.needAsmtCode = needAsmtCode;
		this.needResultCode = needResultCode;
		this.needSoCode = needSoCode;
		this.needSoName = needSoName;
		this.needSoPoint = needSoPoint;
		this.sortKey = sortKey;
		this.startDate = startDate;
		this.hFileFlag = hFileFlag;
	}

	public String getNeedGubun() {
		return needGubun;
	}

	public void setNeedGubun(String needGubun) {
		this.needGubun = needGubun;
	}

	public String getNeedAsmtCode() {
		return needAsmtCode;
	}

	public void setNeedAsmtCode(String needAsmtCode) {
		this.needAsmtCode = needAsmtCode;
	}

	public String getNeedResultCode() {
		return needResultCode;
	}

	public void setNeedResultCode(String needResultCode) {
		this.needResultCode = needResultCode;
	}

	public String getNeedSoCode() {
		return needSoCode;
	}

	public void setNeedSoCode(String needSoCode) {
		this.needSoCode = needSoCode;
	}

	public String getNeedSoName() {
		return needSoName;
	}

	public void setNeedSoName(String needSoName) {
		this.needSoName = needSoName;
	}

	public Double getNeedSoPoint() {
		return needSoPoint;
	}

	public void setNeedSoPoint(Double needSoPoint) {
		this.needSoPoint = needSoPoint;
	}

	public Double getSortKey() {
		return sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public String gethFileFlag() {
		return hFileFlag;
	}

	public void sethFileFlag(String hFileFlag) {
		this.hFileFlag = hFileFlag;
	}

}

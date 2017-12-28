package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR0803U01grdNUR0804Info {

	private String needGubun;
	private String needAsmtCode;
	private String needResultCode;
	private String needResultName;
	private String sumGubun;
	private Double sortKey;
	private String globalYn;
	private Date startDate;
	// private String needResultPoint;

	public NUR0803U01grdNUR0804Info(String needGubun, String needAsmtCode, String needResultCode, String needResultName,
			String sumGubun, Double sortKey, String globalYn, Date startDate) {
		super();
		this.needGubun = needGubun;
		this.needAsmtCode = needAsmtCode;
		this.needResultCode = needResultCode;
		this.needResultName = needResultName;
		this.sumGubun = sumGubun;
		this.sortKey = sortKey;
		this.globalYn = globalYn;
		this.startDate = startDate;
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

	public String getNeedResultName() {
		return needResultName;
	}

	public void setNeedResultName(String needResultName) {
		this.needResultName = needResultName;
	}

	public String getSumGubun() {
		return sumGubun;
	}

	public void setSumGubun(String sumGubun) {
		this.sumGubun = sumGubun;
	}

	public Double getSortKey() {
		return sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

	public String getGlobalYn() {
		return globalYn;
	}

	public void setGlobalYn(String globalYn) {
		this.globalYn = globalYn;
	}

	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

}

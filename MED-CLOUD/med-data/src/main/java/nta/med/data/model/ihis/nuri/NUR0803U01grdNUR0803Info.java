package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR0803U01grdNUR0803Info {
	private String needGubun;
	private String needAsmtCode;
	private Date startDate;
	private Date endDate;
	private String needAsmtName;
	private Double sortKey;
	private String globalYn;

	public NUR0803U01grdNUR0803Info(String needGubun, String needAsmtCode, Date startDate, Date endDate,
			String needAsmtName, Double sortKey, String globalYn) {
		super();
		this.needGubun = needGubun;
		this.needAsmtCode = needAsmtCode;
		this.startDate = startDate;
		this.endDate = endDate;
		this.needAsmtName = needAsmtName;
		this.sortKey = sortKey;
		this.globalYn = globalYn;
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

	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public Date getEndDate() {
		return endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getNeedAsmtName() {
		return needAsmtName;
	}

	public void setNeedAsmtName(String needAsmtName) {
		this.needAsmtName = needAsmtName;
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

}

package nta.med.data.model.ihis.chts;

import java.io.Serializable;
import java.util.Date;

public class CHT0117GrdCHT0117InitListItemInfo implements Serializable{
	private Date startDate;
	private Date endDate;
	private String buwi;
	private String buwiName;
	private Double sortKey;
	private String remark;
	private String contKey;
	private String rowState;

	public CHT0117GrdCHT0117InitListItemInfo(Date startDate, Date endDate,
			String buwi, String buwiName, Double sortKey, String remark,
			String contKey, String rowState) {
		super();
		this.startDate = startDate;
		this.endDate = endDate;
		this.buwi = buwi;
		this.buwiName = buwiName;
		this.sortKey = sortKey;
		this.remark = remark;
		this.contKey = contKey;
		this.rowState = rowState;
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

	public String getBuwi() {
		return buwi;
	}

	public void setBuwi(String buwi) {
		this.buwi = buwi;
	}

	public String getBuwiName() {
		return buwiName;
	}

	public void setBuwiName(String buwiName) {
		this.buwiName = buwiName;
	}

	public Double getSortKey() {
		return sortKey;
	}

	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	public String getContKey() {
		return contKey;
	}

	public void setContKey(String contKey) {
		this.contKey = contKey;
	}

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}

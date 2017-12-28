package nta.med.data.model.ihis.chts;

import java.io.Serializable;
import java.util.Date;

public class CHT0117GrdCHT0118InitListItemInfo implements Serializable{
	private Date startDate;
	private Date endDate;
	private String buwi;
	private String subBuwi;
	private String subBuwiName;
	private Double sortKey;
	private String remark;
	private String contKey;
	private String nosaiJyRate;
	private String rowState;

	public CHT0117GrdCHT0118InitListItemInfo(Date startDate, Date endDate,
			String buwi, String subBuwi, String subBuwiName, Double sortKey,
			String remark, String contKey, String nosaiJyRate, String rowState) {
		super();
		this.startDate = startDate;
		this.endDate = endDate;
		this.buwi = buwi;
		this.subBuwi = subBuwi;
		this.subBuwiName = subBuwiName;
		this.sortKey = sortKey;
		this.remark = remark;
		this.contKey = contKey;
		this.nosaiJyRate = nosaiJyRate;
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

	public String getSubBuwi() {
		return subBuwi;
	}

	public void setSubBuwi(String subBuwi) {
		this.subBuwi = subBuwi;
	}

	public String getSubBuwiName() {
		return subBuwiName;
	}

	public void setSubBuwiName(String subBuwiName) {
		this.subBuwiName = subBuwiName;
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

	public String getNosaiJyRate() {
		return nosaiJyRate;
	}

	public void setNosaiJyRate(String nosaiJyRate) {
		this.nosaiJyRate = nosaiJyRate;
	}

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}

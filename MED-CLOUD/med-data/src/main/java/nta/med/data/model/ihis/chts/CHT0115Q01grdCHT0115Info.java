package nta.med.data.model.ihis.chts;

import java.io.Serializable;
import java.util.Date;

public class CHT0115Q01grdCHT0115Info implements Serializable {
	private String susikCode;
	private String susikName;
	private String susikNameGana;
	private Date susikCrDate;
	private Date susikUpdDate;
	private Date susikDisableDate;
	private String susikGwanriNo;
	private String susikGubun;
	private String susikChangeCode;
	private String susikDetailGubun;
	private Date startDate;
	private Date endDate;
	private Double sort;
	private String rowState;

	public CHT0115Q01grdCHT0115Info(String susikCode, String susikName,
			String susikNameGana, Date susikCrDate, Date susikUpdDate,
			Date susikDisableDate, String susikGwanriNo, String susikGubun,
			String susikChangeCode, String susikDetailGubun, Date startDate,
			Date endDate, Double sort, String rowState) {
		super();
		this.susikCode = susikCode;
		this.susikName = susikName;
		this.susikNameGana = susikNameGana;
		this.susikCrDate = susikCrDate;
		this.susikUpdDate = susikUpdDate;
		this.susikDisableDate = susikDisableDate;
		this.susikGwanriNo = susikGwanriNo;
		this.susikGubun = susikGubun;
		this.susikChangeCode = susikChangeCode;
		this.susikDetailGubun = susikDetailGubun;
		this.startDate = startDate;
		this.endDate = endDate;
		this.sort = sort;
		this.rowState = rowState;
	}

	public String getSusikCode() {
		return susikCode;
	}

	public void setSusikCode(String susikCode) {
		this.susikCode = susikCode;
	}

	public String getSusikName() {
		return susikName;
	}

	public void setSusikName(String susikName) {
		this.susikName = susikName;
	}

	public String getSusikNameGana() {
		return susikNameGana;
	}

	public void setSusikNameGana(String susikNameGana) {
		this.susikNameGana = susikNameGana;
	}

	public Date getSusikCrDate() {
		return susikCrDate;
	}

	public void setSusikCrDate(Date susikCrDate) {
		this.susikCrDate = susikCrDate;
	}

	public Date getSusikUpdDate() {
		return susikUpdDate;
	}

	public void setSusikUpdDate(Date susikUpdDate) {
		this.susikUpdDate = susikUpdDate;
	}

	public Date getSusikDisableDate() {
		return susikDisableDate;
	}

	public void setSusikDisableDate(Date susikDisableDate) {
		this.susikDisableDate = susikDisableDate;
	}

	public String getSusikGwanriNo() {
		return susikGwanriNo;
	}

	public void setSusikGwanriNo(String susikGwanriNo) {
		this.susikGwanriNo = susikGwanriNo;
	}

	public String getSusikGubun() {
		return susikGubun;
	}

	public void setSusikGubun(String susikGubun) {
		this.susikGubun = susikGubun;
	}

	public String getSusikChangeCode() {
		return susikChangeCode;
	}

	public void setSusikChangeCode(String susikChangeCode) {
		this.susikChangeCode = susikChangeCode;
	}

	public String getSusikDetailGubun() {
		return susikDetailGubun;
	}

	public void setSusikDetailGubun(String susikDetailGubun) {
		this.susikDetailGubun = susikDetailGubun;
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

	public Double getSort() {
		return sort;
	}

	public void setSort(Double sort) {
		this.sort = sort;
	}

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}

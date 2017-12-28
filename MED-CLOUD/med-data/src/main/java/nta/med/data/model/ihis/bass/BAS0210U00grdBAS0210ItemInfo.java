package nta.med.data.model.ihis.bass;

import java.io.Serializable;
import java.util.Date;

public class BAS0210U00grdBAS0210ItemInfo implements Serializable {
	private String gubun;
	private String gubunName;
	private String retrieveYn;
	private Date startDate;
	private Date endDate;
	private String johapGubun;
	private String johapName;
	private String gonbiYn;
	public BAS0210U00grdBAS0210ItemInfo(String gubun, String gubunName,
			String retrieveYn, Date startDate, Date endDate, String johapGubun,
			String johapName, String gonbiYn) {
		super();
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.retrieveYn = retrieveYn;
		this.startDate = startDate;
		this.endDate = endDate;
		this.johapGubun = johapGubun;
		this.johapName = johapName;
		this.gonbiYn = gonbiYn;
	}
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}
	public String getGubunName() {
		return gubunName;
	}
	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}
	public String getRetrieveYn() {
		return retrieveYn;
	}
	public void setRetrieveYn(String retrieveYn) {
		this.retrieveYn = retrieveYn;
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
	public String getJohapGubun() {
		return johapGubun;
	}
	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}
	public String getJohapName() {
		return johapName;
	}
	public void setJohapName(String johapName) {
		this.johapName = johapName;
	}
	public String getGonbiYn() {
		return gonbiYn;
	}
	public void setGonbiYn(String gonbiYn) {
		this.gonbiYn = gonbiYn;
	}
}

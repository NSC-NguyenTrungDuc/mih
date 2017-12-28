package nta.med.data.model.ihis.inps;

import java.util.Date;

public class INPORDERTRANSGrdSiksaInfo {
	private Double pkocs ;
	private Double fkinp1001 ;
	private String groupInp1001 ;
	private Date orderDate ;
	private Date drtDate ;
	private String timeGubun1 ;
	private String timeGubun2 ;
	private String timeGubun3 ;
	private String selectYn ;
	public INPORDERTRANSGrdSiksaInfo(Double pkocs, Double fkinp1001, String groupInp1001, Date orderDate, Date drtDate,
			String timeGubun1, String timeGubun2, String timeGubun3, String selectYn) {
		super();
		this.pkocs = pkocs;
		this.fkinp1001 = fkinp1001;
		this.groupInp1001 = groupInp1001;
		this.orderDate = orderDate;
		this.drtDate = drtDate;
		this.timeGubun1 = timeGubun1;
		this.timeGubun2 = timeGubun2;
		this.timeGubun3 = timeGubun3;
		this.selectYn = selectYn;
	}
	public Double getPkocs() {
		return pkocs;
	}
	public void setPkocs(Double pkocs) {
		this.pkocs = pkocs;
	}
	public Double getFkinp1001() {
		return fkinp1001;
	}
	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}
	public String getGroupInp1001() {
		return groupInp1001;
	}
	public void setGroupInp1001(String groupInp1001) {
		this.groupInp1001 = groupInp1001;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public Date getDrtDate() {
		return drtDate;
	}
	public void setDrtDate(Date drtDate) {
		this.drtDate = drtDate;
	}
	public String getTimeGubun1() {
		return timeGubun1;
	}
	public void setTimeGubun1(String timeGubun1) {
		this.timeGubun1 = timeGubun1;
	}
	public String getTimeGubun2() {
		return timeGubun2;
	}
	public void setTimeGubun2(String timeGubun2) {
		this.timeGubun2 = timeGubun2;
	}
	public String getTimeGubun3() {
		return timeGubun3;
	}
	public void setTimeGubun3(String timeGubun3) {
		this.timeGubun3 = timeGubun3;
	}
	public String getSelectYn() {
		return selectYn;
	}
	public void setSelectYn(String selectYn) {
		this.selectYn = selectYn;
	}
	
}

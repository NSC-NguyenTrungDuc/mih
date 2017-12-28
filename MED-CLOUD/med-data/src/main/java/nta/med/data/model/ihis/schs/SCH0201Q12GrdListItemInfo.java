package nta.med.data.model.ihis.schs;

import java.util.Date;

public class SCH0201Q12GrdListItemInfo {
	  private Date kizyunDate ;
      private String gwa ;
      private String gwaName;
      private String doctor;
      private String doctorName;
      private String hangmogCode;
      private String hangmogName;
      private String jundalTable;
      private String jundalPart ;
      private String jundalPartName;
      private String reserTime;
      private String reserYn;
      private String actYn;
      private Date orderDate;
      private Double pksch;
      
      
	public SCH0201Q12GrdListItemInfo(Date kizyunDate,
			String gwa, String gwaName, String doctor, String doctorName,
			String hangmogCode, String hangmogName, String jundalTable,
			String jundalPart, String jundalPartName, String reserTime,
			String reserYn, String actYn, Date orderDate, Double pksch) {
		super();
		this.kizyunDate = kizyunDate;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.jundalPartName = jundalPartName;
		this.reserTime = reserTime;
		this.reserYn = reserYn;
		this.actYn = actYn;
		this.orderDate = orderDate;
		this.pksch = pksch;
	}
	
	public Date getKizyunDate() {
		return kizyunDate;
	}
	public void setKizyunDate(Date kizyunDate) {
		this.kizyunDate = kizyunDate;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getJundalTable() {
		return jundalTable;
	}
	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getJundalPartName() {
		return jundalPartName;
	}
	public void setJundalPartName(String jundalPartName) {
		this.jundalPartName = jundalPartName;
	}
	public String getReserTime() {
		return reserTime;
	}
	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}
	public String getActYn() {
		return actYn;
	}
	public void setActYn(String actYn) {
		this.actYn = actYn;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}
	public Double getPksch() {
		return pksch;
	}
	public void setPksch(Double pksch) {
		this.pksch = pksch;
	}
      
      
	
	
}

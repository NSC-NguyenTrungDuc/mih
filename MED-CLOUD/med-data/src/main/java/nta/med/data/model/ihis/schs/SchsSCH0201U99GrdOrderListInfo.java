package nta.med.data.model.ihis.schs;

import java.util.Date;

public class SchsSCH0201U99GrdOrderListInfo {
	private String hangmogCode;
	private String hangmogName;
	private String jundalTable;
	private String jundalPart;
	private String jundalPartName;
	private Double pksch0201;
	private String bunho;
	private String suname;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private Date orderDate;
	private String emergency;
	private Date reserDate;
	private String reserTime;
	private String orderRemark;
	private String reserYn;
	private Double pkout1001;
	private String groupSer;
	private String outHospCode;
	private Double pksch0201Out;

	public SchsSCH0201U99GrdOrderListInfo(String hangmogCode,
			String hangmogName, String jundalTable, String jundalPart,
			String jundalPartName, Double pksch0201, String bunho,
			String suname, String gwa, String gwaName, String doctor,
			String doctorName, Date orderDate, String emergency,
			Date reserDate, String reserTime, String orderRemark,
			String reserYn, Double pkout1001, String groupSer, String outHospCode, Double pksch0201Out) {
		super();
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.jundalTable = jundalTable;
		this.jundalPart = jundalPart;
		this.jundalPartName = jundalPartName;
		this.pksch0201 = pksch0201;
		this.bunho = bunho;
		this.suname = suname;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.orderDate = orderDate;
		this.emergency = emergency;
		this.reserDate = reserDate;
		this.reserTime = reserTime;
		this.orderRemark = orderRemark;
		this.reserYn = reserYn;
		this.pkout1001 = pkout1001;
		this.groupSer = groupSer;
		this.outHospCode = outHospCode;
		this.pksch0201Out = pksch0201Out;
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

	public Double getPksch0201() {
		return pksch0201;
	}

	public void setPksch0201(Double pksch0201) {
		this.pksch0201 = pksch0201;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
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

	public Date getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	public String getEmergency() {
		return emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	public Date getReserDate() {
		return reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}

	public String getReserTime() {
		return reserTime;
	}

	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}

	public String getOrderRemark() {
		return orderRemark;
	}

	public void setOrderRemark(String orderRemark) {
		this.orderRemark = orderRemark;
	}

	public String getReserYn() {
		return reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}

	public Double getPkout1001() {
		return pkout1001;
	}

	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}

	public String getGroupSer() {
		return groupSer;
	}

	public void setGroupSer(String groupSer) {
		this.groupSer = groupSer;
	}

	public String getOutHospCode() {
		return outHospCode;
	}

	public void setOutHospCode(String outHospCode) {
		this.outHospCode = outHospCode;
	}

	public Double getPksch0201Out() {
		return pksch0201Out;
	}

	public void setPksch0201Out(Double pksch0201Out) {
		this.pksch0201Out = pksch0201Out;
	}
}

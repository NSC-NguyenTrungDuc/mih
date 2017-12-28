package nta.med.data.model.ihis.cpls;

import java.util.Date;

public class CPL2010R02grdOrderListInfo {
	private String hospCode ;
    private String inOutGubun ;
    private String bunho ;
    private Double pkocs1003 ;
    private Date orderDate ;
    private String hangmogCode ;
    private String hangmogName ;
    private String jundalPart ;
    private String slipCode ;
    private Double fkout1001 ;
    private String specimenCode ;
    private String gwa ;
    private String doctor ;
    private String gwaName ;
    private String doctorName ;
	public CPL2010R02grdOrderListInfo(String hospCode, String inOutGubun, String bunho, Double pkocs1003,
			Date orderDate, String hangmogCode, String hangmogName, String jundalPart, String slipCode,
			Double fkout1001, String specimenCode, String gwa, String doctor, String gwaName, String doctorName) {
		super();
		this.hospCode = hospCode;
		this.inOutGubun = inOutGubun;
		this.bunho = bunho;
		this.pkocs1003 = pkocs1003;
		this.orderDate = orderDate;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.jundalPart = jundalPart;
		this.slipCode = slipCode;
		this.fkout1001 = fkout1001;
		this.specimenCode = specimenCode;
		this.gwa = gwa;
		this.doctor = doctor;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Double getPkocs1003() {
		return pkocs1003;
	}
	public void setPkocs1003(Double pkocs1003) {
		this.pkocs1003 = pkocs1003;
	}
	public Date getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
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
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getSlipCode() {
		return slipCode;
	}
	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}
	public Double getFkout1001() {
		return fkout1001;
	}
	public void setFkout1001(Double fkout1001) {
		this.fkout1001 = fkout1001;
	}
	public String getSpecimenCode() {
		return specimenCode;
	}
	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
    
}

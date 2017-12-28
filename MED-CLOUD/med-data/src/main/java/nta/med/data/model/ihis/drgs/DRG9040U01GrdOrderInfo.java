package nta.med.data.model.ihis.drgs;

import java.sql.Date;
import java.sql.Timestamp;

public class DRG9040U01GrdOrderInfo {
	private Timestamp jubsuDate;
    private Double drgBunho;
    private String bunho;
    private Timestamp orderDate;
    private String doctor;
    private String doctorName;
    private String gwa;
    private String buseoName;
    private String orderRemark;
    private String drgRemark;
    private String magamGubun;
    private String bunryu1;
	public DRG9040U01GrdOrderInfo(Timestamp jubsuDate, Double drgBunho,
			String bunho, Timestamp orderDate, String doctor, String doctorName,
			String gwa, String buseoName, String orderRemark, String drgRemark,
			String magamGubun, String bunryu1) {
		super();
		this.jubsuDate = jubsuDate;
		this.drgBunho = drgBunho;
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.gwa = gwa;
		this.buseoName = buseoName;
		this.orderRemark = orderRemark;
		this.drgRemark = drgRemark;
		this.magamGubun = magamGubun;
		this.bunryu1 = bunryu1;
	}
	public Timestamp getJubsuDate() {
		return jubsuDate;
	}
	public void setJubsuDate(Timestamp jubsuDate) {
		this.jubsuDate = jubsuDate;
	}
	public Double getDrgBunho() {
		return drgBunho;
	}
	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Timestamp getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Timestamp orderDate) {
		this.orderDate = orderDate;
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
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getBuseoName() {
		return buseoName;
	}
	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}
	public String getOrderRemark() {
		return orderRemark;
	}
	public void setOrderRemark(String orderRemark) {
		this.orderRemark = orderRemark;
	}
	public String getDrgRemark() {
		return drgRemark;
	}
	public void setDrgRemark(String drgRemark) {
		this.drgRemark = drgRemark;
	}
	public String getMagamGubun() {
		return magamGubun;
	}
	public void setMagamGubun(String magamGubun) {
		this.magamGubun = magamGubun;
	}
	public String getBunryu1() {
		return bunryu1;
	}
	public void setBunryu1(String bunryu1) {
		this.bunryu1 = bunryu1;
	}    
}

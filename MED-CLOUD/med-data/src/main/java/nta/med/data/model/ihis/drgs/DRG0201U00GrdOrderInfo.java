package nta.med.data.model.ihis.drgs;

import java.sql.Timestamp;

public class DRG0201U00GrdOrderInfo {
	private Double drgBunho;
	private String bunho;
	private Timestamp orderDate;
	private Timestamp jubsuDate;
	private Timestamp drgJubsuDate;
	private String jubsuTime;
	private String doctor;
	private String doctorName;
	private String gwa;
	private String buseoName;
	private Timestamp actDate;
	private Timestamp actTime;
	private String actYn;
	private Timestamp sunabDate;
	private Timestamp chulgoDate;
	private String actUserName;
	private String wonyoiOrderYn;
	private String disGubun;
	private String orderRemark;
	private String drgRemark;
	private Double fkout1001;
	private String ifDataSendYn;
	public DRG0201U00GrdOrderInfo(Double drgBunho, String bunho, Timestamp orderDate, Timestamp jubsuDate,
			Timestamp drgJubsuDate, String jubsuTime, String doctor, String doctorName, String gwa, String buseoName,
			Timestamp actDate, Timestamp actTime, String actYn, Timestamp sunabDate, Timestamp chulgoDate,
			String actUserName, String wonyoiOrderYn, String disGubun, String orderRemark, String drgRemark,
			Double fkout1001, String ifDataSendYn) {
		super();
		this.drgBunho = drgBunho;
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.jubsuDate = jubsuDate;
		this.drgJubsuDate = drgJubsuDate;
		this.jubsuTime = jubsuTime;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.gwa = gwa;
		this.buseoName = buseoName;
		this.actDate = actDate;
		this.actTime = actTime;
		this.actYn = actYn;
		this.sunabDate = sunabDate;
		this.chulgoDate = chulgoDate;
		this.actUserName = actUserName;
		this.wonyoiOrderYn = wonyoiOrderYn;
		this.disGubun = disGubun;
		this.orderRemark = orderRemark;
		this.drgRemark = drgRemark;
		this.fkout1001 = fkout1001;
		this.ifDataSendYn = ifDataSendYn;
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
	public Timestamp getJubsuDate() {
		return jubsuDate;
	}
	public void setJubsuDate(Timestamp jubsuDate) {
		this.jubsuDate = jubsuDate;
	}
	public Timestamp getDrgJubsuDate() {
		return drgJubsuDate;
	}
	public void setDrgJubsuDate(Timestamp drgJubsuDate) {
		this.drgJubsuDate = drgJubsuDate;
	}
	public String getJubsuTime() {
		return jubsuTime;
	}
	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
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
	public Timestamp getActDate() {
		return actDate;
	}
	public void setActDate(Timestamp actDate) {
		this.actDate = actDate;
	}
	public Timestamp getActTime() {
		return actTime;
	}
	public void setActTime(Timestamp actTime) {
		this.actTime = actTime;
	}
	public String getActYn() {
		return actYn;
	}
	public void setActYn(String actYn) {
		this.actYn = actYn;
	}
	public Timestamp getSunabDate() {
		return sunabDate;
	}
	public void setSunabDate(Timestamp sunabDate) {
		this.sunabDate = sunabDate;
	}
	public Timestamp getChulgoDate() {
		return chulgoDate;
	}
	public void setChulgoDate(Timestamp chulgoDate) {
		this.chulgoDate = chulgoDate;
	}
	public String getActUserName() {
		return actUserName;
	}
	public void setActUserName(String actUserName) {
		this.actUserName = actUserName;
	}
	public String getWonyoiOrderYn() {
		return wonyoiOrderYn;
	}
	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}
	public String getDisGubun() {
		return disGubun;
	}
	public void setDisGubun(String disGubun) {
		this.disGubun = disGubun;
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
	public Double getFkout1001() {
		return fkout1001;
	}
	public void setFkout1001(Double fkout1001) {
		this.fkout1001 = fkout1001;
	}
	public String getIfDataSendYn() {
		return ifDataSendYn;
	}
	public void setIfDataSendYn(String ifDataSendYn) {
		this.ifDataSendYn = ifDataSendYn;
	}
}

package nta.med.data.model.ihis.drgs;

import java.sql.Date;
import java.sql.Timestamp;

public class DRG9040U01GrdOrderOutInfo {
	private Double drgBunho;                                                                       
    private String bunho;                                                                           
    private Timestamp orderDate;                                                                      
    private Timestamp jubsuDate;                                                                      
    private String jubsuTime;                                                                      
    private String doctor;                                                                          
    private String doctorName;                                                                     
    private String gwa;                                                                             
    private String buseoName;                                                                      
    private Timestamp actDate;                                                                        
    private String actYn;                                                                          
    private Timestamp sunabDate;                                                                      
    private Timestamp chulgoDate;                                                                     
    private String boryuYn;                                                                        
    private String orderRemark;                                                                    
    private String drgRemark;                                                                      
    private String wonyoiOrderYn;
	public DRG9040U01GrdOrderOutInfo(Double drgBunho, String bunho,
			Timestamp orderDate, Timestamp jubsuDate, String jubsuTime,
			String doctor, String doctorName, String gwa, String buseoName,
			Timestamp actDate, String actYn, Timestamp sunabDate,
			Timestamp chulgoDate, String boryuYn, String orderRemark,
			String drgRemark, String wonyoiOrderYn) {
		super();
		this.drgBunho = drgBunho;
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.jubsuDate = jubsuDate;
		this.jubsuTime = jubsuTime;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.gwa = gwa;
		this.buseoName = buseoName;
		this.actDate = actDate;
		this.actYn = actYn;
		this.sunabDate = sunabDate;
		this.chulgoDate = chulgoDate;
		this.boryuYn = boryuYn;
		this.orderRemark = orderRemark;
		this.drgRemark = drgRemark;
		this.wonyoiOrderYn = wonyoiOrderYn;
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
	public String getBoryuYn() {
		return boryuYn;
	}
	public void setBoryuYn(String boryuYn) {
		this.boryuYn = boryuYn;
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
	public String getWonyoiOrderYn() {
		return wonyoiOrderYn;
	}
	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}
}

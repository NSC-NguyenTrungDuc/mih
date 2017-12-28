package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class ORDERTRANSGrdINP2004Info {
	private String bunho             ;
	private String suname            ;
	private Date ipwonDate        ;
	private Date dataDate         ;
	private Double fkinp1001         ;
	private String pkinp1002         ;
	private String fromGwa          ;
	private String toGwa            ;
	private String fromDoctor       ;
	private String toDoctor         ;              
	private String fromHoDong1     ;
	private String toHoDong1       ;
	private String fromHoCode1     ;
	private String toHoCode1       ;
	private String fromBedNo       ;
	private String toBedNo         ;
	private String sendYn           ;
	private String ifFlag           ;
	public ORDERTRANSGrdINP2004Info(String bunho, String suname,
			Date ipwonDate, Date dataDate, Double fkinp1001, String pkinp1002,
			String fromGwa, String toGwa, String fromDoctor, String toDoctor,
			String fromHoDong1, String toHoDong1, String fromHoCode1,
			String toHoCode1, String fromBedNo, String toBedNo, String sendYn,
			String ifFlag) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.ipwonDate = ipwonDate;
		this.dataDate = dataDate;
		this.fkinp1001 = fkinp1001;
		this.pkinp1002 = pkinp1002;
		this.fromGwa = fromGwa;
		this.toGwa = toGwa;
		this.fromDoctor = fromDoctor;
		this.toDoctor = toDoctor;
		this.fromHoDong1 = fromHoDong1;
		this.toHoDong1 = toHoDong1;
		this.fromHoCode1 = fromHoCode1;
		this.toHoCode1 = toHoCode1;
		this.fromBedNo = fromBedNo;
		this.toBedNo = toBedNo;
		this.sendYn = sendYn;
		this.ifFlag = ifFlag;
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
	public Date getIpwonDate() {
		return ipwonDate;
	}
	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}
	public Date getDataDate() {
		return dataDate;
	}
	public void setDataDate(Date dataDate) {
		this.dataDate = dataDate;
	}
	public Double getFkinp1001() {
		return fkinp1001;
	}
	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}
	public String getPkinp1002() {
		return pkinp1002;
	}
	public void setPkinp1002(String pkinp1002) {
		this.pkinp1002 = pkinp1002;
	}
	public String getFromGwa() {
		return fromGwa;
	}
	public void setFromGwa(String fromGwa) {
		this.fromGwa = fromGwa;
	}
	public String getToGwa() {
		return toGwa;
	}
	public void setToGwa(String toGwa) {
		this.toGwa = toGwa;
	}
	public String getFromDoctor() {
		return fromDoctor;
	}
	public void setFromDoctor(String fromDoctor) {
		this.fromDoctor = fromDoctor;
	}
	public String getToDoctor() {
		return toDoctor;
	}
	public void setToDoctor(String toDoctor) {
		this.toDoctor = toDoctor;
	}
	public String getFromHoDong1() {
		return fromHoDong1;
	}
	public void setFromHoDong1(String fromHoDong1) {
		this.fromHoDong1 = fromHoDong1;
	}
	public String getToHoDong1() {
		return toHoDong1;
	}
	public void setToHoDong1(String toHoDong1) {
		this.toHoDong1 = toHoDong1;
	}
	public String getFromHoCode1() {
		return fromHoCode1;
	}
	public void setFromHoCode1(String fromHoCode1) {
		this.fromHoCode1 = fromHoCode1;
	}
	public String getToHoCode1() {
		return toHoCode1;
	}
	public void setToHoCode1(String toHoCode1) {
		this.toHoCode1 = toHoCode1;
	}
	public String getFromBedNo() {
		return fromBedNo;
	}
	public void setFromBedNo(String fromBedNo) {
		this.fromBedNo = fromBedNo;
	}
	public String getToBedNo() {
		return toBedNo;
	}
	public void setToBedNo(String toBedNo) {
		this.toBedNo = toBedNo;
	}
	public String getSendYn() {
		return sendYn;
	}
	public void setSendYn(String sendYn) {
		this.sendYn = sendYn;
	}
	public String getIfFlag() {
		return ifFlag;
	}
	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}
	
}

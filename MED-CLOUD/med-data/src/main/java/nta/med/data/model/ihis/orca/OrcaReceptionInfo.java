package nta.med.data.model.ihis.orca;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class OrcaReceptionInfo {

	private int orcaReceptionId;

	private String actCode;

	private BigDecimal activeFlg;

	private String appTime;

	private double bundNum;

	private String classCode;

	private Timestamp created;

	private String doctor;

	private double fkout1001;

	private String gwa;

	private String hospCode;

	private String ioFlag;

	private String orderTime;

	private String performTime;

	private String registTime;

	private String subCode;

	private String sysId;

	private String timeClass;

	private String updId;

	private Timestamp updated;

	public OrcaReceptionInfo(int orcaReceptionId, String actCode, BigDecimal activeFlg, String appTime, double bundNum,
			String classCode, Timestamp created, String doctor, double fkout1001, String gwa, String hospCode,
			String ioFlag, String orderTime, String performTime, String registTime, String subCode, String sysId,
			String timeClass, String updId, Timestamp updated) {
		super();
		this.orcaReceptionId = orcaReceptionId;
		this.actCode = actCode;
		this.activeFlg = activeFlg;
		this.appTime = appTime;
		this.bundNum = bundNum;
		this.classCode = classCode;
		this.created = created;
		this.doctor = doctor;
		this.fkout1001 = fkout1001;
		this.gwa = gwa;
		this.hospCode = hospCode;
		this.ioFlag = ioFlag;
		this.orderTime = orderTime;
		this.performTime = performTime;
		this.registTime = registTime;
		this.subCode = subCode;
		this.sysId = sysId;
		this.timeClass = timeClass;
		this.updId = updId;
		this.updated = updated;
	}

	public int getOrcaReceptionId() {
		return orcaReceptionId;
	}

	public void setOrcaReceptionId(int orcaReceptionId) {
		this.orcaReceptionId = orcaReceptionId;
	}

	public String getActCode() {
		return actCode;
	}

	public void setActCode(String actCode) {
		this.actCode = actCode;
	}

	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getAppTime() {
		return appTime;
	}

	public void setAppTime(String appTime) {
		this.appTime = appTime;
	}

	public double getBundNum() {
		return bundNum;
	}

	public void setBundNum(double bundNum) {
		this.bundNum = bundNum;
	}

	public String getClassCode() {
		return classCode;
	}

	public void setClassCode(String classCode) {
		this.classCode = classCode;
	}

	public Timestamp getCreated() {
		return created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public double getFkout1001() {
		return fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getIoFlag() {
		return ioFlag;
	}

	public void setIoFlag(String ioFlag) {
		this.ioFlag = ioFlag;
	}

	public String getOrderTime() {
		return orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}

	public String getPerformTime() {
		return performTime;
	}

	public void setPerformTime(String performTime) {
		this.performTime = performTime;
	}

	public String getRegistTime() {
		return registTime;
	}

	public void setRegistTime(String registTime) {
		this.registTime = registTime;
	}

	public String getSubCode() {
		return subCode;
	}

	public void setSubCode(String subCode) {
		this.subCode = subCode;
	}

	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTimeClass() {
		return timeClass;
	}

	public void setTimeClass(String timeClass) {
		this.timeClass = timeClass;
	}

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}	
}

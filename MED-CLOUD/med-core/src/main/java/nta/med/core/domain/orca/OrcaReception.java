package nta.med.core.domain.orca;

import java.io.Serializable;
import javax.persistence.*;

import nta.med.core.domain.BaseEntity;

import java.math.BigDecimal;
import java.sql.Timestamp;


/**
 * The persistent class for the ORCA_RECEPTION database table.
 * 
 */
@Entity
@Table(name="ORCA_RECEPTION")
@NamedQuery(name="OrcaReception.findAll", query="SELECT o FROM OrcaReception o")
public class OrcaReception implements Serializable{
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="ORCA_RECEPTION_ID")
	private int orcaReceptionId;

	@Column(name="ACT_CODE")
	private String actCode;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	@Column(name="APP_TIME")
	private String appTime;

	@Column(name="BUND_NUM")
	private double bundNum;

	@Column(name="CLASS_CODE")
	private String classCode;

	private Timestamp created;

	private String doctor;

	private double fkout1001;

	private String gwa;

	@Column(name="HOSP_CODE")
	private String hospCode;

	@Column(name="IO_FLAG")
	private String ioFlag;

	@Column(name="ORDER_TIME")
	private String orderTime;

	@Column(name="PERFORM_TIME")
	private String performTime;

	@Column(name="REGIST_TIME")
	private String registTime;

	@Column(name="SUB_CODE")
	private String subCode;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="TIME_CLASS")
	private String timeClass;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;

	public OrcaReception() {
	}

	public int getOrcaReceptionId() {
		return this.orcaReceptionId;
	}

	public void setOrcaReceptionId(int orcaReceptionId) {
		this.orcaReceptionId = orcaReceptionId;
	}

	public String getActCode() {
		return this.actCode;
	}

	public void setActCode(String actCode) {
		this.actCode = actCode;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getAppTime() {
		return this.appTime;
	}

	public void setAppTime(String appTime) {
		this.appTime = appTime;
	}

	public double getBundNum() {
		return this.bundNum;
	}

	public void setBundNum(double bundNum) {
		this.bundNum = bundNum;
	}

	public String getClassCode() {
		return this.classCode;
	}

	public void setClassCode(String classCode) {
		this.classCode = classCode;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}

	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getIoFlag() {
		return this.ioFlag;
	}

	public void setIoFlag(String ioFlag) {
		this.ioFlag = ioFlag;
	}

	public String getOrderTime() {
		return this.orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}

	public String getPerformTime() {
		return this.performTime;
	}

	public void setPerformTime(String performTime) {
		this.performTime = performTime;
	}

	public String getRegistTime() {
		return this.registTime;
	}

	public void setRegistTime(String registTime) {
		this.registTime = registTime;
	}

	public String getSubCode() {
		return this.subCode;
	}

	public void setSubCode(String subCode) {
		this.subCode = subCode;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTimeClass() {
		return this.timeClass;
	}

	public void setTimeClass(String timeClass) {
		this.timeClass = timeClass;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}
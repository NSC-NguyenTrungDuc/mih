package nta.med.core.domain.sch;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the SCH0201 database table.
 * 
 */
@Entity
@NamedQuery(name = "Sch0201.findAll", query = "SELECT s FROM Sch0201 s")
@Table(name = "SCH0201")
public class Sch0201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actingDate;
	private String bunho;
	private String cancelYn;
	private String comments;
	private String doctor;
	private String emergency;
	private Double fkocs;
	private String gumsaja;
	private String gwa;
	private String hangmogCode;
	private String holdYn;
	private Date hopeDate;
	private String hospCode;
	private String inOutGubun;
	private Date inputDate;
	private String inputId;
	private Date inputTime;
	private String jundalPart;
	private String jundalTable;
	private String jusaReserYn;
	private Date orderDate;
	private Double partPkkey;
	private Double pksch0201;
	private Date reserDate;
	private String reserGumsaYn;
	private String reserTime;
	private String reserTimeTo;
	private String reserYn;
	private Double seq;
	private String suname;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String outHospCode;
	private Double pksch0201Out;
	private Double fkOcs1003c;

	public Sch0201() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "CANCEL_YN")
	public String getCancelYn() {
		return this.cancelYn;
	}

	public void setCancelYn(String cancelYn) {
		this.cancelYn = cancelYn;
	}

	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}

	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	public Double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(Double fkocs) {
		this.fkocs = fkocs;
	}

	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
	}

	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Column(name = "HOLD_YN")
	public String getHoldYn() {
		return this.holdYn;
	}

	public void setHoldYn(String holdYn) {
		this.holdYn = holdYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "HOPE_DATE")
	public Date getHopeDate() {
		return this.hopeDate;
	}

	public void setHopeDate(Date hopeDate) {
		this.hopeDate = hopeDate;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "INPUT_DATE")
	public Date getInputDate() {
		return this.inputDate;
	}

	public void setInputDate(Date inputDate) {
		this.inputDate = inputDate;
	}

	@Column(name = "INPUT_ID")
	public String getInputId() {
		return this.inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "INPUT_TIME")
	public Date getInputTime() {
		return this.inputTime;
	}

	public void setInputTime(Date inputTime) {
		this.inputTime = inputTime;
	}

	@Column(name = "JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}

	@Column(name = "JUNDAL_TABLE")
	public String getJundalTable() {
		return this.jundalTable;
	}

	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}

	@Column(name = "JUSA_RESER_YN")
	public String getJusaReserYn() {
		return this.jusaReserYn;
	}

	public void setJusaReserYn(String jusaReserYn) {
		this.jusaReserYn = jusaReserYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	@Column(name = "PART_PKKEY")
	public Double getPartPkkey() {
		return this.partPkkey;
	}

	public void setPartPkkey(Double partPkkey) {
		this.partPkkey = partPkkey;
	}

	public Double getPksch0201() {
		return this.pksch0201;
	}

	public void setPksch0201(Double pksch0201) {
		this.pksch0201 = pksch0201;
	}

	@Column(name = "PKSCH0201_OUT")
	public Double getPksch0201Out() {
		return pksch0201Out;
	}

	public void setPksch0201Out(Double pksch0201Out) {
		this.pksch0201Out = pksch0201Out;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}

	@Column(name = "RESER_GUMSA_YN")
	public String getReserGumsaYn() {
		return this.reserGumsaYn;
	}

	public void setReserGumsaYn(String reserGumsaYn) {
		this.reserGumsaYn = reserGumsaYn;
	}

	@Column(name = "RESER_TIME")
	public String getReserTime() {
		return this.reserTime;
	}

	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}

	@Column(name = "RESER_TIME_TO")
	public String getReserTimeTo() {
		return this.reserTimeTo;
	}

	public void setReserTimeTo(String reserTimeTo) {
		this.reserTimeTo = reserTimeTo;
	}

	@Column(name = "RESER_YN")
	public String getReserYn() {
		return this.reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "OUT_HOSP_CODE")
	public String getOutHospCode() {
		return outHospCode;
	}

	public void setOutHospCode(String outHospCode) {
		this.outHospCode = outHospCode;
	}

	@Column(name = "FKOCS1003C")
	public Double getFkOcs1003c() {
		return fkOcs1003c;
	}

	public void setFkOcs1003c(Double fkOcs1003c) {
		this.fkOcs1003c = fkOcs1003c;
	}

}
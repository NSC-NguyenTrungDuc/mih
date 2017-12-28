package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;


/**
 * The persistent class for the OCS2023 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2023.findAll", query="SELECT o FROM Ocs2023 o")
public class Ocs2023 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongCode;
	private String bunho;
	private double daySeq;
	private String drugTime;
	private double dv;
	private String dvTime;
	private double fkocs2003;
	private double groupSer;
	private String hangmogCode;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inputGubun;
	private String ipAddress;
	private Date ipwonDate;
	private String jusa;
	private String labelGubun;
	private String ordDanui;
	private Date orderDate;
	private String orderGubun;
	private String pgrmId;
	private double pkinp1001;
	private BigDecimal seq;
	private String suname;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private String team;
	private double totDaySeq;
	private Date updDate;
	private String updId;

	public Ocs2023() {
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DAY_SEQ")
	public double getDaySeq() {
		return this.daySeq;
	}

	public void setDaySeq(double daySeq) {
		this.daySeq = daySeq;
	}


	@Column(name="DRUG_TIME")
	public String getDrugTime() {
		return this.drugTime;
	}

	public void setDrugTime(String drugTime) {
		this.drugTime = drugTime;
	}


	public double getDv() {
		return this.dv;
	}

	public void setDv(double dv) {
		this.dv = dv;
	}


	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}


	public double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}


	@Column(name="GROUP_SER")
	public double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(double groupSer) {
		this.groupSer = groupSer;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}


	@Column(name="IP_ADDRESS")
	public String getIpAddress() {
		return this.ipAddress;
	}

	public void setIpAddress(String ipAddress) {
		this.ipAddress = ipAddress;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IPWON_DATE")
	public Date getIpwonDate() {
		return this.ipwonDate;
	}

	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}


	public String getJusa() {
		return this.jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}


	@Column(name="LABEL_GUBUN")
	public String getLabelGubun() {
		return this.labelGubun;
	}

	public void setLabelGubun(String labelGubun) {
		this.labelGubun = labelGubun;
	}


	@Column(name="ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}


	@Column(name="PGRM_ID")
	public String getPgrmId() {
		return this.pgrmId;
	}

	public void setPgrmId(String pgrmId) {
		this.pgrmId = pgrmId;
	}


	public double getPkinp1001() {
		return this.pkinp1001;
	}

	public void setPkinp1001(double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}


	public BigDecimal getSeq() {
		return this.seq;
	}

	public void setSeq(BigDecimal seq) {
		this.seq = seq;
	}


	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
		this.suryang = suryang;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	public String getTeam() {
		return this.team;
	}

	public void setTeam(String team) {
		this.team = team;
	}


	@Column(name="TOT_DAY_SEQ")
	public double getTotDaySeq() {
		return this.totDaySeq;
	}

	public void setTotDaySeq(double totDaySeq) {
		this.totDaySeq = totDaySeq;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}
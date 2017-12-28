package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2024 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2024.findAll", query="SELECT o FROM Ocs2024 o")
public class Ocs2024 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double daySeq;
	private String drugTime;
	private double fkocs2003;
	private double groupSer;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inputGubun;
	private String ipAddress;
	private Date ipwonDate;
	private String labelGubun;
	private Date orderDate;
	private String orderGubun;
	private String pgrmId;
	private double pkinp1001;
	private double printSeq;
	private String remark1;
	private String remark2;
	private String remark3;
	private String remark4;
	private String remark5;
	private String remark6;
	private String suname;
	private Date sysDate;
	private String sysId;
	private String team;
	private double totDaySeq;
	private Date updDate;
	private String updId;

	public Ocs2024() {
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


	@Column(name="LABEL_GUBUN")
	public String getLabelGubun() {
		return this.labelGubun;
	}

	public void setLabelGubun(String labelGubun) {
		this.labelGubun = labelGubun;
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


	@Column(name="PRINT_SEQ")
	public double getPrintSeq() {
		return this.printSeq;
	}

	public void setPrintSeq(double printSeq) {
		this.printSeq = printSeq;
	}


	public String getRemark1() {
		return this.remark1;
	}

	public void setRemark1(String remark1) {
		this.remark1 = remark1;
	}


	public String getRemark2() {
		return this.remark2;
	}

	public void setRemark2(String remark2) {
		this.remark2 = remark2;
	}


	public String getRemark3() {
		return this.remark3;
	}

	public void setRemark3(String remark3) {
		this.remark3 = remark3;
	}


	public String getRemark4() {
		return this.remark4;
	}

	public void setRemark4(String remark4) {
		this.remark4 = remark4;
	}


	public String getRemark5() {
		return this.remark5;
	}

	public void setRemark5(String remark5) {
		this.remark5 = remark5;
	}


	public String getRemark6() {
		return this.remark6;
	}

	public void setRemark6(String remark6) {
		this.remark6 = remark6;
	}


	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
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
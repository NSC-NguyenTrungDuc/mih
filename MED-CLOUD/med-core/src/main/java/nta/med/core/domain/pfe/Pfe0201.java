package nta.med.core.domain.pfe;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the PFE0201 database table.
 * 
 */
@Entity
@NamedQuery(name="Pfe0201.findAll", query="SELECT p FROM Pfe0201 p")
public class Pfe0201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actDoctor;
	private String afterActYn;
	private String appendYn;
	private String bunho;
	private String buwiCode;
	private String comments;
	private String dcYn;
	private String deleteYn;
	private String doctor;
	private String emergency;
	private double fkocs1003;
	private double fkocs2003;
	private double fkpfe5010;
	private double groupSer;
	private Date gumsaDate;
	private Date gumsaDate2;
	private Date gumsaDate3;
	private String gumsaSusulGubun;
	private String gumsaTime;
	private String gumsaUser;
	private String gwa;
	private String hangmogCode;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private String inOutGubun;
	private String injNurse;
	private String jindanCode;
	private Date jubsuDate;
	private double jubsuNo;
	private String jubsuTime;
	private String jubsuUser;
	private String jundalPart;
	private String muhyo;
	private String nurse;
	private Date orderDate;
	private double pkpfe0201;
	private String portableYn;
	private String printYn;
	private Date reserDate;
	private String reserTime;
	private String reserType;
	private String reserYn;
	private String resident;
	private Date resultDate;
	private String resultDoctor;
	private String resultDoctor2;
	private String resultGubun;
	private String resultTime;
	private String sgCode;
	private double specialRate;
	private String specialYn;
	private Date sunabDate;
	private double sunabSuryang;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private String tongYn;
	private Date updDate;
	private String updId;

	public Pfe0201() {
	}


	@Column(name="ACT_DOCTOR")
	public String getActDoctor() {
		return this.actDoctor;
	}

	public void setActDoctor(String actDoctor) {
		this.actDoctor = actDoctor;
	}


	@Column(name="AFTER_ACT_YN")
	public String getAfterActYn() {
		return this.afterActYn;
	}

	public void setAfterActYn(String afterActYn) {
		this.afterActYn = afterActYn;
	}


	@Column(name="APPEND_YN")
	public String getAppendYn() {
		return this.appendYn;
	}

	public void setAppendYn(String appendYn) {
		this.appendYn = appendYn;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="BUWI_CODE")
	public String getBuwiCode() {
		return this.buwiCode;
	}

	public void setBuwiCode(String buwiCode) {
		this.buwiCode = buwiCode;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Column(name="DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}


	@Column(name="DELETE_YN")
	public String getDeleteYn() {
		return this.deleteYn;
	}

	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
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


	public double getFkocs1003() {
		return this.fkocs1003;
	}

	public void setFkocs1003(double fkocs1003) {
		this.fkocs1003 = fkocs1003;
	}


	public double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}


	public double getFkpfe5010() {
		return this.fkpfe5010;
	}

	public void setFkpfe5010(double fkpfe5010) {
		this.fkpfe5010 = fkpfe5010;
	}


	@Column(name="GROUP_SER")
	public double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(double groupSer) {
		this.groupSer = groupSer;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUMSA_DATE")
	public Date getGumsaDate() {
		return this.gumsaDate;
	}

	public void setGumsaDate(Date gumsaDate) {
		this.gumsaDate = gumsaDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUMSA_DATE2")
	public Date getGumsaDate2() {
		return this.gumsaDate2;
	}

	public void setGumsaDate2(Date gumsaDate2) {
		this.gumsaDate2 = gumsaDate2;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUMSA_DATE3")
	public Date getGumsaDate3() {
		return this.gumsaDate3;
	}

	public void setGumsaDate3(Date gumsaDate3) {
		this.gumsaDate3 = gumsaDate3;
	}


	@Column(name="GUMSA_SUSUL_GUBUN")
	public String getGumsaSusulGubun() {
		return this.gumsaSusulGubun;
	}

	public void setGumsaSusulGubun(String gumsaSusulGubun) {
		this.gumsaSusulGubun = gumsaSusulGubun;
	}


	@Column(name="GUMSA_TIME")
	public String getGumsaTime() {
		return this.gumsaTime;
	}

	public void setGumsaTime(String gumsaTime) {
		this.gumsaTime = gumsaTime;
	}


	@Column(name="GUMSA_USER")
	public String getGumsaUser() {
		return this.gumsaUser;
	}

	public void setGumsaUser(String gumsaUser) {
		this.gumsaUser = gumsaUser;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
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


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="INJ_NURSE")
	public String getInjNurse() {
		return this.injNurse;
	}

	public void setInjNurse(String injNurse) {
		this.injNurse = injNurse;
	}


	@Column(name="JINDAN_CODE")
	public String getJindanCode() {
		return this.jindanCode;
	}

	public void setJindanCode(String jindanCode) {
		this.jindanCode = jindanCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_NO")
	public double getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Column(name="JUBSU_USER")
	public String getJubsuUser() {
		return this.jubsuUser;
	}

	public void setJubsuUser(String jubsuUser) {
		this.jubsuUser = jubsuUser;
	}


	@Column(name="JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}


	public String getMuhyo() {
		return this.muhyo;
	}

	public void setMuhyo(String muhyo) {
		this.muhyo = muhyo;
	}


	public String getNurse() {
		return this.nurse;
	}

	public void setNurse(String nurse) {
		this.nurse = nurse;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public double getPkpfe0201() {
		return this.pkpfe0201;
	}

	public void setPkpfe0201(double pkpfe0201) {
		this.pkpfe0201 = pkpfe0201;
	}


	@Column(name="PORTABLE_YN")
	public String getPortableYn() {
		return this.portableYn;
	}

	public void setPortableYn(String portableYn) {
		this.portableYn = portableYn;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}


	@Column(name="RESER_TIME")
	public String getReserTime() {
		return this.reserTime;
	}

	public void setReserTime(String reserTime) {
		this.reserTime = reserTime;
	}


	@Column(name="RESER_TYPE")
	public String getReserType() {
		return this.reserType;
	}

	public void setReserType(String reserType) {
		this.reserType = reserType;
	}


	@Column(name="RESER_YN")
	public String getReserYn() {
		return this.reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}


	public String getResident() {
		return this.resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT_DATE")
	public Date getResultDate() {
		return this.resultDate;
	}

	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}


	@Column(name="RESULT_DOCTOR")
	public String getResultDoctor() {
		return this.resultDoctor;
	}

	public void setResultDoctor(String resultDoctor) {
		this.resultDoctor = resultDoctor;
	}


	@Column(name="RESULT_DOCTOR2")
	public String getResultDoctor2() {
		return this.resultDoctor2;
	}

	public void setResultDoctor2(String resultDoctor2) {
		this.resultDoctor2 = resultDoctor2;
	}


	@Column(name="RESULT_GUBUN")
	public String getResultGubun() {
		return this.resultGubun;
	}

	public void setResultGubun(String resultGubun) {
		this.resultGubun = resultGubun;
	}


	@Column(name="RESULT_TIME")
	public String getResultTime() {
		return this.resultTime;
	}

	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SPECIAL_RATE")
	public double getSpecialRate() {
		return this.specialRate;
	}

	public void setSpecialRate(double specialRate) {
		this.specialRate = specialRate;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SUNAB_DATE")
	public Date getSunabDate() {
		return this.sunabDate;
	}

	public void setSunabDate(Date sunabDate) {
		this.sunabDate = sunabDate;
	}


	@Column(name="SUNAB_SURYANG")
	public double getSunabSuryang() {
		return this.sunabSuryang;
	}

	public void setSunabSuryang(double sunabSuryang) {
		this.sunabSuryang = sunabSuryang;
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


	@Column(name="TONG_YN")
	public String getTongYn() {
		return this.tongYn;
	}

	public void setTongYn(String tongYn) {
		this.tongYn = tongYn;
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
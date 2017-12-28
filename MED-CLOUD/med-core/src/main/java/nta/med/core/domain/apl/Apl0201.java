package nta.med.core.domain.apl;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the APL0201 database table.
 * 
 */
@Entity
@NamedQuery(name="Apl0201.findAll", query="SELECT a FROM Apl0201 a")
public class Apl0201 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actDoctor;
	private String afterActYn;
	private BigDecimal age;
	private String block;
	private String bunho;
	private Date chunguDate;
	private String dcYn;
	private String doctor;
	private String doctorName;
	private Date faxDate;
	private String faxUser;
	private Date fax2Date;
	private String fax2User;
	private double fkocs1003;
	private double fkocs2003;
	private String frozenYn;
	private String groupYn;
	private String gubun;
	private String gwa;
	private String hangmogCode;
	private String hoCode;
	private String hoDong;
	private String hosNo;
	private String hospCode;
	private String inOutGubun;
	private Date ingyeDate;
	private String ingyeJubsuja;
	private String ingyeMethod;
	private String ingyeNo;
	private String ingyeTime;
	private String ingyeja;
	private Date jubsuDate;
	private String jubsuTime;
	private String jubsuja;
	private String muhyo;
	private Date orderDate;
	private String orderTime;
	private String pathno;
	private String pathno1;
	private String pathno2;
	private double pathno3;
	private double pkapl0201;
	private Date printDate;
	private String printUser;
	private String printYn;
	private String requestDoctor;
	private String requestGwa;
	private String requestHosp;
	private String resident;
	private Date resultDate;
	private String resultTime;
	private String resultUser;
	private Date result2Date;
	private String result2User;
	private String sex;
	private String slideYn;
	private String specialYn;
	private String specimenCode;
	private double specimenSu;
	private String subYn;
	private String sujumin1;
	private String sujumin2;
	private Date sunabDate;
	private String suname;
	private String supYn;
	private Date sysDate;
	private String sysId;
	private String tel;
	private Date updDate;
	private String updId;
	private String workPrnYn;

	public Apl0201() {
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


	public BigDecimal getAge() {
		return this.age;
	}

	public void setAge(BigDecimal age) {
		this.age = age;
	}


	public String getBlock() {
		return this.block;
	}

	public void setBlock(String block) {
		this.block = block;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHUNGU_DATE")
	public Date getChunguDate() {
		return this.chunguDate;
	}

	public void setChunguDate(Date chunguDate) {
		this.chunguDate = chunguDate;
	}


	@Column(name="DC_YN")
	public String getDcYn() {
		return this.dcYn;
	}

	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DOCTOR_NAME")
	public String getDoctorName() {
		return this.doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FAX_DATE")
	public Date getFaxDate() {
		return this.faxDate;
	}

	public void setFaxDate(Date faxDate) {
		this.faxDate = faxDate;
	}


	@Column(name="FAX_USER")
	public String getFaxUser() {
		return this.faxUser;
	}

	public void setFaxUser(String faxUser) {
		this.faxUser = faxUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FAX2_DATE")
	public Date getFax2Date() {
		return this.fax2Date;
	}

	public void setFax2Date(Date fax2Date) {
		this.fax2Date = fax2Date;
	}


	@Column(name="FAX2_USER")
	public String getFax2User() {
		return this.fax2User;
	}

	public void setFax2User(String fax2User) {
		this.fax2User = fax2User;
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


	@Column(name="FROZEN_YN")
	public String getFrozenYn() {
		return this.frozenYn;
	}

	public void setFrozenYn(String frozenYn) {
		this.frozenYn = frozenYn;
	}


	@Column(name="GROUP_YN")
	public String getGroupYn() {
		return this.groupYn;
	}

	public void setGroupYn(String groupYn) {
		this.groupYn = groupYn;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
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


	@Column(name="HOS_NO")
	public String getHosNo() {
		return this.hosNo;
	}

	public void setHosNo(String hosNo) {
		this.hosNo = hosNo;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="INGYE_DATE")
	public Date getIngyeDate() {
		return this.ingyeDate;
	}

	public void setIngyeDate(Date ingyeDate) {
		this.ingyeDate = ingyeDate;
	}


	@Column(name="INGYE_JUBSUJA")
	public String getIngyeJubsuja() {
		return this.ingyeJubsuja;
	}

	public void setIngyeJubsuja(String ingyeJubsuja) {
		this.ingyeJubsuja = ingyeJubsuja;
	}


	@Column(name="INGYE_METHOD")
	public String getIngyeMethod() {
		return this.ingyeMethod;
	}

	public void setIngyeMethod(String ingyeMethod) {
		this.ingyeMethod = ingyeMethod;
	}


	@Column(name="INGYE_NO")
	public String getIngyeNo() {
		return this.ingyeNo;
	}

	public void setIngyeNo(String ingyeNo) {
		this.ingyeNo = ingyeNo;
	}


	@Column(name="INGYE_TIME")
	public String getIngyeTime() {
		return this.ingyeTime;
	}

	public void setIngyeTime(String ingyeTime) {
		this.ingyeTime = ingyeTime;
	}


	public String getIngyeja() {
		return this.ingyeja;
	}

	public void setIngyeja(String ingyeja) {
		this.ingyeja = ingyeja;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	public String getJubsuja() {
		return this.jubsuja;
	}

	public void setJubsuja(String jubsuja) {
		this.jubsuja = jubsuja;
	}


	public String getMuhyo() {
		return this.muhyo;
	}

	public void setMuhyo(String muhyo) {
		this.muhyo = muhyo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="ORDER_TIME")
	public String getOrderTime() {
		return this.orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}


	public String getPathno() {
		return this.pathno;
	}

	public void setPathno(String pathno) {
		this.pathno = pathno;
	}


	public String getPathno1() {
		return this.pathno1;
	}

	public void setPathno1(String pathno1) {
		this.pathno1 = pathno1;
	}


	public String getPathno2() {
		return this.pathno2;
	}

	public void setPathno2(String pathno2) {
		this.pathno2 = pathno2;
	}


	public double getPathno3() {
		return this.pathno3;
	}

	public void setPathno3(double pathno3) {
		this.pathno3 = pathno3;
	}


	public double getPkapl0201() {
		return this.pkapl0201;
	}

	public void setPkapl0201(double pkapl0201) {
		this.pkapl0201 = pkapl0201;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PRINT_DATE")
	public Date getPrintDate() {
		return this.printDate;
	}

	public void setPrintDate(Date printDate) {
		this.printDate = printDate;
	}


	@Column(name="PRINT_USER")
	public String getPrintUser() {
		return this.printUser;
	}

	public void setPrintUser(String printUser) {
		this.printUser = printUser;
	}


	@Column(name="PRINT_YN")
	public String getPrintYn() {
		return this.printYn;
	}

	public void setPrintYn(String printYn) {
		this.printYn = printYn;
	}


	@Column(name="REQUEST_DOCTOR")
	public String getRequestDoctor() {
		return this.requestDoctor;
	}

	public void setRequestDoctor(String requestDoctor) {
		this.requestDoctor = requestDoctor;
	}


	@Column(name="REQUEST_GWA")
	public String getRequestGwa() {
		return this.requestGwa;
	}

	public void setRequestGwa(String requestGwa) {
		this.requestGwa = requestGwa;
	}


	@Column(name="REQUEST_HOSP")
	public String getRequestHosp() {
		return this.requestHosp;
	}

	public void setRequestHosp(String requestHosp) {
		this.requestHosp = requestHosp;
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


	@Column(name="RESULT_TIME")
	public String getResultTime() {
		return this.resultTime;
	}

	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}


	@Column(name="RESULT_USER")
	public String getResultUser() {
		return this.resultUser;
	}

	public void setResultUser(String resultUser) {
		this.resultUser = resultUser;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESULT2_DATE")
	public Date getResult2Date() {
		return this.result2Date;
	}

	public void setResult2Date(Date result2Date) {
		this.result2Date = result2Date;
	}


	@Column(name="RESULT2_USER")
	public String getResult2User() {
		return this.result2User;
	}

	public void setResult2User(String result2User) {
		this.result2User = result2User;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	@Column(name="SLIDE_YN")
	public String getSlideYn() {
		return this.slideYn;
	}

	public void setSlideYn(String slideYn) {
		this.slideYn = slideYn;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
	}


	@Column(name="SPECIMEN_CODE")
	public String getSpecimenCode() {
		return this.specimenCode;
	}

	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}


	@Column(name="SPECIMEN_SU")
	public double getSpecimenSu() {
		return this.specimenSu;
	}

	public void setSpecimenSu(double specimenSu) {
		this.specimenSu = specimenSu;
	}


	@Column(name="SUB_YN")
	public String getSubYn() {
		return this.subYn;
	}

	public void setSubYn(String subYn) {
		this.subYn = subYn;
	}


	public String getSujumin1() {
		return this.sujumin1;
	}

	public void setSujumin1(String sujumin1) {
		this.sujumin1 = sujumin1;
	}


	public String getSujumin2() {
		return this.sujumin2;
	}

	public void setSujumin2(String sujumin2) {
		this.sujumin2 = sujumin2;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SUNAB_DATE")
	public Date getSunabDate() {
		return this.sunabDate;
	}

	public void setSunabDate(Date sunabDate) {
		this.sunabDate = sunabDate;
	}


	public String getSuname() {
		return this.suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}


	@Column(name="SUP_YN")
	public String getSupYn() {
		return this.supYn;
	}

	public void setSupYn(String supYn) {
		this.supYn = supYn;
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


	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
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


	@Column(name="WORK_PRN_YN")
	public String getWorkPrnYn() {
		return this.workPrnYn;
	}

	public void setWorkPrnYn(String workPrnYn) {
		this.workPrnYn = workPrnYn;
	}

}
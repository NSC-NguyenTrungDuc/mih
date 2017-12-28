package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL2910 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl2910.findAll", query="SELECT c FROM Cpl2910 c")
public class Cpl2910 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address;
	private String afterActYn;
	private double age;
	private String bunho;
	private String dataGubun;
	private String dcYn;
	private String doctor;
	private String doctorName;
	private String donerYn;
	private String dummy;
	private String emergency;
	private double fkocs1003;
	private double fkocs2003;
	private String groupHangmog;
	private double groupSer;
	private String gubun;
	private String gubunName;
	private Date gumJubsuDate;
	private String gumJubsuTime;
	private String gumJubsuja;
	private String gwa;
	private String gwaName;
	private String hangmogCode;
	private String hoCode;
	private String hoDong;
	private Date hopeDate;
	private String hospCode;
	private String inOutGubun;
	private String iudGubun;
	private String jangbiCode;
	private String jangbiJundal;
	private String jangbiOutput;
	private Date jubsuDate;
	private String jubsuTime;
	private String jubsuja;
	private String jundalGubun;
	private String jundalGubunName;
	private String jundalGubunText;
	private String muhyo;
	private Date orderDate;
	private String orderGubun;
	private String orderTime;
	private double parentKey;
	private Date partJubsuDate;
	private String partJubsuTime;
	private String partJubsuja;
	private double pkcpl2010;
	private Date reserDate;
	private String reserTime;
	private Date resultDate;
	private String resultTime;
	private String returnCode;
	private String sex;
	private String slipCode;
	private double sourceFkocs1003;
	private double sourceFkocs2003;
	private String specialYn;
	private String specimenCode;
	private String specimenSer;
	private String sujumin1;
	private String sujumin2;
	private Date sunabDate;
	private String suname;
	private String sutakCode;
	private Date sysDate;
	private String sysId;
	private String tel;
	private String tubeCode;
	private String uitakCode;
	private Date updDate;
	private String updId;

	public Cpl2910() {
	}


	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}


	@Column(name="AFTER_ACT_YN")
	public String getAfterActYn() {
		return this.afterActYn;
	}

	public void setAfterActYn(String afterActYn) {
		this.afterActYn = afterActYn;
	}


	public double getAge() {
		return this.age;
	}

	public void setAge(double age) {
		this.age = age;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DATA_GUBUN")
	public String getDataGubun() {
		return this.dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
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


	@Column(name="DONER_YN")
	public String getDonerYn() {
		return this.donerYn;
	}

	public void setDonerYn(String donerYn) {
		this.donerYn = donerYn;
	}


	public String getDummy() {
		return this.dummy;
	}

	public void setDummy(String dummy) {
		this.dummy = dummy;
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


	@Column(name="GROUP_HANGMOG")
	public String getGroupHangmog() {
		return this.groupHangmog;
	}

	public void setGroupHangmog(String groupHangmog) {
		this.groupHangmog = groupHangmog;
	}


	@Column(name="GROUP_SER")
	public double getGroupSer() {
		return this.groupSer;
	}

	public void setGroupSer(double groupSer) {
		this.groupSer = groupSer;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="GUBUN_NAME")
	public String getGubunName() {
		return this.gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GUM_JUBSU_DATE")
	public Date getGumJubsuDate() {
		return this.gumJubsuDate;
	}

	public void setGumJubsuDate(Date gumJubsuDate) {
		this.gumJubsuDate = gumJubsuDate;
	}


	@Column(name="GUM_JUBSU_TIME")
	public String getGumJubsuTime() {
		return this.gumJubsuTime;
	}

	public void setGumJubsuTime(String gumJubsuTime) {
		this.gumJubsuTime = gumJubsuTime;
	}


	@Column(name="GUM_JUBSUJA")
	public String getGumJubsuja() {
		return this.gumJubsuja;
	}

	public void setGumJubsuja(String gumJubsuja) {
		this.gumJubsuja = gumJubsuja;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GWA_NAME")
	public String getGwaName() {
		return this.gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="HOPE_DATE")
	public Date getHopeDate() {
		return this.hopeDate;
	}

	public void setHopeDate(Date hopeDate) {
		this.hopeDate = hopeDate;
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


	@Column(name="IUD_GUBUN")
	public String getIudGubun() {
		return this.iudGubun;
	}

	public void setIudGubun(String iudGubun) {
		this.iudGubun = iudGubun;
	}


	@Column(name="JANGBI_CODE")
	public String getJangbiCode() {
		return this.jangbiCode;
	}

	public void setJangbiCode(String jangbiCode) {
		this.jangbiCode = jangbiCode;
	}


	@Column(name="JANGBI_JUNDAL")
	public String getJangbiJundal() {
		return this.jangbiJundal;
	}

	public void setJangbiJundal(String jangbiJundal) {
		this.jangbiJundal = jangbiJundal;
	}


	@Column(name="JANGBI_OUTPUT")
	public String getJangbiOutput() {
		return this.jangbiOutput;
	}

	public void setJangbiOutput(String jangbiOutput) {
		this.jangbiOutput = jangbiOutput;
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


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="JUNDAL_GUBUN_NAME")
	public String getJundalGubunName() {
		return this.jundalGubunName;
	}

	public void setJundalGubunName(String jundalGubunName) {
		this.jundalGubunName = jundalGubunName;
	}


	@Column(name="JUNDAL_GUBUN_TEXT")
	public String getJundalGubunText() {
		return this.jundalGubunText;
	}

	public void setJundalGubunText(String jundalGubunText) {
		this.jundalGubunText = jundalGubunText;
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


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}


	@Column(name="ORDER_TIME")
	public String getOrderTime() {
		return this.orderTime;
	}

	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}


	@Column(name="PARENT_KEY")
	public double getParentKey() {
		return this.parentKey;
	}

	public void setParentKey(double parentKey) {
		this.parentKey = parentKey;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="PART_JUBSU_DATE")
	public Date getPartJubsuDate() {
		return this.partJubsuDate;
	}

	public void setPartJubsuDate(Date partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}


	@Column(name="PART_JUBSU_TIME")
	public String getPartJubsuTime() {
		return this.partJubsuTime;
	}

	public void setPartJubsuTime(String partJubsuTime) {
		this.partJubsuTime = partJubsuTime;
	}


	@Column(name="PART_JUBSUJA")
	public String getPartJubsuja() {
		return this.partJubsuja;
	}

	public void setPartJubsuja(String partJubsuja) {
		this.partJubsuja = partJubsuja;
	}


	public double getPkcpl2010() {
		return this.pkcpl2010;
	}

	public void setPkcpl2010(double pkcpl2010) {
		this.pkcpl2010 = pkcpl2010;
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


	@Column(name="RETURN_CODE")
	public String getReturnCode() {
		return this.returnCode;
	}

	public void setReturnCode(String returnCode) {
		this.returnCode = returnCode;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	@Column(name="SLIP_CODE")
	public String getSlipCode() {
		return this.slipCode;
	}

	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
	}


	@Column(name="SOURCE_FKOCS1003")
	public double getSourceFkocs1003() {
		return this.sourceFkocs1003;
	}

	public void setSourceFkocs1003(double sourceFkocs1003) {
		this.sourceFkocs1003 = sourceFkocs1003;
	}


	@Column(name="SOURCE_FKOCS2003")
	public double getSourceFkocs2003() {
		return this.sourceFkocs2003;
	}

	public void setSourceFkocs2003(double sourceFkocs2003) {
		this.sourceFkocs2003 = sourceFkocs2003;
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


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
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


	@Column(name="SUTAK_CODE")
	public String getSutakCode() {
		return this.sutakCode;
	}

	public void setSutakCode(String sutakCode) {
		this.sutakCode = sutakCode;
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


	@Column(name="TUBE_CODE")
	public String getTubeCode() {
		return this.tubeCode;
	}

	public void setTubeCode(String tubeCode) {
		this.tubeCode = tubeCode;
	}


	@Column(name="UITAK_CODE")
	public String getUitakCode() {
		return this.uitakCode;
	}

	public void setUitakCode(String uitakCode) {
		this.uitakCode = uitakCode;
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
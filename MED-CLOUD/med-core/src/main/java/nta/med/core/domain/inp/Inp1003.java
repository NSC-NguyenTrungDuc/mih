package nta.med.core.domain.inp;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the INP1003 database table.
 * 
 */
@Entity
@Table(name="INP1003")
public class Inp1003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bedNo;
	private String bunho;
	private String doctor;
	private String emergency;
	private String emergencyDetail;
	private String emergencyGubun;
	private Double fkout1001;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String hopeRoom;
	private String hospCode;
	private String ipwonMokjuk;
	private String ipwonRtn2;
	private String ipwonsiOrderYn;
	private String jisiDoctor;
	private Date junpyoDate;
	private Double pkinp1003;
	private String remark;
	private Date reserDate;
	private Date reserEndDate;
	private String reserEndType;
	private Double reserFkinp1001;
	private String resident;
	private String sangBigo;
	private String sangCode;
	private String sogyeYn;
	private String susulReserYn;
	private Date sysDate;
	private String sysId;
	private String tel1;
	private String tel2;
	private Date updDate;
	private String updId;

	public Inp1003() {
	}


	@Column(name="BED_NO")
	public String getBedNo() {
		return this.bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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


	@Column(name="EMERGENCY_DETAIL")
	public String getEmergencyDetail() {
		return this.emergencyDetail;
	}

	public void setEmergencyDetail(String emergencyDetail) {
		this.emergencyDetail = emergencyDetail;
	}


	@Column(name="EMERGENCY_GUBUN")
	public String getEmergencyGubun() {
		return this.emergencyGubun;
	}

	public void setEmergencyGubun(String emergencyGubun) {
		this.emergencyGubun = emergencyGubun;
	}


	public Double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(Double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
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


	@Column(name="HOPE_ROOM")
	public String getHopeRoom() {
		return this.hopeRoom;
	}

	public void setHopeRoom(String hopeRoom) {
		this.hopeRoom = hopeRoom;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IPWON_MOKJUK")
	public String getIpwonMokjuk() {
		return this.ipwonMokjuk;
	}

	public void setIpwonMokjuk(String ipwonMokjuk) {
		this.ipwonMokjuk = ipwonMokjuk;
	}


	@Column(name="IPWON_RTN2")
	public String getIpwonRtn2() {
		return this.ipwonRtn2;
	}

	public void setIpwonRtn2(String ipwonRtn2) {
		this.ipwonRtn2 = ipwonRtn2;
	}


	@Column(name="IPWONSI_ORDER_YN")
	public String getIpwonsiOrderYn() {
		return this.ipwonsiOrderYn;
	}

	public void setIpwonsiOrderYn(String ipwonsiOrderYn) {
		this.ipwonsiOrderYn = ipwonsiOrderYn;
	}


	@Column(name="JISI_DOCTOR")
	public String getJisiDoctor() {
		return this.jisiDoctor;
	}

	public void setJisiDoctor(String jisiDoctor) {
		this.jisiDoctor = jisiDoctor;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="JUNPYO_DATE")
	public Date getJunpyoDate() {
		return this.junpyoDate;
	}

	public void setJunpyoDate(Date junpyoDate) {
		this.junpyoDate = junpyoDate;
	}


	public Double getPkinp1003() {
		return this.pkinp1003;
	}

	public void setPkinp1003(Double pkinp1003) {
		this.pkinp1003 = pkinp1003;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_DATE")
	public Date getReserDate() {
		return this.reserDate;
	}

	public void setReserDate(Date reserDate) {
		this.reserDate = reserDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="RESER_END_DATE")
	public Date getReserEndDate() {
		return this.reserEndDate;
	}

	public void setReserEndDate(Date reserEndDate) {
		this.reserEndDate = reserEndDate;
	}


	@Column(name="RESER_END_TYPE")
	public String getReserEndType() {
		return this.reserEndType;
	}

	public void setReserEndType(String reserEndType) {
		this.reserEndType = reserEndType;
	}


	@Column(name="RESER_FKINP1001")
	public Double getReserFkinp1001() {
		return this.reserFkinp1001;
	}

	public void setReserFkinp1001(Double reserFkinp1001) {
		this.reserFkinp1001 = reserFkinp1001;
	}


	public String getResident() {
		return this.resident;
	}

	public void setResident(String resident) {
		this.resident = resident;
	}


	@Column(name="SANG_BIGO")
	public String getSangBigo() {
		return this.sangBigo;
	}

	public void setSangBigo(String sangBigo) {
		this.sangBigo = sangBigo;
	}


	@Column(name="SANG_CODE")
	public String getSangCode() {
		return this.sangCode;
	}

	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}


	@Column(name="SOGYE_YN")
	public String getSogyeYn() {
		return this.sogyeYn;
	}

	public void setSogyeYn(String sogyeYn) {
		this.sogyeYn = sogyeYn;
	}


	@Column(name="SUSUL_RESER_YN")
	public String getSusulReserYn() {
		return this.susulReserYn;
	}

	public void setSusulReserYn(String susulReserYn) {
		this.susulReserYn = susulReserYn;
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


	public String getTel1() {
		return this.tel1;
	}

	public void setTel1(String tel1) {
		this.tel1 = tel1;
	}


	public String getTel2() {
		return this.tel2;
	}

	public void setTel2(String tel2) {
		this.tel2 = tel2;
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
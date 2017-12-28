package nta.med.core.domain.inp;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INP1004 database table.
 * 
 */
@Entity
@Table(name = "INP1004")
public class Inp1004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address1;
	private String address2;
	private String bigo;
	private Date birth;
	private String boninGubun;
	private String bunho;
	private String hospCode;
	private String juminNo1;
	private String juminNo2;
	private String liveYn;
	private String name;
	private String name2;
	private Double priority;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private String telGubun;
	private String telGubun2;
	private String telGubun3;
	private String tel1;
	private String tel2;
	private String tel3;
	private Date updDate;
	private String updId;
	private String withYn;
	private String zipCode1;
	private String zipCode2;

	public Inp1004() {
	}


	public String getAddress1() {
		return this.address1;
	}

	public void setAddress1(String address1) {
		this.address1 = address1;
	}


	public String getAddress2() {
		return this.address2;
	}

	public void setAddress2(String address2) {
		this.address2 = address2;
	}


	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	public Date getBirth() {
		return this.birth;
	}

	public void setBirth(Date birth) {
		this.birth = birth;
	}


	@Column(name="BONIN_GUBUN")
	public String getBoninGubun() {
		return this.boninGubun;
	}

	public void setBoninGubun(String boninGubun) {
		this.boninGubun = boninGubun;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUMIN_NO1")
	public String getJuminNo1() {
		return this.juminNo1;
	}

	public void setJuminNo1(String juminNo1) {
		this.juminNo1 = juminNo1;
	}


	@Column(name="JUMIN_NO2")
	public String getJuminNo2() {
		return this.juminNo2;
	}

	public void setJuminNo2(String juminNo2) {
		this.juminNo2 = juminNo2;
	}


	@Column(name="LIVE_YN")
	public String getLiveYn() {
		return this.liveYn;
	}

	public void setLiveYn(String liveYn) {
		this.liveYn = liveYn;
	}


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}


	public String getName2() {
		return this.name2;
	}

	public void setName2(String name2) {
		this.name2 = name2;
	}


	public Double getPriority() {
		return this.priority;
	}

	public void setPriority(Double priority) {
		this.priority = priority;
	}


	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
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


	@Column(name="TEL_GUBUN")
	public String getTelGubun() {
		return this.telGubun;
	}

	public void setTelGubun(String telGubun) {
		this.telGubun = telGubun;
	}


	@Column(name="TEL_GUBUN2")
	public String getTelGubun2() {
		return this.telGubun2;
	}

	public void setTelGubun2(String telGubun2) {
		this.telGubun2 = telGubun2;
	}


	@Column(name="TEL_GUBUN3")
	public String getTelGubun3() {
		return this.telGubun3;
	}

	public void setTelGubun3(String telGubun3) {
		this.telGubun3 = telGubun3;
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


	public String getTel3() {
		return this.tel3;
	}

	public void setTel3(String tel3) {
		this.tel3 = tel3;
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


	@Column(name="WITH_YN")
	public String getWithYn() {
		return this.withYn;
	}

	public void setWithYn(String withYn) {
		this.withYn = withYn;
	}


	@Column(name="ZIP_CODE1")
	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}


	@Column(name="ZIP_CODE2")
	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}

}
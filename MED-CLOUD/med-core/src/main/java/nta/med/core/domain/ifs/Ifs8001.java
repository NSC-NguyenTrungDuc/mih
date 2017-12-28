package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS8001 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs8001.findAll", query="SELECT i FROM Ifs8001 i")
public class Ifs8001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address;
	private String biko;
	private String birthday;
	private String dataKubun;
	private String fax;
	private String hospCode;
	private String kanjaFname;
	private String kanjaKanaFname;
	private String kanjaKanaLname;
	private String kanjaLname;
	private String kanjaNo;
	private String mobile;
	private double pSeq;
	private double pkIfsPatient;
	private String post;
	private String remark;
	private String sex;
	private String syoriFlag;
	private Date sysDate;
	private String tel;
	private Date updDate;
	private String userId;

	public Ifs8001() {
	}


	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}


	public String getBiko() {
		return this.biko;
	}

	public void setBiko(String biko) {
		this.biko = biko;
	}


	public String getBirthday() {
		return this.birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}


	@Column(name="DATA_KUBUN")
	public String getDataKubun() {
		return this.dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
	}


	public String getFax() {
		return this.fax;
	}

	public void setFax(String fax) {
		this.fax = fax;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="KANJA_FNAME")
	public String getKanjaFname() {
		return this.kanjaFname;
	}

	public void setKanjaFname(String kanjaFname) {
		this.kanjaFname = kanjaFname;
	}


	@Column(name="KANJA_KANA_FNAME")
	public String getKanjaKanaFname() {
		return this.kanjaKanaFname;
	}

	public void setKanjaKanaFname(String kanjaKanaFname) {
		this.kanjaKanaFname = kanjaKanaFname;
	}


	@Column(name="KANJA_KANA_LNAME")
	public String getKanjaKanaLname() {
		return this.kanjaKanaLname;
	}

	public void setKanjaKanaLname(String kanjaKanaLname) {
		this.kanjaKanaLname = kanjaKanaLname;
	}


	@Column(name="KANJA_LNAME")
	public String getKanjaLname() {
		return this.kanjaLname;
	}

	public void setKanjaLname(String kanjaLname) {
		this.kanjaLname = kanjaLname;
	}


	@Column(name="KANJA_NO")
	public String getKanjaNo() {
		return this.kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}


	public String getMobile() {
		return this.mobile;
	}

	public void setMobile(String mobile) {
		this.mobile = mobile;
	}


	@Column(name="P_SEQ")
	public double getPSeq() {
		return this.pSeq;
	}

	public void setPSeq(double pSeq) {
		this.pSeq = pSeq;
	}


	@Column(name="PK_IFS_PATIENT")
	public double getPkIfsPatient() {
		return this.pkIfsPatient;
	}

	public void setPkIfsPatient(double pkIfsPatient) {
		this.pkIfsPatient = pkIfsPatient;
	}


	public String getPost() {
		return this.post;
	}

	public void setPost(String post) {
		this.post = post;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	@Column(name="SYORI_FLAG")
	public String getSyoriFlag() {
		return this.syoriFlag;
	}

	public void setSyoriFlag(String syoriFlag) {
		this.syoriFlag = syoriFlag;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
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


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}
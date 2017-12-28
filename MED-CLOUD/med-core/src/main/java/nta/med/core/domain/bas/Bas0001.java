package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the BAS0001 database table.
 *
 */
@Entity
@Table(name = "BAS0001")
public class Bas0001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address;
	private String address1;
	private String bankAccName;
	private String bankJijum;
	private String bankName;
	private String bankNo;
	private String countryCode;
	private String director;
	private String dodobuhyeunNo;
	private String email;
	private Date endDate;
	private String fax;
	private String gwaGubun;
	private String homepage;
	private String hospCode;

	private String hospJinGubun;
	private String jaedanName;
	private Date openDate;
	private String orcaGigwanCode;
	private String presidentName;
	private String rousaiYoyangGiho;
	private String sijungchonNo;
	private String simpleYoyangName;
	private Double singoHoCnt;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private String tel;
	private String tel1;
	private Double totBed;
	private Date updDate;
	private String updId;
	private String upperHospCode;
	private String yoyangGiho;
	private String yoyangName;
	private String yoyangName2;
	private String zipCode;
	private String zipCode1;
	private String zipCode2;
	private String language;
	private int shardingId;
	private String hospGroupCd;
	private int hospSysId;
	private String acctRefId;
	private String revision;
	private String groupCode;
	private String vpnYn;
	private Integer timeZone;
	private Date certExpired;
	
	public Bas0001() {
	}

	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getAddress1() {
		return this.address1;
	}

	public void setAddress1(String address1) {
		this.address1 = address1;
	}

	@Column(name = "BANK_ACC_NAME")
	public String getBankAccName() {
		return this.bankAccName;
	}

	public void setBankAccName(String bankAccName) {
		this.bankAccName = bankAccName;
	}

	@Column(name = "BANK_JIJUM")
	public String getBankJijum() {
		return this.bankJijum;
	}

	public void setBankJijum(String bankJijum) {
		this.bankJijum = bankJijum;
	}

	@Column(name = "BANK_NAME")
	public String getBankName() {
		return this.bankName;
	}

	public void setBankName(String bankName) {
		this.bankName = bankName;
	}

	@Column(name = "BANK_NO")
	public String getBankNo() {
		return this.bankNo;
	}

	public void setBankNo(String bankNo) {
		this.bankNo = bankNo;
	}

	@Column(name = "COUNTRY_CODE")
	public String getCountryCode() {
		return this.countryCode;
	}

	public void setCountryCode(String countryCode) {
		this.countryCode = countryCode;
	}

	public String getDirector() {
		return this.director;
	}

	public void setDirector(String director) {
		this.director = director;
	}

	@Column(name = "DODOBUHYEUN_NO")
	public String getDodobuhyeunNo() {
		return this.dodobuhyeunNo;
	}

	public void setDodobuhyeunNo(String dodobuhyeunNo) {
		this.dodobuhyeunNo = dodobuhyeunNo;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getFax() {
		return this.fax;
	}

	public void setFax(String fax) {
		this.fax = fax;
	}

	@Column(name = "GWA_GUBUN")
	public String getGwaGubun() {
		return this.gwaGubun;
	}

	public void setGwaGubun(String gwaGubun) {
		this.gwaGubun = gwaGubun;
	}

	public String getHomepage() {
		return this.homepage;
	}

	public void setHomepage(String homepage) {
		this.homepage = homepage;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "HOSP_JIN_GUBUN")
	public String getHospJinGubun() {
		return this.hospJinGubun;
	}

	public void setHospJinGubun(String hospJinGubun) {
		this.hospJinGubun = hospJinGubun;
	}

	@Column(name = "JAEDAN_NAME")
	public String getJaedanName() {
		return this.jaedanName;
	}

	public void setJaedanName(String jaedanName) {
		this.jaedanName = jaedanName;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "OPEN_DATE")
	public Date getOpenDate() {
		return this.openDate;
	}

	public void setOpenDate(Date openDate) {
		this.openDate = openDate;
	}

	@Column(name = "ORCA_GIGWAN_CODE")
	public String getOrcaGigwanCode() {
		return this.orcaGigwanCode;
	}

	public void setOrcaGigwanCode(String orcaGigwanCode) {
		this.orcaGigwanCode = orcaGigwanCode;
	}

	@Column(name = "PRESIDENT_NAME")
	public String getPresidentName() {
		return this.presidentName;
	}

	public void setPresidentName(String presidentName) {
		this.presidentName = presidentName;
	}

	@Column(name = "ROUSAI_YOYANG_GIHO")
	public String getRousaiYoyangGiho() {
		return this.rousaiYoyangGiho;
	}

	public void setRousaiYoyangGiho(String rousaiYoyangGiho) {
		this.rousaiYoyangGiho = rousaiYoyangGiho;
	}

	@Column(name = "SIJUNGCHON_NO")
	public String getSijungchonNo() {
		return this.sijungchonNo;
	}

	public void setSijungchonNo(String sijungchonNo) {
		this.sijungchonNo = sijungchonNo;
	}

	@Column(name = "SIMPLE_YOYANG_NAME")
	public String getSimpleYoyangName() {
		return this.simpleYoyangName;
	}

	public void setSimpleYoyangName(String simpleYoyangName) {
		this.simpleYoyangName = simpleYoyangName;
	}

	@Column(name = "SINGO_HO_CNT")
	public Double getSingoHoCnt() {
		return this.singoHoCnt;
	}

	public void setSingoHoCnt(Double singoHoCnt) {
		this.singoHoCnt = singoHoCnt;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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

	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getTel1() {
		return this.tel1;
	}

	public void setTel1(String tel1) {
		this.tel1 = tel1;
	}

	@Column(name = "TOT_BED")
	public Double getTotBed() {
		return this.totBed;
	}

	public void setTotBed(Double totBed) {
		this.totBed = totBed;
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

	@Column(name = "UPPER_HOSP_CODE")
	public String getUpperHospCode() {
		return this.upperHospCode;
	}

	public void setUpperHospCode(String upperHospCode) {
		this.upperHospCode = upperHospCode;
	}

	@Column(name = "YOYANG_GIHO")
	public String getYoyangGiho() {
		return this.yoyangGiho;
	}

	public void setYoyangGiho(String yoyangGiho) {
		this.yoyangGiho = yoyangGiho;
	}

	@Column(name = "YOYANG_NAME")
	public String getYoyangName() {
		return this.yoyangName;
	}

	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}

	@Column(name = "YOYANG_NAME2")
	public String getYoyangName2() {
		return this.yoyangName2;
	}

	public void setYoyangName2(String yoyangName2) {
		this.yoyangName2 = yoyangName2;
	}

	@Column(name = "ZIP_CODE")
	public String getZipCode() {
		return this.zipCode;
	}

	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}

	@Column(name = "ZIP_CODE1")
	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}

	@Column(name = "ZIP_CODE2")
	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}

	@Column(name = "LANGUAGE")
	public String getLanguage() {
		return this.language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

	@Column(name = "SHARDING_ID")
	public Integer getShardingId() {
		return this.shardingId;
	}

	public void setShardingId(Integer shardingId) {
		this.shardingId = shardingId;
	}

	@Column(name = "HOSP_GROUP_CD")
	public String getHospGroupCd() {
		return this.hospGroupCd;
	}

	public void setHospGroupCd(String hospGroupCd) {
		this.hospGroupCd = hospGroupCd;
	}

	@Column(name = "HOSP_SYS_ID")
	public Integer getHospSysId() {
		return this.hospSysId;
	}

	@Column(name = "ACCT_REF_ID")
	public String getAcctRefId() {
		return acctRefId;
	}

	public void setAcctRefId(String acctRefId) {
		this.acctRefId = acctRefId;
	}

	public void setHospSysId(Integer hospSysId) {
		this.hospSysId = hospSysId;
	}
	@Column(name = "REVISION")
	public String getRevision() {
		return revision;
	}

	public void setRevision(String revision) {
		this.revision = revision;
	}

	@Column(name = "GROUP_CODE")
	public String getGroupCode() {
		return groupCode;
	}

	public void setGroupCode(String groupCode) {
		this.groupCode = groupCode;
	}

	@Column(name = "VPN_YN")
	public String getVpnYn() {
		return vpnYn;
	}

	public void setVpnYn(String vpnYn) {
		this.vpnYn = vpnYn;
	}

	@Column(name = "TIME_ZONE")
	public Integer getTimeZone() {
		return timeZone;
	}

	public void setTimeZone(Integer timeZone) {
		this.timeZone = timeZone;
	}
	
	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "CERT_EXPIRED")
	public Date getCertExpired() {
		return certExpired;
	}

	public void setCertExpired(Date certExpired) {
		this.certExpired = certExpired;
	}
	
}
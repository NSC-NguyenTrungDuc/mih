package nta.med.data.model.ihis.orca;

import java.util.Date;

public class ORCALibGetClaimInsuredInfo {
	private Date sysDate             ;
	private String sysId               ;
	private String updDate             ;
	private String updId               ;
	private String hospCode            ;
	private Double fkoif1101            ;
	private Double pkoif2101            ;
	private String docUid              ;
	private String cmId                ;
	private String depId               ;
	private String depname             ;
	private String license              ;
	private String insurCode           ;
	private String insurName           ;
	private String insurNum            ;
	private String clientGroup         ;
	private String clientNum           ;
	private String familyCode          ;
	private String suname1              ;
	private String suname2              ;
	private String suname3              ;
	private String startDateA         ;
	private String endDateA           ;
	private String inratio              ;
	private String outratio             ;
	private String insuredId           ;
	private String insuredName         ;
	private String workId              ;
	private String workName            ;
	private Double pkoif2102            ;
	private Double priority             ;
	private String providerName        ;
	private String provider             ;
	private String recipient            ;
	private String startDateB         ;
	private String endDateB           ;
	private String ratioType           ;
	private String ratio                ;
	private Double pkoif2103            ;
	private String diseases             ;
	private Double pkoif2104            ;
	private String address              ;
	private String addrCode            ;
	private String addrFull            ;
	private String prefecture           ;
	private String cityD               ;
	private String town                 ;
	private String homeNum             ;
	private String zip                  ;
	private String countryD            ;
	private Double pkoif2105            ;
	private String phone                ;
	private String telCode             ;
	private String area                 ;
	private String cityE               ;
	private String num                  ;
	private String extension            ;
	private String countryE            ;
	private String memo                 ;
	public ORCALibGetClaimInsuredInfo(Date sysDate, String sysId,
			String updDate, String updId, String hospCode, Double fkoif1101,
			Double pkoif2101, String docUid, String cmId, String depId,
			String depname, String license, String insurCode, String insurName,
			String insurNum, String clientGroup, String clientNum,
			String familyCode, String suname1, String suname2, String suname3,
			String startDateA, String endDateA, String inratio,
			String outratio, String insuredId, String insuredName,
			String workId, String workName, Double pkoif2102, Double priority,
			String providerName, String provider, String recipient,
			String startDateB, String endDateB, String ratioType, String ratio,
			Double pkoif2103, String diseases, Double pkoif2104,
			String address, String addrCode, String addrFull,
			String prefecture, String cityD, String town, String homeNum,
			String zip, String countryD, Double pkoif2105, String phone,
			String telCode, String area, String cityE, String num,
			String extension, String countryE, String memo) {
		super();
		this.sysDate = sysDate;
		this.sysId = sysId;
		this.updDate = updDate;
		this.updId = updId;
		this.hospCode = hospCode;
		this.fkoif1101 = fkoif1101;
		this.pkoif2101 = pkoif2101;
		this.docUid = docUid;
		this.cmId = cmId;
		this.depId = depId;
		this.depname = depname;
		this.license = license;
		this.insurCode = insurCode;
		this.insurName = insurName;
		this.insurNum = insurNum;
		this.clientGroup = clientGroup;
		this.clientNum = clientNum;
		this.familyCode = familyCode;
		this.suname1 = suname1;
		this.suname2 = suname2;
		this.suname3 = suname3;
		this.startDateA = startDateA;
		this.endDateA = endDateA;
		this.inratio = inratio;
		this.outratio = outratio;
		this.insuredId = insuredId;
		this.insuredName = insuredName;
		this.workId = workId;
		this.workName = workName;
		this.pkoif2102 = pkoif2102;
		this.priority = priority;
		this.providerName = providerName;
		this.provider = provider;
		this.recipient = recipient;
		this.startDateB = startDateB;
		this.endDateB = endDateB;
		this.ratioType = ratioType;
		this.ratio = ratio;
		this.pkoif2103 = pkoif2103;
		this.diseases = diseases;
		this.pkoif2104 = pkoif2104;
		this.address = address;
		this.addrCode = addrCode;
		this.addrFull = addrFull;
		this.prefecture = prefecture;
		this.cityD = cityD;
		this.town = town;
		this.homeNum = homeNum;
		this.zip = zip;
		this.countryD = countryD;
		this.pkoif2105 = pkoif2105;
		this.phone = phone;
		this.telCode = telCode;
		this.area = area;
		this.cityE = cityE;
		this.num = num;
		this.extension = extension;
		this.countryE = countryE;
		this.memo = memo;
	}
	public Date getSysDate() {
		return sysDate;
	}
	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getUpdDate() {
		return updDate;
	}
	public void setUpdDate(String updDate) {
		this.updDate = updDate;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public Double getFkoif1101() {
		return fkoif1101;
	}
	public void setFkoif1101(Double fkoif1101) {
		this.fkoif1101 = fkoif1101;
	}
	public Double getPkoif2101() {
		return pkoif2101;
	}
	public void setPkoif2101(Double pkoif2101) {
		this.pkoif2101 = pkoif2101;
	}
	public String getDocUid() {
		return docUid;
	}
	public void setDocUid(String docUid) {
		this.docUid = docUid;
	}
	public String getCmId() {
		return cmId;
	}
	public void setCmId(String cmId) {
		this.cmId = cmId;
	}
	public String getDepId() {
		return depId;
	}
	public void setDepId(String depId) {
		this.depId = depId;
	}
	public String getDepname() {
		return depname;
	}
	public void setDepname(String depname) {
		this.depname = depname;
	}
	public String getLicense() {
		return license;
	}
	public void setLicense(String license) {
		this.license = license;
	}
	public String getInsurCode() {
		return insurCode;
	}
	public void setInsurCode(String insurCode) {
		this.insurCode = insurCode;
	}
	public String getInsurName() {
		return insurName;
	}
	public void setInsurName(String insurName) {
		this.insurName = insurName;
	}
	public String getInsurNum() {
		return insurNum;
	}
	public void setInsurNum(String insurNum) {
		this.insurNum = insurNum;
	}
	public String getClientGroup() {
		return clientGroup;
	}
	public void setClientGroup(String clientGroup) {
		this.clientGroup = clientGroup;
	}
	public String getClientNum() {
		return clientNum;
	}
	public void setClientNum(String clientNum) {
		this.clientNum = clientNum;
	}
	public String getFamilyCode() {
		return familyCode;
	}
	public void setFamilyCode(String familyCode) {
		this.familyCode = familyCode;
	}
	public String getSuname1() {
		return suname1;
	}
	public void setSuname1(String suname1) {
		this.suname1 = suname1;
	}
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public String getSuname3() {
		return suname3;
	}
	public void setSuname3(String suname3) {
		this.suname3 = suname3;
	}
	public String getStartDateA() {
		return startDateA;
	}
	public void setStartDateA(String startDateA) {
		this.startDateA = startDateA;
	}
	public String getEndDateA() {
		return endDateA;
	}
	public void setEndDateA(String endDateA) {
		this.endDateA = endDateA;
	}
	public String getInratio() {
		return inratio;
	}
	public void setInratio(String inratio) {
		this.inratio = inratio;
	}
	public String getOutratio() {
		return outratio;
	}
	public void setOutratio(String outratio) {
		this.outratio = outratio;
	}
	public String getInsuredId() {
		return insuredId;
	}
	public void setInsuredId(String insuredId) {
		this.insuredId = insuredId;
	}
	public String getInsuredName() {
		return insuredName;
	}
	public void setInsuredName(String insuredName) {
		this.insuredName = insuredName;
	}
	public String getWorkId() {
		return workId;
	}
	public void setWorkId(String workId) {
		this.workId = workId;
	}
	public String getWorkName() {
		return workName;
	}
	public void setWorkName(String workName) {
		this.workName = workName;
	}
	public Double getPkoif2102() {
		return pkoif2102;
	}
	public void setPkoif2102(Double pkoif2102) {
		this.pkoif2102 = pkoif2102;
	}
	public Double getPriority() {
		return priority;
	}
	public void setPriority(Double priority) {
		this.priority = priority;
	}
	public String getProviderName() {
		return providerName;
	}
	public void setProviderName(String providerName) {
		this.providerName = providerName;
	}
	public String getProvider() {
		return provider;
	}
	public void setProvider(String provider) {
		this.provider = provider;
	}
	public String getRecipient() {
		return recipient;
	}
	public void setRecipient(String recipient) {
		this.recipient = recipient;
	}
	public String getStartDateB() {
		return startDateB;
	}
	public void setStartDateB(String startDateB) {
		this.startDateB = startDateB;
	}
	public String getEndDateB() {
		return endDateB;
	}
	public void setEndDateB(String endDateB) {
		this.endDateB = endDateB;
	}
	public String getRatioType() {
		return ratioType;
	}
	public void setRatioType(String ratioType) {
		this.ratioType = ratioType;
	}
	public String getRatio() {
		return ratio;
	}
	public void setRatio(String ratio) {
		this.ratio = ratio;
	}
	public Double getPkoif2103() {
		return pkoif2103;
	}
	public void setPkoif2103(Double pkoif2103) {
		this.pkoif2103 = pkoif2103;
	}
	public String getDiseases() {
		return diseases;
	}
	public void setDiseases(String diseases) {
		this.diseases = diseases;
	}
	public Double getPkoif2104() {
		return pkoif2104;
	}
	public void setPkoif2104(Double pkoif2104) {
		this.pkoif2104 = pkoif2104;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getAddrCode() {
		return addrCode;
	}
	public void setAddrCode(String addrCode) {
		this.addrCode = addrCode;
	}
	public String getAddrFull() {
		return addrFull;
	}
	public void setAddrFull(String addrFull) {
		this.addrFull = addrFull;
	}
	public String getPrefecture() {
		return prefecture;
	}
	public void setPrefecture(String prefecture) {
		this.prefecture = prefecture;
	}
	public String getCityD() {
		return cityD;
	}
	public void setCityD(String cityD) {
		this.cityD = cityD;
	}
	public String getTown() {
		return town;
	}
	public void setTown(String town) {
		this.town = town;
	}
	public String getHomeNum() {
		return homeNum;
	}
	public void setHomeNum(String homeNum) {
		this.homeNum = homeNum;
	}
	public String getZip() {
		return zip;
	}
	public void setZip(String zip) {
		this.zip = zip;
	}
	public String getCountryD() {
		return countryD;
	}
	public void setCountryD(String countryD) {
		this.countryD = countryD;
	}
	public Double getPkoif2105() {
		return pkoif2105;
	}
	public void setPkoif2105(Double pkoif2105) {
		this.pkoif2105 = pkoif2105;
	}
	public String getPhone() {
		return phone;
	}
	public void setPhone(String phone) {
		this.phone = phone;
	}
	public String getTelCode() {
		return telCode;
	}
	public void setTelCode(String telCode) {
		this.telCode = telCode;
	}
	public String getArea() {
		return area;
	}
	public void setArea(String area) {
		this.area = area;
	}
	public String getCityE() {
		return cityE;
	}
	public void setCityE(String cityE) {
		this.cityE = cityE;
	}
	public String getNum() {
		return num;
	}
	public void setNum(String num) {
		this.num = num;
	}
	public String getExtension() {
		return extension;
	}
	public void setExtension(String extension) {
		this.extension = extension;
	}
	public String getCountryE() {
		return countryE;
	}
	public void setCountryE(String countryE) {
		this.countryE = countryE;
	}
	public String getMemo() {
		return memo;
	}
	public void setMemo(String memo) {
		this.memo = memo;
	}
	
}

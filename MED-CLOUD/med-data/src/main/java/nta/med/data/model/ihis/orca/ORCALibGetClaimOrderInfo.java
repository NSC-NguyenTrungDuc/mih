package nta.med.data.model.ihis.orca;

import java.util.Date;

public class ORCALibGetClaimOrderInfo {
	private Date sysDate                ;
	private String sysId                  ;
	private String updDate                ;
	private String updId                  ;
	private String hospCode               ;
	private Double fkoif1101               ;
	private Double pkoif4001               ;
	private String docUid                 ;
	private String cmId                   ;
	private String depId                  ;
	private String depName                ;
	private String license                 ;
	private String doctor                  ;
	private String status                  ;
	private String orderTime              ;
	private String appTime                ;
	private String registTime             ;
	private String performTime            ;
	private String uuid                    ;
	private String insurGubun             ;
	private String insurName              ;
	private String wardId                 ;
	private String wardName               ;
	private String ioFlag                 ;
	private String timeCls                ;
	private Double pkoif4002               ;
	private String clsCode                ;
	private String clsCodename           ;
	private String clsCodeTd             ;
	private String admCode                ;
	private String admCodeName           ;
	private String admMemo                ;
	private String bundNum                ;
	private String memo                    ;
	private Double pkSeq                  ;
	private String subCode                ;
	private String actCode                ;
	private String actCodeName           ;
	private String actCodeTd             ;
	private String aliasCode              ;
	private String numCode                ;
	private String numUnit                ;
	private Double numSu                  ;
	private String duration                ;
	private String eventStart             ;
	private String eventEnd               ;
	private String eventName              ;
	private String actMemo                ;
	public ORCALibGetClaimOrderInfo(Date sysDate, String sysId, String updDate,
			String updId, String hospCode, Double fkoif1101, Double pkoif4001,
			String docUid, String cmId, String depId, String depName,
			String license, String doctor, String status, String orderTime,
			String appTime, String registTime, String performTime, String uuid,
			String insurGubun, String insurName, String wardId,
			String wardName, String ioFlag, String timeCls, Double pkoif4002,
			String clsCode, String clsCodename, String clsCodeTd,
			String admCode, String admCodeName, String admMemo, String bundNum,
			String memo, Double pkSeq, String subCode, String actCode,
			String actCodeName, String actCodeTd, String aliasCode,
			String numCode, String numUnit, Double numSu, String duration,
			String eventStart, String eventEnd, String eventName, String actMemo) {
		super();
		this.sysDate = sysDate;
		this.sysId = sysId;
		this.updDate = updDate;
		this.updId = updId;
		this.hospCode = hospCode;
		this.fkoif1101 = fkoif1101;
		this.pkoif4001 = pkoif4001;
		this.docUid = docUid;
		this.cmId = cmId;
		this.depId = depId;
		this.depName = depName;
		this.license = license;
		this.doctor = doctor;
		this.status = status;
		this.orderTime = orderTime;
		this.appTime = appTime;
		this.registTime = registTime;
		this.performTime = performTime;
		this.uuid = uuid;
		this.insurGubun = insurGubun;
		this.insurName = insurName;
		this.wardId = wardId;
		this.wardName = wardName;
		this.ioFlag = ioFlag;
		this.timeCls = timeCls;
		this.pkoif4002 = pkoif4002;
		this.clsCode = clsCode;
		this.clsCodename = clsCodename;
		this.clsCodeTd = clsCodeTd;
		this.admCode = admCode;
		this.admCodeName = admCodeName;
		this.admMemo = admMemo;
		this.bundNum = bundNum;
		this.memo = memo;
		this.pkSeq = pkSeq;
		this.subCode = subCode;
		this.actCode = actCode;
		this.actCodeName = actCodeName;
		this.actCodeTd = actCodeTd;
		this.aliasCode = aliasCode;
		this.numCode = numCode;
		this.numUnit = numUnit;
		this.numSu = numSu;
		this.duration = duration;
		this.eventStart = eventStart;
		this.eventEnd = eventEnd;
		this.eventName = eventName;
		this.actMemo = actMemo;
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
	public Double getPkoif4001() {
		return pkoif4001;
	}
	public void setPkoif4001(Double pkoif4001) {
		this.pkoif4001 = pkoif4001;
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
	public String getDepName() {
		return depName;
	}
	public void setDepName(String depName) {
		this.depName = depName;
	}
	public String getLicense() {
		return license;
	}
	public void setLicense(String license) {
		this.license = license;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public String getOrderTime() {
		return orderTime;
	}
	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}
	public String getAppTime() {
		return appTime;
	}
	public void setAppTime(String appTime) {
		this.appTime = appTime;
	}
	public String getRegistTime() {
		return registTime;
	}
	public void setRegistTime(String registTime) {
		this.registTime = registTime;
	}
	public String getPerformTime() {
		return performTime;
	}
	public void setPerformTime(String performTime) {
		this.performTime = performTime;
	}
	public String getUuid() {
		return uuid;
	}
	public void setUuid(String uuid) {
		this.uuid = uuid;
	}
	public String getInsurGubun() {
		return insurGubun;
	}
	public void setInsurGubun(String insurGubun) {
		this.insurGubun = insurGubun;
	}
	public String getInsurName() {
		return insurName;
	}
	public void setInsurName(String insurName) {
		this.insurName = insurName;
	}
	public String getWardId() {
		return wardId;
	}
	public void setWardId(String wardId) {
		this.wardId = wardId;
	}
	public String getWardName() {
		return wardName;
	}
	public void setWardName(String wardName) {
		this.wardName = wardName;
	}
	public String getIoFlag() {
		return ioFlag;
	}
	public void setIoFlag(String ioFlag) {
		this.ioFlag = ioFlag;
	}
	public String getTimeCls() {
		return timeCls;
	}
	public void setTimeCls(String timeCls) {
		this.timeCls = timeCls;
	}
	public Double getPkoif4002() {
		return pkoif4002;
	}
	public void setPkoif4002(Double pkoif4002) {
		this.pkoif4002 = pkoif4002;
	}
	public String getClsCode() {
		return clsCode;
	}
	public void setClsCode(String clsCode) {
		this.clsCode = clsCode;
	}
	public String getClsCodename() {
		return clsCodename;
	}
	public void setClsCodename(String clsCodename) {
		this.clsCodename = clsCodename;
	}
	public String getClsCodeTd() {
		return clsCodeTd;
	}
	public void setClsCodeTd(String clsCodeTd) {
		this.clsCodeTd = clsCodeTd;
	}
	public String getAdmCode() {
		return admCode;
	}
	public void setAdmCode(String admCode) {
		this.admCode = admCode;
	}
	public String getAdmCodeName() {
		return admCodeName;
	}
	public void setAdmCodeName(String admCodeName) {
		this.admCodeName = admCodeName;
	}
	public String getAdmMemo() {
		return admMemo;
	}
	public void setAdmMemo(String admMemo) {
		this.admMemo = admMemo;
	}
	public String getBundNum() {
		return bundNum;
	}
	public void setBundNum(String bundNum) {
		this.bundNum = bundNum;
	}
	public String getMemo() {
		return memo;
	}
	public void setMemo(String memo) {
		this.memo = memo;
	}
	public Double getPkSeq() {
		return pkSeq;
	}
	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}
	public String getSubCode() {
		return subCode;
	}
	public void setSubCode(String subCode) {
		this.subCode = subCode;
	}
	public String getActCode() {
		return actCode;
	}
	public void setActCode(String actCode) {
		this.actCode = actCode;
	}
	public String getActCodeName() {
		return actCodeName;
	}
	public void setActCodeName(String actCodeName) {
		this.actCodeName = actCodeName;
	}
	public String getActCodeTd() {
		return actCodeTd;
	}
	public void setActCodeTd(String actCodeTd) {
		this.actCodeTd = actCodeTd;
	}
	public String getAliasCode() {
		return aliasCode;
	}
	public void setAliasCode(String aliasCode) {
		this.aliasCode = aliasCode;
	}
	public String getNumCode() {
		return numCode;
	}
	public void setNumCode(String numCode) {
		this.numCode = numCode;
	}
	public String getNumUnit() {
		return numUnit;
	}
	public void setNumUnit(String numUnit) {
		this.numUnit = numUnit;
	}
	public Double getNumSu() {
		return numSu;
	}
	public void setNumSu(Double numSu) {
		this.numSu = numSu;
	}
	public String getDuration() {
		return duration;
	}
	public void setDuration(String duration) {
		this.duration = duration;
	}
	public String getEventStart() {
		return eventStart;
	}
	public void setEventStart(String eventStart) {
		this.eventStart = eventStart;
	}
	public String getEventEnd() {
		return eventEnd;
	}
	public void setEventEnd(String eventEnd) {
		this.eventEnd = eventEnd;
	}
	public String getEventName() {
		return eventName;
	}
	public void setEventName(String eventName) {
		this.eventName = eventName;
	}
	public String getActMemo() {
		return actMemo;
	}
	public void setActMemo(String actMemo) {
		this.actMemo = actMemo;
	}

}

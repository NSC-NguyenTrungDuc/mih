package nta.med.data.model.ihis.cpls;

import java.util.Date;

public class CPL2010U02grdSpecimenInfo {
	private String specimenSer;
    private String specimenCode;
    private String specimenCodeName;
    private String bunho;
    private String suname;
    private String gwaName;
    private String hoDong;
    private String hoCode;
    private String jubsuja;
    private String jundalGubun;
    private Date gumJubsuDate;
    private String gumJubsuTime;
    private String gumJubsuja;
    private String remark;
    private String jubsuFlag;
    private String checkYn;
	public CPL2010U02grdSpecimenInfo(String specimenSer, String specimenCode, String specimenCodeName, String bunho,
			String suname, String gwaName, String hoDong, String hoCode, String jubsuja, String jundalGubun,
			Date gumJubsuDate, String gumJubsuTime, String gumJubsuja, String remark, String jubsuFlag,
			String checkYn) {
		super();
		this.specimenSer = specimenSer;
		this.specimenCode = specimenCode;
		this.specimenCodeName = specimenCodeName;
		this.bunho = bunho;
		this.suname = suname;
		this.gwaName = gwaName;
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.jubsuja = jubsuja;
		this.jundalGubun = jundalGubun;
		this.gumJubsuDate = gumJubsuDate;
		this.gumJubsuTime = gumJubsuTime;
		this.gumJubsuja = gumJubsuja;
		this.remark = remark;
		this.jubsuFlag = jubsuFlag;
		this.checkYn = checkYn;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public String getSpecimenCode() {
		return specimenCode;
	}
	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}
	public String getSpecimenCodeName() {
		return specimenCodeName;
	}
	public void setSpecimenCodeName(String specimenCodeName) {
		this.specimenCodeName = specimenCodeName;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public String getHoCode() {
		return hoCode;
	}
	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}
	public String getJubsuja() {
		return jubsuja;
	}
	public void setJubsuja(String jubsuja) {
		this.jubsuja = jubsuja;
	}
	public String getJundalGubun() {
		return jundalGubun;
	}
	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}
	public Date getGumJubsuDate() {
		return gumJubsuDate;
	}
	public void setGumJubsuDate(Date gumJubsuDate) {
		this.gumJubsuDate = gumJubsuDate;
	}
	public String getGumJubsuTime() {
		return gumJubsuTime;
	}
	public void setGumJubsuTime(String gumJubsuTime) {
		this.gumJubsuTime = gumJubsuTime;
	}
	public String getGumJubsuja() {
		return gumJubsuja;
	}
	public void setGumJubsuja(String gumJubsuja) {
		this.gumJubsuja = gumJubsuja;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getJubsuFlag() {
		return jubsuFlag;
	}
	public void setJubsuFlag(String jubsuFlag) {
		this.jubsuFlag = jubsuFlag;
	}
	public String getCheckYn() {
		return checkYn;
	}
	public void setCheckYn(String checkYn) {
		this.checkYn = checkYn;
	}
    
}

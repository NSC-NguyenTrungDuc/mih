package nta.med.data.model.ihis.cpls;

import java.math.BigInteger;
import java.sql.Timestamp;

public class CPL3010U00GrdPartListItemInfo {
	private String labNo;
    private String specimenSer;
    private String bunho;
    private String suname2;
    private String fnBasLoadGwaName;
    private String hoDong;
    private Timestamp partJubsuDate;
    private String partJubsuTime;
    private String partJubsuja;
    private String jubsuja;
    private String remark;
    private String partJubsuFlag;
    private BigInteger fkocs;
    private String inOutGubun;
    private String doctorName;
    private String tubeName;
    private String emergency;
    private String sunabYn;
    private String resultYn;
    private String labelOneMore;
	public CPL3010U00GrdPartListItemInfo(String labNo, String specimenSer,
			String bunho, String suname2, String fnBasLoadGwaName,
			String hoDong, Timestamp partJubsuDate, String partJubsuTime,
			String partJubsuja, String jubsuja, String remark,
			String partJubsuFlag, BigInteger fkocs, String inOutGubun,
			String doctorName, String tubeName, String emergency,
			String sunabYn, String resultYn, String labelOneMore) {
		super();
		this.labNo = labNo;
		this.specimenSer = specimenSer;
		this.bunho = bunho;
		this.suname2 = suname2;
		this.fnBasLoadGwaName = fnBasLoadGwaName;
		this.hoDong = hoDong;
		this.partJubsuDate = partJubsuDate;
		this.partJubsuTime = partJubsuTime;
		this.partJubsuja = partJubsuja;
		this.jubsuja = jubsuja;
		this.remark = remark;
		this.partJubsuFlag = partJubsuFlag;
		this.fkocs = fkocs;
		this.inOutGubun = inOutGubun;
		this.doctorName = doctorName;
		this.tubeName = tubeName;
		this.emergency = emergency;
		this.sunabYn = sunabYn;
		this.resultYn = resultYn;
		this.labelOneMore = labelOneMore;
	}
	public String getLabNo() {
		return labNo;
	}
	public void setLabNo(String labNo) {
		this.labNo = labNo;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public String getFnBasLoadGwaName() {
		return fnBasLoadGwaName;
	}
	public void setFnBasLoadGwaName(String fnBasLoadGwaName) {
		this.fnBasLoadGwaName = fnBasLoadGwaName;
	}
	public String getHoDong() {
		return hoDong;
	}
	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}
	public Timestamp getPartJubsuDate() {
		return partJubsuDate;
	}
	public void setPartJubsuDate(Timestamp partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}
	public String getPartJubsuTime() {
		return partJubsuTime;
	}
	public void setPartJubsuTime(String partJubsuTime) {
		this.partJubsuTime = partJubsuTime;
	}
	public String getPartJubsuja() {
		return partJubsuja;
	}
	public void setPartJubsuja(String partJubsuja) {
		this.partJubsuja = partJubsuja;
	}
	public String getJubsuja() {
		return jubsuja;
	}
	public void setJubsuja(String jubsuja) {
		this.jubsuja = jubsuja;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getPartJubsuFlag() {
		return partJubsuFlag;
	}
	public void setPartJubsuFlag(String partJubsuFlag) {
		this.partJubsuFlag = partJubsuFlag;
	}
	public BigInteger getFkocs() {
		return fkocs;
	}
	public void setFkocs(BigInteger fkocs) {
		this.fkocs = fkocs;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getTubeName() {
		return tubeName;
	}
	public void setTubeName(String tubeName) {
		this.tubeName = tubeName;
	}
	public String getEmergency() {
		return emergency;
	}
	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}
	public String getSunabYn() {
		return sunabYn;
	}
	public void setSunabYn(String sunabYn) {
		this.sunabYn = sunabYn;
	}
	public String getResultYn() {
		return resultYn;
	}
	public void setResultYn(String resultYn) {
		this.resultYn = resultYn;
	}
	public String getLabelOneMore() {
		return labelOneMore;
	}
	public void setLabelOneMore(String labelOneMore) {
		this.labelOneMore = labelOneMore;
	}
}
package nta.med.data.model.ihis.adma;

public class ADM101UgrdSystemItemInfo {
	private String grpId      ;
	private String sysId      ;
	private String sysNm      ;
	private Double sysSeq     ;
	private String admSysYn  ;
	private String msgSysYn  ;
	private String sysDesc    ;
	private String mangDept   ;
	private String buseoName1  ;
	private String mangDept1  ;
	private String buseoName2  ;
	public ADM101UgrdSystemItemInfo(String grpId, String sysId, String sysNm,
			Double sysSeq, String admSysYn, String msgSysYn, String sysDesc,
			String mangDept, String buseoName1, String mangDept1,
			String buseoName2) {
		super();
		this.grpId = grpId;
		this.sysId = sysId;
		this.sysNm = sysNm;
		this.sysSeq = sysSeq;
		this.admSysYn = admSysYn;
		this.msgSysYn = msgSysYn;
		this.sysDesc = sysDesc;
		this.mangDept = mangDept;
		this.buseoName1 = buseoName1;
		this.mangDept1 = mangDept1;
		this.buseoName2 = buseoName2;
	}
	public String getGrpId() {
		return grpId;
	}
	public void setGrpId(String grpId) {
		this.grpId = grpId;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getSysNm() {
		return sysNm;
	}
	public void setSysNm(String sysNm) {
		this.sysNm = sysNm;
	}
	public Double getSysSeq() {
		return sysSeq;
	}
	public void setSysSeq(Double sysSeq) {
		this.sysSeq = sysSeq;
	}
	public String getAdmSysYn() {
		return admSysYn;
	}
	public void setAdmSysYn(String admSysYn) {
		this.admSysYn = admSysYn;
	}
	public String getMsgSysYn() {
		return msgSysYn;
	}
	public void setMsgSysYn(String msgSysYn) {
		this.msgSysYn = msgSysYn;
	}
	public String getSysDesc() {
		return sysDesc;
	}
	public void setSysDesc(String sysDesc) {
		this.sysDesc = sysDesc;
	}
	public String getMangDept() {
		return mangDept;
	}
	public void setMangDept(String mangDept) {
		this.mangDept = mangDept;
	}
	public String getBuseoName1() {
		return buseoName1;
	}
	public void setBuseoName1(String buseoName1) {
		this.buseoName1 = buseoName1;
	}
	public String getMangDept1() {
		return mangDept1;
	}
	public void setMangDept1(String mangDept1) {
		this.mangDept1 = mangDept1;
	}
	public String getBuseoName2() {
		return buseoName2;
	}
	public void setBuseoName2(String buseoName2) {
		this.buseoName2 = buseoName2;
	}
	
}

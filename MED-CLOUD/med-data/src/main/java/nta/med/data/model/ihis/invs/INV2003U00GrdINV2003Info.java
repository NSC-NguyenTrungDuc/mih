package nta.med.data.model.ihis.invs;

import java.util.Date;

public class INV2003U00GrdINV2003Info {
	private Double pkinv2003;
	private Date churiDate;
	private String churiTime;
	private String churiBuseo;
	private String chulgoType;
	private String exportCode;
	private Double churiSeq;
	private String jareyoGubun;
	private String remark;
	public INV2003U00GrdINV2003Info(Double pkinv2003, Date churiDate, String churiTime, String churiBuseo,
			String chulgoType, String exportCode, Double churiSeq, String jareyoGubun, String remark) {
		super();
		this.pkinv2003 = pkinv2003;
		this.churiDate = churiDate;
		this.churiTime = churiTime;
		this.churiBuseo = churiBuseo;
		this.chulgoType = chulgoType;
		this.exportCode = exportCode;
		this.churiSeq = churiSeq;
		this.jareyoGubun = jareyoGubun;
		this.remark = remark;
	}
	public Double getPkinv2003() {
		return pkinv2003;
	}
	public void setPkinv2003(Double pkinv2003) {
		this.pkinv2003 = pkinv2003;
	}
	public Date getChuriDate() {
		return churiDate;
	}
	public void setChuriDate(Date churiDate) {
		this.churiDate = churiDate;
	}
	public String getChuriTime() {
		return churiTime;
	}
	public void setChuriTime(String churiTime) {
		this.churiTime = churiTime;
	}
	public String getChuriBuseo() {
		return churiBuseo;
	}
	public void setChuriBuseo(String churiBuseo) {
		this.churiBuseo = churiBuseo;
	}
	public String getChulgoType() {
		return chulgoType;
	}
	public void setChulgoType(String chulgoType) {
		this.chulgoType = chulgoType;
	}
	public String getExportCode() {
		return exportCode;
	}
	public void setExportCode(String exportCode) {
		this.exportCode = exportCode;
	}
	public Double getChuriSeq() {
		return churiSeq;
	}
	public void setChuriSeq(Double churiSeq) {
		this.churiSeq = churiSeq;
	}
	public String getJareyoGubun() {
		return jareyoGubun;
	}
	public void setJareyoGubun(String jareyoGubun) {
		this.jareyoGubun = jareyoGubun;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	
}

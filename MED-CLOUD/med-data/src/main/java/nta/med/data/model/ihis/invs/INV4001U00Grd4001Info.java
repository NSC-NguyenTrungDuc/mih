package nta.med.data.model.ihis.invs;

import java.sql.Date;
import java.sql.Timestamp;

public class INV4001U00Grd4001Info {
	 private Double pkinv4001     ;
	 private Timestamp churiDate    ;
	 private String importTime;
	 private String churiBuseo   ;
	 private String ipgoType     ;
	 private String importCode;
	 private Double churiSeq     ;
	 private String jaeryoGubun  ;
	 private String remark        ;
	 private String inOutGubun  ;
	 private String ipchulType   ;
	 private String rowState     ;
	public INV4001U00Grd4001Info(Double pkinv4001, Timestamp churiDate, String importTime, String churiBuseo,
			String ipgoType, String importCode, Double churiSeq, String jaeryoGubun, String remark, String inOutGubun,
			String ipchulType) {
		super();
		this.pkinv4001 = pkinv4001;
		this.churiDate = churiDate;
		this.importTime = importTime;
		this.churiBuseo = churiBuseo;
		this.ipgoType = ipgoType;
		this.importCode = importCode;
		this.churiSeq = churiSeq;
		this.jaeryoGubun = jaeryoGubun;
		this.remark = remark;
		this.inOutGubun = inOutGubun;
		this.ipchulType = ipchulType;
	}
	public Double getPkinv4001() {
		return pkinv4001;
	}
	public void setPkinv4001(Double pkinv4001) {
		this.pkinv4001 = pkinv4001;
	}
	public Timestamp getChuriDate() {
		return churiDate;
	}
	public void setChuriDate(Timestamp churiDate) {
		this.churiDate = churiDate;
	}
	public String getImportTime() {
		return importTime;
	}
	public void setImportTime(String importTime) {
		this.importTime = importTime;
	}
	public String getChuriBuseo() {
		return churiBuseo;
	}
	public void setChuriBuseo(String churiBuseo) {
		this.churiBuseo = churiBuseo;
	}
	public String getIpgoType() {
		return ipgoType;
	}
	public void setIpgoType(String ipgoType) {
		this.ipgoType = ipgoType;
	}
	public String getImportCode() {
		return importCode;
	}
	public void setImportCode(String importCode) {
		this.importCode = importCode;
	}
	public Double getChuriSeq() {
		return churiSeq;
	}
	public void setChuriSeq(Double churiSeq) {
		this.churiSeq = churiSeq;
	}
	public String getJaeryoGubun() {
		return jaeryoGubun;
	}
	public void setJaeryoGubun(String jaeryoGubun) {
		this.jaeryoGubun = jaeryoGubun;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getInOutGubun() {
		return inOutGubun;
	}
	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}
	public String getIpchulType() {
		return ipchulType;
	}
	public void setIpchulType(String ipchulType) {
		this.ipchulType = ipchulType;
	}
	public String getRowState() {
		return rowState;
	}
	public void setRowState(String rowState) {
		this.rowState = rowState;
	}
	
}

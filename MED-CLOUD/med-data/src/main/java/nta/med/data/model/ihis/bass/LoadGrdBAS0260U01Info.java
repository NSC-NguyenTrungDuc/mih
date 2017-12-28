package nta.med.data.model.ihis.bass;

import java.math.BigDecimal;
import java.math.BigInteger;

public class LoadGrdBAS0260U01Info {
	
	private BigInteger id;
	private String buseoCode;
	private String buseoName;
	private String buseoName2;
	private String buseoGubun;
	private String parentBuseo;
	private String gwa;
	private String gwaName;
	private String gwaName2;
	private String gwaGubun;
	private String parentGwa;
	private String note;
	private String language;
	private BigDecimal activeFlg;
	
	public LoadGrdBAS0260U01Info(BigInteger id, String buseoCode, String buseoName, String buseoName2,
			String buseoGubun, String parentBuseo, String gwa, String gwaName, String gwaName2, String gwaGubun,
			String parentGwa, String note, String language, BigDecimal activeFlg) {
		super();
		this.id = id;
		this.buseoCode = buseoCode;
		this.buseoName = buseoName;
		this.buseoName2 = buseoName2;
		this.buseoGubun = buseoGubun;
		this.parentBuseo = parentBuseo;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.gwaName2 = gwaName2;
		this.gwaGubun = gwaGubun;
		this.parentGwa = parentGwa;
		this.note = note;
		this.language = language;
		this.activeFlg = activeFlg;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public String getBuseoCode() {
		return buseoCode;
	}

	public void setBuseoCode(String buseoCode) {
		this.buseoCode = buseoCode;
	}

	public String getBuseoName() {
		return buseoName;
	}

	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}

	public String getBuseoName2() {
		return buseoName2;
	}

	public void setBuseoName2(String buseoName2) {
		this.buseoName2 = buseoName2;
	}

	public String getBuseoGubun() {
		return buseoGubun;
	}

	public void setBuseoGubun(String buseoGubun) {
		this.buseoGubun = buseoGubun;
	}

	public String getParentBuseo() {
		return parentBuseo;
	}

	public void setParentBuseo(String parentBuseo) {
		this.parentBuseo = parentBuseo;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getGwaName2() {
		return gwaName2;
	}

	public void setGwaName2(String gwaName2) {
		this.gwaName2 = gwaName2;
	}

	public String getGwaGubun() {
		return gwaGubun;
	}

	public void setGwaGubun(String gwaGubun) {
		this.gwaGubun = gwaGubun;
	}

	public String getParentGwa() {
		return parentGwa;
	}

	public void setParentGwa(String parentGwa) {
		this.parentGwa = parentGwa;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}
	
	
}

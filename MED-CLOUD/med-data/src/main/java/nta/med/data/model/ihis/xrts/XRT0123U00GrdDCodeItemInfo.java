package nta.med.data.model.ihis.xrts;

import java.io.Serializable;

public class XRT0123U00GrdDCodeItemInfo implements Serializable{
	private String xrayGubun;
	private String buwiCode;
	private String buwiName;
	private Double valtage;
	private Double curElectric;
	private Double time;
	private Double distance;
	private String grid;
	private String note;
	private Double xrayGubunName;
	private Double fromAge;
	private Double toAge;
	private Double masVal;
	private String contKey;
	public XRT0123U00GrdDCodeItemInfo(String xrayGubun, String buwiCode,
			String buwiName, Double valtage, Double curElectric, Double time,
			Double distance, String grid, String note, Double xrayGubunName,
			Double fromAge, Double toAge, Double masVal, String contKey) {
		super();
		this.xrayGubun = xrayGubun;
		this.buwiCode = buwiCode;
		this.buwiName = buwiName;
		this.valtage = valtage;
		this.curElectric = curElectric;
		this.time = time;
		this.distance = distance;
		this.grid = grid;
		this.note = note;
		this.xrayGubunName = xrayGubunName;
		this.fromAge = fromAge;
		this.toAge = toAge;
		this.masVal = masVal;
		this.contKey = contKey;
	}
	public String getXrayGubun() {
		return xrayGubun;
	}
	public void setXrayGubun(String xrayGubun) {
		this.xrayGubun = xrayGubun;
	}
	public String getBuwiCode() {
		return buwiCode;
	}
	public void setBuwiCode(String buwiCode) {
		this.buwiCode = buwiCode;
	}
	public String getBuwiName() {
		return buwiName;
	}
	public void setBuwiName(String buwiName) {
		this.buwiName = buwiName;
	}
	public Double getValtage() {
		return valtage;
	}
	public void setValtage(Double valtage) {
		this.valtage = valtage;
	}
	public Double getCurElectric() {
		return curElectric;
	}
	public void setCurElectric(Double curElectric) {
		this.curElectric = curElectric;
	}
	public Double getTime() {
		return time;
	}
	public void setTime(Double time) {
		this.time = time;
	}
	public Double getDistance() {
		return distance;
	}
	public void setDistance(Double distance) {
		this.distance = distance;
	}
	public String getGrid() {
		return grid;
	}
	public void setGrid(String grid) {
		this.grid = grid;
	}
	public String getNote() {
		return note;
	}
	public void setNote(String note) {
		this.note = note;
	}
	public Double getXrayGubunName() {
		return xrayGubunName;
	}
	public void setXrayGubunName(Double xrayGubunName) {
		this.xrayGubunName = xrayGubunName;
	}
	public Double getFromAge() {
		return fromAge;
	}
	public void setFromAge(Double fromAge) {
		this.fromAge = fromAge;
	}
	public Double getToAge() {
		return toAge;
	}
	public void setToAge(Double toAge) {
		this.toAge = toAge;
	}
	public Double getMasVal() {
		return masVal;
	}
	public void setMasVal(Double masVal) {
		this.masVal = masVal;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
}

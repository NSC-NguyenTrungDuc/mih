package nta.med.data.model.ihis.nuri;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class NuriMeasurePhysicalConditionListItemInfo {
	private String bunho;
	private Timestamp measureDate;
	private Double seq ;
	private Double height  ;
	private Double weight ;
	private Double bpFrom ;
	private Double bpTo ;
	private Double bodyHeat;
	private BigDecimal pulse;
	private String suname;
	private Double spo2;
	private String measureTime;
	private Double breath;
	private String updId;
	public NuriMeasurePhysicalConditionListItemInfo(String bunho,
			Timestamp measureDate, Double seq, Double height, Double weight,
			Double bpFrom, Double bpTo, Double bodyHeat, BigDecimal pulse,
			String suname, Double spo2, String measureTime, Double breath,
			String updId) {
		this.bunho = bunho;
		this.measureDate = measureDate;
		this.seq = seq;
		this.height = height;
		this.weight = weight;
		this.bpFrom = bpFrom;
		this.bpTo = bpTo;
		this.bodyHeat = bodyHeat;
		this.pulse = pulse;
		this.suname = suname;
		this.spo2 = spo2;
		this.measureTime = measureTime;
		this.breath = breath;
		this.updId = updId;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Timestamp getMeasureDate() {
		return measureDate;
	}
	public void setMeasureDate(Timestamp measureDate) {
		this.measureDate = measureDate;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public Double getHeight() {
		return height;
	}
	public void setHeight(Double height) {
		this.height = height;
	}
	public Double getWeight() {
		return weight;
	}
	public void setWeight(Double weight) {
		this.weight = weight;
	}
	public Double getBpFrom() {
		return bpFrom;
	}
	public void setBpFrom(Double bpFrom) {
		this.bpFrom = bpFrom;
	}
	public Double getBpTo() {
		return bpTo;
	}
	public void setBpTo(Double bpTo) {
		this.bpTo = bpTo;
	}
	public Double getBodyHeat() {
		return bodyHeat;
	}
	public void setBodyHeat(Double bodyHeat) {
		this.bodyHeat = bodyHeat;
	}
	public BigDecimal getPulse() {
		return pulse;
	}
	public void setPulse(BigDecimal pulse) {
		this.pulse = pulse;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public Double getSpo2() {
		return spo2;
	}
	public void setSpo2(Double spo2) {
		this.spo2 = spo2;
	}
	public String getMeasureTime() {
		return measureTime;
	}
	public void setMeasureTime(String measureTime) {
		this.measureTime = measureTime;
	}
	public Double getBreath() {
		return breath;
	}
	public void setBreath(Double breath) {
		this.breath = breath;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	@Override
	public String toString() {
		return "NuriMeasurePhysicalConditionListItemInfo [bunho=" + bunho
				+ ", measureDate=" + measureDate + ", seq=" + seq + ", height="
				+ height + ", weight=" + weight + ", bpFrom=" + bpFrom
				+ ", bpTo=" + bpTo + ", bodyHeat=" + bodyHeat + ", pulse="
				+ pulse + ", suname=" + suname + ", spo2=" + spo2
				+ ", measureTime=" + measureTime + ", breath=" + breath
				+ ", updId=" + updId + "]";
	}
}

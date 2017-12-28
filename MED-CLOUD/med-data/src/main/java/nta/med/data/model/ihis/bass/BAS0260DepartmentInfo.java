package nta.med.data.model.ihis.bass;

import java.math.BigInteger;

public class BAS0260DepartmentInfo {
	
	private BigInteger id;
	private String gwa;
	private String gwaName;
	private Double avgTime;
	
	public BAS0260DepartmentInfo(BigInteger id, String gwa, String gwaName, Double avgTime) {
		super();
		this.id = id;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.avgTime = avgTime;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
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

	public Double getAvgTime() {
		return avgTime;
	}

	public void setAvgTime(Double avgTime) {
		this.avgTime = avgTime;
	}
}

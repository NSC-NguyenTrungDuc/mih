package nta.med.data.model.ihis.nuri;

import java.math.BigInteger;

public class NUR8003R02grdMasterInfo {

	private String writeMonth;
	private String writeHodong;
	private String writeHodongName;
	private BigInteger patientCnt;

	public NUR8003R02grdMasterInfo(String writeMonth, String writeHodong, String writeHodongName,
			BigInteger patientCnt) {
		super();
		this.writeMonth = writeMonth;
		this.writeHodong = writeHodong;
		this.writeHodongName = writeHodongName;
		this.patientCnt = patientCnt;
	}

	public String getWriteMonth() {
		return writeMonth;
	}

	public void setWriteMonth(String writeMonth) {
		this.writeMonth = writeMonth;
	}

	public String getWriteHodong() {
		return writeHodong;
	}

	public void setWriteHodong(String writeHodong) {
		this.writeHodong = writeHodong;
	}

	public String getWriteHodongName() {
		return writeHodongName;
	}

	public void setWriteHodongName(String writeHodongName) {
		this.writeHodongName = writeHodongName;
	}

	public BigInteger getPatientCnt() {
		return patientCnt;
	}

	public void setPatientCnt(BigInteger patientCnt) {
		this.patientCnt = patientCnt;
	}

}

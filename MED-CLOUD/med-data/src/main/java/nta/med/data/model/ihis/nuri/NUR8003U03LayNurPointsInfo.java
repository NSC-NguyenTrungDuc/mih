package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR8003U03LayNurPointsInfo {

	private Date writeDate;
	private String needPoint;
	private String needYn;
	private String writeCnt;
	private String writeHodong;

	public NUR8003U03LayNurPointsInfo(Date writeDate, String needPoint, String needYn, String writeCnt,
			String writeHodong) {
		super();
		this.writeDate = writeDate;
		this.needPoint = needPoint;
		this.needYn = needYn;
		this.writeCnt = writeCnt;
		this.writeHodong = writeHodong;
	}

	public Date getWriteDate() {
		return writeDate;
	}

	public void setWriteDate(Date writeDate) {
		this.writeDate = writeDate;
	}

	public String getNeedPoint() {
		return needPoint;
	}

	public void setNeedPoint(String needPoint) {
		this.needPoint = needPoint;
	}

	public String getNeedYn() {
		return needYn;
	}

	public void setNeedYn(String needYn) {
		this.needYn = needYn;
	}

	public String getWriteCnt() {
		return writeCnt;
	}

	public void setWriteCnt(String writeCnt) {
		this.writeCnt = writeCnt;
	}

	public String getWriteHodong() {
		return writeHodong;
	}

	public void setWriteHodong(String writeHodong) {
		this.writeHodong = writeHodong;
	}

}

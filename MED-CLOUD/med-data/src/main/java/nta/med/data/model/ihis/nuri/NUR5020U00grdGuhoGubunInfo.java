package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR5020U00grdGuhoGubunInfo {

	private String stair;
	private String stairName;
	private String stairTotalCnt;
	private Date nurWrdt;
	private String hoDong;
	private Double dansongCnt;
	private Double hosongCnt;
	private Double dokboCnt;

	public NUR5020U00grdGuhoGubunInfo(String stair, String stairName, String stairTotalCnt, Date nurWrdt, String hoDong,
			Double dansongCnt, Double hosongCnt, Double dokboCnt) {
		super();
		this.stair = stair;
		this.stairName = stairName;
		this.stairTotalCnt = stairTotalCnt;
		this.nurWrdt = nurWrdt;
		this.hoDong = hoDong;
		this.dansongCnt = dansongCnt;
		this.hosongCnt = hosongCnt;
		this.dokboCnt = dokboCnt;
	}

	public String getStair() {
		return stair;
	}

	public void setStair(String stair) {
		this.stair = stair;
	}

	public String getStairName() {
		return stairName;
	}

	public void setStairName(String stairName) {
		this.stairName = stairName;
	}

	public String getStairTotalCnt() {
		return stairTotalCnt;
	}

	public void setStairTotalCnt(String stairTotalCnt) {
		this.stairTotalCnt = stairTotalCnt;
	}

	public Date getNurWrdt() {
		return nurWrdt;
	}

	public void setNurWrdt(Date nurWrdt) {
		this.nurWrdt = nurWrdt;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public Double getDansongCnt() {
		return dansongCnt;
	}

	public void setDansongCnt(Double dansongCnt) {
		this.dansongCnt = dansongCnt;
	}

	public Double getHosongCnt() {
		return hosongCnt;
	}

	public void setHosongCnt(Double hosongCnt) {
		this.hosongCnt = hosongCnt;
	}

	public Double getDokboCnt() {
		return dokboCnt;
	}

	public void setDokboCnt(Double dokboCnt) {
		this.dokboCnt = dokboCnt;
	}

}

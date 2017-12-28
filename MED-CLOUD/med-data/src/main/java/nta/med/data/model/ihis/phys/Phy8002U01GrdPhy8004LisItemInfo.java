package nta.med.data.model.ihis.phys;

import java.util.Date;

public class Phy8002U01GrdPhy8004LisItemInfo {
	private Date sysDate;
	private String userId;
	private Date updDate;
	private String hospCode;
	private Double pkPhySyougai;
	private String dataKubun;
	private Double fkOcsIrai;
	private String syougaiId;
	private String syougaimei;
	private String kanjaNo;
	private Double fkcht0113;

	public Phy8002U01GrdPhy8004LisItemInfo(Date sysDate, String userId,
			Date updDate, String hospCode, Double pkPhySyougai,
			String dataKubun, Double fkOcsIrai, String syougaiId,
			String syougaimei, String kanjaNo, Double fkcht0113) {
		super();
		this.sysDate = sysDate;
		this.userId = userId;
		this.updDate = updDate;
		this.hospCode = hospCode;
		this.pkPhySyougai = pkPhySyougai;
		this.dataKubun = dataKubun;
		this.fkOcsIrai = fkOcsIrai;
		this.syougaiId = syougaiId;
		this.syougaimei = syougaimei;
		this.kanjaNo = kanjaNo;
		this.fkcht0113 = fkcht0113;
	}

	public Date getSysDate() {
		return sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public Date getUpdDate() {
		return updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public Double getPkPhySyougai() {
		return pkPhySyougai;
	}

	public void setPkPhySyougai(Double pkPhySyougai) {
		this.pkPhySyougai = pkPhySyougai;
	}

	public String getDataKubun() {
		return dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
	}

	public Double getFkOcsIrai() {
		return fkOcsIrai;
	}

	public void setFkOcsIrai(Double fkOcsIrai) {
		this.fkOcsIrai = fkOcsIrai;
	}

	public String getSyougaiId() {
		return syougaiId;
	}

	public void setSyougaiId(String syougaiId) {
		this.syougaiId = syougaiId;
	}

	public String getSyougaimei() {
		return syougaimei;
	}

	public void setSyougaimei(String syougaimei) {
		this.syougaimei = syougaimei;
	}

	public String getKanjaNo() {
		return kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}

	public Double getFkcht0113() {
		return fkcht0113;
	}

	public void setFkcht0113(Double fkcht0113) {
		this.fkcht0113 = fkcht0113;
	}

}
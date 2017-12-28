package nta.med.data.model.ihis.injs;

import java.sql.Timestamp;

public class INJ1001U01GrdSangItemInfo {
	private  Double pkSeq;
	private  String sangName;
	private  String juSangYn;
	private  Timestamp sangStartDate;
	public INJ1001U01GrdSangItemInfo(Double pkSeq, String sangName,
			String juSangYn, Timestamp sangStartDate) {
		super();
		this.pkSeq = pkSeq;
		this.sangName = sangName;
		this.juSangYn = juSangYn;
		this.sangStartDate = sangStartDate;
	}
	public Double getPkSeq() {
		return pkSeq;
	}
	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}
	public String getSangName() {
		return sangName;
	}
	public void setSangName(String sangName) {
		this.sangName = sangName;
	}
	public String getJuSangYn() {
		return juSangYn;
	}
	public void setJuSangYn(String juSangYn) {
		this.juSangYn = juSangYn;
	}
	public Timestamp getSangStartDate() {
		return sangStartDate;
	}
	public void setSangStartDate(Timestamp sangStartDate) {
		this.sangStartDate = sangStartDate;
	}
}

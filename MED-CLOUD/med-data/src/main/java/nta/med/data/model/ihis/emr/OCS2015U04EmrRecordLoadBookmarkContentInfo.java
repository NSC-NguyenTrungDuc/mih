package nta.med.data.model.ihis.emr;

import java.util.Date;

public class OCS2015U04EmrRecordLoadBookmarkContentInfo {
	private Integer emrBookmarkId;
	private String bookmarkText;
	private Date naewonDate;
	private String sysId;
	private String userNm;
	private String gwa;
	private String gwaName;
	public OCS2015U04EmrRecordLoadBookmarkContentInfo(Integer emrBookmarkId,
			String bookmarkText, Date naewonDate, String sysId, String userNm,
			String gwa, String gwaName) {
		super();
		this.emrBookmarkId = emrBookmarkId;
		this.bookmarkText = bookmarkText;
		this.naewonDate = naewonDate;
		this.sysId = sysId;
		this.userNm = userNm;
		this.gwa = gwa;
		this.gwaName = gwaName;
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
	public Integer getEmrBookmarkId() {
		return emrBookmarkId;
	}
	public void setEmrBookmarkId(Integer emrBookmarkId) {
		this.emrBookmarkId = emrBookmarkId;
	}
	public String getBookmarkText() {
		return bookmarkText;
	}
	public void setBookmarkText(String bookmarkText) {
		this.bookmarkText = bookmarkText;
	}
	public Date getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public String getUserNm() {
		return userNm;
	}
	public void setUserNm(String userNm) {
		this.userNm = userNm;
	}
	
}

package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.util.Date;

public class OCS2015U04LoadBookmarkByPk0ut1001Info {
	private Integer emrBookmarkId;
	private Integer emrRecordId;
	private Double pkout1001;
	private String bookmarkText;
	private Date naewonDate;
	private String sysId;
	private String updId;
	private Date created;
	private Date updated;
	private BigDecimal activeFlg;
	public OCS2015U04LoadBookmarkByPk0ut1001Info(Integer emrBookmarkId,
			Integer emrRecordId, Double pkout1001, String bookmarkText,
			Date naewonDate, String sysId, String updId, Date created,
			Date updated, BigDecimal activeFlg) {
		super();
		this.emrBookmarkId = emrBookmarkId;
		this.emrRecordId = emrRecordId;
		this.pkout1001 = pkout1001;
		this.bookmarkText = bookmarkText;
		this.naewonDate = naewonDate;
		this.sysId = sysId;
		this.updId = updId;
		this.created = created;
		this.updated = updated;
		this.activeFlg = activeFlg;
	}
	public Integer getEmrBookmarkId() {
		return emrBookmarkId;
	}
	public void setEmrBookmarkId(Integer emrBookmarkId) {
		this.emrBookmarkId = emrBookmarkId;
	}
	public Integer getEmrRecordId() {
		return emrRecordId;
	}
	public void setEmrRecordId(Integer emrRecordId) {
		this.emrRecordId = emrRecordId;
	}
	public Double getPkout1001() {
		return pkout1001;
	}
	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
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
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	public Date getCreated() {
		return created;
	}
	public void setCreated(Date created) {
		this.created = created;
	}
	public Date getUpdated() {
		return updated;
	}
	public void setUpdated(Date updated) {
		this.updated = updated;
	}
	public BigDecimal getActiveFlg() {
		return activeFlg;
	}
	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}
	
}

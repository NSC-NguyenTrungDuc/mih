package nta.med.core.domain.emr;

import java.io.Serializable;

import javax.persistence.*;

import java.math.BigDecimal;
import java.util.Date;
import java.sql.Timestamp;


/**
 * The persistent class for the EMR_BOOKMARK database table.
 * 
 */
@Entity
@Table(name="EMR_BOOKMARK")
@NamedQuery(name="EmrBookmark.findAll", query="SELECT e FROM EmrBookmark e")
public class EmrBookmark implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="EMR_BOOKMARK_ID")
	private int emrBookmarkId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	@Column(name="BOOKMARK_TEXT")
	private String bookmarkText;

	private Timestamp created;

	@Column(name="EMR_RECORD_ID")
	private int emrRecordId;

	@Temporal(TemporalType.DATE)
	@Column(name="NAEWON_DATE")
	private Date naewonDate;

	private double pkout1001;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Timestamp updated;
	
	@Column(name="BOOKMARK_TITLE")
	private String bookmarkTitle;

	public EmrBookmark() {
	}

	public String getBookmarkTitle() {
		return bookmarkTitle;
	}

	public void setBookmarkTitle(String bookmarkTitle) {
		this.bookmarkTitle = bookmarkTitle;
	}

	public int getEmrBookmarkId() {
		return this.emrBookmarkId;
	}

	public void setEmrBookmarkId(int emrBookmarkId) {
		this.emrBookmarkId = emrBookmarkId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getBookmarkText() {
		return this.bookmarkText;
	}

	public void setBookmarkText(String bookmarkText) {
		this.bookmarkText = bookmarkText;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public int getEmrRecordId() {
		return this.emrRecordId;
	}

	public void setEmrRecordId(int emrRecordId) {
		this.emrRecordId = emrRecordId;
	}

	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}

	public double getPkout1001() {
		return this.pkout1001;
	}

	public void setPkout1001(double pkout1001) {
		this.pkout1001 = pkout1001;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}
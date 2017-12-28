package nta.med.data.model.ihis.emr;

import java.math.BigDecimal;
import java.util.Date;

public class OCS2015U06EmrRecordInfo {

	private Integer recordId;
	private String bunho;
	private String pkout1001;
	private String naewonDate;
	private String content;
	private String metadata;
	private Integer version;
	private BigDecimal activeFlg;
	private Date created;
	private Date updated;
	private String gwa;
	public Integer getRecordId() {
		return recordId;
	}
	public void setRecordId(Integer recordId) {
		this.recordId = recordId;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getPkout1001() {
		return pkout1001;
	}
	public void setPkout1001(String pkout1001) {
		this.pkout1001 = pkout1001;
	}
	public String getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public String getMetadata() {
		return metadata;
	}
	public void setMetadata(String metadata) {
		this.metadata = metadata;
	}
	public Integer getVersion() {
		return version;
	}
	public void setVersion(Integer version) {
		this.version = version;
	}
	public BigDecimal getActiveFlg() {
		return activeFlg;
	}
	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
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
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public OCS2015U06EmrRecordInfo(Integer recordId, String bunho,
			String pkout1001, String naewonDate, String content, String metadata,
			Integer version, BigDecimal activeFlg, Date created, Date updated,
			String gwa) {
		super();
		this.recordId = recordId;
		this.bunho = bunho;
		this.pkout1001 = pkout1001;
		this.naewonDate = naewonDate;
		this.content = content;
		this.metadata = metadata;
		this.version = version;
		this.activeFlg = activeFlg;
		this.created = created;
		this.updated = updated;
		this.gwa = gwa;
	}

}
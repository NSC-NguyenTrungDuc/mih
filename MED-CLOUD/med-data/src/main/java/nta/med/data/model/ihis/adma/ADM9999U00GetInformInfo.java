/**
 * 
 */
package nta.med.data.model.ihis.adma;

import java.util.Date;

/**
 * @author admin
 *
 */
public class ADM9999U00GetInformInfo {
	
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String bunho;
	
	public ADM9999U00GetInformInfo(Date sysDate, String sysId, Date updDate, String bunho) {
		super();
		this.sysDate = sysDate;
		this.sysId = sysId;
		this.updDate = updDate;
		this.bunho = bunho;
	}
	
	
	public Date getSysDate() {
		return sysDate;
	}
	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public Date getUpdDate() {
		return updDate;
	}
	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
}

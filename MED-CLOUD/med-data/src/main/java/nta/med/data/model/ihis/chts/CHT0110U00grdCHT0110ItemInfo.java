package nta.med.data.model.ihis.chts;

import java.io.Serializable;
import java.util.Date;

public class CHT0110U00grdCHT0110ItemInfo implements Serializable {

	private String sangCode;
	private String sangName;
	private String sangNameHan;
	private String sangNameSelf;
	private Date startDate;
	private Date endDate;
	private String bulyongYn;
	private String sugaSangCode;
	private String sugaSangName;
	private String junyeomBuryn;
	private String junyeomKind;
	public CHT0110U00grdCHT0110ItemInfo(String sangCode, String sangName,
			String sangNameHan, String sangNameSelf, Date startDate,
			Date endDate, String bulyongYn, String sugaSangCode,
			String sugaSangName, String junyeomBuryn, String junyeomKind) {
		super();
		this.sangCode = sangCode;
		this.sangName = sangName;
		this.sangNameHan = sangNameHan;
		this.sangNameSelf = sangNameSelf;
		this.startDate = startDate;
		this.endDate = endDate;
		this.bulyongYn = bulyongYn;
		this.sugaSangCode = sugaSangCode;
		this.sugaSangName = sugaSangName;
		this.junyeomBuryn = junyeomBuryn;
		this.junyeomKind = junyeomKind;
	}
	public String getSangCode() {
		return sangCode;
	}
	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}
	public String getSangName() {
		return sangName;
	}
	public void setSangName(String sangName) {
		this.sangName = sangName;
	}
	public String getSangNameHan() {
		return sangNameHan;
	}
	public void setSangNameHan(String sangNameHan) {
		this.sangNameHan = sangNameHan;
	}
	public String getSangNameSelf() {
		return sangNameSelf;
	}
	public void setSangNameSelf(String sangNameSelf) {
		this.sangNameSelf = sangNameSelf;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getBulyongYn() {
		return bulyongYn;
	}
	public void setBulyongYn(String bulyongYn) {
		this.bulyongYn = bulyongYn;
	}
	public String getSugaSangCode() {
		return sugaSangCode;
	}
	public void setSugaSangCode(String sugaSangCode) {
		this.sugaSangCode = sugaSangCode;
	}
	public String getSugaSangName() {
		return sugaSangName;
	}
	public void setSugaSangName(String sugaSangName) {
		this.sugaSangName = sugaSangName;
	}
	public String getJunyeomBuryn() {
		return junyeomBuryn;
	}
	public void setJunyeomBuryn(String junyeomBuryn) {
		this.junyeomBuryn = junyeomBuryn;
	}
	public String getJunyeomKind() {
		return junyeomKind;
	}
	public void setJunyeomKind(String junyeomKind) {
		this.junyeomKind = junyeomKind;
	}
	
}

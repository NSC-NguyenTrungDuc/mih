package nta.med.data.model.ihis.chts;

import java.math.BigInteger;
import java.util.Date;

public class CHT0110Q01GrdCHT0110MListInfo {
	
	private String sangCode ;
	private String sangName ;
	private String sangNameHan;
	private String sangNameSelf ;
	private String sangNameInx;
	private Date startDate ;
	private String bulyongYn ;
	private String sugaSangCode ;
	private String sugaSangName ;
	private String junyeomBunryu ;
	private String junyeomKind ;
	private String samangSangGroup ;
	private String samangGroupName ;
	private BigInteger rankCnt ;
	public CHT0110Q01GrdCHT0110MListInfo(String sangCode, String sangName,
			String sangNameHan, String sangNameSelf, String sangNameInx,
			Date startDate, String bulyongYn, String sugaSangCode,
			String sugaSangName, String junyeomBunryu, String junyeomKind,
			String samangSangGroup, String samangGroupName, BigInteger rankCnt) {
		super();
		this.sangCode = sangCode;
		this.sangName = sangName;
		this.sangNameHan = sangNameHan;
		this.sangNameSelf = sangNameSelf;
		this.sangNameInx = sangNameInx;
		this.startDate = startDate;
		this.bulyongYn = bulyongYn;
		this.sugaSangCode = sugaSangCode;
		this.sugaSangName = sugaSangName;
		this.junyeomBunryu = junyeomBunryu;
		this.junyeomKind = junyeomKind;
		this.samangSangGroup = samangSangGroup;
		this.samangGroupName = samangGroupName;
		this.rankCnt = rankCnt;
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
	public String getSangNameInx() {
		return sangNameInx;
	}
	public void setSangNameInx(String sangNameInx) {
		this.sangNameInx = sangNameInx;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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
	public String getJunyeomBunryu() {
		return junyeomBunryu;
	}
	public void setJunyeomBunryu(String junyeomBunryu) {
		this.junyeomBunryu = junyeomBunryu;
	}
	public String getJunyeomKind() {
		return junyeomKind;
	}
	public void setJunyeomKind(String junyeomKind) {
		this.junyeomKind = junyeomKind;
	}
	public String getSamangSangGroup() {
		return samangSangGroup;
	}
	public void setSamangSangGroup(String samangSangGroup) {
		this.samangSangGroup = samangSangGroup;
	}
	public String getSamangGroupName() {
		return samangGroupName;
	}
	public void setSamangGroupName(String samangGroupName) {
		this.samangGroupName = samangGroupName;
	}
	public BigInteger getRankCnt() {
		return rankCnt;
	}
	public void setRankCnt(BigInteger rankCnt) {
		this.rankCnt = rankCnt;
	}
}

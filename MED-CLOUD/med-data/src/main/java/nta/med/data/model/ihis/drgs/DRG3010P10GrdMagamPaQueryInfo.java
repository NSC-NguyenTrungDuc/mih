package nta.med.data.model.ihis.drgs;

import java.util.Date;

public class DRG3010P10GrdMagamPaQueryInfo {
	private Date magamDate;
    private Double magamSer;
    private String magamTime;
    private String magamGubun;
    private String magamCancel;
    private String actFlag;
    private String minDrgBunho;
    private String maxDrgBunho;
    private String magamBunryu;
	public DRG3010P10GrdMagamPaQueryInfo(Date magamDate, Double magamSer, String magamTime, String magamGubun,
			String magamCancel, String actFlag, String minDrgBunho, String maxDrgBunho, String magamBunryu) {
		super();
		this.magamDate = magamDate;
		this.magamSer = magamSer;
		this.magamTime = magamTime;
		this.magamGubun = magamGubun;
		this.magamCancel = magamCancel;
		this.actFlag = actFlag;
		this.minDrgBunho = minDrgBunho;
		this.maxDrgBunho = maxDrgBunho;
		this.magamBunryu = magamBunryu;
	}
	public Date getMagamDate() {
		return magamDate;
	}
	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}
	public Double getMagamSer() {
		return magamSer;
	}
	public void setMagamSer(Double magamSer) {
		this.magamSer = magamSer;
	}
	public String getMagamTime() {
		return magamTime;
	}
	public void setMagamTime(String magamTime) {
		this.magamTime = magamTime;
	}
	public String getMagamGubun() {
		return magamGubun;
	}
	public void setMagamGubun(String magamGubun) {
		this.magamGubun = magamGubun;
	}
	public String getMagamCancel() {
		return magamCancel;
	}
	public void setMagamCancel(String magamCancel) {
		this.magamCancel = magamCancel;
	}
	public String getActFlag() {
		return actFlag;
	}
	public void setActFlag(String actFlag) {
		this.actFlag = actFlag;
	}
	public String getMinDrgBunho() {
		return minDrgBunho;
	}
	public void setMinDrgBunho(String minDrgBunho) {
		this.minDrgBunho = minDrgBunho;
	}
	public String getMaxDrgBunho() {
		return maxDrgBunho;
	}
	public void setMaxDrgBunho(String maxDrgBunho) {
		this.maxDrgBunho = maxDrgBunho;
	}
	public String getMagamBunryu() {
		return magamBunryu;
	}
	public void setMagamBunryu(String magamBunryu) {
		this.magamBunryu = magamBunryu;
	}
    
}

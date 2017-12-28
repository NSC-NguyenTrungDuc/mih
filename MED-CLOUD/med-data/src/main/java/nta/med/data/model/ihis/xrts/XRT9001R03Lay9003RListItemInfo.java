package nta.med.data.model.ihis.xrts;

public class XRT9001R03Lay9003RListItemInfo {
	private String actingMonth;
	private Double crCntN;
	private Double crCntY;
	private Double drCntN;
	private Double drCntY;
	private Double ctCntN;
	private Double ctCntY;
	private Double mriCntN;
	private Double mriCntY;
	private Double totalCnt;
	private String zeroValue;
	public XRT9001R03Lay9003RListItemInfo(String actingMonth, Double crCntN,
			Double crCntY, Double drCntN, Double drCntY, Double ctCntN,
			Double ctCntY, Double mriCntN, Double mriCntY, Double totalCnt,
			String zeroValue) {
		super();
		this.actingMonth = actingMonth;
		this.crCntN = crCntN;
		this.crCntY = crCntY;
		this.drCntN = drCntN;
		this.drCntY = drCntY;
		this.ctCntN = ctCntN;
		this.ctCntY = ctCntY;
		this.mriCntN = mriCntN;
		this.mriCntY = mriCntY;
		this.totalCnt = totalCnt;
		this.zeroValue = zeroValue;
	}
	public String getActingMonth() {
		return actingMonth;
	}
	public void setActingMonth(String actingMonth) {
		this.actingMonth = actingMonth;
	}
	public Double getCrCntN() {
		return crCntN;
	}
	public void setCrCntN(Double crCntN) {
		this.crCntN = crCntN;
	}
	public Double getCrCntY() {
		return crCntY;
	}
	public void setCrCntY(Double crCntY) {
		this.crCntY = crCntY;
	}
	public Double getDrCntN() {
		return drCntN;
	}
	public void setDrCntN(Double drCntN) {
		this.drCntN = drCntN;
	}
	public Double getDrCntY() {
		return drCntY;
	}
	public void setDrCntY(Double drCntY) {
		this.drCntY = drCntY;
	}
	public Double getCtCntN() {
		return ctCntN;
	}
	public void setCtCntN(Double ctCntN) {
		this.ctCntN = ctCntN;
	}
	public Double getCtCntY() {
		return ctCntY;
	}
	public void setCtCntY(Double ctCntY) {
		this.ctCntY = ctCntY;
	}
	public Double getMriCntN() {
		return mriCntN;
	}
	public void setMriCntN(Double mriCntN) {
		this.mriCntN = mriCntN;
	}
	public Double getMriCntY() {
		return mriCntY;
	}
	public void setMriCntY(Double mriCntY) {
		this.mriCntY = mriCntY;
	}
	public Double getTotalCnt() {
		return totalCnt;
	}
	public void setTotalCnt(Double totalCnt) {
		this.totalCnt = totalCnt;
	}
	public String getZeroValue() {
		return zeroValue;
	}
	public void setZeroValue(String zeroValue) {
		this.zeroValue = zeroValue;
	}
	
}

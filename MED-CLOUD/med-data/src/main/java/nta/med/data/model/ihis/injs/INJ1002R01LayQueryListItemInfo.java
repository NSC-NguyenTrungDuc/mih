package nta.med.data.model.ihis.injs;

import java.math.BigInteger;

public class INJ1002R01LayQueryListItemInfo {
	private String gwa;
    private String buseoName;
    private String actingDate;
    private String hangmogCode;
    private String hangmogName;
    private String ordDanui;
    private BigInteger inwonCnt;
    private Double subulSuryang;
	public INJ1002R01LayQueryListItemInfo(String gwa, String buseoName,
			String actingDate, String hangmogCode, String hangmogName,
			String ordDanui, BigInteger inwonCnt, Double subulSuryang) {
		super();
		this.gwa = gwa;
		this.buseoName = buseoName;
		this.actingDate = actingDate;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.ordDanui = ordDanui;
		this.inwonCnt = inwonCnt;
		this.subulSuryang = subulSuryang;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getBuseoName() {
		return buseoName;
	}
	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}
	public String getActingDate() {
		return actingDate;
	}
	public void setActingDate(String actingDate) {
		this.actingDate = actingDate;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getHangmogName() {
		return hangmogName;
	}
	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}
	public String getOrdDanui() {
		return ordDanui;
	}
	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}
	public BigInteger getInwonCnt() {
		return inwonCnt;
	}
	public void setInwonCnt(BigInteger inwonCnt) {
		this.inwonCnt = inwonCnt;
	}
	public Double getSubulSuryang() {
		return subulSuryang;
	}
	public void setSubulSuryang(Double subulSuryang) {
		this.subulSuryang = subulSuryang;
	}
}
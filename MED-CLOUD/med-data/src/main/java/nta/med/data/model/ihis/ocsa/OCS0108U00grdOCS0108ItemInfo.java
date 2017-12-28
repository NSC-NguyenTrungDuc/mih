package nta.med.data.model.ihis.ocsa;

import java.sql.Timestamp;

public class OCS0108U00grdOCS0108ItemInfo {
	private String hangmogCode;
	private Double seq;
	private String ordDanui;
	private Double changeQty1;
	private Double changeQty2;
	private String sunabDanui;
	private String subulDanui;
	private Timestamp hangmogStartDate;
	public OCS0108U00grdOCS0108ItemInfo(String hangmogCode, Double seq,
			String ordDanui, Double changeQty1, Double changeQty2,
			String sunabDanui, String subulDanui, Timestamp hangmogStartDate) {
		super();
		this.hangmogCode = hangmogCode;
		this.seq = seq;
		this.ordDanui = ordDanui;
		this.changeQty1 = changeQty1;
		this.changeQty2 = changeQty2;
		this.sunabDanui = sunabDanui;
		this.subulDanui = subulDanui;
		this.hangmogStartDate = hangmogStartDate;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public String getOrdDanui() {
		return ordDanui;
	}
	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}
	public Double getChangeQty1() {
		return changeQty1;
	}
	public void setChangeQty1(Double changeQty1) {
		this.changeQty1 = changeQty1;
	}
	public Double getChangeQty2() {
		return changeQty2;
	}
	public void setChangeQty2(Double changeQty2) {
		this.changeQty2 = changeQty2;
	}
	public String getSunabDanui() {
		return sunabDanui;
	}
	public void setSunabDanui(String sunabDanui) {
		this.sunabDanui = sunabDanui;
	}
	public String getSubulDanui() {
		return subulDanui;
	}
	public void setSubulDanui(String subulDanui) {
		this.subulDanui = subulDanui;
	}
	public Timestamp getHangmogStartDate() {
		return hangmogStartDate;
	}
	public void setHangmogStartDate(Timestamp hangmogStartDate) {
		this.hangmogStartDate = hangmogStartDate;
	}
}

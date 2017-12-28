package nta.med.data.model.ihis.drug;

import java.io.Serializable;
import java.util.Date;

public class DRGOCSCHKgrdOCS0108Info implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private String hangmogCode ;
	private String ordDanui ;
	private Double seq ;
	private Double changeQty1 ;
	private Double changeQty2 ;
	private String hospCode ;
	private Date hangmogStartDate ;
	private String changeDanui1 ;
	private String changeDanui2 ;
	public DRGOCSCHKgrdOCS0108Info(String hangmogCode, String ordDanui, Double seq, Double changeQty1,
			Double changeQty2, String hospCode, Date hangmogStartDate, String changeDanui1, String changeDanui2) {
		super();
		this.hangmogCode = hangmogCode;
		this.ordDanui = ordDanui;
		this.seq = seq;
		this.changeQty1 = changeQty1;
		this.changeQty2 = changeQty2;
		this.hospCode = hospCode;
		this.hangmogStartDate = hangmogStartDate;
		this.changeDanui1 = changeDanui1;
		this.changeDanui2 = changeDanui2;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getOrdDanui() {
		return ordDanui;
	}
	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
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
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public Date getHangmogStartDate() {
		return hangmogStartDate;
	}
	public void setHangmogStartDate(Date hangmogStartDate) {
		this.hangmogStartDate = hangmogStartDate;
	}
	public String getChangeDanui1() {
		return changeDanui1;
	}
	public void setChangeDanui1(String changeDanui1) {
		this.changeDanui1 = changeDanui1;
	}
	public String getChangeDanui2() {
		return changeDanui2;
	}
	public void setChangeDanui2(String changeDanui2) {
		this.changeDanui2 = changeDanui2;
	}
	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
}

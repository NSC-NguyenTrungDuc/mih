package nta.med.data.model.ihis.ocsa;

import java.sql.Timestamp;

public class OCS0108U00grdOCS0103ItemInfo {
	private String slipCode ;    
	private String hangmogCode ; 
	private String hangmogName  ;  
	private String sunabDanui;         
	private String sunabDanuiName;   
	private String subulDanui  ;      
	private String subulDanuiName ;  
	private Timestamp hangmogStartDate ;
	public OCS0108U00grdOCS0103ItemInfo(String slipCode, String hangmogCode,
			String hangmogName, String sunabDanui, String sunabDanuiName,
			String subulDanui, String subulDanuiName, Timestamp hangmogStartDate) {
		super();
		this.slipCode = slipCode;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.sunabDanui = sunabDanui;
		this.sunabDanuiName = sunabDanuiName;
		this.subulDanui = subulDanui;
		this.subulDanuiName = subulDanuiName;
		this.hangmogStartDate = hangmogStartDate;
	}
	public String getSlipCode() {
		return slipCode;
	}
	public void setSlipCode(String slipCode) {
		this.slipCode = slipCode;
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
	public String getSunabDanui() {
		return sunabDanui;
	}
	public void setSunabDanui(String sunabDanui) {
		this.sunabDanui = sunabDanui;
	}
	public String getSunabDanuiName() {
		return sunabDanuiName;
	}
	public void setSunabDanuiName(String sunabDanuiName) {
		this.sunabDanuiName = sunabDanuiName;
	}
	public String getSubulDanui() {
		return subulDanui;
	}
	public void setSubulDanui(String subulDanui) {
		this.subulDanui = subulDanui;
	}
	public String getSubulDanuiName() {
		return subulDanuiName;
	}
	public void setSubulDanuiName(String subulDanuiName) {
		this.subulDanuiName = subulDanuiName;
	}
	public Timestamp getHangmogStartDate() {
		return hangmogStartDate;
	}
	public void setHangmogStartDate(Timestamp hangmogStartDate) {
		this.hangmogStartDate = hangmogStartDate;
	}
}

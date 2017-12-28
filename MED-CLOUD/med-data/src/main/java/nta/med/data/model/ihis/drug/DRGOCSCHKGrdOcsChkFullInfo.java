package nta.med.data.model.ihis.drug;

import java.io.Serializable;
import java.util.Date;

import org.apache.commons.net.ntp.TimeStamp;

public class DRGOCSCHKGrdOcsChkFullInfo implements Serializable{
	  private String jaeryoCode ;
	  private String jaeryoName ;
      private String drgPackYn ;
      private String phamarcyYn ;
      private String powerYn ;
      private String hubalChangeYn ;
      private String mayakYn ;
      private String smallCode ;
      private String smallCodeName ;
      private String cautionCode ;
      private String cautionName ; 
      private Date startDate ;       
      private String sunabDanui ;  
      private String sunabDanuiName ;  
      private String subulDanui ;  
      private String subulDanuiName  ;  
      private String stockYn ;  
      private Double subulDanga ;  
      private String subulQcodeOut ;  
      private String subulQcodeOutName ;  
      private String subulQcodeInp ;  
      private String subulQcodeInpName ;
	public DRGOCSCHKGrdOcsChkFullInfo(String jaeryoCode, String jaeryoName, String drgPackYn, String phamarcyYn,
			String powerYn, String hubalChangeYn, String mayakYn, String smallCode, String smallCodeName,
			String cautionCode, String cautionName, Date startDate, String sunabDanui, String sunabDanuiName,
			String subulDanui, String subulDanuiName, String stockYn, Double subulDanga, String subulQcodeOut,
			String subulQcodeOutName, String subulQcodeInp, String subulQcodeInpName) {
		super();
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.drgPackYn = drgPackYn;
		this.phamarcyYn = phamarcyYn;
		this.powerYn = powerYn;
		this.hubalChangeYn = hubalChangeYn;
		this.mayakYn = mayakYn;
		this.smallCode = smallCode;
		this.smallCodeName = smallCodeName;
		this.cautionCode = cautionCode;
		this.cautionName = cautionName;
		this.startDate = startDate;
		this.sunabDanui = sunabDanui;
		this.sunabDanuiName = sunabDanuiName;
		this.subulDanui = subulDanui;
		this.subulDanuiName = subulDanuiName;
		this.stockYn = stockYn;
		this.subulDanga = subulDanga;
		this.subulQcodeOut = subulQcodeOut;
		this.subulQcodeOutName = subulQcodeOutName;
		this.subulQcodeInp = subulQcodeInp;
		this.subulQcodeInpName = subulQcodeInpName;
	}
	public String getJaeryoCode() {
		return jaeryoCode;
	}
	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}
	public String getJaeryoName() {
		return jaeryoName;
	}
	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}
	public String getDrgPackYn() {
		return drgPackYn;
	}
	public void setDrgPackYn(String drgPackYn) {
		this.drgPackYn = drgPackYn;
	}
	public String getPhamarcyYn() {
		return phamarcyYn;
	}
	public void setPhamarcyYn(String phamarcyYn) {
		this.phamarcyYn = phamarcyYn;
	}
	public String getPowerYn() {
		return powerYn;
	}
	public void setPowerYn(String powerYn) {
		this.powerYn = powerYn;
	}
	public String getHubalChangeYn() {
		return hubalChangeYn;
	}
	public void setHubalChangeYn(String hubalChangeYn) {
		this.hubalChangeYn = hubalChangeYn;
	}
	public String getMayakYn() {
		return mayakYn;
	}
	public void setMayakYn(String mayakYn) {
		this.mayakYn = mayakYn;
	}
	public String getSmallCode() {
		return smallCode;
	}
	public void setSmallCode(String smallCode) {
		this.smallCode = smallCode;
	}
	public String getSmallCodeName() {
		return smallCodeName;
	}
	public void setSmallCodeName(String smallCodeName) {
		this.smallCodeName = smallCodeName;
	}
	public String getCautionCode() {
		return cautionCode;
	}
	public void setCautionCode(String cautionCode) {
		this.cautionCode = cautionCode;
	}
	public String getCautionName() {
		return cautionName;
	}
	public void setCautionName(String cautionName) {
		this.cautionName = cautionName;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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
	public String getStockYn() {
		return stockYn;
	}
	public void setStockYn(String stockYn) {
		this.stockYn = stockYn;
	}
	public Double getSubulDanga() {
		return subulDanga;
	}
	public void setSubulDanga(Double subulDanga) {
		this.subulDanga = subulDanga;
	}
	public String getSubulQcodeOut() {
		return subulQcodeOut;
	}
	public void setSubulQcodeOut(String subulQcodeOut) {
		this.subulQcodeOut = subulQcodeOut;
	}
	public String getSubulQcodeOutName() {
		return subulQcodeOutName;
	}
	public void setSubulQcodeOutName(String subulQcodeOutName) {
		this.subulQcodeOutName = subulQcodeOutName;
	}
	public String getSubulQcodeInp() {
		return subulQcodeInp;
	}
	public void setSubulQcodeInp(String subulQcodeInp) {
		this.subulQcodeInp = subulQcodeInp;
	}
	public String getSubulQcodeInpName() {
		return subulQcodeInpName;
	}
	public void setSubulQcodeInpName(String subulQcodeInpName) {
		this.subulQcodeInpName = subulQcodeInpName;
	}
	
}

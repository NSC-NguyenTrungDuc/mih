package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS3003Q11grdOrderDateListInfo {
	private Date iraiDate ;
    private String bunho ;
    private String suname ;
    private String hangmogCode ;
    private String hangmogName ;
    private String sinryouka ;
    private String sindanisi ;
    private String nutritionistName ;
    private String sijijikou ;
    private String nutritionObject ;
    private String remark ;
    private String ioGubun ;
    private String ocsFlag ;
    private Date resultDate ;
    private String sunabCheck ;
    private Double nalsu ;
    private String dcYn ;
    private Double pkocskey ;
	public OCS3003Q11grdOrderDateListInfo(Date iraiDate, String bunho, String suname, String hangmogCode,
			String hangmogName, String sinryouka, String sindanisi, String nutritionistName, String sijijikou,
			String nutritionObject, String remark, String ioGubun, String ocsFlag, Date resultDate, String sunabCheck,
			Double nalsu, String dcYn, Double pkocskey) {
		super();
		this.iraiDate = iraiDate;
		this.bunho = bunho;
		this.suname = suname;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.sinryouka = sinryouka;
		this.sindanisi = sindanisi;
		this.nutritionistName = nutritionistName;
		this.sijijikou = sijijikou;
		this.nutritionObject = nutritionObject;
		this.remark = remark;
		this.ioGubun = ioGubun;
		this.ocsFlag = ocsFlag;
		this.resultDate = resultDate;
		this.sunabCheck = sunabCheck;
		this.nalsu = nalsu;
		this.dcYn = dcYn;
		this.pkocskey = pkocskey;
	}
	public Date getIraiDate() {
		return iraiDate;
	}
	public void setIraiDate(Date iraiDate) {
		this.iraiDate = iraiDate;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
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
	public String getSinryouka() {
		return sinryouka;
	}
	public void setSinryouka(String sinryouka) {
		this.sinryouka = sinryouka;
	}
	public String getSindanisi() {
		return sindanisi;
	}
	public void setSindanisi(String sindanisi) {
		this.sindanisi = sindanisi;
	}
	public String getNutritionistName() {
		return nutritionistName;
	}
	public void setNutritionistName(String nutritionistName) {
		this.nutritionistName = nutritionistName;
	}
	public String getSijijikou() {
		return sijijikou;
	}
	public void setSijijikou(String sijijikou) {
		this.sijijikou = sijijikou;
	}
	public String getNutritionObject() {
		return nutritionObject;
	}
	public void setNutritionObject(String nutritionObject) {
		this.nutritionObject = nutritionObject;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getIoGubun() {
		return ioGubun;
	}
	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}
	public String getOcsFlag() {
		return ocsFlag;
	}
	public void setOcsFlag(String ocsFlag) {
		this.ocsFlag = ocsFlag;
	}
	public Date getResultDate() {
		return resultDate;
	}
	public void setResultDate(Date resultDate) {
		this.resultDate = resultDate;
	}
	public String getSunabCheck() {
		return sunabCheck;
	}
	public void setSunabCheck(String sunabCheck) {
		this.sunabCheck = sunabCheck;
	}
	public Double getNalsu() {
		return nalsu;
	}
	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}
	public String getDcYn() {
		return dcYn;
	}
	public void setDcYn(String dcYn) {
		this.dcYn = dcYn;
	}
	public Double getPkocskey() {
		return pkocskey;
	}
	public void setPkocskey(Double pkocskey) {
		this.pkocskey = pkocskey;
	}
    
}

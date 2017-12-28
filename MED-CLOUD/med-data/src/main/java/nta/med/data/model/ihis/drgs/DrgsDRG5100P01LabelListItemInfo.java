package nta.med.data.model.ihis.drgs;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class DrgsDRG5100P01LabelListItemInfo {
	private Timestamp orderDate;
	private String danui;
	private String danui1;
	private Double drgBunho;
	private String bunho;
	private Double dv;
	private String drgGrp;
	private String name;
	private String gwa;
	private String bogyongCode;
	private String bogyongName;
	private Double nalsu;
	private String bunryu1;
	private String cautionNm;
	private String jaeryoName;
	private String gyunbonYn;
	private BigDecimal su;
	private String rp;
	private Timestamp hopeDate;
	private String donbok;
	
	public DrgsDRG5100P01LabelListItemInfo(Timestamp orderDate, String danui,
			String danui1, Double drgBunho, String bunho, Double dv,
			String drgGrp, String name, String gwa, String bogyongCode,
			String bogyongName, Double nalsu, String bunryu1, String cautionNm,
			String jaeryoName, String gyunbonYn, BigDecimal su, String rp,
			Timestamp hopeDate, String donbok) {
		this.orderDate = orderDate;
		this.danui = danui;
		this.danui1 = danui1;
		this.drgBunho = drgBunho;
		this.bunho = bunho;
		this.dv = dv;
		this.drgGrp = drgGrp;
		this.name = name;
		this.gwa = gwa;
		this.bogyongCode = bogyongCode;
		this.bogyongName = bogyongName;
		this.nalsu = nalsu;
		this.bunryu1 = bunryu1;
		this.cautionNm = cautionNm;
		this.jaeryoName = jaeryoName;
		this.gyunbonYn = gyunbonYn;
		this.su = su;
		this.rp = rp;
		this.hopeDate = hopeDate;
		this.donbok = donbok;
	}
	public Timestamp getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Timestamp orderDate) {
		this.orderDate = orderDate;
	}
	public String getDanui() {
		return danui;
	}
	public void setDanui(String danui) {
		this.danui = danui;
	}
	public String getDanui1() {
		return danui1;
	}
	public void setDanui1(String danui1) {
		this.danui1 = danui1;
	}
	public Double getDrgBunho() {
		return drgBunho;
	}
	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Double getDv() {
		return dv;
	}
	public void setDv(Double dv) {
		this.dv = dv;
	}
	public String getDrgGrp() {
		return drgGrp;
	}
	public void setDrgGrp(String drgGrp) {
		this.drgGrp = drgGrp;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getGwa() {
		return gwa;
	}
	public void setGwa(String gwa) {
		this.gwa = gwa;
	}
	public String getBogyongCode() {
		return bogyongCode;
	}
	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}
	public String getBogyongName() {
		return bogyongName;
	}
	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}
	public Double getNalsu() {
		return nalsu;
	}
	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}
	public String getBunryu1() {
		return bunryu1;
	}
	public void setBunryu1(String bunryu1) {
		this.bunryu1 = bunryu1;
	}
	public String getCautionNm() {
		return cautionNm;
	}
	public void setCautionNm(String cautionNm) {
		this.cautionNm = cautionNm;
	}
	public String getJaeryoName() {
		return jaeryoName;
	}
	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}
	public String getGyunbonYn() {
		return gyunbonYn;
	}
	public void setGyunbonYn(String gyunbonYn) {
		this.gyunbonYn = gyunbonYn;
	}
	public BigDecimal getSu() {
		return su;
	}
	public void setSu(BigDecimal su) {
		this.su = su;
	}
	public String getRp() {
		return rp;
	}
	public void setRp(String rp) {
		this.rp = rp;
	}
	public Timestamp getHopeDate() {
		return hopeDate;
	}
	public void setHopeDate(Timestamp hopeDate) {
		this.hopeDate = hopeDate;
	}
	public String getDonbok() {
		return donbok;
	}
	public void setDonbok(String donbok) {
		this.donbok = donbok;
	}
}

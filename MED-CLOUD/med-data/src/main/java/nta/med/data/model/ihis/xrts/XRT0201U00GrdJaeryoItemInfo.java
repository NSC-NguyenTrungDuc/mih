package nta.med.data.model.ihis.xrts;

import java.math.BigDecimal;
import java.util.Date;

public class XRT0201U00GrdJaeryoItemInfo {
	private String jaeryoCode;
	private String jaeryoName;
	private String suryang;
	private String ordDanui;
	private Double pkinv1001;
	private String bunho;
	private String orderDate;
	private String inOutGubun;
	private Date actingDate;
	private String actingBuseo;
	private Double fkocsInv;
	private BigDecimal fkocsXrt;
	private String danuiName;
	private String bunryu2;
	private String jaeryoGubun;
	private String jaeryoYn;
	private String inputControl;
	private String bunCode;
	private Double nalsu;

	public XRT0201U00GrdJaeryoItemInfo(String jaeryoCode, String jaeryoName,
			String suryang, String ordDanui, Double pkinv1001, String bunho,
			String orderDate, String inOutGubun, Date actingDate,
			String actingBuseo, Double fkocsInv, BigDecimal fkocsXrt,
			String danuiName, String bunryu2, String jaeryoGubun,
			String jaeryoYn, String inputControl, String bunCode, Double nalsu) {
		super();
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.suryang = suryang;
		this.ordDanui = ordDanui;
		this.pkinv1001 = pkinv1001;
		this.bunho = bunho;
		this.orderDate = orderDate;
		this.inOutGubun = inOutGubun;
		this.actingDate = actingDate;
		this.actingBuseo = actingBuseo;
		this.fkocsInv = fkocsInv;
		this.fkocsXrt = fkocsXrt;
		this.danuiName = danuiName;
		this.bunryu2 = bunryu2;
		this.jaeryoGubun = jaeryoGubun;
		this.jaeryoYn = jaeryoYn;
		this.inputControl = inputControl;
		this.bunCode = bunCode;
		this.nalsu = nalsu;
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

	public String getSuryang() {
		return suryang;
	}

	public void setSuryang(String suryang) {
		this.suryang = suryang;
	}

	public String getOrdDanui() {
		return ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	public Double getPkinv1001() {
		return pkinv1001;
	}

	public void setPkinv1001(Double pkinv1001) {
		this.pkinv1001 = pkinv1001;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}

	public String getInOutGubun() {
		return inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}

	public Date getActingDate() {
		return actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}

	public String getActingBuseo() {
		return actingBuseo;
	}

	public void setActingBuseo(String actingBuseo) {
		this.actingBuseo = actingBuseo;
	}

	public Double getFkocsInv() {
		return fkocsInv;
	}

	public void setFkocsInv(Double fkocsInv) {
		this.fkocsInv = fkocsInv;
	}

	public BigDecimal getFkocsXrt() {
		return fkocsXrt;
	}

	public void setFkocsXrt(BigDecimal fkocsXrt) {
		this.fkocsXrt = fkocsXrt;
	}

	public String getDanuiName() {
		return danuiName;
	}

	public void setDanuiName(String danuiName) {
		this.danuiName = danuiName;
	}

	public String getBunryu2() {
		return bunryu2;
	}

	public void setBunryu2(String bunryu2) {
		this.bunryu2 = bunryu2;
	}

	public String getJaeryoGubun() {
		return jaeryoGubun;
	}

	public void setJaeryoGubun(String jaeryoGubun) {
		this.jaeryoGubun = jaeryoGubun;
	}

	public String getJaeryoYn() {
		return jaeryoYn;
	}

	public void setJaeryoYn(String jaeryoYn) {
		this.jaeryoYn = jaeryoYn;
	}

	public String getInputControl() {
		return inputControl;
	}

	public void setInputControl(String inputControl) {
		this.inputControl = inputControl;
	}

	public String getBunCode() {
		return bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}

	public Double getNalsu() {
		return nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}

}
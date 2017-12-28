package nta.med.data.model.ihis.inps;

public class INP2001U02grdOcs2003Info {

	private Double pkOcs2003;
	private String orderGubunName;
	private String hangmogCode;
	private String hangmogName;
	private Double surYang;
	private String ordDanuiName;
	private String dvTime;
	private Double dv;
	private Double nalsu;
	private String specimenName;

	public INP2001U02grdOcs2003Info(Double pkOcs2003, String orderGubunName, String hangmogCode, String hangmogName,
			Double surYang, String ordDanuiName, String dvTime, Double dv, Double nalsu, String specimenName) {
		super();
		this.pkOcs2003 = pkOcs2003;
		this.orderGubunName = orderGubunName;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.surYang = surYang;
		this.ordDanuiName = ordDanuiName;
		this.dvTime = dvTime;
		this.dv = dv;
		this.nalsu = nalsu;
		this.specimenName = specimenName;
	}

	public Double getPkOcs2003() {
		return pkOcs2003;
	}

	public void setPkOcs2003(Double pkOcs2003) {
		this.pkOcs2003 = pkOcs2003;
	}

	public String getOrderGubunName() {
		return orderGubunName;
	}

	public void setOrderGubunName(String orderGubunName) {
		this.orderGubunName = orderGubunName;
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

	public Double getSurYang() {
		return surYang;
	}

	public void setSurYang(Double surYang) {
		this.surYang = surYang;
	}

	public String getOrdDanuiName() {
		return ordDanuiName;
	}

	public void setOrdDanuiName(String ordDanuiName) {
		this.ordDanuiName = ordDanuiName;
	}

	public String getDvTime() {
		return dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}

	public Double getDv() {
		return dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

	public Double getNalsu() {
		return nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}

	public String getSpecimenName() {
		return specimenName;
	}

	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}

}

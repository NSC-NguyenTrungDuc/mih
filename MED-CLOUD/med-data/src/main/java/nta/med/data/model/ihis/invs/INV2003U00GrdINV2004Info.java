package nta.med.data.model.ihis.invs;

public class INV2003U00GrdINV2004Info {
	private Double pkinv2004;
	private Double fkinv2003;
	private String jaeryoCode;
	private String jaeryoName;
	private Double chulgoQty;
	private String chulgoDanuiName;
	private Double chulgoDanga;
	private String remark;


	public INV2003U00GrdINV2004Info(Double pkinv2004, Double fkinv2003, String jaeryoCode, String jaeryoName, Double chulgoQty, String chulgoDanuiName, Double chulgoDanga, String remark) {
		super();
		this.pkinv2004 = pkinv2004;
		this.fkinv2003 = fkinv2003;
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.chulgoQty = chulgoQty;
		this.chulgoDanuiName = chulgoDanuiName;
		this.chulgoDanga = chulgoDanga;
		this.remark = remark;
				
	}


	public Double getPkinv2004() {
		return pkinv2004;
	}


	public void setPkinv2004(Double pkinv2004) {
		this.pkinv2004 = pkinv2004;
	}


	public Double getFkinv2003() {
		return fkinv2003;
	}


	public void setFkinv2003(Double fkinv2003) {
		this.fkinv2003 = fkinv2003;
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


	public Double getChulgoQty() {
		return chulgoQty;
	}


	public void setChulgoQty(Double chulgoQty) {
		this.chulgoQty = chulgoQty;
	}


	public String getChulgoDanuiName() {
		return chulgoDanuiName;
	}


	public void setChulgoDanuiName(String chulgoDanuiName) {
		this.chulgoDanuiName = chulgoDanuiName;
	}


	public Double getChulgoDanga() {
		return chulgoDanga;
	}


	public void setChulgoDanga(Double chulgoDanga) {
		this.chulgoDanga = chulgoDanga;
	}


	public String getRemark() {
		return remark;
	}


	public void setRemark(String remark) {
		this.remark = remark;
	}

	
}

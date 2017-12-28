package nta.med.data.model.ihis.system;

public class HILoadCodeNameInfo {
	private String orderGubunName      ;
	private String specimenName         ;
	private String jusaName             ;
	private String payName              ;
	private String bogyongName          ;
	private String jundalPartOutName  ;
	private String jundalPartInpName  ;
	private String ordDanuiName        ;
	private String mayakYn              ;
	public HILoadCodeNameInfo(String orderGubunName, String specimenName,
			String jusaName, String payName, String bogyongName,
			String jundalPartOutName, String jundalPartInpName,
			String ordDanuiName, String mayakYn) {
		super();
		this.orderGubunName = orderGubunName;
		this.specimenName = specimenName;
		this.jusaName = jusaName;
		this.payName = payName;
		this.bogyongName = bogyongName;
		this.jundalPartOutName = jundalPartOutName;
		this.jundalPartInpName = jundalPartInpName;
		this.ordDanuiName = ordDanuiName;
		this.mayakYn = mayakYn;
	}
	public String getOrderGubunName() {
		return orderGubunName;
	}
	public void setOrderGubunName(String orderGubunName) {
		this.orderGubunName = orderGubunName;
	}
	public String getSpecimenName() {
		return specimenName;
	}
	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}
	public String getJusaName() {
		return jusaName;
	}
	public void setJusaName(String jusaName) {
		this.jusaName = jusaName;
	}
	public String getPayName() {
		return payName;
	}
	public void setPayName(String payName) {
		this.payName = payName;
	}
	public String getBogyongName() {
		return bogyongName;
	}
	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}
	public String getJundalPartOutName() {
		return jundalPartOutName;
	}
	public void setJundalPartOutName(String jundalPartOutName) {
		this.jundalPartOutName = jundalPartOutName;
	}
	public String getJundalPartInpName() {
		return jundalPartInpName;
	}
	public void setJundalPartInpName(String jundalPartInpName) {
		this.jundalPartInpName = jundalPartInpName;
	}
	public String getOrdDanuiName() {
		return ordDanuiName;
	}
	public void setOrdDanuiName(String ordDanuiName) {
		this.ordDanuiName = ordDanuiName;
	}
	public String getMayakYn() {
		return mayakYn;
	}
	public void setMayakYn(String mayakYn) {
		this.mayakYn = mayakYn;
	}
	

}

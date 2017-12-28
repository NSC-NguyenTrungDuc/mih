package nta.med.data.model.ihis.bass;

public class BAS0111U00GrdBas0111ItemInfo {
	private String johapGubun ;
	private String johap ;
	private String gaein ;
	private String useYn ;
	private String zipCode1 ;
	private String zipCode2 ;
	private String address ;
	private String address1 ;
	private String name ;
	private String contKey ;
	public BAS0111U00GrdBas0111ItemInfo(String johapGubun, String johap,
			String gaein, String useYn, String zipCode1, String zipCode2,
			String address, String address1, String name, String contKey) {
		super();
		this.johapGubun = johapGubun;
		this.johap = johap;
		this.gaein = gaein;
		this.useYn = useYn;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
		this.address = address;
		this.address1 = address1;
		this.name = name;
		this.contKey = contKey;
	}
	public String getJohapGubun() {
		return johapGubun;
	}
	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}
	public String getJohap() {
		return johap;
	}
	public void setJohap(String johap) {
		this.johap = johap;
	}
	public String getGaein() {
		return gaein;
	}
	public void setGaein(String gaein) {
		this.gaein = gaein;
	}
	public String getUseYn() {
		return useYn;
	}
	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}
	public String getZipCode1() {
		return zipCode1;
	}
	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}
	public String getZipCode2() {
		return zipCode2;
	}
	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getAddress1() {
		return address1;
	}
	public void setAddress1(String address1) {
		this.address1 = address1;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getContKey() {
		return contKey;
	}
	public void setContKey(String contKey) {
		this.contKey = contKey;
	}
	
}

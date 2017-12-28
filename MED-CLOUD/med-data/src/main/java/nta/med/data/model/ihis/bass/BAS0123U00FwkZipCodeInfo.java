package nta.med.data.model.ihis.bass;

import java.io.Serializable;

public class BAS0123U00FwkZipCodeInfo implements Serializable{
	 private String zipCode;
     private String zipName1;
     private String zipName2;
     private String zipName3;
	public BAS0123U00FwkZipCodeInfo(String zipCode, String zipName1,
			String zipName2, String zipName3) {
		super();
		this.zipCode = zipCode;
		this.zipName1 = zipName1;
		this.zipName2 = zipName2;
		this.zipName3 = zipName3;
	}
	public String getZipCode() {
		return zipCode;
	}
	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}
	public String getZipName1() {
		return zipName1;
	}
	public void setZipName1(String zipName1) {
		this.zipName1 = zipName1;
	}
	public String getZipName2() {
		return zipName2;
	}
	public void setZipName2(String zipName2) {
		this.zipName2 = zipName2;
	}
	public String getZipName3() {
		return zipName3;
	}
	public void setZipName3(String zipName3) {
		this.zipName3 = zipName3;
	}
}

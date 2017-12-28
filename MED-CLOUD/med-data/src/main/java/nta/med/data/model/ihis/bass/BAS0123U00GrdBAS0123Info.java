package nta.med.data.model.ihis.bass;

import java.io.Serializable;

public class BAS0123U00GrdBAS0123Info implements Serializable{
	 private String zipCode;
     private String zipName1;
     private String zipName2;
     private String zipName3;
     private String zipNameGana1;
     private String zipNameGana2;
     private String zipNameGana3;
     private String zipTonggye;
	public BAS0123U00GrdBAS0123Info(String zipCode, String zipName1,
			String zipName2, String zipName3, String zipNameGana1,
			String zipNameGana2, String zipNameGana3, String zipTonggye) {
		super();
		this.zipCode = zipCode;
		this.zipName1 = zipName1;
		this.zipName2 = zipName2;
		this.zipName3 = zipName3;
		this.zipNameGana1 = zipNameGana1;
		this.zipNameGana2 = zipNameGana2;
		this.zipNameGana3 = zipNameGana3;
		this.zipTonggye = zipTonggye;
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
	public String getZipNameGana1() {
		return zipNameGana1;
	}
	public void setZipNameGana1(String zipNameGana1) {
		this.zipNameGana1 = zipNameGana1;
	}
	public String getZipNameGana2() {
		return zipNameGana2;
	}
	public void setZipNameGana2(String zipNameGana2) {
		this.zipNameGana2 = zipNameGana2;
	}
	public String getZipNameGana3() {
		return zipNameGana3;
	}
	public void setZipNameGana3(String zipNameGana3) {
		this.zipNameGana3 = zipNameGana3;
	}
	public String getZipTonggye() {
		return zipTonggye;
	}
	public void setZipTonggye(String zipTonggye) {
		this.zipTonggye = zipTonggye;
	}
}

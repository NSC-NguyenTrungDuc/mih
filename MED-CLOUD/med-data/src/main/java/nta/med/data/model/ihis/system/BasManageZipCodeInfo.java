package nta.med.data.model.ihis.system;

import java.io.Serializable;

public class BasManageZipCodeInfo implements Serializable{
	private String zipCode;
    private String zipName1;
    private String zipName2;
    private String zipName3;
    private String zipNameGaga1;
    private String zipNameGaga2;
    private String zipNameGaga3;
    private String zipCode1;
    private String zipCode2;
	public BasManageZipCodeInfo(String zipCode, String zipName1,
			String zipName2, String zipName3, String zipNameGaga1,
			String zipNameGaga2, String zipNameGaga3, String zipCode1,
			String zipCode2) {
		super();
		this.zipCode = zipCode;
		this.zipName1 = zipName1;
		this.zipName2 = zipName2;
		this.zipName3 = zipName3;
		this.zipNameGaga1 = zipNameGaga1;
		this.zipNameGaga2 = zipNameGaga2;
		this.zipNameGaga3 = zipNameGaga3;
		this.zipCode1 = zipCode1;
		this.zipCode2 = zipCode2;
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
	public String getZipNameGaga1() {
		return zipNameGaga1;
	}
	public void setZipNameGaga1(String zipNameGaga1) {
		this.zipNameGaga1 = zipNameGaga1;
	}
	public String getZipNameGaga2() {
		return zipNameGaga2;
	}
	public void setZipNameGaga2(String zipNameGaga2) {
		this.zipNameGaga2 = zipNameGaga2;
	}
	public String getZipNameGaga3() {
		return zipNameGaga3;
	}
	public void setZipNameGaga3(String zipNameGaga3) {
		this.zipNameGaga3 = zipNameGaga3;
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
    
}

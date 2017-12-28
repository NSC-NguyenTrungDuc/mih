package nta.med.data.model.ihis.system;

import java.util.Date;

public class LoadPatientBaseInfo {
	private String ioSuname;
	private String ioSuname2;
	private String ioSujumin1;
	private String ioSujumin2;
	private String ioSex;
	private Date ioBirth;
	private String ioAge;
	private Double ioAgeNum;
	private Double ioWeight;
	private Double ioHeight;
	private String ioZipCode1;
	private String ioZipCode2;
	private String ioAddress1;
	private String ioAddress2;
	private String ioTel;
	private String ioTel1;
	private String ioTelHp;
	private String ioPaceMakerYn;
	private String ioDummy2;
	private String ioDummy3;
	private String ioFlag;

	public LoadPatientBaseInfo(String ioSuname, String ioSuname2,
			String ioSujumin1, String ioSujumin2, String ioSex, Date ioBirth,
			String ioAge, Double ioAgeNum, Double ioWeight, Double ioHeight,
			String ioZipCode1, String ioZipCode2, String ioAddress1,
			String ioAddress2, String ioTel, String ioTel1, String ioTelHp,
			String ioPaceMakerYn, String ioDummy2, String ioDummy3,
			String ioFlag) {
		super();
		this.ioSuname = ioSuname;
		this.ioSuname2 = ioSuname2;
		this.ioSujumin1 = ioSujumin1;
		this.ioSujumin2 = ioSujumin2;
		this.ioSex = ioSex;
		this.ioBirth = ioBirth;
		this.ioAge = ioAge;
		this.ioAgeNum = ioAgeNum;
		this.ioWeight = ioWeight;
		this.ioHeight = ioHeight;
		this.ioZipCode1 = ioZipCode1;
		this.ioZipCode2 = ioZipCode2;
		this.ioAddress1 = ioAddress1;
		this.ioAddress2 = ioAddress2;
		this.ioTel = ioTel;
		this.ioTel1 = ioTel1;
		this.ioTelHp = ioTelHp;
		this.ioPaceMakerYn = ioPaceMakerYn;
		this.ioDummy2 = ioDummy2;
		this.ioDummy3 = ioDummy3;
		this.ioFlag = ioFlag;
	}

	public String getIoSuname() {
		return ioSuname;
	}

	public void setIoSuname(String ioSuname) {
		this.ioSuname = ioSuname;
	}

	public String getIoSuname2() {
		return ioSuname2;
	}

	public void setIoSuname2(String ioSuname2) {
		this.ioSuname2 = ioSuname2;
	}

	public String getIoSujumin1() {
		return ioSujumin1;
	}

	public void setIoSujumin1(String ioSujumin1) {
		this.ioSujumin1 = ioSujumin1;
	}

	public String getIoSujumin2() {
		return ioSujumin2;
	}

	public void setIoSujumin2(String ioSujumin2) {
		this.ioSujumin2 = ioSujumin2;
	}

	public String getIoSex() {
		return ioSex;
	}

	public void setIoSex(String ioSex) {
		this.ioSex = ioSex;
	}

	public Date getIoBirth() {
		return ioBirth;
	}

	public void setIoBirth(Date ioBirth) {
		this.ioBirth = ioBirth;
	}

	public String getIoAge() {
		return ioAge;
	}

	public void setIoAge(String ioAge) {
		this.ioAge = ioAge;
	}

	public Double getIoAgeNum() {
		return ioAgeNum;
	}

	public void setIoAgeNum(Double ioAgeNum) {
		this.ioAgeNum = ioAgeNum;
	}

	public Double getIoWeight() {
		return ioWeight;
	}

	public void setIoWeight(Double ioWeight) {
		this.ioWeight = ioWeight;
	}

	public Double getIoHeight() {
		return ioHeight;
	}

	public void setIoHeight(Double ioHeight) {
		this.ioHeight = ioHeight;
	}

	public String getIoZipCode1() {
		return ioZipCode1;
	}

	public void setIoZipCode1(String ioZipCode1) {
		this.ioZipCode1 = ioZipCode1;
	}

	public String getIoZipCode2() {
		return ioZipCode2;
	}

	public void setIoZipCode2(String ioZipCode2) {
		this.ioZipCode2 = ioZipCode2;
	}

	public String getIoAddress1() {
		return ioAddress1;
	}

	public void setIoAddress1(String ioAddress1) {
		this.ioAddress1 = ioAddress1;
	}

	public String getIoAddress2() {
		return ioAddress2;
	}

	public void setIoAddress2(String ioAddress2) {
		this.ioAddress2 = ioAddress2;
	}

	public String getIoTel() {
		return ioTel;
	}

	public void setIoTel(String ioTel) {
		this.ioTel = ioTel;
	}

	public String getIoTel1() {
		return ioTel1;
	}

	public void setIoTel1(String ioTel1) {
		this.ioTel1 = ioTel1;
	}

	public String getIoTelHp() {
		return ioTelHp;
	}

	public void setIoTelHp(String ioTelHp) {
		this.ioTelHp = ioTelHp;
	}

	public String getIoPaceMakerYn() {
		return ioPaceMakerYn;
	}

	public void setIoPaceMakerYn(String ioPaceMakerYn) {
		this.ioPaceMakerYn = ioPaceMakerYn;
	}

	public String getIoDummy2() {
		return ioDummy2;
	}

	public void setIoDummy2(String ioDummy2) {
		this.ioDummy2 = ioDummy2;
	}

	public String getIoDummy3() {
		return ioDummy3;
	}

	public void setIoDummy3(String ioDummy3) {
		this.ioDummy3 = ioDummy3;
	}

	public String getIoFlag() {
		return ioFlag;
	}

	public void setIoFlag(String ioFlag) {
		this.ioFlag = ioFlag;
	}
	
	public boolean isEmptyPatient(){
		return 	ioSuname == null
				&& ioSuname2 == null
				&& ioSujumin1 == null
				&& ioSujumin2 == null
				&& ioSex == null
				&& ioBirth == null
				&& ioAge == null
				&& ioAgeNum == null
				&& ioWeight == null
				&& ioHeight == null
				&& ioZipCode1 == null
				&& ioZipCode2 == null
				&& ioAddress1 == null
				&& ioAddress2 == null
				&& ioTel == null
				&& ioTel1 == null
				&& ioTelHp == null
				&& ioPaceMakerYn == null
				&& ioDummy2 == null
				&& ioDummy3 == null;
	}
}

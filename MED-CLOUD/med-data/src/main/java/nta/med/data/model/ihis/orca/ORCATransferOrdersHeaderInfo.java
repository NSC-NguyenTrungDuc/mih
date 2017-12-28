package nta.med.data.model.ihis.orca;

public class ORCATransferOrdersHeaderInfo {
	private String facilityId     ;
	private String sysDate        ;
	private String hospName       ;
	private String hospAddress    ;
	private String hospZipcode    ;
	private String facilityCode   ;
	private String creatorText    ;
	private String countryType    ;
	public ORCATransferOrdersHeaderInfo(String facilityId, String sysDate,
			String hospName, String hospAddress, String hospZipcode,
			String facilityCode, String creatorText, String countryType) {
		super();
		this.facilityId = facilityId;
		this.sysDate = sysDate;
		this.hospName = hospName;
		this.hospAddress = hospAddress;
		this.hospZipcode = hospZipcode;
		this.facilityCode = facilityCode;
		this.creatorText = creatorText;
		this.countryType = countryType;
	}
	public String getFacilityId() {
		return facilityId;
	}
	public void setFacilityId(String facilityId) {
		this.facilityId = facilityId;
	}
	public String getSysDate() {
		return sysDate;
	}
	public void setSysDate(String sysDate) {
		this.sysDate = sysDate;
	}
	public String getHospName() {
		return hospName;
	}
	public void setHospName(String hospName) {
		this.hospName = hospName;
	}
	public String getHospAddress() {
		return hospAddress;
	}
	public void setHospAddress(String hospAddress) {
		this.hospAddress = hospAddress;
	}
	public String getHospZipcode() {
		return hospZipcode;
	}
	public void setHospZipcode(String hospZipcode) {
		this.hospZipcode = hospZipcode;
	}
	public String getFacilityCode() {
		return facilityCode;
	}
	public void setFacilityCode(String facilityCode) {
		this.facilityCode = facilityCode;
	}
	public String getCreatorText() {
		return creatorText;
	}
	public void setCreatorText(String creatorText) {
		this.creatorText = creatorText;
	}
	public String getCountryType() {
		return countryType;
	}
	public void setCountryType(String countryType) {
		this.countryType = countryType;
	}
	
}

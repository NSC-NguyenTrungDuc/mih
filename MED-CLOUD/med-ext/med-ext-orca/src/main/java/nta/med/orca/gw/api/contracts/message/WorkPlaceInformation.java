package nta.med.orca.gw.api.contracts.message;

import java.util.Objects;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class WorkPlaceInformation {

	private String wholeName;
	private String addressZipCode;
	private String wholeAddress1;
	private String wholeAddress2;
	private String phoneNumber;

	@JacksonXmlProperty(localName = "WholeName")
	public String getWholeName() {
		return wholeName;
	}

	public void setWholeName(String wholeName) {
		this.wholeName = wholeName;
	}

	@JacksonXmlProperty(localName = "Address_ZipCode")
	public String getAddressZipCode() {
		return addressZipCode;
	}

	public void setAddressZipCode(String addressZipCode) {
		this.addressZipCode = addressZipCode;
	}

	@JacksonXmlProperty(localName = "WholeAddress1")
	public String getWholeAddress1() {
		return wholeAddress1;
	}

	public void setWholeAddress1(String wholeAddress1) {
		this.wholeAddress1 = wholeAddress1;
	}

	@JacksonXmlProperty(localName = "WholeAddress2")
	public String getWholeAddress2() {
		return wholeAddress2;
	}

	public void setWholeAddress2(String wholeAddress2) {
		this.wholeAddress2 = wholeAddress2;
	}

	@JacksonXmlProperty(localName = "PhoneNumber")
	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	@Override
	public int hashCode() {
		return Objects.hash(wholeName, addressZipCode, wholeAddress1, wholeAddress2, phoneNumber);
	}
	
}

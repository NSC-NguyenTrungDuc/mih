package nta.med.orca.gw.api.contracts.message;

import java.util.Objects;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class HomeAddressInformation {

	private String addressZipCode;
	private String wholeAddress1;
	private String wholeAddress2;
	private String phoneNumber1;
	private String phoneNumber2;

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

	@JacksonXmlProperty(localName = "PhoneNumber1")
	public String getPhoneNumber1() {
		return phoneNumber1;
	}

	public void setPhoneNumber1(String phoneNumber1) {
		this.phoneNumber1 = phoneNumber1;
	}

	@JacksonXmlProperty(localName = "PhoneNumber2")
	public String getPhoneNumber2() {
		return phoneNumber2;
	}

	public void setPhoneNumber2(String phoneNumber2) {
		this.phoneNumber2 = phoneNumber2;
	}

	@Override
	public int hashCode() {
		return Objects.hash(addressZipCode, wholeAddress1, wholeAddress2, phoneNumber1, phoneNumber2);
	}
}

package nta.med.orca.gw.api.contracts.message;

import java.util.Objects;

import org.apache.commons.math3.filter.KalmanFilter;

import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlText;

public class BaseNode {

	private String value;
	private String type;

	public BaseNode() {
		super();
	}

	public BaseNode(String value) {
		super();
		this.value = value;
		this.type = "string";
	}

	public BaseNode(String value, String type) {
		super();
		this.value = value;
		this.type = type;
	}

	@JacksonXmlText
	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

	@JacksonXmlProperty(localName = "type", isAttribute = true)
	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	@Override
	public int hashCode() {
		return Objects.hash(value);
	}
	
}

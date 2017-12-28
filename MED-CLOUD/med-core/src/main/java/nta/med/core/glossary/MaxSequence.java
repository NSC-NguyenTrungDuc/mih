package nta.med.core.glossary;

import java.math.BigDecimal;

public enum MaxSequence {
	OUT0101_MAX_SEQUENCE(new BigDecimal(999999));
	
	private final BigDecimal value;
	MaxSequence(BigDecimal value) {
		this.value = value;
	}
	
	public BigDecimal getValue() {
		return value;
	}
}

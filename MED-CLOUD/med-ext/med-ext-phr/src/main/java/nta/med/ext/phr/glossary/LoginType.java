package nta.med.ext.phr.glossary;

import java.math.BigDecimal;

public enum LoginType {
	NORMAL(BigDecimal.ZERO), FACE_BOOK(BigDecimal.ONE);

	private BigDecimal value;

	private LoginType(BigDecimal value) {
		this.value = value;
	}

	public BigDecimal getValue() {
		return value;
	}
}

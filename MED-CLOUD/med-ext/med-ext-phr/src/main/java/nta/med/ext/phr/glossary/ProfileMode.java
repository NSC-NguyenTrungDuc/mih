package nta.med.ext.phr.glossary;

import java.math.BigDecimal;

/**
 * @author DEV-TiepNM
 */
public enum  ProfileMode {
    BABY(new BigDecimal(1)), STANDARD(new BigDecimal(0));

    private BigDecimal value;

    private ProfileMode(BigDecimal value) {
        this.value = value;
    }

    public BigDecimal getValue() {
        return value;
    }
}

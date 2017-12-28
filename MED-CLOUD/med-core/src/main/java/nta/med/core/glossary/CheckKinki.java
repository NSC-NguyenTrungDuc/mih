package nta.med.core.glossary;

/**
 * @author DEV-TiepNM
 */
public enum CheckKinki {
    CHECK_DOSAGE("CHECK_DOSAGE"), CHECK_INTERACTION("CHECK_INTERACTION"), CHECK_KINKI("CHECK_KINKI");
    private String value;

    CheckKinki(String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}

package nta.med.core.glossary;

/**
 * @author DEV-TiepNM
 */
public enum KinkiTable {


    DRUG_KINKI_MESSAGE("DRUG_KINKI_MESSAGE"),
    DRUG_KINKI_DISEASE("DRUG_KINKI_DISEASE"),
    DRUG_DOSAGE("DRUG_DOSAGE"),
    DRUG_DOSAGE_NORMAL("DRUG_DOSAGE_NORMAL"),
    DRUG_DOSAGE_STANDARD("DRUG_DOSAGE_STANDARD"),
    DRUG_DOSAGE_ADDITION("DRUG_DOSAGE_ADDITION"),
    DRUG_CHECKING("DRUG_CHECKING"),
    DRUG_INTERACTION("DRUG_INTERACTION"),
    DRUG_GENERIC_NAME("DRUG_GENERIC_NAME");
    private String value;

    KinkiTable(String value) {
        this.value = value;
    }
    public static KinkiTable get(String value) {
        for (KinkiTable kinkiTable : KinkiTable.values()) {
            if (kinkiTable.value.equals(value)) return kinkiTable;
        }
        return null;
    }

    public String getValue() {
        return value;
    }
}

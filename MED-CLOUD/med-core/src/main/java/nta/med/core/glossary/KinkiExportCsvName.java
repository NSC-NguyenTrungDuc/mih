package nta.med.core.glossary;

/**
 * @author DEV-TiepNM
 */
public enum KinkiExportCsvName {


    DRUG_KINKI_MESSAGE("Sample_kinki_honnbunn"),
    DRUG_KINKI_DISEASE("Sample_kinki_byoumei"),
    DRUG_DOSAGE("Sample_youhou"),
    DRUG_CHECKING("info_part"),
    DRUG_INTERACTION("Sample_Drug_Interaction"),
    DRUG_GENERIC_NAME("Sample_Generic_Name");
    private String value;

    KinkiExportCsvName(String value) {
        this.value = value;
    }
    public static KinkiExportCsvName get(String value) {
        for (KinkiExportCsvName kinkiTable : KinkiExportCsvName.values()) {
            if (kinkiTable.value.equals(value)) return kinkiTable;
        }
        return null;
    }

    public String getValue() {
        return value;
    }
}

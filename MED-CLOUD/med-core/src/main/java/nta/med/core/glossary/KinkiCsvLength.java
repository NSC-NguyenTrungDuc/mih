package nta.med.core.glossary;

public enum KinkiCsvLength {
	DRUG_KINKI_MESSAGE(5), DRUG_KINKI_DISEASE(7), DRUG_DOSAGE(100), DRUG_INTERACTION (11), DRUG_GENERIC_NAME(9), DRUG_CHECKING (27);
    private Integer value;

    KinkiCsvLength(Integer value) {
        this.value = value;
    }

    public Integer getValue() {
        return value;
    }

}

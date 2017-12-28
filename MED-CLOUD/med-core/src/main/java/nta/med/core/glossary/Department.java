package nta.med.core.glossary;

/**
 * @author dainguyen.
 */
public enum Department {
    ADMA("adma"), BASS("bass"), CHTS("chts"), CPLS("cpls"), DRGS("drgs"), DRUG("drug"), INJS("injs"), NURI("nuri"), NURO("patient"), NUTS("nuts"),
    OCSA("ocsa"), OCSO("ocso"), PFES("pfes"), PHYS("phys"), SCHS("schs"), SYSTEM("system"), XRTS("xrts"), SHUNOU("shunou"), EMR("emr"), HOM("hom");

    private String value;

    Department(String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}

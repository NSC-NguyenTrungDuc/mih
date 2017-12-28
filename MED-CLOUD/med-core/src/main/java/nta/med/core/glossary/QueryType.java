package nta.med.core.glossary;

/**
 * @author Tiepnm
 */
public enum QueryType {

    SANGCODE("SangCode"),
    SUSIKCODE("SusikCode"),
    DRUGCODE("DrugCode"),
    JINRYOCODE("JinryoCode"),
    TOKUTEICODE("TokuteiCode"),
    JOJECODE("JojeCode"),
    YJCODE("YJCode"),
    DRGSAKURA("DrgSakura"),
    GENDRG("GenDrg"),
    GENDRMAP("GenDrgMap");

    private String value;

    QueryType(String value) {
        this.value = value;
    }

    public static QueryType get(String value) {
        for (QueryType queryType : QueryType.values()) {
            if (queryType.value.equals(value)) return queryType;
        }
        return null;
    }

    public String getValue() {
        return value;
    }
}

package nta.med.core.glossary;

/**
 * @author DEV-TiepNM
 */
public enum AccountingConfig {
	ACCCT_TYPE_ORCA("00"), ACCT_TYPE_MISA("20"),
    ACCT_TYPE("ACCT_TYPE"), ACCT_ORCA("ACCT_ORCA"), ACCT_MISA("ACCT_MISA"),
    ORCA_IP("ORCA_IP"), ORCA_USER("ORCA_USER"), ORCA_PWD("ORCA_PWD"),
    HOSP_CODE("HOSP_CODE"), ORCA_CONF("ORCA_CONF"),
    ORCA_PORT("ORCA_PORT"), PORT_CLAIM("PORT_CLAIM"), CLOUD_YN("CLOUD_YN"),
    
    IF_ORCA_GWA("IF_ORCA_GWA"), IF_ORCA_DOCTOR("IF_ORCA_DOCTOR"),
    
    MISA_IP("MISA_IP"), MISA_USER("MISA_USER"), MISA_PWD("MISA_PWD"),
    INST_NAME("INST_NAME"),DB_NAME("DB_NAME");
    private String value;

    AccountingConfig(String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}

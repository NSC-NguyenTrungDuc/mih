package nta.med.core.glossary;

/**
 * @author dainguyen.
 */
public enum AdministrationNotice {
    MAINTAINANCE_NOTICE("MAINTAINANCE_NOTICE"),
    MAINTAINANCE_WHOLE_SYSTEM_NOTICE("MAINTAINANCE_WHOLE_SYSTEM_NOTICE");

    private String address;

    AdministrationNotice(String address) {
        this.address = address;
    }

    public String getAddress() {
        return address;
    }
}

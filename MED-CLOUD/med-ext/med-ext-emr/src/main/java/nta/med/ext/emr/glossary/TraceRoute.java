package nta.med.ext.emr.glossary;

/**
 * @author dainguyen.
 */
public enum TraceRoute {
    KCCK((byte)1, "KCCK"), PHR((byte)2, "PHR");


    private final byte value;
    private final String displayName;

    TraceRoute(byte value, String displayName) {
        this.value = value;
        this.displayName = displayName;
    }

    public byte getValue() {
        return value;
    }

    public String getDisplayName() {
        return displayName;
    }
}

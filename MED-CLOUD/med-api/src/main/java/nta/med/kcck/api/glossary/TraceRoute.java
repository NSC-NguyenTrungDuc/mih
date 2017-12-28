package nta.med.kcck.api.glossary;

/**
 * @author dainguyen.
 */
public enum TraceRoute {
    CMS((byte)1, "CMS"), MSS((byte)2, "MSS"), ORCA((byte)3, "ORCA"), PHR((byte)4, "PHR"), MISA((byte)5, "MISA");


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

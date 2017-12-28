package nta.med.ext.mss.glossary;
/**
 * @author dainguyen.
 */
public enum TraceRoute {
    CMS((byte)1, "CMS"), MSS((byte)2, "MSS");


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

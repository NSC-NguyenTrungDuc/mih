package nta.med.core.glossary;

/**
 * @author DEV-TiepNM
 */
public enum  Booking {
    BOOKING(0), CHANGE_BOOKING(1), DELETE_BOOKING(3);
    private int value;

    Booking(int value)
    {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}

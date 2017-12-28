package nta.med.core.caching.glossary;

/**
 * @author dainguyen
 */
public enum LockingStrategy {
    NONE(0), TABLE_LEVEL(1), ROW_LEVEL(2);

    private int value;

    LockingStrategy(int value) {
        this.value = value;
    }
}

package nta.med.core.caching.glossary;

/**
 * @author dainguyen
 */
public enum StorageStrategy {
    JDK(0), JACKSON(1), JACKSON2(2);

    private int value;

    StorageStrategy(int value) {
        this.value = value;
    }
}

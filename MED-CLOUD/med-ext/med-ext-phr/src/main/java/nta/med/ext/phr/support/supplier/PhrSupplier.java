package nta.med.ext.phr.support.supplier;

/**
 * @author DEV-TiepNM
 */
@FunctionalInterface
public interface PhrSupplier<T> {

    T get() throws Exception;
}

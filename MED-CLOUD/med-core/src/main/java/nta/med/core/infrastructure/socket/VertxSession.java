package nta.med.core.infrastructure.socket;

/**
 * @author dainguyen.
 */
public interface VertxSession {
    String getLoginId();

    String getHospCode();

    String getLanguage();

    String getUserGroup();

    Integer getClisSmoId();
}

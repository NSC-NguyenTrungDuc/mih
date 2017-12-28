package nta.med.core.glossary;

import java.util.UUID;

/**
 * @author DEV-TiepNM
 */
public enum SessionApp {
    SESSION_PHR_APP(UUID.randomUUID().toString()),
    SESSION_EMR_APP(UUID.randomUUID().toString()),
    SESSION_CMS_APP(UUID.randomUUID().toString());

    private String value;

    SessionApp(String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}

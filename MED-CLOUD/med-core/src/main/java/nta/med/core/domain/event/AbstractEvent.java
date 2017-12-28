package nta.med.core.domain.event;

import org.springframework.data.annotation.Id;

/**
 * @author dainguyen.
 */
public abstract class AbstractEvent {
    private long id;
    private long timestamp;

    public AbstractEvent() {
    }

    public AbstractEvent(long id, long timestamp) {
        this.id = id;
        this.timestamp = timestamp;
    }

    @Id
    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public long getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(long timestamp) {
        this.timestamp = timestamp;
    }
}

package nta.med.core.infrastructure.socket.listener;

import com.google.protobuf.Message;

/**
 * @author dainguyen.
 */
public abstract class AbstractListener <T extends Message> {

    public abstract void onEvent(T event);

}

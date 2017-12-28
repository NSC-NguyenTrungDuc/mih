package nta.med.core.infrastructure.socket.store.impl;

import com.google.protobuf.Message;
import nta.med.core.infrastructure.socket.store.EventStore;

import java.util.function.BiFunction;
import java.util.function.Supplier;

/**
 * @author dainguyen.
 */
public class FakeEventStoreImpl implements EventStore {

    @Override
    public Message persist(Message event, BiFunction<String, Supplier<Long>, Long> counterFunc) {
        return event;
    }
}

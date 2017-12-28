package nta.med.core.infrastructure.socket.store;

import com.google.protobuf.Message;

import java.util.function.BiFunction;
import java.util.function.Supplier;

/**
 * @author dainguyen.
 */
public interface EventStore {
    Message persist(Message event, BiFunction<String, Supplier<Long>, Long> counterFunc);
}

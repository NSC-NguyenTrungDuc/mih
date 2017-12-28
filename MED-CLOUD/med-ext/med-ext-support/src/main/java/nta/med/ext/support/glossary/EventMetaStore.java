package nta.med.ext.support.glossary;

import com.google.protobuf.Message;
import nta.med.common.util.Objects;
import nta.med.ext.support.proto.BookingServiceProto;
import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.proto.PatientServiceProto;

/**
 * @author dainguyen.
 */
public enum EventMetaStore {
    HOSPITAL(Long.BYTES * 0, "HOSPITAL") {
        @Override
        public long eventID(Message event) {
            if(event != null && event.getClass().equals(HospitalServiceProto.HospitalEvent.class)) {
                HospitalServiceProto.HospitalEvent evt = Objects.cast(event);
                return evt.getId();
            }
            return -1;
        }
    }, PATIENT(Long.BYTES * 1, "PATIENT") {
        @Override
        public long eventID(Message event) {
            if(event != null && event.getClass().equals(PatientServiceProto.PatientEvent.class)) {
                PatientServiceProto.PatientEvent evt = Objects.cast(event);
                return evt.getId();
            }
            return -1;
        }
    }, BOOKING(Long.BYTES * 2, "BOOKING") {
        @Override
        public long eventID(Message event) {
            if(event != null && event.getClass().equals(BookingServiceProto.BookingEvent.class)) {
                BookingServiceProto.BookingEvent evt = Objects.cast(event);
                return evt.getId();
            }
            return -1;
        }
    };
    private final int position;
    private final String eventName;

    public abstract long eventID(Message event);

    EventMetaStore(int position, String eventName) {
        this.position = position;
        this.eventName = eventName;
    }

    public int getPosition() {
        return position;
    }

    public String getEventName() {
        return eventName;
    }
}

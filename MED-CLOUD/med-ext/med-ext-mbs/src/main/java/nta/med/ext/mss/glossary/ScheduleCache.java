package nta.med.ext.mss.glossary;

import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;

import nta.med.common.util.type.Triple;
import nta.med.data.model.ihis.nuro.BookingSchedule;


/**
 * @author DEV-TiepNM
 */
public class ScheduleCache {

    public static ConcurrentMap<String, Triple<Boolean, String, ConcurrentMap<String,  Map<String, List<BookingSchedule>>>>> doctorSchedules = new ConcurrentHashMap<>();
}

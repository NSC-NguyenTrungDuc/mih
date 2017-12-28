package nta.med.core.utils;

import nta.med.common.util.DateTimes;
import nta.med.common.util.type.Pair;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
public class BookingUtils {

    public static List<String> createBookingDate(String startDate, String endDate) {
        List<String> r = new ArrayList<>();
        Date start = DateTimes.toDate("yyyyMMdd", startDate);
        Date end = DateTimes.toDate("yyyyMMdd", endDate);
        while(start.before(end) || start.equals(end)) {
            r.add(DateTimes.format("yyyyMMdd", start));
            start = new Date(DateTimes.addDays(start.getTime(), 1));
        }
        return r;
    }

    public static List<Pair<String>> createTimeFrames(String start, String end, int frame) {
        List<Pair<String>> r = new ArrayList<>();
        String date = DateTimes.format("yyyyMMdd", new Date());
        Date startTime = DateTimes.toDate("yyyyMMdd HHmm", date + " " + start);
        Date endTime = DateTimes.toDate("yyyyMMdd HHmm", date + " " + end);
        while (startTime.before(endTime) || startTime.equals(endTime)) {
            Date mid = new Date(DateTimes.addMinutes(startTime.getTime(), frame));
            r.add(new Pair<>(DateTimes.format("HHmm", startTime), DateTimes.format("HHmm", mid.before(endTime) ? mid : endTime )));
            startTime = mid;
        }
        return r;
    }



    public static boolean isIn(String bookingTime, Pair<String> frame) {
        if(bookingTime == null) return false;
        return frame.getV1().compareTo(bookingTime) <= 0 && frame.getV2().compareTo(bookingTime) > 0;
    }

    public static boolean isIn(String startTime, String endTime, Pair<String> frame) {
        if(startTime == null || endTime == null || frame.getV1() == null || frame.getV2() == null) return false;
        if(endTime.compareTo(frame.getV1()) < 0 || startTime.compareTo(frame.getV2()) > 0) return false;
        String maxStart = startTime.compareTo(frame.getV1()) > 0 ? startTime : frame.getV1();
        String minEnd = endTime.compareTo(frame.getV2()) < 0 ? endTime : frame.getV2();
        return minEnd.compareTo(maxStart) > 0;
    }
}

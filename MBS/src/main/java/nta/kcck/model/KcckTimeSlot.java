package nta.kcck.model;

import java.util.List;

public class KcckTimeSlot {
    private List<KcckBookingSlotModel> enable_booking;
    private String enable_date_slot;
    private String enable_time_slot;

    public String getEnable_date_slot() {
        return enable_date_slot;
    }

    public void setEnable_date_slot(String enable_date_slot) {
        this.enable_date_slot = enable_date_slot;
    }

    public String getEnable_time_slot() {
        return enable_time_slot;
    }

    public void setEnable_time_slot(String enable_time_slot) {
        this.enable_time_slot = enable_time_slot;
    }

    public List<KcckBookingSlotModel> getEnable_booking() {
        return enable_booking;
    }

    public void setEnable_booking(List<KcckBookingSlotModel> enable_booking) {
        this.enable_booking = enable_booking;
    }
}

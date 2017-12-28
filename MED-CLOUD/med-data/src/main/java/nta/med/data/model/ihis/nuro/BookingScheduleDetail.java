package nta.med.data.model.ihis.nuro;

import nta.med.common.util.type.Pair;
import static nta.med.core.utils.BookingUtils.isIn;
public class BookingScheduleDetail {
    private String startTime;
    private String endTime;
    private String totalBookedInSelf;
    private String totalBookedInOther;
    private String totalBookedOut;
    
    public boolean isAvailable(Pair<String> frame, String totalSlot, String otherSlots){
    	return Integer.parseInt(totalSlot) >
        (Integer.parseInt(this.getTotalBookedInOther()) + Integer.parseInt(this.getTotalBookedInSelf()) + Integer.parseInt(this.getTotalBookedOut()))
        && (isIn(this.getStartTime(), this.getEndTime(), frame) && Integer.parseInt(otherSlots) > Integer.parseInt(this.getTotalBookedInOther()));
    }
    
    public boolean isAvailable(String bookingTime, String totalSlot, String otherSlots){
    	return Integer.parseInt(totalSlot) >
        (Integer.parseInt(this.getTotalBookedInOther()) + Integer.parseInt(this.getTotalBookedInSelf()) + Integer.parseInt(this.getTotalBookedOut()))
        && (isIn(bookingTime, new Pair<String>(this.getStartTime(), this.getEndTime()))
                && Integer.parseInt(otherSlots) > Integer.parseInt(this.getTotalBookedInOther()));
    }

	public String getStartTime() {
		return startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	public String getEndTime() {
		return endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}

	public String getTotalBookedInSelf() {
		return totalBookedInSelf;
	}

	public void setTotalBookedInSelf(String totalBookedInSelf) {
		this.totalBookedInSelf = totalBookedInSelf;
	}

	public String getTotalBookedInOther() {
		return totalBookedInOther;
	}

	public void setTotalBookedInOther(String totalBookedInOther) {
		this.totalBookedInOther = totalBookedInOther;
	}

	public String getTotalBookedOut() {
		return totalBookedOut;
	}

	public void setTotalBookedOut(String totalBookedOut) {
		this.totalBookedOut = totalBookedOut;
	}
}

package nta.med.data.model.ihis.nuro;

import java.util.Date;

/**
 * @author DEV-TiepNM
 */
public class BookedDetailInfo {
    private String doctorCode;
    private String bookingDate;
    private String bookingTime;
    private String bookingType;


    public BookedDetailInfo(String doctorCode, String bookingDate, String bookingTime, String bookingType) {
        this.doctorCode = doctorCode;
        this.bookingDate = bookingDate;
        this.bookingTime = bookingTime;
        this.bookingType = bookingType;
    }

    public String getDoctorCode() {
        return doctorCode;
    }

    public void setDoctorCode(String doctorCode) {
        this.doctorCode = doctorCode;
    }

    public String getBookingDate() {
        return bookingDate;
    }

    public void setBookingDate(String bookingDate) {
        this.bookingDate = bookingDate;
    }

    public String getBookingTime() {
        return bookingTime;
    }

    public void setBookingTime(String bookingTime) {
        this.bookingTime = bookingTime;
    }

    public String getBookingType() {
        return bookingType;
    }

    public void setBookingType(String bookingType) {
        this.bookingType = bookingType;
    }
}

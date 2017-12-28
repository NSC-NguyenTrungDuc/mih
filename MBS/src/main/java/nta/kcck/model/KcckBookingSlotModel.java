package nta.kcck.model;

/**
 * Created by CuongTV on 8/8/2016.
 */
public class KcckBookingSlotModel {
    private String doctor_code;
    private String start_time;
    private String end_time;
    private String waiting_patient;

    public KcckBookingSlotModel(String doctor_code, String start_time, String end_time , String waiting_patient) {
        this.doctor_code = doctor_code;
        this.start_time = start_time;
        this.end_time = end_time;
        this.waiting_patient = waiting_patient;
    }

    public String getDoctor_code() {
		return doctor_code;
	}

	public void setDoctor_code(String doctor_code) {
		this.doctor_code = doctor_code;
	}

	public String getStart_time() {
        return start_time;
    }

    public void setStart_time(String start_time) {
        this.start_time = start_time;
    }

    public String getEnd_time() {
        return end_time;
    }

    public void setEnd_time(String end_time) {
        this.end_time = end_time;
    }

	public String getWaiting_patient() {
		return waiting_patient;
	}

	public void setWaiting_patient(String waiting_patient) {
		this.waiting_patient = waiting_patient;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((doctor_code == null) ? 0 : doctor_code.hashCode());
		result = prime * result + ((end_time == null) ? 0 : end_time.hashCode());
		result = prime * result + ((start_time == null) ? 0 : start_time.hashCode());
		result = prime * result + ((waiting_patient == null) ? 0 : waiting_patient.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		KcckBookingSlotModel other = (KcckBookingSlotModel) obj;
		if (doctor_code == null) {
			if (other.doctor_code != null)
				return false;
		} else if (!doctor_code.equals(other.doctor_code))
			return false;
		if (end_time == null) {
			if (other.end_time != null)
				return false;
		} else if (!end_time.equals(other.end_time))
			return false;
		if (start_time == null) {
			if (other.start_time != null)
				return false;
		} else if (!start_time.equals(other.start_time))
			return false;
		if (waiting_patient == null) {
			if (other.waiting_patient != null)
				return false;
		} else if (!waiting_patient.equals(other.waiting_patient))
			return false;
		return true;
	}
    
}
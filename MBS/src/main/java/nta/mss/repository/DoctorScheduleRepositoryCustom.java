package nta.mss.repository;


/**
 *
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 *
 */
public interface DoctorScheduleRepositoryCustom {
	boolean copyDoctorSchedule(Integer copyDoctorId, Integer doctorId, String currentDate);
}

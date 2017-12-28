package nta.mss.repository;

import java.util.List;

/**
 * The Interface DepartmentScheduleRepositoryCustom. 
 *
 * @author MinhLS
 * @crtDate Sep 20, 2014
 */
public interface DepartmentScheduleRepositoryCustom {
	boolean generateDepartmentSchedule(Integer doctorId, Integer deptId, Integer kpiAvg, String currentDate);
	List<String> getFullTimeslotListByDepartment(Integer deptId);
}

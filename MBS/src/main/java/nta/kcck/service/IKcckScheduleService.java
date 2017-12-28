package nta.kcck.service;

import nta.kcck.model.TimeslotScheduleModel;

import java.util.Map;

public interface IKcckScheduleService {
	TimeslotScheduleModel checkKcckDepartmentSchedule(String hospCode, String avgTime, String startDate, String endDate, String departmentCode, String doctorCode, String doctorGrade);
	TimeslotScheduleModel checkKcckDoctorSchedule(String hospCode, String departmentCode, String doctorCode, String startDate, String endDate);
}

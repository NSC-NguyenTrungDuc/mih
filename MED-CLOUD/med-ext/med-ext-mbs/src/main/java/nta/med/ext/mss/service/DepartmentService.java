package nta.med.ext.mss.service;

import java.util.List;

import nta.med.ext.mss.model.DepartmentModel;
import nta.med.ext.mss.model.UpdateDefaultScheduleModel;

/**
 * 
 * @author DEV-HuanLT
 *
 */
public interface DepartmentService {

    List<DepartmentModel> getDepartmentByHospitalCode(String hospCode, String locale);
    
    String updateDefaultSchedule(UpdateDefaultScheduleModel updateDefaultSchedule);
    
    void updateMbsConfig(String hospCode, Integer useMovieTalk, Integer useSurvey, String locale);
}

package nta.kcck.service;

import java.util.List;

import nta.kcck.model.KcckDefaultScheduleModel;
import nta.kcck.model.KcckDepartmentModel;
import nta.kcck.model.MessageResponse;
import nta.mss.model.DepartmentModel;

/**
 * The Interface IDepartmentService.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
public interface IKcckDepartmentService {

	public List<DepartmentModel> getListDepartment(String hospCode,String locate);

	public DepartmentModel findKcckDepartmentById(String hospCode,String locate, Integer deptId);
	
	public DepartmentModel findKcckDepartmentByType(String hospCode,String locale,Integer type); 
	
	public DepartmentModel findKcckDepartmentByIdAndType(String hospCode,String locale,Integer deptId, Integer type);
	
	public String updateKcckDefaultSchedule(KcckDefaultScheduleModel kcckDefaultSchedule);
}

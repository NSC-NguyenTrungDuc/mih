package nta.kcck.service.impl;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.kcck.model.KcckDefaultScheduleModel;
import nta.kcck.model.KcckDepartmentModel;
import nta.kcck.model.MessageResponse;
import nta.kcck.service.IKcckDepartmentService;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.DepartmentType;
import nta.mss.model.DepartmentModel;

@Service
@Transactional
public class KcckDepartmentService implements IKcckDepartmentService {
	KcckApiService kcckApiService = new KcckApiService();

	
	@Override
	public DepartmentModel findKcckDepartmentById(String hospCode,String locale,Integer deptId) {
		
		Map<Integer,DepartmentModel> departmentLists = new HashMap<Integer,DepartmentModel>();
		//Get List Department From Session
		List<DepartmentModel> departmentList;
		if(MssContextHolder.getKcckDepartmentList()==null){
			 departmentList = getListDepartment(hospCode,locale);
			MssContextHolder.setKcckDepartmentList(departmentList);
		}else{
			departmentList= MssContextHolder.getKcckDepartmentList();
		}
		
		for(DepartmentModel model:departmentList){
			departmentLists.put(model.getDeptId(), model );
		}
		DepartmentModel model = departmentLists.get( deptId );
		return model;
	
	}
	@Override
	public DepartmentModel findKcckDepartmentByIdAndType(String hospCode,String locale,Integer deptId, Integer type) {
		
			List<DepartmentModel> departmentList;
		if(MssContextHolder.getKcckDepartmentList()==null){
			 departmentList = getListDepartment(hospCode,locale);
			MssContextHolder.setKcckDepartmentList(departmentList);
		}else{
			departmentList= MssContextHolder.getKcckDepartmentList();
		}
		
		for(DepartmentModel model:departmentList){
			if(model.getDeptId().equals(deptId) && model.getDeptType().equals(type)){
				return model;
			}
		}
		return null;
	
	}
	
	@Override
	public DepartmentModel findKcckDepartmentByType(String hospCode,String locale,Integer type) {
		
		Map<Integer,DepartmentModel> departmentLists = new HashMap<Integer,DepartmentModel>();
		//Get List Department From Session
		List<DepartmentModel> departmentList;
		if(MssContextHolder.getKcckDepartmentList()==null){
			 departmentList = getListDepartment(hospCode,locale);
			MssContextHolder.setKcckDepartmentList(departmentList);
		}else{
			departmentList= MssContextHolder.getKcckDepartmentList();
		}
		
		for(DepartmentModel model:departmentList){
			departmentLists.put(model.getDeptType(), model );
		}
		DepartmentModel model = departmentLists.get( type );
		return model;
		
	}
	// department API: KCCK-MSS
	@Override
	public List<DepartmentModel> getListDepartment(String hospCode, String locale) {
		DepartmentModel depatmentModel = null;
		List<DepartmentModel> departmentList = new ArrayList<DepartmentModel>();
		MessageResponse<List<KcckDepartmentModel>> response = (MessageResponse<List<KcckDepartmentModel>>) kcckApiService.listDepartment(hospCode,locale);	
		if(response == null || response.getData() == null){
			return departmentList;
		}
		for (KcckDepartmentModel department : response.getData()) {			
			depatmentModel = new DepartmentModel();
			depatmentModel.setDeptId(Integer.parseInt(department.getDepartment_id()));
			depatmentModel.setDeptCode(department.getDepartment_code());
			depatmentModel.setDeptName(department.getDepartment_name());
			Double avgTime = Double.parseDouble(department.getAvg_time());
			depatmentModel.setDefaultTimeSlot(avgTime.intValue());
			try {
				if (department.getDepartment_code().equals(MssConfiguration.getInstance().getApiKcckVaccineCode())) {
					depatmentModel.setDeptType(DepartmentType.NEWBORNS.toInt());
				}else{
					depatmentModel.setDeptType(DepartmentType.INTERNAL.toInt());
				}
			} catch (Exception e) {
			}
			departmentList.add(depatmentModel);
		}
		if (MssContextHolder.isUseVaccine()) {
			for (KcckDepartmentModel department : response.getData()) {			
				try {
					if (department.getDepartment_code().equals(MssConfiguration.getInstance().getApiKcckVaccineCode())) {
						depatmentModel = new DepartmentModel();
						depatmentModel.setDeptId(Integer.parseInt(department.getDepartment_id()));
						depatmentModel.setDeptCode(department.getDepartment_code());
						depatmentModel.setDeptName(department.getDepartment_name());
						Double avgTime = Double.parseDouble(department.getAvg_time());
						depatmentModel.setDefaultTimeSlot(avgTime.intValue());
						depatmentModel.setDeptType(DepartmentType.VACCINE.toInt());
						departmentList.add(depatmentModel);
					}
				} catch (Exception e) {
				}
				
			}
		}
		
		return departmentList;

	}
	@Override
	public String updateKcckDefaultSchedule(KcckDefaultScheduleModel kcckDefaultSchedule) {
		String result = "";
		result = kcckApiService.updateKcckDefaultSchedule(kcckDefaultSchedule);
		return result;
	}

	
}
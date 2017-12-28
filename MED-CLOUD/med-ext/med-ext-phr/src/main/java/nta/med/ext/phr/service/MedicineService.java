package nta.med.ext.phr.service;

import java.util.List;

import org.springframework.data.domain.PageRequest;

import nta.med.ext.phr.model.MedicineModel;

public interface MedicineService {
	
	public List<MedicineModel> getLimitMedicine(Long profileId, PageRequest pageRequest);

	public MedicineModel getDetailMedicine(Long profileId, Long medicineId);

	public MedicineModel addMedicine(MedicineModel medicineModel);

	public MedicineModel updateMedicine(MedicineModel medicineModel);

	public Boolean deleteMedicine(Long medicineId);

	public MedicineModel deleteMedicine(Long medicineId, Long profileId, Long presciptionId);

	public MedicineModel updatePrescription(MedicineModel medicineModel);

	public MedicineModel deletePrescription(Long profileId, Long presciptionId);
}

package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.phr.PhrMedicine;
import nta.med.core.domain.phr.PhrPrescription;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.phr.MedicineRepository;
import nta.med.data.dao.phr.PhrPrescriptionRepository;
import nta.med.ext.phr.model.MedicineModel;
import nta.med.ext.phr.model.PrescriptionDetailModel;
import nta.med.ext.phr.model.PrescriptionModel;
import nta.med.ext.phr.service.PhrPrescriptionService;

@Service
@Transactional
public class PhrPrescriptionServiceImpl implements PhrPrescriptionService{
	 @Resource
	 private PhrPrescriptionRepository phrPrescriptionRepository;
	 @Resource
	 private MedicineRepository medicineRepository;

	@Override
	public List<PrescriptionModel> getPrescription(Long profileId, PageRequest pageRequest) {
		List<PrescriptionModel> listPreModel = new ArrayList<PrescriptionModel>();
		List<PhrPrescription> listRescription = phrPrescriptionRepository.getPrescriptionByProfileId(profileId, pageRequest);
		for (PhrPrescription prescription : listRescription) {
			PrescriptionModel model = new PrescriptionModel();
			BeanUtils.copyProperties(prescription, model, Language.JAPANESE.toString());
			model.setCreated(prescription.getDatetimeRecord());
			listPreModel.add(model);
		}
		return listPreModel;
	}

	@Override
	public PrescriptionDetailModel getPrescriptionDetail(Long prescriptionId, PageRequest pageRequest) {
		PrescriptionDetailModel preDetail = new PrescriptionDetailModel();
		List<MedicineModel> medicineModels = new ArrayList<MedicineModel>();
		List<PhrPrescription> listRescription = phrPrescriptionRepository.getPrescriptionById(prescriptionId, pageRequest);
		if(!CollectionUtils.isEmpty(listRescription)){
			BeanUtils.copyProperties(listRescription.get(0), preDetail, Language.JAPANESE.toString());
		}
		List<PhrMedicine> prhMedicines = medicineRepository.getMedicineDetail(prescriptionId, pageRequest);
		for (PhrMedicine prhMedicine : prhMedicines) {
			MedicineModel model = new MedicineModel();
			BeanUtils.copyProperties(prhMedicine, model, Language.JAPANESE.toString());
			medicineModels.add(model);
		}
		preDetail.setMedicineList(medicineModels);
		return preDetail;
	}
}

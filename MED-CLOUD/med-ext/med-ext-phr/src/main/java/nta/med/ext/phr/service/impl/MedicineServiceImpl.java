package nta.med.ext.phr.service.impl;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.phr.PhrMedicine;
import nta.med.core.domain.phr.PhrPrescription;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.phr.MedicineRepository;
import nta.med.data.dao.phr.PhrPrescriptionRepository;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.glossary.Message;
import nta.med.ext.phr.model.MedicineModel;
import nta.med.ext.phr.service.MedicineService;

@Service
@Transactional
//@Transactional(value = DataSources.PHR)
public class MedicineServiceImpl implements MedicineService{

    @Resource
    private MedicineRepository medicineRepository;
    
    @Resource
	private PhrPrescriptionRepository prescriptionRepository;
	
	@Override
	public List<MedicineModel> getLimitMedicine(Long profileId, PageRequest pageRequest){	
		List<MedicineModel> listMedicineModel = new ArrayList<MedicineModel>();
		List<PhrMedicine> listMedicine = medicineRepository.getLimitMedicine(profileId, pageRequest);
		for (PhrMedicine medicine : listMedicine) {
			MedicineModel medicineModel = new MedicineModel();
			BeanUtils.copyProperties(medicine, medicineModel, Language.JAPANESE.toString());
			listMedicineModel.add(medicineModel);
		}
		
		return listMedicineModel;
	}
	
	@Override
	public MedicineModel getDetailMedicine(Long profileId, Long medicineId){
		PhrMedicine medicine = medicineRepository.findOne(medicineId);
		
		if(medicine == null || !medicine.getProfileId().equals(profileId) ||medicine.getActiveFlg() == ActiveFlag.INACTIVE.toInt()){
			return null;
		}
		
		MedicineModel medicineModel = new MedicineModel();
		BeanUtils.copyProperties(medicine, medicineModel, Language.JAPANESE.toString());
		medicineModel.setCreated(new Timestamp(medicine.getCreated().getTime()));
		medicineModel.setUpdated(new Timestamp(medicine.getUpdated().getTime()));
		
		return medicineModel;
	}
	
	@Override
	public MedicineModel addMedicine(MedicineModel medicineModel){
		PhrPrescription prescription = prescriptionRepository.getPrescriptionByIdAndProfileId(medicineModel.getPrescriptionId(), medicineModel.getProfileId());
		if(prescription == null){
			medicineModel.setMessage(Message.DRUG_PRESCRIPTION_ID_NOT_FOUND.getValue());
			return medicineModel;
		}
		PhrMedicine phrMedicine = new PhrMedicine();
		BeanUtils.copyProperties(medicineModel, phrMedicine, Language.JAPANESE.toString());
		medicineRepository.save(phrMedicine);
		BeanUtils.copyProperties(phrMedicine, medicineModel, Language.JAPANESE.toString());

		return medicineModel;
	}
	
	public MedicineModel updateMedicine(MedicineModel medicineModel){
		PhrPrescription prescription = prescriptionRepository.getPrescriptionByIdAndProfileId(medicineModel.getPrescriptionId(), medicineModel.getProfileId());
		if(prescription == null){
			medicineModel.setMessage(Message.DRUG_PRESCRIPTION_ID_NOT_FOUND.getValue());
			return medicineModel;
		}
		PhrMedicine phrMedicine =  medicineRepository.getMedicineByIdAndProfileIdAndPrescriptionId(medicineModel.getId(), medicineModel.getProfileId(), medicineModel.getPrescriptionId());
		if(phrMedicine == null){
			medicineModel.setMessage(Message.DRUG_PRESCRIPTION_ID_NOT_FOUND.getValue());
			return medicineModel;
		}

		BeanUtils.copyProperties(medicineModel, phrMedicine, Language.JAPANESE.toString());
		medicineRepository.save(phrMedicine);
		BeanUtils.copyProperties(phrMedicine, medicineModel, Language.JAPANESE.toString());
		
		return medicineModel;
	}
	
	@Override
	public Boolean deleteMedicine(Long medicineId){
		Boolean isDeleted = true;
		PhrMedicine phrMedicine =  medicineRepository.findOne(medicineId);
		
		if(phrMedicine != null && phrMedicine.getActiveFlg().equals(ActiveFlag.ACTIVE.toInt())){
			phrMedicine.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			medicineRepository.save(phrMedicine);
		} else {
			isDeleted = false;
		}
		
		return isDeleted;
	}

	@Override
	public MedicineModel deleteMedicine(Long medicineId, Long profileId, Long presciptionId) {
		MedicineModel medicineModel = new MedicineModel();
		PhrPrescription prescription = prescriptionRepository.getPrescriptionByIdAndProfileId(presciptionId, profileId);
		if(prescription == null){
			medicineModel.setMessage(Message.DRUG_PRESCRIPTION_ID_NOT_FOUND.getValue());
			return medicineModel;
		}
		PhrMedicine phrMedicine =  medicineRepository.getMedicineByIdAndProfileIdAndPrescriptionId(medicineId, profileId, presciptionId);
		if(phrMedicine == null){
			medicineModel.setMessage(Message.DRUG_PRESCRIPTION_ID_NOT_FOUND.getValue());
			return medicineModel;
		}

		phrMedicine.setActiveFlg(ActiveFlag.INACTIVE.toInt());
		medicineRepository.save(phrMedicine);
		BeanUtils.copyProperties(phrMedicine, medicineModel, Language.JAPANESE.toString());
		
		return medicineModel;
	}

	@Override
	public MedicineModel updatePrescription(MedicineModel medicineModel) {
		if(medicineModel.getDatetimeRecord() == null){
			medicineModel.setMessage(Message.DATETIME_RECORD_REQUIRED.getValue());
			return medicineModel;
		}
		// insert prescription
		PhrPrescription prescription = new PhrPrescription();
		if(medicineModel.getPrescriptionId() != null){
			prescription = prescriptionRepository.getPrescriptionByIdAndProfileId(medicineModel.getPrescriptionId(), medicineModel.getProfileId());
			if(prescription == null){
				medicineModel.setMessage(Message.DRUG_PRESCRIPTION_ID_NOT_FOUND.getValue());
				return medicineModel;
			}
		}
		prescription.setActiveFlg(new BigDecimal(ActiveFlag.ACTIVE.toInt()));
		prescription.setPrescriptionName(medicineModel.getPrescriptionName());
		prescription.setSource(medicineModel.getSource());
		prescription.setProfileId(medicineModel.getProfileId());
		prescription.setDatetimeRecord(medicineModel.getDatetimeRecord());
		prescription.setCreated(DateUtil.toTimestamp(DateUtil.toString(new Date(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
		prescription.setUpdated(DateUtil.toTimestamp(DateUtil.toString(new Date(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
		prescriptionRepository.save(prescription);
		BeanUtils.copyProperties(prescription, medicineModel, Language.JAPANESE.toString());
		return medicineModel;
	}

	@Override
	public MedicineModel deletePrescription(Long profileId, Long presciptionId) {
		MedicineModel medicineModel = new MedicineModel();
		PhrPrescription prescription = prescriptionRepository.getPrescriptionByIdAndProfileId(presciptionId, profileId);
		if(prescription == null){
			medicineModel.setMessage(Message.DRUG_PRESCRIPTION_ID_NOT_FOUND.getValue());
			return medicineModel;
		}
		prescription.setActiveFlg(new BigDecimal(ActiveFlag.INACTIVE.toInt()));
		prescriptionRepository.save(prescription);
		BeanUtils.copyProperties(prescription, medicineModel, Language.JAPANESE.toString());
		return medicineModel;
	}
}

package nta.med.ext.phr.service.impl;

import com.google.common.collect.Lists;
import nta.med.core.domain.phr.*;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.phr.*;
import nta.med.ext.phr.glossary.ActiveFlag;
import nta.med.ext.phr.model.StandardDiseasModel;
import nta.med.ext.phr.service.StandardDiseasService;
import nta.med.ext.support.glossary.EventMetaStore;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.AbstractRpcExtListener;
import nta.med.ext.support.service.patient.PatientRpcService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import javax.annotation.Resource;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;


@Service
@Transactional
public class StandardDiseasServiceImpl implements StandardDiseasService{

	private static final Logger LOGGER = LoggerFactory.getLogger(StandardDiseasServiceImpl.class);
	
	@Resource
	private StandardDiseasRepository standardDiseasRepository;
	
	@Override
	public List<StandardDiseasModel> getLimitStandardDiseas(Long profileId, PageRequest pageRequest) {
		List<StandardDiseasModel> listStandardDiseasModel = new ArrayList<StandardDiseasModel>();
		List<PhrStandardDiseas> listPhrStandardDiseas = standardDiseasRepository.getLimitStandardDiseas(profileId, pageRequest);
		for (PhrStandardDiseas standardDiseas : listPhrStandardDiseas) {
			StandardDiseasModel standardDiseasModel = new StandardDiseasModel();
			BeanUtils.copyProperties(standardDiseas, standardDiseasModel, Language.JAPANESE.toString());
			listStandardDiseasModel.add(standardDiseasModel);
		}
		
		return listStandardDiseasModel;
	}

	@Override
	public StandardDiseasModel getDetailStandardDiseas(Long profileId, Long standardDiseasId) {
		PhrStandardDiseas phrStandardDiseas = standardDiseasRepository.findOne(standardDiseasId);
		if(phrStandardDiseas == null || !phrStandardDiseas.getProfileId().equals(profileId) || phrStandardDiseas.getActiveFlg() == ActiveFlag.INACTIVE.toInt()){
			return null;
		}
		
		StandardDiseasModel standardDiseasModel = new StandardDiseasModel();
		BeanUtils.copyProperties(phrStandardDiseas, standardDiseasModel, Language.JAPANESE.toString());
		
		return standardDiseasModel;
	}

	@Override
	public StandardDiseasModel addStandardDiseas(StandardDiseasModel standardDiseasModel) {
		PhrStandardDiseas phrStandardDiseas = new PhrStandardDiseas();
		BeanUtils.copyProperties(standardDiseasModel, phrStandardDiseas, Language.JAPANESE.toString());
		standardDiseasRepository.save(phrStandardDiseas);
		BeanUtils.copyProperties(phrStandardDiseas, standardDiseasModel, Language.JAPANESE.toString());
		
		return standardDiseasModel;
	}

	@Override
	public StandardDiseasModel updateStandardDiseas(StandardDiseasModel standardDiseasModel) {
		PhrStandardDiseas phrStandardDiseas = standardDiseasRepository.findOne(standardDiseasModel.getId());
		if(phrStandardDiseas == null || phrStandardDiseas.getActiveFlg() == ActiveFlag.INACTIVE.toInt()){
			return null;
		}
		
		BeanUtils.copyProperties(standardDiseasModel, phrStandardDiseas, Language.JAPANESE.toString());
		standardDiseasRepository.save(phrStandardDiseas);
		BeanUtils.copyProperties(phrStandardDiseas, standardDiseasModel, Language.JAPANESE.toString());
		
		return standardDiseasModel;
	}

	@Override
	public Boolean deleteStandardDiseas(Long standardDiseasId) {
		Boolean isDeleted = true;
		PhrStandardDiseas phrStandardDiseas = standardDiseasRepository.findOne(standardDiseasId);
		if(phrStandardDiseas != null && phrStandardDiseas.getActiveFlg() == ActiveFlag.ACTIVE.toInt()){
			phrStandardDiseas.setActiveFlg(ActiveFlag.INACTIVE.toInt());
			standardDiseasRepository.save(phrStandardDiseas);
		}else {
			isDeleted = false;
		}
		
		return isDeleted;
	}

	public static class ListenerImpl extends AbstractRpcExtListener<PatientServiceProto.PatientEvent> {


		@Resource
		private PatientRpcService patientRpcService;

		protected ListenerImpl() {
			super(PatientServiceProto.PatientEvent.class);
		}

		@Override
		public EventMetaStore meta() {
			return EventMetaStore.PATIENT;
		}

		@Resource
		private StandardDiseasRepository standardDiseasRepository;
		
		@Resource
		private AccountClinicRepository accountClinicRepository;		
		
		@Resource
		private PhrPrescriptionRepository prescriptionRepository;
		
		@Resource
		private MedicineRepository medicineRepository;
		
		@Resource
		private StandardHealthHeightRepository standardHealthHeightRepository;
		
		@Resource
		private StandardHealthWeightRepository standardHealthWeightRepository;
		
		@Resource
		private StandardTempTemperatureRepository standardTempTemperatureRepository;
		
		@Resource
		private StandardTempHeartrateRepository standardTempHeartrateRepository;
		
		@Resource
		private StandardTempBreathRepository standardTempBreathRepository;
		
		@Resource
		private StandardTempBpRepository standardTempBpRepository;
		
		@Override
		public void handleEvent(PatientServiceProto.PatientEvent event) throws Exception {
			LOGGER.info("Patient Event Listener: "+ (event != null ? event.getId() : ""));
			// sync disease
			if(!CollectionUtils.isEmpty(event.getDiseaseInfoList()))
			{
				LOGGER.info("Disease Listener: "+ (event != null ? event.getId() : ""));
				syncDisease(event);
			}
			
			// sync prescription
			LOGGER.info("Medicine Listener: syncPrescription"+ (event != null ? event.getId() : ""));
			syncPrescription(event);
			
			// sync drug
			LOGGER.info("Medicine Listener: syncDrug"+ (event != null ? event.getId() : ""));
			syncMedicine(event);
			
			// sync height		
			if(!CollectionUtils.isEmpty(event.getPatientHeightInfoList())){
				LOGGER.info("Vitals Listener: syncPatientHeight"+ (event != null ? event.getId() : ""));
				syncVitalsHeight(event);
			}
			// sync weight
			if(!CollectionUtils.isEmpty(event.getPatientWeightInfoList())){
				LOGGER.info("Vitals Listener: syncPatientWeight"+ (event != null ? event.getId() : ""));
				syncVitalsWeight(event);
			}
			// sync temperature
			if(!CollectionUtils.isEmpty(event.getPatientTemperatureInfoList())){
				LOGGER.info("Vitals Listener: syncPatientTemperature"+ (event != null ? event.getId() : ""));
				syncVitalsTempTemperature(event);
			}
			// sync heart_rate
			if(!CollectionUtils.isEmpty(event.getPatientHeartRateInfoList())){
				LOGGER.info("Vitals Listener: syncPatientHeartRate"+ (event != null ? event.getId() : ""));
				syncVitalsHeartRate(event);
			}
			// sync respiration_rate
			if(!CollectionUtils.isEmpty(event.getPatientRespirationRateInfoList())){
				LOGGER.info("Vitals Listener: syncPatientRespirationRate"+ (event != null ? event.getId() : ""));
				syncVitalsRespirationRate(event);
			}
			// sync blood pressure
			if(!CollectionUtils.isEmpty(event.getPatientBloodPressureInfoList())){
				LOGGER.info("Vitals Listener: syncPatientBloodPressure"+ (event != null ? event.getId() : ""));
				syncVitalsBloodPressure(event);
			}	
		}

		@Override
		public Collection<PatientServiceProto.PatientEvent> invokeSubscribe(long eventId) throws Exception {
			PatientServiceProto.SubscribePatientEventRequest request = PatientServiceProto.SubscribePatientEventRequest
					.newBuilder().setEventId(-1L).build();
			PatientServiceProto.SubscribePatientEventResponse response = patientRpcService.subscribePatient(request);
			if (response != null
					&& PatientServiceProto.SubscribePatientEventResponse.Result.SUCCESS.equals(response.getResult())) {
				if (isVerbose())
					LOGGER.info("{} was successfully subscribed");
				return response.getEventsList();
			}
			return java.util.Collections.emptyList();
		}
		
		private void syncDisease(PatientServiceProto.PatientEvent event){

			LOGGER.info("Disease Listener Change!!! execute sync data for phr !!!");
			for (PatientModelProto.SyncDisease syncDisease : event.getDiseaseInfoList()) {
				if(syncDisease.getIsDelete()){
					// delete
					List<PhrStandardDiseas> diseases = standardDiseasRepository.getStandardDiseasBySyncId(BigInteger.valueOf(syncDisease.getSyncId()));
					for (PhrStandardDiseas disease : diseases) {
						disease.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						LOGGER.info("Disease Listener Change!!! execute sync data for phr !!! delete disease: id=" + disease.getId());
						standardDiseasRepository.save(disease);
					}

				} else {
					List<PhrStandardDiseas> diseases = standardDiseasRepository.getStandardDiseasBySyncId(BigInteger.valueOf(syncDisease.getSyncId()));
					if(CollectionUtils.isEmpty(diseases)){
						// insert
						List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
						for (Long profile : profiles) {
							PhrStandardDiseas disease = new PhrStandardDiseas();
							BeanUtils.copyProperties(syncDisease, disease, Language.JAPANESE.toString());
							disease.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							disease.setHospital(syncDisease.getHospName());
							disease.setSyncId(BigInteger.valueOf(syncDisease.getSyncId()));
							disease.setStatus(syncDisease.getDisease());
							disease.setProfileId(profile);
							disease.setDatetimeRecord(DateUtil.toTimestamp(syncDisease.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD));
							disease.setDiseaseStartDate(DateUtil.toTimestamp(syncDisease.getDiseaseStartDate(), DateUtil.PATTERN_YYYY_MM_DD));
							disease.setDiseaseEndDate(DateUtil.toTimestamp(syncDisease.getDiseaseEndDate(), DateUtil.PATTERN_YYYY_MM_DD));
							LOGGER.info("Disease Listener Change!!! execute sync data for phr !!! insert disease!!!");
							standardDiseasRepository.save(disease);
						}
					} else {
						// update
						for (PhrStandardDiseas disease : diseases) {
							BeanUtils.copyProperties(syncDisease, disease, Language.JAPANESE.toString());
							disease.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							disease.setHospital(syncDisease.getHospName());
							disease.setStatus(syncDisease.getDisease());
							disease.setDatetimeRecord(DateUtil.toTimestamp(syncDisease.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD));
							disease.setDiseaseStartDate(DateUtil.toTimestamp(syncDisease.getDiseaseStartDate(), DateUtil.PATTERN_YYYY_MM_DD));
							disease.setDiseaseEndDate(DateUtil.toTimestamp(syncDisease.getDiseaseEndDate(), DateUtil.PATTERN_YYYY_MM_DD));
							LOGGER.info("Disease Listener Change!!! execute sync data for phr !!! update disease: id=" + disease.getId());
							standardDiseasRepository.save(disease);
						}
					}
				}
			}
		}
		
		private void syncPrescription(PatientServiceProto.PatientEvent event){

			LOGGER.info("Medicine Listener Change!!! execute sync data for phr !!!");
			List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
			if(CollectionUtils.isEmpty(profiles)){
				return;
			}
			
			if(event.getDeletedAllPrescription()){
				List<PhrPrescription> prescriptions = prescriptionRepository.getPrescriptionByListProfileIds(profiles);
				if(!CollectionUtils.isEmpty(prescriptions)){
					for (PhrPrescription prescription : prescriptions) {
						prescription.setSource("KCCK");
						prescription.setActiveFlg(new BigDecimal(ActiveFlag.INACTIVE.toInt()));
						LOGGER.info("Prescription Listener Change!!! execute sync data for phr !!! delete prescription: id=" + prescription.getId());
					}
					prescriptionRepository.save(prescriptions);
				}
			} else {
				// find list prescription deleted
				List<Long> syncIds = event.getPrescriptionInfoList().stream().map(PatientModelProto.SyncPrescription::getSyncId).collect(Collectors.toList());
				List<BigInteger> syncList = Lists.transform(syncIds, id -> BigInteger.valueOf(id));
				if(!CollectionUtils.isEmpty(syncList)){	
					List<PhrPrescription> prescriptions = prescriptionRepository.getPrescriptionByListSyncId(syncList, profiles);
					if(!CollectionUtils.isEmpty(prescriptions)){
						for (PhrPrescription prescription : prescriptions) {
							prescription.setSource("KCCK");
							prescription.setActiveFlg(new BigDecimal(ActiveFlag.INACTIVE.toInt()));
							LOGGER.info("Prescription Listener Change!!! execute sync data for phr !!! delete prescription: id=" + prescription.getId());
						}
						prescriptionRepository.save(prescriptions);
					}
				}
				
				// insert or update prescription
				for (PatientModelProto.SyncPrescription syncPrescription : event.getPrescriptionInfoList()) {
					List<PhrPrescription> prescriptionList = prescriptionRepository.getPrescriptionBySyncId(BigInteger.valueOf(syncPrescription.getSyncId()));
					if(CollectionUtils.isEmpty(prescriptionList)){
						// insert
						for (Long profile : profiles) {
							PhrPrescription pres = new PhrPrescription();
							BeanUtils.copyProperties(syncPrescription, pres, Language.JAPANESE.toString());
							pres.setActiveFlg(new BigDecimal(ActiveFlag.ACTIVE.toInt()));
							pres.setPrescriptionName(syncPrescription.getPrescriptionName());
							pres.setSyncId(BigInteger.valueOf(syncPrescription.getSyncId()));
							pres.setSource("KCCK");
							pres.setProfileId(profile);
							pres.setDatetimeRecord(DateUtil.toTimestamp(syncPrescription.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							LOGGER.info("Prescription Listener Change!!! execute sync data for phr !!! insert prescription!!!");
							prescriptionRepository.save(pres);
						}
					} else {
						// update
						for (PhrPrescription pres : prescriptionList) {
							BeanUtils.copyProperties(syncPrescription, pres, Language.JAPANESE.toString());
							pres.setActiveFlg(new BigDecimal(ActiveFlag.ACTIVE.toInt()));
							pres.setSource("KCCK");
							pres.setDatetimeRecord(DateUtil.toTimestamp(syncPrescription.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							LOGGER.info("Prescription Listener Change!!! execute sync data for phr !!! update prescription: id=" + pres.getId());
							prescriptionRepository.save(pres);
						}
					}
				}
			}
		}
		
		private void syncMedicine(PatientServiceProto.PatientEvent event){

			LOGGER.info("Medicine Listener Change!!! execute sync data for phr !!!");
			List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
			if(CollectionUtils.isEmpty(profiles)){
				return;
			}
			
			if(event.getDeletedAllDrug()){
				List<PhrMedicine> medicines = medicineRepository.getMedicineByListProfileIds(profiles);
				if(!CollectionUtils.isEmpty(medicines)){
					for (PhrMedicine medicine : medicines) {
						medicine.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						LOGGER.info("Medicine Listener Change!!! execute sync data for phr !!! delete medicine: id=" + medicine.getId());
					}
					medicineRepository.save(medicines);
				}
			} else {
				// find list medicine deleted
				List<Long> syncIds = event.getDrugInfoList().stream().map(PatientModelProto.SyncDrug::getMedicineId).collect(Collectors.toList());	
				List<BigInteger> syncList = Lists.transform(syncIds, id -> BigInteger.valueOf(id));
				if(!CollectionUtils.isEmpty(syncList)){	
					List<PhrMedicine> medicines = medicineRepository.getMedicineByListSyncId(syncList, profiles);
					if(!CollectionUtils.isEmpty(medicines)){
						for (PhrMedicine medicine : medicines) {
							medicine.setActiveFlg(ActiveFlag.INACTIVE.toInt());
							LOGGER.info("Medicine Listener Change!!! execute sync data for phr !!! delete medicine: id=" + medicine.getId());
						}
						medicineRepository.save(medicines);
					}
				}
				
				// insert or update medicine
				for (PatientModelProto.SyncDrug drug : event.getDrugInfoList()) {
					List<PhrMedicine> medicineList = medicineRepository.getMedicineBySyncId(BigInteger.valueOf(drug.getMedicineId()));
					if(CollectionUtils.isEmpty(medicineList)){
						for (Long profile : profiles) {
							// check prescription is exist
							Long prescriptionId;
							if(!isExistPrescriptionIdByPrescriptionNameAndProfileId(drug.getPrescriptionName(), profile)){
								// insert prescription
								PhrPrescription prescription = new PhrPrescription();
								prescription.setActiveFlg(new BigDecimal(ActiveFlag.ACTIVE.toInt()));
								prescription.setPrescriptionName(drug.getPrescriptionName());
								prescription.setSyncId(BigInteger.valueOf(drug.getPrescriptionId()));
								prescription.setSource("KCCK");
								prescription.setProfileId(profile);
								prescription.setDatetimeRecord(DateUtil.toTimestamp(drug.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
								prescription.setCreated(DateUtil.toTimestamp(drug.getPresciptionCreated(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
								prescription.setUpdated(DateUtil.toTimestamp(drug.getPresciptionUpdated(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
								LOGGER.info("WARN!!! prescription not exist profile: profileId=" + profile + " !!! insert prescription!!!");
								prescriptionRepository.save(prescription);
								prescriptionId = prescription.getId();
							} else {
								prescriptionId = getPrescriptionIdByPrescriptionNameAndProfileId(drug.getPrescriptionName(), profile);
							}
							
							PhrMedicine medicine = new PhrMedicine();
							BeanUtils.copyProperties(drug, medicine, Language.JAPANESE.toString());
							medicine.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							medicine.setName(drug.getMedicineName());
							medicine.setPrescriptionId(prescriptionId);
							medicine.setProfileId(profile);
							medicine.setMethod(drug.getMedicineMethod());
							medicine.setQuantity(new BigDecimal(drug.getDays()));
							medicine.setUnit(drug.getUnit());
							medicine.setDose(CommonUtils.parseBigDecimal(drug.getDose()));
							medicine.setFrequency(new BigDecimal(drug.getFrequency()));
							medicine.setNote(drug.getNote());
							medicine.setSyncId(BigInteger.valueOf(drug.getMedicineId()));
							medicine.setCreated(DateUtil.toTimestamp(drug.getCreated(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
							medicine.setUpdated(DateUtil.toTimestamp(drug.getUpdated(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
							LOGGER.info("Medicine Listener Change!!! execute sync data for phr !!! insert medicine!!!");
							medicineRepository.save(medicine);
							
						}
					} else {
						// update
						for (PhrMedicine medicine : medicineList) {
							BeanUtils.copyProperties(drug, medicine, Language.JAPANESE.toString());
							medicine.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							medicine.setName(drug.getMedicineName());
							medicine.setMethod(drug.getMedicineMethod());
							medicine.setQuantity(new BigDecimal(drug.getDays()));
							medicine.setUnit(drug.getUnit());
							medicine.setDose(CommonUtils.parseBigDecimal(drug.getDose()));
							medicine.setFrequency(new BigDecimal(drug.getFrequency()));
							medicine.setNote(drug.getNote());
							LOGGER.info("Medicine Listener Change!!! execute sync data for phr !!! update medicine!!!");
							medicineRepository.save(medicine);
						}
					}
				}
			}
		}
		
		private void syncVitalsHeight(PatientServiceProto.PatientEvent event){
			for (PatientModelProto.SyncHeight info : event.getPatientHeightInfoList()) {
				if(info.getIsDelete()){
					List<PhrStandardHealthHeight> standardHealthHeights = standardHealthHeightRepository.getStandardHealthHeightBySyncId(BigInteger.valueOf(info.getSyncId()));
					for (PhrStandardHealthHeight phrStandardHealthHeight : standardHealthHeights) {
						phrStandardHealthHeight.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						phrStandardHealthHeight.setSource("KCCK");
					}
					standardHealthHeightRepository.save(standardHealthHeights);
				} else {
					List<PhrStandardHealthHeight> standardHealthHeights = standardHealthHeightRepository.getStandardHealthHeightBySyncId(BigInteger.valueOf(info.getSyncId()));
					if(CollectionUtils.isEmpty(standardHealthHeights)){
						// insert
						List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
						for (Long profile : profiles) {
							PhrStandardHealthHeight standardHealthHeight = new PhrStandardHealthHeight();
							BeanUtils.copyProperties(info, standardHealthHeight, Language.JAPANESE.toString());
							standardHealthHeight.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardHealthHeight.setHeight(new BigDecimal(info.getHeight()));
							standardHealthHeight.setSyncId(BigInteger.valueOf(info.getSyncId()));
							standardHealthHeight.setProfileId(profile);
							standardHealthHeight.setDatetimeRecord(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardHealthHeight.setSource("KCCK");
							LOGGER.info("HealthHeight Listener Change!!! execute sync data for phr !!! insert HealthHeight!!!");
							standardHealthHeightRepository.save(standardHealthHeight);
						}
					} else {
						// update
						for (PhrStandardHealthHeight standardHealthHeight : standardHealthHeights) {
							BeanUtils.copyProperties(info, standardHealthHeight, Language.JAPANESE.toString());
							standardHealthHeight.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardHealthHeight.setHeight(new BigDecimal(info.getHeight()));
							standardHealthHeight.setSyncId(BigInteger.valueOf(info.getSyncId()));
							standardHealthHeight.setDatetimeRecord(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardHealthHeight.setSource("KCCK");
							LOGGER.info("HealthHeight Listener Change!!! execute sync data for phr !!! update HealthHeight: id=" + standardHealthHeight.getId());
							standardHealthHeightRepository.save(standardHealthHeight);
						}
					}
				}
			}
		}
		
		private void syncVitalsWeight(PatientServiceProto.PatientEvent event){
			for (PatientModelProto.SyncWeight info : event.getPatientWeightInfoList()) {
				if(info.getIsDelete()){
					List<PhrStandardHealthWeight> standardHealthWeights = standardHealthWeightRepository.getStandardHealthWeightBySyncId(BigInteger.valueOf(info.getSyncId()));
					for (PhrStandardHealthWeight phrStandardHealthWeight : standardHealthWeights) {
						phrStandardHealthWeight.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						phrStandardHealthWeight.setSource("KCCK");
					}
					standardHealthWeightRepository.save(standardHealthWeights);
				} else {
					List<PhrStandardHealthWeight> standardHealthWeights = standardHealthWeightRepository.getStandardHealthWeightBySyncId(BigInteger.valueOf(info.getSyncId()));
					if(CollectionUtils.isEmpty(standardHealthWeights)){
						// insert
						List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
						for (Long profile : profiles) {
							PhrStandardHealthWeight standardHealthWeight = new PhrStandardHealthWeight();
							BeanUtils.copyProperties(info, standardHealthWeight, Language.JAPANESE.toString());
							standardHealthWeight.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardHealthWeight.setWeight(new BigDecimal(info.getWeight()));
							standardHealthWeight.setSyncId(BigInteger.valueOf(info.getSyncId()));
							standardHealthWeight.setProfileId(profile);
							standardHealthWeight.setDatetimeRecord(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardHealthWeight.setSource("KCCK");
							LOGGER.info("HealthWeight Listener Change!!! execute sync data for phr !!! insert HealthWeight!!!");
							standardHealthWeightRepository.save(standardHealthWeight);
						}
					} else {
						// update
						for (PhrStandardHealthWeight standardHealthWeight : standardHealthWeights) {
							BeanUtils.copyProperties(info, standardHealthWeight, Language.JAPANESE.toString());
							standardHealthWeight.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardHealthWeight.setWeight(new BigDecimal(info.getWeight()));
							standardHealthWeight.setSyncId(BigInteger.valueOf(info.getSyncId()));
							standardHealthWeight.setDatetimeRecord(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardHealthWeight.setSource("KCCK");
							LOGGER.info("HealthWeight Listener Change!!! execute sync data for phr !!! update HealthWeight: id=" + standardHealthWeight.getId());
							standardHealthWeightRepository.save(standardHealthWeight);
						}
					}
				}
			}
		}
		
		private void syncVitalsTempTemperature(PatientServiceProto.PatientEvent event){
			for (PatientModelProto.SyncTemperature info : event.getPatientTemperatureInfoList()) {
				if(info.getIsDelete()){
					List<PhrStandardTempTemperature> standardTempTemperatures = standardTempTemperatureRepository.getStandardTempTemperatureBySyncId(BigInteger.valueOf(info.getSyncId()));
					for (PhrStandardTempTemperature phrStandardTempTemperature : standardTempTemperatures) {
						phrStandardTempTemperature.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						phrStandardTempTemperature.setSource("KCCK");
					}
					standardTempTemperatureRepository.save(standardTempTemperatures);
				} else {
					List<PhrStandardTempTemperature> standardTemperatures = standardTempTemperatureRepository.getStandardTempTemperatureBySyncId(BigInteger.valueOf(info.getSyncId()));
					if(CollectionUtils.isEmpty(standardTemperatures)){
						// insert
						List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
						for (Long profile : profiles) {
							PhrStandardTempTemperature standardTemperature = new PhrStandardTempTemperature();
							BeanUtils.copyProperties(info, standardTemperature, Language.JAPANESE.toString());
							standardTemperature.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardTemperature.setTemperature(new BigDecimal(info.getTemperature()));
							standardTemperature.setSyncId(BigInteger.valueOf(info.getSyncId()));
							standardTemperature.setProfileId(profile);
							standardTemperature.setDateMeasure(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardTemperature.setSource("KCCK");
							LOGGER.info("Temperature Listener Change!!! execute sync data for phr !!! insert Temperature!!!");
							standardTempTemperatureRepository.save(standardTemperature);
						}
					} else {
						// update
						for (PhrStandardTempTemperature standardTemperature : standardTemperatures) {
							BeanUtils.copyProperties(info, standardTemperature, Language.JAPANESE.toString());
							standardTemperature.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardTemperature.setTemperature(new BigDecimal(info.getTemperature()));
							standardTemperature.setDateMeasure(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardTemperature.setSource("KCCK");
							LOGGER.info("Temperature Listener Change!!! execute sync data for phr !!! update Temperature: id=" + standardTemperature.getId());
							standardTempTemperatureRepository.save(standardTemperature);
						}
					}
				}
			}
		}
		
		private void syncVitalsHeartRate(PatientServiceProto.PatientEvent event){
			for (PatientModelProto.SyncHeartRate info : event.getPatientHeartRateInfoList()) {
				if(info.getIsDelete()){
					List<PhrStandardTempHeartrate> standardTempHeartrates = standardTempHeartrateRepository.getStandardTempHeartrateBySyncId(BigInteger.valueOf(info.getSyncId()));
					for (PhrStandardTempHeartrate phrStandardTempHeartrate : standardTempHeartrates) {
						phrStandardTempHeartrate.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						phrStandardTempHeartrate.setSource("KCCK");
					}
					standardTempHeartrateRepository.save(standardTempHeartrates);
				} else {
					List<PhrStandardTempHeartrate> standardTempHeartrates = standardTempHeartrateRepository.getStandardTempHeartrateBySyncId(BigInteger.valueOf(info.getSyncId()));
					if(CollectionUtils.isEmpty(standardTempHeartrates)){
						// insert
						List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
						for (Long profile : profiles) {
							PhrStandardTempHeartrate standardTempHeartrate = new PhrStandardTempHeartrate();
							BeanUtils.copyProperties(info, standardTempHeartrate, Language.JAPANESE.toString());
							standardTempHeartrate.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardTempHeartrate.setHeartrate(new BigDecimal(info.getHeartRate()));
							standardTempHeartrate.setSyncId(BigInteger.valueOf(info.getSyncId()));
							standardTempHeartrate.setProfileId(profile);
							standardTempHeartrate.setDateMeasure(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardTempHeartrate.setSource("KCCK");
							LOGGER.info("TempHeartrate Listener Change!!! execute sync data for phr !!! insert TempHeartrate!!!");
							standardTempHeartrateRepository.save(standardTempHeartrate);
						}
					} else {
						// update
						for (PhrStandardTempHeartrate standardTempHeartrate : standardTempHeartrates) {
							BeanUtils.copyProperties(info, standardTempHeartrate, Language.JAPANESE.toString());
							standardTempHeartrate.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardTempHeartrate.setHeartrate(new BigDecimal(info.getHeartRate()));
							standardTempHeartrate.setDateMeasure(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardTempHeartrate.setSource("KCCK");
							LOGGER.info("TempHeartrate Listener Change!!! execute sync data for phr !!! update TempHeartrate: id=" + standardTempHeartrate.getId());
							standardTempHeartrateRepository.save(standardTempHeartrate);
						}
					}
				}
			}
		}
		
		private void syncVitalsRespirationRate(PatientServiceProto.PatientEvent event){
			for (PatientModelProto.SyncRespirationRate info : event.getPatientRespirationRateInfoList()) {
				if(info.getIsDelete()){
					List<PhrStandardTempBreath> standardTempBreaths = standardTempBreathRepository.getStandardTempBreathBySyncId(BigInteger.valueOf(info.getSyncId()));
					for (PhrStandardTempBreath phrStandardTempBreath : standardTempBreaths) {
						phrStandardTempBreath.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						phrStandardTempBreath.setSource("KCCK");
					}
					standardTempBreathRepository.save(standardTempBreaths);
				} else {
					List<PhrStandardTempBreath> standardTempBreaths = standardTempBreathRepository.getStandardTempBreathBySyncId(BigInteger.valueOf(info.getSyncId()));
					if(CollectionUtils.isEmpty(standardTempBreaths)){
						// insert
						List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
						for (Long profile : profiles) {
							PhrStandardTempBreath standardTempBreath = new PhrStandardTempBreath();
							BeanUtils.copyProperties(info, standardTempBreath, Language.JAPANESE.toString());
							standardTempBreath.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardTempBreath.setBreath(new BigDecimal(info.getRespirationRate()));
							standardTempBreath.setSyncId(BigInteger.valueOf(info.getSyncId()));
							standardTempBreath.setProfileId(profile);
							standardTempBreath.setDateMeasure(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardTempBreath.setSource("KCCK");
							LOGGER.info("TempBreath Listener Change!!! execute sync data for phr !!! insert TempBreath!!!");
							standardTempBreathRepository.save(standardTempBreath);
						}
					} else {
						// update
						for (PhrStandardTempBreath standardTempBreath : standardTempBreaths) {
							BeanUtils.copyProperties(info, standardTempBreath, Language.JAPANESE.toString());
							standardTempBreath.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardTempBreath.setBreath(new BigDecimal(info.getRespirationRate()));
							standardTempBreath.setDateMeasure(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardTempBreath.setSource("KCCK");
							LOGGER.info("TempBreath Listener Change!!! execute sync data for phr !!! update TempBreath: id=" + standardTempBreath.getId());
							standardTempBreathRepository.save(standardTempBreath);
						}
					}
				}
			}
		}
		
		private void syncVitalsBloodPressure(PatientServiceProto.PatientEvent event){
			for (PatientModelProto.SyncBloodPressure info : event.getPatientBloodPressureInfoList()) {
				if(info.getIsDelete()){
					List<PhrStandardTempBp> standardTempBps = standardTempBpRepository.getStandardTempBpBySyncId(BigInteger.valueOf(info.getSyncId()));
					for (PhrStandardTempBp phrStandardTempBp : standardTempBps) {
						phrStandardTempBp.setActiveFlg(ActiveFlag.INACTIVE.toInt());
						phrStandardTempBp.setSource("KCCK");
					}
					standardTempBpRepository.save(standardTempBps);
				} else {
					List<PhrStandardTempBp> standardTempBps = standardTempBpRepository.getStandardTempBpBySyncId(BigInteger.valueOf(info.getSyncId()));
					if(CollectionUtils.isEmpty(standardTempBps)){
						// insert
						List<Long> profiles = accountClinicRepository.getProfileIdByHospCodeAndPatientCode(event.getHospCode(), event.getPatientCode());
						for (Long profile : profiles) {
							PhrStandardTempBp standardTempBp = new PhrStandardTempBp();
							BeanUtils.copyProperties(info, standardTempBp, Language.JAPANESE.toString());
							standardTempBp.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardTempBp.setBpFrom(new BigDecimal(info.getLowBloodPressure()));
							standardTempBp.setBpTo(new BigDecimal(info.getHighBloodPressure()));
							standardTempBp.setSyncId(BigInteger.valueOf(info.getSyncId()));
							standardTempBp.setProfileId(profile);
							standardTempBp.setDateMeasure(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardTempBp.setSource("KCCK");
							LOGGER.info("TempBp Listener Change!!! execute sync data for phr !!! insert TempBp!!!");
							standardTempBpRepository.save(standardTempBp);
						}
					} else {
						// update
						for (PhrStandardTempBp standardTempBp : standardTempBps) {
							BeanUtils.copyProperties(info, standardTempBp, Language.JAPANESE.toString());
							standardTempBp.setActiveFlg(ActiveFlag.ACTIVE.toInt());
							standardTempBp.setBpFrom(new BigDecimal(info.getLowBloodPressure()));
							standardTempBp.setBpTo(new BigDecimal(info.getHighBloodPressure()));
							standardTempBp.setDateMeasure(DateUtil.toTimestamp(info.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD_HHMM));
							standardTempBp.setSource("KCCK");
							LOGGER.info("TempBp Listener Change!!! execute sync data for phr !!! update TempBp: id=" + standardTempBp.getId());
							standardTempBpRepository.save(standardTempBp);
						}
					}
				}
			}
		}
		
		private boolean isExistPrescriptionIdByPrescriptionNameAndProfileId (String prescriptionName, Long profileId) {
			List<PhrPrescription> prescriptions = prescriptionRepository.getPrescriptionIdByPrescriptionNameAndProfileId(prescriptionName, profileId);
			if(!CollectionUtils.isEmpty(prescriptions)){
				return true;
			}
			return false;
		}
		
		private Long getPrescriptionIdByPrescriptionNameAndProfileId (String prescriptionName, Long profileId) {
			List<PhrPrescription> prescriptions = prescriptionRepository.getPrescriptionIdByPrescriptionNameAndProfileId(prescriptionName, profileId);
			if(!CollectionUtils.isEmpty(prescriptions)){
				return prescriptions.get(0).getId();
			}
			return null;
		}
	}
}

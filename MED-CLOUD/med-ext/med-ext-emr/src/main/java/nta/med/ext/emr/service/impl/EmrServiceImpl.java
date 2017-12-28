package nta.med.ext.emr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;
import javax.ws.rs.NotFoundException;

import org.springframework.stereotype.Service;

import nta.med.core.domain.emr.ExaminationHistory;
import nta.med.core.domain.emr.ExaminationItemVo;
import nta.med.core.domain.emr.ExaminationPatient;
import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.data.mongo.emr.ExaminationHistoryRepository;
import nta.med.data.mongo.emr.ExaminationPatientRepository;
import nta.med.ext.emr.model.EmrRecordModel;
import nta.med.ext.emr.model.EmrTagModel;
import nta.med.ext.emr.model.HistoryListModel;
import nta.med.ext.emr.model.PatientModel;
import nta.med.ext.emr.service.EmrService;
import nta.med.ext.support.proto.SystemModelProto;
import nta.med.ext.support.proto.SystemServiceProto;
import nta.med.ext.support.service.system.SystemRpcService;

/**
 * @author dainguyen.
 */
@Service("emrService")
public class EmrServiceImpl implements EmrService {

    @Resource
    private ExaminationHistoryRepository historyRepository;

    @Resource
    private ExaminationPatientRepository patientRepository;
    
    @Resource
	private SystemRpcService systemRpcService;
    
    public EmrServiceImpl() {
    }

    public EmrServiceImpl(ExaminationHistoryRepository historyRepository, ExaminationPatientRepository patientRepository) {
        this.historyRepository = historyRepository;
        this.patientRepository = patientRepository;
    }

    @Override
    public PatientModel findPatient(String hospCode, String patientId) {
        String persistenceId = hospCode + patientId;
        ExaminationPatient patient = patientRepository.findOne(persistenceId);
        if(patient == null) throw new NotFoundException(String.format("hospital: %s, patient: %s", hospCode, patientId));
        PatientModel response = new PatientModel(patientId, patient.getName(), patient.getKanaName(), patient.getBirthday(),
                patient.getGender(), patient.getAddress(), patient.getZip(), patient.getTelephone(), patient.getHospCode(), patient.getDoctor());
        return response;
    }

    @Override
    public PatientModel savePatient(PatientModel patient) {
        String persistenceId = patient.getHospCode() + patient.getPatientId();
        ExaminationPatient exPatient = patientRepository.findOne(persistenceId);
        if(exPatient == null) exPatient = new ExaminationPatient();
        BeanUtils.copyProperties(patient, exPatient, "ja");
        patientRepository.save(exPatient);
        return patient;
    }

    @Override
    public ExaminationPatient findEmrByID(String hospCode, String patientId) {
        String persistenceId = hospCode + patientId;
        ExaminationPatient patient = patientRepository.findOne(persistenceId);
        if(patient == null) throw new NotFoundException(String.format("hospital: %s, patient: %s", hospCode, patientId));
        return patient;
    }

    @Override
    public ExaminationPatient saveAll(ExaminationPatient patient) {
        return patientRepository.save(patient);
    }

    @Override
    public void updateExamination(String hospCode, String patientId, List<ExaminationItemVo> exams) {
        String persistenceId = hospCode + patientId;
        ExaminationPatient patient = patientRepository.findOne(persistenceId);
        if(patient == null) patient = new ExaminationPatient();
        patient.setId(persistenceId);
        patient.setHospCode(hospCode);
        patient.setPatientId(patientId);
        patient.setExaminations(exams);
        patientRepository.save(patient);
    }

    @Override
    public List<HistoryListModel> findAllHistories(String hospCode, String patientId) {
        List<ExaminationHistory> histories = historyRepository.findShortFields(hospCode, patientId);
        List<HistoryListModel> r = new ArrayList<>(histories.size());
        for (ExaminationHistory history : histories) {
            HistoryListModel item = new HistoryListModel();
            BeanUtils.copyProperties(history, item, "ja");
            r.add(item);
        }
        return r;
    }

    @Override
    public ExaminationHistory findHistoryDetail(String hospCode, String patientId, String revision) {
        ExaminationHistory history = historyRepository.findByHospCodeAndPatientIdAndRevision(hospCode, patientId, Integer.parseInt(revision));
        if(history == null) throw new NotFoundException(String.format("hospital: %s, patient: %s, revision: %s", hospCode, patientId, revision));
        return history;
    }

	@Override
	public EmrRecordModel findEmrRecordByPatientCodeAndHospCode(String patientCode, String hospCode) {
		EmrRecordModel emrRecordModel = new EmrRecordModel();
		SystemServiceProto.GetEmrDataRequest.Builder emrRequest = SystemServiceProto.GetEmrDataRequest.newBuilder();
		emrRequest.setHospCode(hospCode);
		emrRequest.setPatientCode(patientCode);
    	
		SystemServiceProto.GetEmrDataResponse emrResponse = systemRpcService.getEmrData(emrRequest.build());
		if(emrResponse != null){
			emrRecordModel.setVersion(emrResponse.getVersion());
			emrRecordModel.setContent(emrResponse.getContent());
			List<EmrTagModel> listEmrTagModel = new ArrayList<>();
			List<SystemModelProto.EmrTagInfo> listEmrTag = emrResponse.getEmrTagInfoList();
			for (SystemModelProto.EmrTagInfo emrTagInfo : listEmrTag) {
				EmrTagModel emrTagModel = new EmrTagModel();
				BeanUtils.copyProperties(emrTagInfo, emrTagModel, Language.JAPANESE.toString());
				listEmrTagModel.add(emrTagModel);
			}
			emrRecordModel.setListEmrTagModel(listEmrTagModel);
		}
		return emrRecordModel;
	}
}

package nta.mss.service.impl;

import java.util.ArrayList;
import java.util.List;

import nta.med.common.util.Collections;
import nta.mss.entity.Department;
import nta.mss.entity.Hospital;
import nta.mss.entity.User;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.repository.HospitalRepository;
import nta.mss.repository.UserRepository;
import nta.phr.model.AccountClinicModel;
import nta.phr.model.ProfileStandard;
import nta.phr.service.impl.PhrApiService;
import org.apache.logging.log4j.util.Strings;
import org.dozer.Mapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.mss.entity.Patient;
import nta.mss.model.PatientModel;
import nta.mss.repository.PatientRepository;
import nta.mss.service.IPatientService;

import javax.annotation.Resource;

/**
 * The Class BookingService.
 *
 * @author HoanPC
 * @CrtDate Sep 13, 2016
 */
@Service
@Transactional
public class PatientService implements IPatientService {
	private PatientRepository patientRepository;
	private HospitalRepository hospitalRepository;
	private UserRepository userRepository;
	@Resource
	private PhrApiService phrApiService;
	private Mapper mapper;
	public PatientService() {}

	@Autowired
	public PatientService(Mapper mapper, PatientRepository patientRepository, HospitalRepository hospitalRepository,UserRepository userRepository) {
		this.mapper = mapper;
		this.patientRepository = patientRepository;
		this.hospitalRepository = hospitalRepository;
		this.userRepository = userRepository;
	}

	@Override
	public List<PatientModel> getListByPatientId(Integer patientId) {
		List<PatientModel> result = new ArrayList<PatientModel>();
		List<Patient> patientList = this.patientRepository.findPatientById(patientId);
		if(patientList != null) {
			for(Patient patient : patientList) {
				PatientModel patientModel = new PatientModel();
				patientModel.setName(patient.getName());
				patientModel.setNameFurigana(patient.getNameFurigana());
				patientModel.setPhoneNumber(patient.getPhoneNumber());
				patientModel.setEmail(patient.getEmail());
				patientModel.setGender(patient.getGender());
				patientModel.setBirthDay(patient.getBirthDay());
				patientModel.setCardNumber(patient.getCardNumber());
				patientModel.setKcckParentCode(patient.getKcckParentCode());
				patientModel.setProfileId(patient.getProfileId());
				result.add(patientModel);
			}
		}
		return result;
	}

	@Override
	public Patient savePatient(PatientModel patientModel, Integer hospitalId) {
		Patient patient = patientModel.toEntity(mapper);
		Hospital hospital = hospitalRepository.findOne(hospitalId);
		if(hospital != null)
		{
			patient.setHospital(hospital);
			this.patientRepository.save(patient);
			return patient;
		}
		return null;
	}

	public String getStrPatientCodeFromAccountClinic(String token, Integer userId) {
		String patientCode = "";

		try {
			User user = this.userRepository.findOne(userId);
			if (user.getPatient() != null) {
				Integer patientId = user.getPatient().getPatientId();
				List<PatientModel> patients = getListByPatientId(patientId);
				if (!Collections.isEmpty(patients)) {
					ProfileStandard profileStandard = phrApiService
							.getListPatientByprofileId(patients.get(0).getProfileId(), token);
					if (profileStandard != null) {
						List<AccountClinicModel> listAccoutClinic = profileStandard.getList_account_clinic();
						if (listAccoutClinic != null && listAccoutClinic.size() > 0) {
							for (AccountClinicModel account : listAccoutClinic) {
								if (account.getHosp_code().equals(MssContextHolder.getHospCode())) {
									if (!Strings.isEmpty(patientCode))
										patientCode = patientCode + ",";
									patientCode = patientCode + account.getPatient_code();
								}
							}
						}
					}
				}
			} else {
				return "";
			}
		} catch (Exception e) {
			e.printStackTrace();
			patientCode = "";
		}
		return patientCode;
	}
}

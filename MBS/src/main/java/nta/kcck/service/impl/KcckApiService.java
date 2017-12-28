package nta.kcck.service.impl;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

import javax.ws.rs.core.MultivaluedMap;

import nta.kcck.model.*;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.model.SearchPaymentTransaction;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.codehaus.jackson.map.ObjectMapper;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.google.common.reflect.TypeToken;
import com.google.gson.Gson;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;
import com.sun.jersey.core.util.MultivaluedMapImpl;

import nta.kcck.service.IKcckApiService;
import nta.mss.controller.HospitalController;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.model.PatientWaitingModel;

@Service
@Transactional
public class KcckApiService implements IKcckApiService {

	private static final Logger LOG = LogManager.getLogger(HospitalController.class);

	@Override
	public String getFullUrl(String apiName) {
		String severUrl = null;
		String severPort = null;
		try {
			severUrl = MssConfiguration.getInstance().getApiKcckSeverUrl();
			severPort = MssConfiguration.getInstance().getApiKcckSeverPort();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return severUrl + ":" + severPort + "/" + apiName;
	}
	@Override
	public String getFullUrlMis(String apiName) {
		String severUrl = null;
		String severPort = null;
		try {
			severUrl = MssConfiguration.getInstance().getApiMisSeverUrl();
			severPort = MssConfiguration.getInstance().getApiMisSeverPort();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return severUrl + ":" + severPort + "/" + apiName;
	}
	@Override
	public Integer saveVaccineReservation(KcckVaccineReservationModel model) {
		Integer status = 0;
		KcckVaccineReservationModel vaccineReservationModel = new KcckVaccineReservationModel();
		try {
			MessageResponse<KcckVaccineReservationModel> messageResponse = new MessageResponse<KcckVaccineReservationModel>();
			Type confType = new TypeToken<KcckVaccineReservationModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(model, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckVaccineBooking());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.accept("application/json").type("application/json")
					.post(ClientResponse.class, json);
			LOG.info("BOOKING VACCINE: [REQUEST URL = ] " + url);
			LOG.info("BOOKING VACCINE: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Save Vaccine:" +response.getStatus() );
				LOG.warn("KCCK-API Response:" +response.getEntity(String.class) );
			}

			String output = response.getEntity(String.class);
			Type confType2 = new TypeToken<MessageResponse<KcckVaccineReservationModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			vaccineReservationModel = messageResponse.getData();
			status = Integer.valueOf(messageResponse.getStatus());
		} catch (Exception e) {
			e.printStackTrace();
		}
		return status;
	}

	@Override
	public MessageResponse<KcckVaccineScheduleModel> getKcckVaccineSchedule(String hospCode, String avgTime,
			String startDate, String endDate, String jundalTable, String jundalPart) {

		MessageResponse<KcckVaccineScheduleModel> messageResponse = new MessageResponse<KcckVaccineScheduleModel>();
		try {
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckBookinglabSchedule());
			WebResource webResource = client
					.resource(url + "?hosp_code=" + hospCode + "&avg_time=" + avgTime + "&start_date=" + startDate
							+ "&end_date=" + endDate + "&jundal_table=" + jundalTable + "&jundal_part=" + jundalPart);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET VACCINE SCHEDULE: [REQUEST URL = ] " + url + "?hosp_code=" + hospCode + "&avg_time=" + avgTime + "&start_date=" + startDate
					+ "&end_date=" + endDate + "&jundal_table=" + jundalTable + "&jundal_part=" + jundalPart);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Vaccine Schedule:" +response.getStatus() );
				LOG.warn("KCCK-API Response:" +response.getEntity(String.class) );
				return messageResponse;
			}

			String output = response.getEntity(String.class);

			Type confType = new TypeToken<MessageResponse<KcckVaccineScheduleModel>>() {
			}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);
		} catch (Exception e) {

			e.printStackTrace();

		}
		return messageResponse;
	}

	public List<String> listKcckVaccineTime(String hospCode, String avgTime, String startDate, String endDate,
			String jundalTable, String jundalPart) {
		MessageResponse<KcckVaccineScheduleModel> messageResponse = getKcckVaccineSchedule(hospCode, avgTime, startDate,
				endDate, jundalTable, jundalPart);
		HashSet<String> time = new HashSet<String>();
		KcckVaccineScheduleModel kcckVaccineScheduleModel = messageResponse.getData();
		for (KcckBookingSlot slot : kcckVaccineScheduleModel.getEnable_slot()) {
			String timeSlot = slot.getEnable_date_slot() + "_" + slot.getEnable_time_slot();
			time.add(timeSlot);
		}
		List<String> listTime = new ArrayList<String>(time);
		return listTime;
	}

	@Override
	public KcckReservationModel saveReservation(KcckReservationModel model) {
		KcckReservationModel reservationModel = new KcckReservationModel();
		try {
			MessageResponse<KcckReservationModel> messageResponse = new MessageResponse<KcckReservationModel>();
			Type confType = new TypeToken<KcckReservationModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(model, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckNewBooking());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("BOOKING EXAMATION: [REQUEST URL = ] " + url);
			LOG.info("BOOKING EXAMATION: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Save Booking:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return reservationModel;
			}

			String output = response.getEntity(String.class);

			Type confType2 = new TypeToken<MessageResponse<KcckReservationModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			reservationModel = messageResponse.getData();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return reservationModel;

	}

	@Override
	public KcckReservationModel changeReservation(KcckReservationModel model) {
		KcckReservationModel reservationModel = new KcckReservationModel();

		try {
			MessageResponse<KcckReservationModel> messageResponse = new MessageResponse<KcckReservationModel>();
			Type confType = new TypeToken<KcckReservationModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(model, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckChangeBooking());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("CHANGE BOOKING EXAMATION: [REQUEST URL = ] " + url);
			LOG.info("CHANGE BOOKING EXAMATION: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Change Booking:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return reservationModel;
			}

			String output = response.getEntity(String.class);
			Type confType2 = new TypeToken<MessageResponse<KcckReservationModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			reservationModel = messageResponse.getData();

		} catch (Exception e) {

			e.printStackTrace();

		}
		return reservationModel;
	}

	@Override
	public KcckReservationModel cancelReservation(KcckReservationModel model) {
		KcckReservationModel reservationModel = new KcckReservationModel();

		try {
			MessageResponse<KcckReservationModel> messageResponse = new MessageResponse<KcckReservationModel>();
			Type confType = new TypeToken<KcckReservationModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(model, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckCancelBooking());

			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("CANCEL BOOKING EXAMATION: [REQUEST URL = ] " + url);
			LOG.info("CANCEL BOOKING EXAMATION: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Cancel Booking:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return reservationModel;
			}

			String output = response.getEntity(String.class);
			LOG.info(output);
			Type confType2 = new TypeToken<MessageResponse<KcckReservationModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			reservationModel = messageResponse.getData();

		} catch (Exception e) {

			e.printStackTrace();

		}
		return reservationModel;
	}

	@Override
	public MessageResponse<KcckPendingModel> getKcckPendingStatus(String hospCode, String departmentCode) {

		MessageResponse<KcckPendingModel> messageResponse = new MessageResponse<KcckPendingModel>();
		try {
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckPendingStatus());

			WebResource webResource = client
					.resource(url + "?hosp_code=" + hospCode + "&department_code=" + departmentCode);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET_PENDING_STATUS: [REQUEST URL = ] " + url + "?hosp_code=" + hospCode + "&department_code=" + departmentCode);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API PendingStatus:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return messageResponse;
			}
			ObjectMapper mapper = new ObjectMapper();
			String output = response.getEntity(String.class);

			Type confType = new TypeToken<MessageResponse<KcckPendingModel>>() {
			}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);

		} catch (Exception e) {

			e.printStackTrace();

		}
		return messageResponse;
	}

	// department API: KCCK-MSS
	@Override
	public MessageResponse<List<KcckDepartmentModel>> listDepartment(String hospCode, String locate) {

		MessageResponse<List<KcckDepartmentModel>> messageResponse = new MessageResponse<List<KcckDepartmentModel>>();
		try {
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckDepartmentList());

			WebResource webResource = client.resource(url + "?hospCode=" + hospCode + "&locale=" + locate);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET_DEPARTMENT: [REQUEST URL = ] " + url + "?hospCode=" + hospCode + "&locale=" + locate);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API List Department:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return null;
			}

			String output = response.getEntity(String.class);

			Type confType = new TypeToken<MessageResponse<List<KcckDepartmentModel>>>() {
			}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);

		} catch (Exception e) {

			e.printStackTrace();

		}
		return messageResponse;
	}

	// List Doctor
	@Override
	public MessageResponse<List<DoctorModelInfo>> listKcckDoctor(String hospCode, String departmentCode) {

		MessageResponse<List<DoctorModelInfo>> messageResponse = new MessageResponse<List<DoctorModelInfo>>();
		try {
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckDoctorList());
			WebResource webResource = client
					.resource(url + "?departmentCode=" + departmentCode + "&hospCode=" + hospCode);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET_LIST_DOCTOR: [REQUEST URL = ] " + url + "?departmentCode=" + departmentCode + "&hospCode=" + hospCode);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API List Doctor:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return messageResponse;
			}

			String output = response.getEntity(String.class);
			Type confType = new TypeToken<MessageResponse<List<DoctorModelInfo>>>() {
			}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);

		} catch (Exception e) {

			e.printStackTrace();

		}
		return messageResponse;
	}

	// Kcck Doctor Schedule
	@Override
	public MessageResponse<List<KcckDoctorScheduleModel>> getKcckDoctorSchedule(String hospCode, String departmentCode,
			String doctorCode, String startDate, String endDate) {

		MessageResponse<List<KcckDoctorScheduleModel>> messageResponse = new MessageResponse<List<KcckDoctorScheduleModel>>();
		try {
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckDoctorSchedule());
			WebResource webResource = client
					.resource(url + "?hosp_code=" + hospCode + "&department_code=" + departmentCode + "&doctor_code="
							+ doctorCode + "&start_date=" + startDate + "&end_date=" + endDate);
			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET_DOCTOR_SCHEDULE: [REQUEST URL = ] " + url + "?hosp_code=" + hospCode + "&department_code=" + departmentCode + "&doctor_code="
					+ doctorCode + "&start_date=" + startDate + "&end_date=" + endDate);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Doctor Schedule:" + response.getStatus());
				LOG.warn("KCCK-API Response:" + response.getEntity(String.class));
				return null;
			}

			String output = response.getEntity(String.class);

			Type confType = new TypeToken<MessageResponse<List<KcckDoctorScheduleModel>>>() {

			}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);
		} catch (Exception e) {

			e.printStackTrace();

		}
		return messageResponse;
	}

	@Override
	public MessageResponse<KcckScheduleModel> getKcckDepartmentSchedule(
			String hospCode,
			String avgTime,
			String startDate,
			String endDate,
			String departmentCode,
			String doctorCode,
			String doctorGrade) {
		MessageResponse<KcckScheduleModel> messageResponse = new MessageResponse<KcckScheduleModel>();
		try {
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckDepartmentSchedule());
			url +=  "?" +
					"hosp_code=" + hospCode +
					"&agv_time=" + avgTime+
					"&start_date=" + startDate +
					"&end_date=" + endDate +
					"&department_code=" + departmentCode +
					(doctorCode != null ? ("&doctor_code=" + doctorCode) : "") +
					(doctorGrade != null ? ("&doctor_grade=" + doctorGrade) : "");

			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET_PATIENT_INFO: [REQUEST URL = ] " + url + "?hosp_code=" + hospCode + "&agv_time=" + avgTime
					+ "&start_date=" + startDate + "&end_date=" + endDate + "&department_code=" + departmentCode + "&doctor_grade=" +doctorGrade);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Patient Info Status:" + response.getStatus());
				LOG.warn("KCCK-API Patient Info:" + response.getEntity(String.class));
				return null;
			}

			String output = response.getEntity(String.class);

			Type confType = new TypeToken<MessageResponse<KcckScheduleModel>>() {
			}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);
			LOG.debug("Kcck PatientModel=" + messageResponse.toString());
		} catch (Exception e) {
			e.printStackTrace();
		}
		return messageResponse;
	}

	@Override
	public KcckPatientModel getKcckPatientInfo(String hospCode, String patientCode) {
		KcckPatientModel kcckPatientModel = new KcckPatientModel();
		try {
			MessageResponse<KcckPatientModel> messageResponse = new MessageResponse<KcckPatientModel>();
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckPatientInfo());

			WebResource webResource = client
					.resource(url + "?hosp_code=" + hospCode + "&patient_code=" + patientCode);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET_PATIENT_INFO: [REQUEST URL = ] " + url + "?hosp_code=" + hospCode + "&patient_code=" + patientCode);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Patient Info Status:" + response.getStatus());
				LOG.warn("KCCK-API Patient Info:" + response.getEntity(String.class));
				return kcckPatientModel;
			}

			String output = response.getEntity(String.class);

			Type confType = new TypeToken<MessageResponse<KcckPatientModel>>() {
			}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);
			kcckPatientModel = messageResponse.getData();
			LOG.debug("Kcck PatientModel=" + kcckPatientModel.toString());
		} catch (Exception e) {

			e.printStackTrace();

		}
		return kcckPatientModel;
	}

	// crm API: KCCK-MSS
	@Override
	public KcckCrmModel listCrm(KcckCrmModel crmModel) {

		KcckCrmModel responseModel = new KcckCrmModel();
		try {
			MessageResponse<KcckCrmModel> messageResponse = new MessageResponse<KcckCrmModel>();
			Type confType = new TypeToken<KcckCrmModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(crmModel, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckCrmSearch());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("CRM SEARCH: [REQUEST URL = ] " + url);
			LOG.info("CRM SEARCH: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Crm Search:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return responseModel;
			}

			String output = response.getEntity(String.class);
			LOG.info(output);
			Type confType2 = new TypeToken<MessageResponse<KcckCrmModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			responseModel = messageResponse.getData();
		} catch (Exception e) {
			e.printStackTrace();
			return responseModel;
		}
		return responseModel;
	}

	@Override
	public KcckSysUserModel getKcckSysUserInfo(KcckSysUserModel sysUserModel) {
		KcckSysUserModel responseSysUser = new KcckSysUserModel();
		try {
			MessageResponse<KcckSysUserModel> messageResponse = new MessageResponse<KcckSysUserModel>();
			Type confType = new TypeToken<KcckSysUserModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(sysUserModel, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckSysUser());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("SysUer SEARCH: [REQUEST URL = ] " + url);
			LOG.info("SysUer SEARCH: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API SysUser Search:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return responseSysUser;
			}

			String output = response.getEntity(String.class);
			LOG.info(output);
			Type confType2 = new TypeToken<MessageResponse<KcckSysUserModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			responseSysUser = messageResponse.getData();
			responseSysUser.setStatus(messageResponse.getStatus());
			responseSysUser.setMessage(messageResponse.getMessage());
		} catch (Exception e) {
			e.printStackTrace();
			return responseSysUser;
		}
		return responseSysUser;
	}

	@Override
	public String updateKcckDefaultSchedule(KcckDefaultScheduleModel kcckDefaultSchedule) {
		String result = "";
		try {
			MessageResponse<KcckDefaultScheduleModel> messageResponse = new MessageResponse<KcckDefaultScheduleModel>();
			Type confType = new TypeToken<KcckDefaultScheduleModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(kcckDefaultSchedule, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckUpdateDefaultSchedule());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("SysUer SEARCH: [REQUEST URL = ] " + url);
			LOG.info("SysUer SEARCH: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API SysUser Search:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return result;
			}

			String output = response.getEntity(String.class);
			LOG.info(output);
			Type confType2 = new TypeToken<MessageResponse<KcckDefaultScheduleModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			result = messageResponse.getMessage();
		} catch (Exception e) {
			e.printStackTrace();
			return result;
		}
		return result;
	}
	
	// List Patient waiting by DoctorCode
	@Override
	public MessageResponse<List<PatientWaitingModel>> listKcckPatientWaiting(String doctorCode, String examinationDate,
			String examinationSituation, String departmentCode, String hospCode, String locale) {

		MessageResponse<List<PatientWaitingModel>> messageResponse = new MessageResponse<List<PatientWaitingModel>>();
		try {
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckPatientWaitingList());
			WebResource webResource = client
					.resource(url + "?doctor_code=" + doctorCode + "&examination_date=" + examinationDate
							+ "&examination_situation=" + examinationSituation + "&department_code=" + departmentCode
							+ "&hosp_code=" + hospCode + "&locale=" + locale);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET__WAITING_LIST_BY_DOCTOR: [REQUEST URL = ] " + url + "?doctor_code=" + doctorCode + "&examination_date=" + examinationDate
					 + "&examination_situation=" + examinationSituation + "&department_code=" + departmentCode
					 + "&hosp_code=" + hospCode + "&locale=" + locale);
			
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API List Patient Waiting By Doctor:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return messageResponse;
			}
			

			String output = response.getEntity(String.class);
			Type confType = new TypeToken<MessageResponse<List<PatientWaitingModel>>>() {}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);

		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return messageResponse;
	}

	// List Patient waiting by PatientCode
	@Override
	public MessageResponse<List<PatientWaitingModel>> listKcckPatientWaitingByPaientCode(String examinationDate,
			String hospCode, String patient_code, String locale) {
		MessageResponse<List<PatientWaitingModel>> messageResponse = new MessageResponse<List<PatientWaitingModel>>();
		try {
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckPatientWaitingList());
			WebResource webResource = client
					.resource(url + "?examination_date=" + examinationDate + "&hosp_code=" + hospCode
							+ "&patient_code=" + patient_code + "&locale=" + locale);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET__WAITING_LIST_BY_PATIENT: [REQUEST URL = ] " + url + "?examination_date=" + examinationDate
					+ "&hosp_code=" + hospCode + "&patient_code=" + patient_code + "&locale=" + locale);
			
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API List Patient Waiting By Patient:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return messageResponse;
			}
			

			String output = response.getEntity(String.class);
			Type confType = new TypeToken<MessageResponse<List<PatientWaitingModel>>>() {}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);

		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return messageResponse;
	}

	@Override
	public PatientWaitingModel updateKcckMtCallingIdByReservationCode(String reservation_code, String mt_calling_id) {
		PatientWaitingModel patientWaitingModel = new PatientWaitingModel();
		try {
			MessageResponse<PatientWaitingModel> messageResponse = new MessageResponse<PatientWaitingModel>();
			Type confType = new TypeToken<PatientWaitingModel>() {}.getType();
			Gson gson = new Gson();
			PatientWaitingModel model = new PatientWaitingModel();
			model.setReservation_code(reservation_code);
			if(mt_calling_id == null){
				mt_calling_id = "";
			}
			model.setMt_calling_id(mt_calling_id);
			model.setHospital_id(String.valueOf(MssContextHolder.getHospitalId()));
			String json = gson.toJson(model, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckPatientCallingId());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").put(ClientResponse.class, json);
			LOG.info("UPDATE CALLING_ID BYR ESERVATION_CODE: [REQUEST URL = ] " + url);
			LOG.info("UPDATE CALLING_ID BYR ESERVATION_CODE: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API update calling_id:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return patientWaitingModel;
			}

			String output = response.getEntity(String.class);
			LOG.info(output);
			Type confType2 = new TypeToken<MessageResponse<PatientWaitingModel>>() {}.getType();
			messageResponse = gson.fromJson(output, confType2);
			patientWaitingModel = messageResponse.getData();

		} catch (Exception e) {
			e.printStackTrace();
		}
		return patientWaitingModel;
	}

	@Override
	public String getLinkSurvey(String hospCode, String departmentCode, String patientCode, String reservationCode) {
		MessageResponse<String> messageResponse = new MessageResponse<String>();
		try {
			Gson gson = new Gson();
			Client client = Client.create();
			String url = this.getFullUrlMis(MssConfiguration.getInstance().getApiGetLinkSurvey());
			WebResource webResource = client
					.resource(url + "?hosp_code=" + hospCode + "&department_code=" + departmentCode
							+ "&patient_code=" + patientCode + "&reservation_code=" + reservationCode);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("Get link survey: [REQUEST URL = ] " + url + "?hosp_code=" + hospCode
					+ "&department_code=" + departmentCode + "&patient_code=" + patientCode + "&reservation_code=" + reservationCode);

			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API List Patient Waiting By Patient:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return "";
			}
			else
			{

				String output = response.getEntity(String.class);
				Type confType2 = new TypeToken<MessageResponse<String>>() {
				}.getType();
				messageResponse = gson.fromJson(output, confType2);
				return  messageResponse.getData();
			}



		} catch (Exception e) {
			e.printStackTrace();
		}

		return "";
	}
	@Override
	public String getAutoReceiptByPatientCodeAndHospCode(String patientCode, String hospCode) {
		// TODO Auto-generated method stub
		String autoReceipt = "N";
		try{
		Client client = Client.create();
		String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckAutoRecept());
		WebResource webResource = client.resource(url);
		MultivaluedMap<String, String> queryParams  = new MultivaluedMapImpl();
		queryParams.add("patient_code", patientCode);
		queryParams.add("hosp_code", hospCode);
		ClientResponse response = webResource.queryParams(queryParams).type("application/json").get(ClientResponse.class);
		if (response.getStatus() != 200) {
			LOG.warn(response.getStatus());
			return "N";
		}
		String output = response.getEntity(String.class);
		Gson gson = new Gson();
		Type confType = new TypeToken<MessageResponse<String>>() {
		}.getType();
		MessageResponse<String> messageResponse = gson.fromJson(output, confType);
		autoReceipt = messageResponse.getData().equals("Y") ? "Y" : "N";
		LOG.info("Get token device successfully");
		return autoReceipt;
		}catch(Exception e)
		{
		e.printStackTrace();
		return  "N";
		}
	}

	@Override
	public KcckTransactionInfoModel getTransactionInfos(SearchPaymentTransaction searchPaymentTransaction) {
		KcckTransactionInfoModel kcckTransactionInfoModel = new KcckTransactionInfoModel();

		MessageResponse<KcckTransactionInfoModel> messageResponse = new MessageResponse<KcckTransactionInfoModel>();
		try {

			Type confType = new TypeToken<SearchPaymentTransaction>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(searchPaymentTransaction, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckSearchPaymentHistory());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").post(ClientResponse.class, json);
			LOG.info("BOOKING EXAMATION: [REQUEST URL = ] " + url);
			LOG.info("BOOKING EXAMATION: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Save Booking:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return kcckTransactionInfoModel;
			}
			String output = response.getEntity(String.class);
			LOG.info(output);
			Type confType2 = new TypeToken<MessageResponse<KcckTransactionInfoModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			kcckTransactionInfoModel = messageResponse.getData();

		} catch (Exception e) {
			LOG.error("Exception when call get transaction to kcck", e);
		}
		return kcckTransactionInfoModel;
	}

	@Override
	public KcckPaymentModel getKcckPayment(String fkOut, String patientCode, String hospCode, String orderId) {

		KcckPaymentModel kcckPaymentModel = new KcckPaymentModel();
		try {
			MessageResponse<KcckPaymentModel> messageResponse = new MessageResponse<KcckPaymentModel>();
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckPaymentInfo());
			WebResource webResource = client.resource(url);
			MultivaluedMap<String, String> queryParams  = new MultivaluedMapImpl();
			queryParams.add("fk_out", fkOut);
			queryParams.add("patient_code", patientCode);
			queryParams.add("hosp_code", hospCode);
			queryParams.add("order_id", orderId);
			ClientResponse response = webResource.queryParams(queryParams).type("application/json").get(ClientResponse.class);
			if (response.getStatus() != 200) {
				LOG.warn(response.getStatus());
				return kcckPaymentModel;
			}
			String output = response.getEntity(String.class);
			Gson gson = new Gson();
			Type confType = new TypeToken<MessageResponse<KcckPaymentModel>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType);
			kcckPaymentModel = messageResponse.getData();
			return kcckPaymentModel;

		} catch (Exception e) {
			e.printStackTrace();
		}
		return kcckPaymentModel;
	}

	@Override
	public boolean updatePayment(KcckUpdatePaymentStatusModel paymentInfoModel) {

		MessageResponse<Boolean> messageResponse = new MessageResponse<Boolean>();
		boolean result =false;
		try {

			Type confType = new TypeToken<KcckUpdatePaymentStatusModel>() {
			}.getType();
			Gson gson = new Gson();
			String json = gson.toJson(paymentInfoModel, confType);

			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckUpdatePayment());
			WebResource webResource = client.resource(url);

			ClientResponse response = webResource.type("application/json").put(ClientResponse.class, json);
			LOG.info("BOOKING EXAMATION: [REQUEST URL = ] " + url);
			LOG.info("BOOKING EXAMATION: [REQUEST BODY JSON = ] " + json);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Save Booking:" + response.getStatus());
				LOG.warn("KCCK-API :" + response.getEntity(String.class));
				return false;
			}
			String output = response.getEntity(String.class);
			LOG.info(output);
			Type confType2 = new TypeToken<MessageResponse<Boolean>>() {
			}.getType();
			messageResponse = gson.fromJson(output, confType2);
			result = messageResponse.getData();

		} catch (Exception e) {
			LOG.error("Exception when call get transaction to kcck", e);
		}
		return result;
	}
	
	@Override
	public KcckGmoShopInfoModel getGmoShopInfo(String hospCode) {
		KcckGmoShopInfoModel kcckGmoShopInfoModel = new KcckGmoShopInfoModel();
		try {
			MessageResponse<KcckGmoShopInfoModel> messageResponse = new MessageResponse<KcckGmoShopInfoModel>();
			Client client = Client.create();
			String url = this.getFullUrl(MssConfiguration.getInstance().getApiKcckGmoPaymentInfo());

			WebResource webResource = client.resource(url + "?hosp_code=" + hospCode);

			ClientResponse response = webResource.accept("application/json").get(ClientResponse.class);
			LOG.info("GET_GMO_SHOP_INFO: [REQUEST URL = ] " + url + "?hosp_code=" + hospCode);
			if (response.getStatus() != 200) {
				LOG.warn("KCCK-API Gmo Shop Info Status:" + response.getStatus());
				LOG.warn("KCCK-API Gmo Shop Info:" + response.getEntity(String.class));
				return kcckGmoShopInfoModel;
			}

			String output = response.getEntity(String.class);

			Type confType = new TypeToken<MessageResponse<KcckGmoShopInfoModel>>() {
			}.getType();
			Gson gson = new Gson();
			messageResponse = gson.fromJson(output, confType);
			kcckGmoShopInfoModel = messageResponse.getData();
			LOG.debug("Kcck KcckGmoShopInfoModel=" + kcckGmoShopInfoModel.toString());
		} catch (Exception e) {
			e.printStackTrace();
		}
		return kcckGmoShopInfoModel;
	}

}

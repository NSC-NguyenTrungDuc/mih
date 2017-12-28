package nta.kcck.service;

import java.util.List;

import nta.kcck.model.*;
import nta.mss.model.PatientWaitingModel;
import nta.mss.model.SearchPaymentTransaction;

public interface IKcckApiService {
	public String getFullUrl(String apiName);
	public String getFullUrlMis(String apiName);

	public Integer saveVaccineReservation(KcckVaccineReservationModel model);

	//booking
	public KcckReservationModel saveReservation(KcckReservationModel model);
	public KcckReservationModel changeReservation(KcckReservationModel model);
	public KcckReservationModel cancelReservation(KcckReservationModel model);
	//Pending
	public MessageResponse<KcckPendingModel> getKcckPendingStatus(String hospCode, String departmentCode);

	//Department
	public MessageResponse<List<KcckDepartmentModel>> listDepartment(String hospCode,String locate);
	//Doctor
	public MessageResponse<List<DoctorModelInfo>> listKcckDoctor(String hospCode, String departmentCode);
	//Schedule
	public MessageResponse<List<KcckDoctorScheduleModel>> getKcckDoctorSchedule(String hospCode, String departmentCode,
			String doctorCode, String startDate, String endDate);
	public MessageResponse<KcckScheduleModel> getKcckDepartmentSchedule(String hospCode, String avgTime,
																			  String startDate, String endDate, String departmentCode, String doctorCode, String doctorGrade);


	public MessageResponse<KcckVaccineScheduleModel> getKcckVaccineSchedule(String hospCode, String avgTime,
																					 String startDate, String endDate, String jundalTable, String jundalPart);
	// Get Patient Info
	public KcckPatientModel getKcckPatientInfo(String hospCode, String patientCode);

	public KcckCrmModel listCrm(KcckCrmModel crmModel);
	
	public KcckSysUserModel getKcckSysUserInfo(KcckSysUserModel sysUserModel);
	
	public String updateKcckDefaultSchedule(KcckDefaultScheduleModel kcckDefaultSchedule);
	
	//Patient waiting
	public MessageResponse<List<PatientWaitingModel>> listKcckPatientWaiting(String doctorCode, String examinationDate,
			String examinationSituation, String departmentCode, String hospCode, String locale);
	
	//Patient waiting
	public MessageResponse<List<PatientWaitingModel>> listKcckPatientWaitingByPaientCode(String examinationDate,
			String hospCode, String patient_code, String locale);
	
	//Update MtCallingId
	public PatientWaitingModel updateKcckMtCallingIdByReservationCode(String reservation_code, String mt_calling_id);

	public String getLinkSurvey(String hospCode, String departmentCode, String patientCode, String reservationCode);
	
	public String getAutoReceiptByPatientCodeAndHospCode(String patientCode, String hospCode);

	public KcckTransactionInfoModel getTransactionInfos(SearchPaymentTransaction searchPaymentTransaction);
	public KcckPaymentModel getKcckPayment(String fkOut, String patientCode, String hospCode, String orderId);
	public boolean updatePayment(KcckUpdatePaymentStatusModel paymentInfoModel);
	
	// GMO payment config
	public KcckGmoShopInfoModel getGmoShopInfo(String hospCode);
}

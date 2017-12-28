package nta.mss.controller;

/**
 * @author TungLT
 */
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import nta.med.common.util.Collections;
import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.util.Strings;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import nta.kcck.service.impl.KcckPatientService;
import nta.mss.entity.DataTableJsonObject;
import nta.mss.entity.MovieTalkHistory;
import nta.mss.entity.PatientWaitingInfo;
import nta.mss.entity.User;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.SessionMode;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.PatientModel;
import nta.mss.model.PatientWaitingModel;
import nta.mss.model.UserModel;
import nta.mss.repository.UserRepository;
import nta.mss.service.IMovieTalkService;
import nta.mss.service.IPatientService;
import nta.phr.model.AccountClinicModel;
import nta.phr.model.ProfileStandard;
import nta.phr.service.impl.PhrApiService;

@Controller
@Scope("prototype")
@RequestMapping("movie-talk")
@NavigationConfig(leftMenuType = NavigationType.FRONT_LEFT_MENU)
public class PantientController extends BaseController {
	private static final Logger LOG = LogManager.getLogger(PantientController.class);

	KcckPatientService kcckPatientService = new KcckPatientService();
	private IPatientService patientService;
	@Resource
	private PhrApiService phrApiService;
	@Resource
	private UserRepository userRepository;

	@Resource
	private IMovieTalkService movieTalkService;

	public PantientController() {
	}

	@Autowired
	public PantientController(IPatientService patientService) {
		this.patientService = patientService;
	}

	@RequestMapping("/index")
	@NavigationConfig(group = { NavigationGroup.MOVIES_TALK })
	public ModelAndView Index() {
		LOG.info("[Start] View patient movie talk screen.");
		return new ModelAndView("front.movietalk.patient.index");
	}

	/**
	 * Method getWaitingList Examination
	 */
	@RequestMapping(value = "/get-patient-waiting-list", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String getWaitingListExamination(@RequestParam String examinationDate,
			@RequestParam int iDisplayStart, @RequestParam int iDisplayLength) {
		LOG.info("[Start] View get examination waiting list data.");
		// Integer hospitalId = MssContextHolder.getHospitalId();
		// String patientCode = MssContextHolder.get;
		List<PatientWaitingInfo> listInsuranceHistory = new ArrayList<PatientWaitingInfo>();

		// Parameter for call KCCK api
		// TODO
		String hospCode = MssContextHolder.currentSessionContext().getHospCode();

		// Current date
		if (StringUtils.isBlank(examinationDate)) {
			Date currentDate = new Date();
			DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");
			examinationDate = dateFormat.format(currentDate);
		} else {
			// Convert date format "MM/dd/yyyy" to "yyyy/MM/dd"
			DateFormat formatter = new SimpleDateFormat("MM/dd/yyyy");
			Date date;
			try {
				date = (Date) formatter.parse(examinationDate);
				SimpleDateFormat newFormat = new SimpleDateFormat("yyyy/MM/dd");
				examinationDate = newFormat.format(date);
			} catch (ParseException e) {
				e.printStackTrace();
				e.printStackTrace();
			}
		}

		// examinationDate = "2016/08/31";
		String examinationSituation = "1";

		String locale = "VI";
		if (StringUtils.isNotBlank(MssContextHolder.getLocale().toString())) {
			locale = MssContextHolder.getLocale().toString();
		}

		String patientCode = this.getStrPatientCodeFromAccountClinic();
		/*
		 * if (patients != null && patients.size() > 0) { patientCode =
		 * patients.get(0).getCardNumber(); }
		 */

		// TODO
		List<PatientWaitingModel> patientWaitingModels = this.kcckPatientService.findKcckPaitentWaitingByPatientCode(
				examinationDate, examinationSituation, hospCode, patientCode, locale);
		Integer totalRecord = patientWaitingModels.size();

		List<PatientWaitingInfo> listUpcoming = new ArrayList<PatientWaitingInfo>();
		List<PatientWaitingInfo> listCompleted = new ArrayList<PatientWaitingInfo>();
		List<PatientWaitingInfo> listExpired = new ArrayList<PatientWaitingInfo>();

		if (patientWaitingModels != null && patientWaitingModels.size() > 0) {
			PatientWaitingInfo info = null;
			for (PatientWaitingModel model : patientWaitingModels) {
				// Status
				String status = null;
				if (StringUtils.isNotBlank(model.getNawon_yn())) {
					if ("E".equalsIgnoreCase(model.getNawon_yn())) {
						// Display is blue
						status = "1";
						info = new PatientWaitingInfo(model.getExamination_date(), model.getExamination_time(),
								model.getDepartment_name(), model.getPatient_name(), model.getPatient_code(),
								model.getPatient_name_kana(), model.getRecept_time(), "isOnline", status,
								model.getDoctor_code(), model.getDoctor_name(), model.getExaminationTimeFrm(),
								model.getExaminationTimeAmPm(), model.getReservation_code());
						listCompleted.add(info);
					}

					if ("Y".equalsIgnoreCase(model.getNawon_yn()) || "N".equalsIgnoreCase(model.getNawon_yn())) {
						String examDateStr = model.getExamination_date() + " " + model.getExamination_time();
						DateFormat format = new SimpleDateFormat("yyyy/MM/dd hhmm");
						Date examDate = null;
						try {
							examDate = format.parse(examDateStr);
						} catch (ParseException e) {
							e.printStackTrace();
						}

						Date currentDate = new Date();
						Date examDateTommorrow = new Date(examDate.getTime() + (1000 * 60 * 60 * 24));
						if (examDateTommorrow.after(currentDate)) {
							// Display is Green
							status = "0";
							info = new PatientWaitingInfo(model.getExamination_date(), model.getExamination_time(),
									model.getDepartment_name(), model.getPatient_name(), model.getPatient_code(),
									model.getPatient_name_kana(), model.getRecept_time(), "isOnline", status,
									model.getDoctor_code(), model.getDoctor_name(), model.getExaminationTimeFrm(),
									model.getExaminationTimeAmPm(), model.getReservation_code());
							listUpcoming.add(info);
						} else {
							// Display is Gray
							status = "-1";
							info = new PatientWaitingInfo(model.getExamination_date(), model.getExamination_time(),
									model.getDepartment_name(), model.getPatient_name(), model.getPatient_code(),
									model.getPatient_name_kana(), model.getRecept_time(), "isOnline", status,
									model.getDoctor_code(), model.getDoctor_name(), model.getExaminationTimeFrm(),
									model.getExaminationTimeAmPm(), model.getReservation_code());
							listExpired.add(info);
						}
					}
				}
			}

			// Set to listInsuranceHistory
			for (PatientWaitingInfo upcoming : listUpcoming) {
				listInsuranceHistory.add(upcoming);
			}
			for (PatientWaitingInfo completed : listCompleted) {
				listInsuranceHistory.add(completed);
			}
			for (PatientWaitingInfo expired : listExpired) {
				listInsuranceHistory.add(expired);
			}

		}

		DataTableJsonObject<PatientWaitingInfo> reservationJsonObject = new DataTableJsonObject<>();
		reservationJsonObject.setiTotalDisplayRecords(totalRecord);
		reservationJsonObject.setiTotalRecords(totalRecord);
		reservationJsonObject.setAaData(listInsuranceHistory);
		GsonBuilder builder = new GsonBuilder();
		builder.serializeNulls();
		Gson gson = builder.create();
		String jsonOBJ = gson.toJson(reservationJsonObject);

		return jsonOBJ;
	}

	/**
	 * Method update mtCallingId
	 */
	@RequestMapping(value = "/update-mt-calling-id", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String updateMtCallingId(@RequestParam String reservationCode,
			@RequestParam String mtCallingId) {
		LOG.info("[Start] View update mtCallingId.");
		PatientWaitingModel patientWaitingModel = this.kcckPatientService
				.updateKcckMtCallingIdByReservationCode(reservationCode, mtCallingId);

		if (patientWaitingModel != null) {
			GsonBuilder builder = new GsonBuilder();
			builder.serializeNulls();
			Gson gson = builder.create();
			String jsonOBJ = gson.toJson("OK");
			return jsonOBJ;
		}

		return null;
	}

	@RequestMapping("/movietalk-history")
	@NavigationConfig(group = { NavigationGroup.PATIENT_MOVIE_TALK_HISTORY })
	public ModelAndView movieTalkHistory(ModelMap model) {
		LOG.info("[Start] view chart");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("patient.moviestalkHistory");
	}

	/**
	 * Method getListMovieTalkHistory
	 * 
	 * @param iDisplayStart
	 * @param iDisplayLength
	 * @return
	 */
	@RequestMapping(value = "/get-history-movietalk", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String getMovieTalkHistoryPagenation(@RequestParam int iDisplayStart,
			HttpServletRequest request, HttpSession session, @RequestParam int iDisplayLength) {
		LOG.info("[Start] View get data history insurance.");
		String colSort = request.getParameter("iSortCol_0");
		String typeSort = request.getParameter("sSortDir_0");
		Integer hospitalId = MssContextHolder.getHospitalId();
		String patientCode = this.getStrPatientCodeFromAccountClinic();
		Integer totalRecord = this.movieTalkService.getTotalRecordMovieTalkHistoryByHospIdAndPatientId(hospitalId,
				patientCode);

		List<MovieTalkHistory> listMovieTalkHistory = this.movieTalkService.getListMovieTalkHistory(hospitalId,
				patientCode, iDisplayStart, iDisplayLength, colSort, typeSort);

		DataTableJsonObject<MovieTalkHistory> movieTalkJsonObject = new DataTableJsonObject<>();
		movieTalkJsonObject.setiTotalDisplayRecords(totalRecord);
		movieTalkJsonObject.setiTotalRecords(totalRecord);
		movieTalkJsonObject.setAaData(listMovieTalkHistory);
		GsonBuilder builder = new GsonBuilder();
		builder.serializeNulls();
		Gson gson = builder.create();
		String jsonOBJ = gson.toJson(movieTalkJsonObject);

		return jsonOBJ;
	}

	private String getStrPatientCodeFromAccountClinic() {
		String patientCode = "";

		try {
			String token = getUser().getToken();
			User user = this.userRepository.findOne(getUser().getUserId());			
			if (user.getPatient() != null) {
				Integer patientId = user.getPatient().getPatientId();
				List<PatientModel> patients = patientService.getListByPatientId(patientId);
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

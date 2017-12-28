package nta.mss.controller;

import java.io.File;
import java.lang.reflect.Type;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import nta.helper.ClientHelper;
import nta.kcck.model.DoctorModelInfo;
import nta.kcck.service.impl.KcckApiService;
import nta.kcck.service.impl.KcckDoctorService;
import nta.mss.misc.common.*;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.google.common.reflect.TypeToken;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.notnoop.apns.APNS;
import com.notnoop.apns.ApnsService;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;

import nta.kcck.model.MessageResponse;
import nta.mss.entity.DataTableJsonObject;
import nta.mss.entity.ExaminationInfo;
import nta.mss.entity.InsuranceHistory;
import nta.mss.entity.MovieTalkHistory;
import nta.mss.info.AjaxResponse;
import nta.mss.info.ReservationOnlineInfo;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.misc.enums.SessionMode;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.PatientWaitingModel;
import nta.mss.service.IMovieTalkService;
import nta.mss.service.IReservationService;
import nta.phr.model.PhrAccountModel;
import nta.phr.service.IPhrApiService;

/**
 * The Class DoctorViewController.
 * 
 * @author tunglethanh
 * @CrtDate Aug 8, 2016
 */
/**
 * @author tunglt
 *
 */
@Controller
@Scope("prototype")
@RequestMapping("doctor")
@NavigationConfig(leftMenuType = NavigationType.DOCTOR_VIEW_MENU)
public class DoctorController extends BaseController {

	/** The Constant LOG. */
	private static final Logger LOG = LogManager.getLogger(DoctorController.class);
	@Resource
	private TokenManager<MSSSession> cache;
	@Resource
	private IPhrApiService phrApiService;
	/** The Constant DEFAULT_RESERVATIONS_DISPLAY. */
	public static final Integer DEFAULT_RESERVATIONS_DISPLAY = 10;

	@Resource
	private IReservationService reservationService;

	@Resource
	private IMovieTalkService movieTalkService;

	@Resource
	private KcckApiService kcckApiService;

	KcckDoctorService kcckDoctorService = new KcckDoctorService();

	public DoctorController() {
	}

	/**
	 * @param tokenHospCode
	 * @param model
	 * @return
	 * @throws Exception
	 */
	@RequestMapping("/movies-talk")
	@NavigationConfig(group = { NavigationGroup.MOVIES_TALK })
	public ModelAndView movieTalk(ModelMap model ,HttpSession session) {
		LOG.info("[Start] view chart");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.moviestalk");
	}

	@RequestMapping("/profile-info")
	@NavigationConfig(group = { NavigationGroup.PERSONAL_HEATH, NavigationGroup.PROFILE_INFO })
	public ModelAndView profileInfo(ModelMap model) {
		LOG.info("[Start] View profile information screen.");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.profileInfo");
	}

	@RequestMapping("/body-measurement")
	@NavigationConfig(group = { NavigationGroup.PERSONAL_HEATH, NavigationGroup.BODY_MEASUREMENT })
	public ModelAndView bodyMeasurement(ModelMap model) {
		LOG.info("[Start] view chart");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.bodyMeasurement");
	}

	@RequestMapping("/vital")
	@NavigationConfig(group = { NavigationGroup.PERSONAL_HEATH, NavigationGroup.VITAL })
	public ModelAndView vital(ModelMap model) {
		LOG.info("[Start] view chart");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.vital");
	}

	@RequestMapping("/fitness")
	@NavigationConfig(group = { NavigationGroup.PERSONAL_HEATH, NavigationGroup.FITNESS })
	public ModelAndView fitNess(ModelMap model) {
		LOG.info("[Start] view chart");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.fitness");
	}

	@RequestMapping("/food")
	@NavigationConfig(group = { NavigationGroup.PERSONAL_HEATH, NavigationGroup.FOOD })
	public ModelAndView food(ModelMap model) {
		LOG.info("[Start] view chart");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.food");
	}

	@RequestMapping("/sleep")
	@NavigationConfig(group = { NavigationGroup.PERSONAL_HEATH, NavigationGroup.SLEEP })
	public ModelAndView sleep(ModelMap model) {
		LOG.info("[Start] view chart");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.sleep");
	}

	@RequestMapping("/movietalk-history")
	@NavigationConfig(group = { NavigationGroup.PERSONAL_HEATH, NavigationGroup.MOVIE_TALK_HISTORY })
	public ModelAndView movieTalkHistory(ModelMap model) {
		LOG.info("[Start] view chart");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.moviestalkHistory");
	}

	/**
	 * Method getListhistory Insurance
	 */

	@RequestMapping(value = "/get-history-insurance", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String getHistoryInsuarancePagenation(@RequestParam int iDisplayStart,
			@RequestParam int iDisplayLength, HttpServletRequest request, HttpSession session) {
		LOG.info("[Start] View get data history insurance.");
		Integer hospitalId = MssContextHolder.getHospitalId();
		String patientCode = MssContextHolder.getPatientCode();
		Integer totalRecord = this.reservationService.getTotalRecordReservationByHospIdAndPatientId(hospitalId,
				patientCode);
		String colSort = request.getParameter("iSortCol_0");
		String typeSort = request.getParameter("sSortDir_0");
		List<InsuranceHistory> listInsuranceHistory = this.reservationService.getListReservationByHospIdAndCardNumber(
				hospitalId, patientCode, iDisplayStart, iDisplayLength, colSort, typeSort);
		DataTableJsonObject<InsuranceHistory> reservationJsonObject = new DataTableJsonObject<>();
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
	 * Generate token index
	 * 
	 * @param request
	 * @param model
	 * @param session
	 * @return
	 * @throws Exception
	 */
	@RequestMapping("/generate-token")
	public ModelAndView generateToken(HttpServletRequest request, ModelMap model, HttpSession session)
			throws Exception {
		String msbToken = TokenUtils.generateToken();
		LOG.info("Generate token is" + msbToken);
		// call kcck api for generate mbs token
		Client client = Client.create();
		String url = kcckApiService.getFullUrl(MssConfiguration.getInstance().getApiKcckDoctorInformationFromSession());
		WebResource webResource = client.resource(url + "?session_id=" + request.getParameter("session_id"));
		ClientResponse kcckResponse = webResource.accept("application/json").get(ClientResponse.class);

		model.addAttribute("mbs_token", msbToken);
		if (kcckResponse.getStatus() != 200) {
			LOG.warn("Generate token fail:" + kcckResponse.getStatus());
			return new ModelAndView("front.booking.index");
		} else {

			String output = kcckResponse.getEntity(String.class);
			Type confType = new TypeToken<MessageResponse<DoctorModelInfo>>() {
			}.getType();
			Gson gson = new Gson();
			MessageResponse<DoctorModelInfo> messageResponse = gson.fromJson(output, confType);
			if (messageResponse.getData() != null && !Strings.isEmpty(messageResponse.getData().getDoctor_code())) {
				String hospCode = messageResponse.getData().getHosp_code();
				if (!hospCode.equals(MssContextHolder.getHospCode())) {
					return new ModelAndView("front.booking.index");
				}
				String doctorCode = messageResponse.getData().getDoctor_code();
				cache.put(msbToken, new MSSSession(hospCode, "JA", doctorCode));

				// call phr api for generate phr token
				Client clientPhr = Client.create(ClientHelper.configureClient()); // Client.create();
				url = phrApiService.getFullUrl(MssConfiguration.getInstance().getApiPhrGenerateToken());
				WebResource webResourcePhr = clientPhr.resource(
						url + "?hosp_code=" + hospCode + "&patient_code=" + request.getParameter("patient_code"));

				ClientResponse phrResponse = webResourcePhr.accept("application/json").get(ClientResponse.class);

				if (phrResponse.getStatus() != 200) {
					LOG.warn("Generate token fail:" + phrResponse.getStatus());
					return new ModelAndView("front.booking.index");
				} else {
					String phrOutput = phrResponse.getEntity(String.class);
					Type type = new TypeToken<MessageResponse<PhrAccountModel>>() {
					}.getType();
					gson = new Gson();
					MessageResponse<PhrAccountModel> response = gson.fromJson(phrOutput, type);
					model.addAttribute("phr_token", response.getContent().getToken());
					model.addAttribute("profile_id", response.getContent().getMaster_profile_id());
					model.addAttribute("mbs_token", msbToken);
					session.setAttribute("phr_token", response.getContent().getToken());
					session.setAttribute("profile_id", response.getContent().getMaster_profile_id());
					MssContextHolder.setDepCode(messageResponse.getData().getDepartment_code());
					MssContextHolder.setDoctorCode(messageResponse.getData().getDoctor_code());
					MssContextHolder.setPatientCode(request.getParameter("patient_code"));
					MssContextHolder.setPatientName(messageResponse.getData().getDoctor_code());
					MssContextHolder.setDoctorName(messageResponse.getData().getDoctor_name());		
					String urlAPI = phrApiService.getFullUrl("");
					session.setAttribute("url", urlAPI);
					session.setAttribute("urlUpload", urlAPI + "api/profiles/" + session.getValue("profile_id")
							+ "/upload?token=" + session.getValue("phr_token"));
					int mode = Integer.parseInt(request.getParameter("mode"));
					MssContextHolder.setMode(String.valueOf(mode));
					switch (mode) {
					case 1:
						return new ModelAndView(new RedirectView("profile-info"));
					case 2:
						MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
						return new ModelAndView(new RedirectView("movies-talk"));
					case 3:
						MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
						return new ModelAndView(new RedirectView("profile-info"));
					default:
						return new ModelAndView("front.booking.index");
					}
				}
			} else {
				return new ModelAndView("front.booking.index");
			}
		}

	}

	@RequestMapping(value = "/get-waiting-list", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String getWaitingListExamination(@RequestParam String examinationDate,
			@RequestParam int iDisplayStart, @RequestParam int iDisplayLength, HttpSession session ) {
		LOG.info("[Start] View get examination waiting list data.");
		// Integer hospitalId = MssContextHolder.getHospitalId();
		// String patientCode = MssContextHolder.get;
		List<ExaminationInfo> listInsuranceHistory = new ArrayList<ExaminationInfo>();

		// Parameter for call KCCK api
		String hospCode = MssContextHolder.currentSessionContext().getHospCode();
		String departmentCode = MssContextHolder.currentSessionContext().getDeptCode();
		String doctorCode = MssContextHolder.currentSessionContext().getDoctorCode();

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

		List<PatientWaitingModel> patientWaitingModels = this.kcckDoctorService.findKcckPaitentWaitingByCode(doctorCode,
				examinationDate, examinationSituation, departmentCode, hospCode, locale);
		Integer totalRecord = patientWaitingModels.size();
		if (patientWaitingModels != null && patientWaitingModels.size() > 0) {

			// Online/Offline
			List<String> reservationCodes = new ArrayList<String>();
			
			if (patientWaitingModels != null && patientWaitingModels.size() > 0) {
				for (PatientWaitingModel model : patientWaitingModels) {
					reservationCodes.add(model.getReservation_code());
				}
			}

			List<ReservationOnlineInfo> reservationInfos = null;
			if (reservationCodes.size() > 0) {
				// TODO -FIX
				Integer hospitalIdCall = MssContextHolder.currentSessionContext().getHospitalId();
				// reservationInfos =
				// this.reservationService.findReservationInfoByReCodeHosId(hospitalIdCall,
				// Arrays.asList("2475"));
				reservationInfos = this.reservationService.findReservationInfoByReCodeHosId(hospitalIdCall,
						reservationCodes);
			}

			ExaminationInfo info = null;
			for (PatientWaitingModel model : patientWaitingModels) {
				// Detect online status
				String isOnline = "0";
				String mtCallingId = "";
				Integer reservationId = null;
				for (ReservationOnlineInfo reservationInfo : reservationInfos) {
					if (model.getReservation_code().equalsIgnoreCase(reservationInfo.getReservation_code())) {
						reservationId = reservationInfo.getReservation_id();
						if (StringUtils.isNotBlank(reservationInfo.getMt_calling_id())) {
							isOnline = "1";
							mtCallingId = reservationInfo.getMt_calling_id();
							break;
						}

						break;
					}

				}
				info = new ExaminationInfo(model.getExamination_date(), model.getExaminationTimeFrm(),
						model.getDepartment_name(), model.getPatient_name(), model.getPatient_code(),
						model.getPatient_name_kana(), model.getRecept_time(), isOnline, "waiting", mtCallingId,
						model.getReservation_code(), reservationId,false);

				listInsuranceHistory.add(info);
			}
		}
		String connections = phrApiService.getAllConnectionFromPeer();
		String patientCode = MssContextHolder.getPatientCode();
		String hosp_Code = MssContextHolder.getHospCode();
		Object token = session.getAttribute("phr_token");
		String  phrDeviceToken = (token == null) ? "" : phrApiService.getPhrDeviceToken(patientCode, hosp_Code, token.toString());
		listInsuranceHistory.stream().map(v -> {
				if(!connections.contains(v.getMtCallingId()))
				{
					v.setIsOnline("0");
				}
			    if(v.getPatientCode().equals(patientCode) && !StringUtils.isEmpty(phrDeviceToken))
				v.setHasTokenDevice(true);
			return v;
			})
		.collect(Collectors.toList());
	    MssContextHolder.setPhrDeviceToken(phrDeviceToken);
		DataTableJsonObject<ExaminationInfo> reservationJsonObject = new DataTableJsonObject<>();
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
		String patientCode = MssContextHolder.getPatientCode();
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

	@RequestMapping(value = "/get-mtcalling-id-mt", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String getMtCallingId(@RequestParam String reservationId) {
		LOG.info("[Start] Get reservation Id.");
		String mtCallingId = this.reservationService.getMtCallingIdByReservationId(new Integer(reservationId));

		GsonBuilder builder = new GsonBuilder();
		builder.serializeNulls();
		Gson gson = builder.create();
		String jsonOBJ = gson.toJson(mtCallingId);

		return jsonOBJ;
	}

	@RequestMapping(value = "/delete-movietalk/{id}", method = RequestMethod.PUT)
	@ResponseBody
	public Integer deleteSmartphone(@PathVariable Integer id, HttpServletRequest request) {
		Integer result = this.movieTalkService.deleteRecordMovieTalkHistoryById(id);
		return result;
	}

	@RequestMapping(value = "/send-noti-to-phr", method = RequestMethod.POST, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody
	public AjaxResponse sendNotiToPhr(@RequestBody Map<String, String> response) throws Exception {
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();
		String hospitalName = MssContextHolder.getHospitalName();
		response.put("hospital_name", hospitalName);
		GsonBuilder builder = new GsonBuilder();
		builder.serializeNulls();
		Gson gson = builder.create();
		String message = gson.toJson(response);
		sendNoti(message, "Receive calling from doctor", MssContextHolder.getPhrDeviceToken(),response);
		responseBuilder.status(HttpStatus.OK);
		responseBuilder.message("Get data for notify to patient");
		responseBuilder.data(null);
		return responseBuilder.build();
	}

	private void sendNoti(String message, String noti, String tokenId , Map<String, String> response) throws Exception {
		ApnsService service = null;
		String payload = null;
		File file = null;
		String certFullPath = MssConfiguration.getInstance().getCertPhrFullPath();
		int badgeCount = 1;
		file = new File(certFullPath);
		if (!file.exists()) {
			System.out.println("File not exists");
			LOG.info("Send notification to PHR : File not exists");
			
			
			
		} else {
			//service = APNS.newService().withCert(certFullPath, "").withSandboxDestination().build(); With UAT
			service = APNS.newService().withCert(certFullPath, "").withProductionDestination().build(); //Building for production enviroment
			payload = APNS.newPayload().badge(badgeCount).alertBody(message).localizedKey(noti).localizedArguments(response.get("doctor_name").toString(),MssContextHolder.getHospitalName()).toString();
			service.push(tokenId, payload);
			LOG.info("Send notification to PHR : Send successfully");
		}

	}

}

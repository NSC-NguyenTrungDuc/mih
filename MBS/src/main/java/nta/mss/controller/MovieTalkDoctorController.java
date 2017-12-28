package nta.mss.controller;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.restfb.types.Message;
import com.restfb.types.Notification;
import nta.kcck.model.MessageResponse;
import nta.kcck.service.impl.KcckDoctorService;
import nta.mss.entity.DataTableJsonObject;
import nta.mss.entity.ExaminationInfo;
import nta.mss.entity.MtHistory;
import nta.mss.entity.Patient;
import nta.mss.info.PatientProfileInfo;
import nta.mss.info.ReservationInfo;
import nta.mss.info.ReservationOnlineInfo;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.enums.SessionMode;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.MtHistoryModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.PatientModel;
import nta.mss.model.PatientWaitingModel;
import nta.mss.repository.MovieTalkRepository;
import nta.mss.service.IBookingService;
import nta.mss.service.IMovieTalkService;
import nta.mss.service.IPatientService;
import nta.mss.service.IReservationService;
import nta.mss.service.impl.PatientService;

/**
 * The Class MovieTalkDoctorController.
 * 
 * @author phamconghoan
 * @CrtDate Sep 1, 2016
 */
/**
 * @author hoanpc
 *
 */
@Controller
@Scope("prototype")
@RequestMapping("doctor/movie-talk")
@NavigationConfig(leftMenuType = NavigationType.DOCTOR_VIEW_MENU)
public class MovieTalkDoctorController extends BaseController {

	/** The Constant LOG. */
	private static final Logger LOG = LogManager.getLogger(MovieTalkDoctorController.class);

	/** The Constant DEFAULT_RESERVATIONS_DISPLAY. */
	public static final Integer DEFAULT_RESERVATIONS_DISPLAY = 10;
	
	@Resource
	private IMovieTalkService movieTalkService;
	
	@Resource
	private IReservationService reservationService;
	
	@Resource
	private IBookingService bookingService;
	
	private IPatientService patientService;
	
	//@Resource
	//private IKcckDoctorService KcckDoctorService;
	KcckDoctorService kcckDoctorService = new KcckDoctorService();

	public MovieTalkDoctorController() {}
	
	@RequestMapping("/index")
	@NavigationConfig(group = {NavigationGroup.MOVIES_TALK })
	public ModelAndView profileInfo(ModelMap model) {
		LOG.info("[Start] View doctor movie talk screen.");
		MssContextHolder.setSessionMode(SessionMode.FRONT_MODE.toInt());
		return new ModelAndView("doctor.movieTalk.waitingList");
	}

	/**
     * Method getPatientByPatientCode
     */
	@RequestMapping(value = "/get-patient-by-patient-code", method = RequestMethod.GET, produces={"application/json; charset=UTF-8"})
	public @ResponseBody String getPatientByPatientCode(@RequestParam String patientCode) {
		LOG.info("[Start] View get Patient By Patient Code."); 
		Integer hospitalId = MssContextHolder.getHospitalId();
//		Integer hospitalIdOfpatient = MssContextHolder.currentSessionContext().getHospitalId();
		
		PatientModel patientModel = this.bookingService.findKcckPatientByCardNumber(patientCode, hospitalId);
		if(patientModel != null) {
			try {
				PatientProfileInfo patientInfo = new PatientProfileInfo();
				patientInfo.setName(patientModel.getName());
				patientInfo.setNameFurigana(patientModel.getNameFurigana());
				patientInfo.setPhoneNumber(patientModel.getPhoneNumber());
				patientInfo.setGender(patientModel.getGender());
				patientInfo.setCardNumber(patientModel.getCardNumber());
				patientInfo.setBirthDate(patientModel.getBirthDay());
				patientInfo.setAge(patientInfo.getAge());
				
				GsonBuilder builder = new GsonBuilder();
		        builder.serializeNulls();
		        Gson gson = builder.create();
				String jsonOBJ = gson.toJson(patientInfo);
				return jsonOBJ;
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
		
		return null;
	}
		
	
	@RequestMapping(value = "/uploadvideo", method = RequestMethod.GET, produces={"application/json; charset=UTF-8"})
	public @ResponseBody String uploadvideo(String doctorCode,String duration,String patientCode,String videoUrl,String reservationDate,String reservationTime,String reservationId, String reservationCode) {
		LOG.info("[Start] View upload Video."); 
		Integer hospitalId = MssContextHolder.getHospitalId();
		MtHistoryModel mt_history = new MtHistoryModel();
			PatientModel patientModel = this.bookingService.findKcckPatientByCardNumber(patientCode, hospitalId);			
			List<ReservationOnlineInfo> reservationInfos = 
					this.reservationService.findReservationInfoByReCodeHosId(hospitalId, Arrays.asList(reservationCode));
			if(patientModel!=null && !CollectionUtils.isEmpty(reservationInfos))
			{
				mt_history.setHospitalId(hospitalId);
				mt_history.setPatientId(patientModel.getPatientId());
				//TODO: insert with doctor id form kcck
				mt_history.setDoctorId(1);
				mt_history.setActiveFlag(1);
							
				mt_history.setReservationDate(reservationDate.replace("/",""));
				mt_history.setReservationTime(reservationTime);
				mt_history.setReservationId(reservationInfos.get(0).getReservation_id());
				mt_history.setMtHistoryUrl(videoUrl);
				mt_history.setDuration(duration);
			}
			
			
			if(movieTalkService.insertRecordMovieTalkHistoryById(mt_history))
			{
				GsonBuilder builder = new GsonBuilder();
		        builder.serializeNulls();
		        Gson gson = builder.create();
		        String jsonOBJ = gson.toJson(nta.helper.Message.SUCCESS.getValue());				
				return jsonOBJ;
			}
		
			return null;
	
	}
	

 
}

package nta.mss.controller;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.validation.Valid;

import nta.mss.info.AjaxResponse;
import nta.mss.info.VaccineInfo;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.info.VaccineReportAjaxRequest;
import nta.mss.info.VaccineReportInfo;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.common.MssFileUtils;
import nta.mss.misc.enums.ActiveFlag;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.DepartmentType;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.DepartmentModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.SysUserModel;
import nta.mss.model.VaccineChildHistoryModel;
import nta.mss.model.VaccineHospitalModel;
import nta.mss.model.VaccineModel;
import nta.mss.security.WebSysUserDetails;
import nta.mss.security.WebUserDetails;
import nta.mss.service.IDepartmentService;
import nta.mss.service.IVaccineChildHistoryService;
import nta.mss.service.IVaccineHospitalService;
import nta.mss.service.IVaccineService;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.io.IOUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

/**
 * The Class ScheduleController.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
@NavigationConfig(leftMenuType = NavigationType.BACK_LEFT_MENU)
@Controller
@Scope("prototype")
@RequestMapping(value = "/vaccine")
public class VaccineController extends BaseController {
	private static final Logger LOG = LogManager.getLogger(VaccineController.class);
	private IVaccineService vaccineService;
	private IDepartmentService departmentService;
	private IVaccineHospitalService vaccineHospitalService;
	private IVaccineChildHistoryService vaccineChildHistoryService;
	
    public VaccineController() {
    	
    }
    
    /**
     * Gets the sys user name.
     *
     * @return the sys user name
     */
    public SysUserModel getSysUser() {
    	if(SecurityContextHolder.getContext().getAuthentication()!=null){
    	Object principal =  (WebSysUserDetails) SecurityContextHolder.getContext().getAuthentication().getPrincipal();
    	if (principal instanceof WebSysUserDetails) {
			return ((WebSysUserDetails) principal).getSysUser();
		}
    	}
		return null;
    }
    	

    /**
	 * Instantiates a new schedule controller.
	 * 
	 * @param doctorService
	 *            the doctor service
	 * @param scheduleService
	 *            the schedule service
	 * @param hospitalService
	 *            the hospital service
	 * @param departmentService
	 *            the department service
	 */
	@Autowired
	public VaccineController(IVaccineService vaccineService, IDepartmentService departmentService, IVaccineHospitalService vaccineHospitalService, IVaccineChildHistoryService vaccineChildHistoryService) {
		this.vaccineService = vaccineService;
		this.departmentService = departmentService;
		this.vaccineHospitalService = vaccineHospitalService;
		this.vaccineChildHistoryService = vaccineChildHistoryService;
	}
	
	/**
	 * View schedule remove coma.
	 * 
	 * @param deptId
	 *            the dept id
	 * @param model
	 *            the model
	 * @return the model and view
	 * @throws Exception 
	 */
	@NavigationConfig(group = {NavigationGroup.VACCINE_MANAGEMENT, NavigationGroup.VACCINE_REPORT})
	@RequestMapping(value = "/vaccine-report", method = RequestMethod.GET)
	public ModelAndView viewScheduleDeleteComa(ModelMap model) throws Exception {
		// Get hospital code from login user
		String hospitalCode = this.getSysUser().getHospitalCode();
		List<VaccineModel> defaultVaccineList = this.vaccineService.findVaccineByHospitalCode(hospitalCode);
		// get the vaccine department
		DepartmentModel deptModel = this.departmentService.findDeptByType(MssContextHolder.getHospCode(), DepartmentType.VACCINE.toInt());
		if (deptModel != null) {
			model.addAttribute("deptId", deptModel.getDeptId());
		}
		model.addAttribute("vaccineList", defaultVaccineList);
		MssContextHolder.currentSessionContext().setVaccineList(defaultVaccineList);
		return new ModelAndView("back.vaccine.report");
	}
	
	/**
	 * Ajax generate vaccine report.
	 *
	 * @param vaccineReportAjaxRequest the vaccine report ajax request
	 * @return the ajax response
	 */
	@RequestMapping(value = "/ajax-vaccine-report", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxGenerateVaccineReport(@RequestBody VaccineReportAjaxRequest vaccineReportAjaxRequest) {
		LOG.info("[Start] Generate vaccine report");
		// Get hospital code from login user
		String hospitalCode = this.getSysUser().getHospitalCode();
		
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		String fromDate = vaccineReportAjaxRequest.getFromDate();
		String toDate = vaccineReportAjaxRequest.getToDate();
		List<String> dateList = MssDateTimeUtil.getDateBetween(fromDate, toDate);
		List<VaccineModel> vaccineModelList = vaccineReportAjaxRequest.getVaccineModelList();
		Map<VaccineReportInfo, VaccineReportInfo> vaccineReportMap = 
				this.vaccineService.getVaccineReportMap(
						MssDateTimeUtil.dateFromString(fromDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD), 
						MssDateTimeUtil.dateFromString(toDate, DateTimeFormat.DATE_FORMAT_YYYYMMDD), 
						hospitalCode);
		Map<String, List<VaccineReportInfo>> data = getVaccineReport(vaccineReportMap, dateList, vaccineModelList);
		
		MssContextHolder.currentSessionContext().setVaccineReport(data);
		// TODO: optimize code
		List<VaccineModel> defaultVaccineList = MssContextHolder.currentSessionContext().getVaccineList();
		List<VaccineModel> newVaccineList = new ArrayList<VaccineModel>();
		for (VaccineModel vaccine : vaccineModelList) {
			for (VaccineModel defaultVaccine : defaultVaccineList) {
				if (vaccine.getVaccineId().equals(defaultVaccine.getVaccineId())) {
					newVaccineList.add(defaultVaccine);
					break;
				}
			}
		}
		MssContextHolder.currentSessionContext().setVaccineList(newVaccineList);
		
		builder.status(HttpStatus.OK).data(data);
		LOG.info("[End] Generate vaccine report");
		return builder.build();
	}
	
	/**
	 * Gets the vaccine report.
	 *
	 * @param vaccineReportMap the vaccine report map
	 * @param dateList the date list
	 * @param vaccineModelList the vaccine model list
	 * @return the vaccine report
	 */
	private Map<String, List<VaccineReportInfo>> getVaccineReport (Map<VaccineReportInfo, VaccineReportInfo> vaccineReportMap, List<String> dateList, List<VaccineModel> vaccineModelList) {
		Map<String, List<VaccineReportInfo>> allVaccineReportMap = new LinkedHashMap<String, List<VaccineReportInfo>>();
		VaccineReportInfo vaccineReportInfo;
		for (String date : dateList) {
			for (VaccineModel vaccine : vaccineModelList) {
				vaccineReportInfo = new VaccineReportInfo(vaccine.getVaccineId(), date, BigDecimal.ZERO, BigInteger.ZERO);
				if(vaccineReportMap.containsKey(vaccineReportInfo)) {
					vaccineReportInfo = vaccineReportMap.get(vaccineReportInfo);
				}
				if(!allVaccineReportMap.containsKey(date)){
					allVaccineReportMap.put(date, new LinkedList<VaccineReportInfo>());
				}
				allVaccineReportMap.get(date).add(vaccineReportInfo);
			}
		}
		return allVaccineReportMap;
	}
	
	/**
	 * Export vaccine report.
	 *
	 * @param response the response
	 */
	@NavigationConfig(group = {NavigationGroup.VACCINE_MANAGEMENT, NavigationGroup.VACCINE_REPORT})
	@RequestMapping(value = "export-vaccine-report-csv", method = RequestMethod.GET) 
	public void exportVaccineReport(HttpServletResponse response) {
		LOG.info("[Start] Export vaccine report");
		InputStream inputStream = null;
		try {
			Map<String, List<VaccineReportInfo>> vaccineReport = MssContextHolder.currentSessionContext().getVaccineReport();
			List<VaccineModel> vaccineList = MssContextHolder.currentSessionContext().getVaccineList();
			if (vaccineReport != null && vaccineList != null) {
				String destDir = MssConfiguration.getInstance().getDirFileUpload();
				String fileName = URLEncoder.encode(this.getText("be203.export.csv.vaccine") + ".csv",  "UTF-8").replace("+", "%20");
				File file = generateFileVaccineReportList(vaccineList, vaccineReport, destDir, fileName);
				if (file == null) {
					return;
				}
				// Download
				inputStream = new FileInputStream(file);
				response.setContentType("application/force-download; charset=UTF-8");
				response.setCharacterEncoding("UTF-8");
				response.setHeader("Content-Disposition",
						"attachment; filename*=UTF-8''"+ fileName);
				IOUtils.copy(inputStream, response.getOutputStream());
				response.flushBuffer();
			}
		} catch (Exception e) {
			LOG.error("Exception: " + e.getMessage());
		} finally {
			if (inputStream != null) {
				try {
					inputStream.close();
				} catch (IOException e) {
					LOG.error(" Cannot close the input stream: " + e.getMessage());
				}
			}
		}
		LOG.info("[Start] Export vaccine report");
	}
	
	/**
	 * Generate file vaccine report list.
	 *
	 * @param vaccineList the vaccine list
	 * @param vaccineMap the vaccine map
	 * @param destDir the dest dir
	 * @param fileName the file name
	 * @return the file
	 */
	private File generateFileVaccineReportList(List<VaccineModel> vaccineList, Map<String, List<VaccineReportInfo>> vaccineMap, String destDir, String fileName) {
		StringBuilder data = new StringBuilder(""); 
		if (vaccineMap != null && !vaccineMap.isEmpty() && vaccineList != null && !vaccineList.isEmpty()) {
			// header
			data.append(this.getText("be203.table.label.date")).append(",");
			for (VaccineModel vaccineModel : vaccineList) {
				data.append(vaccineModel.getVaccineName()).append(",");
			}
			data.append("\n");
			// content
			for (Map.Entry<String, List<VaccineReportInfo>> entry : vaccineMap.entrySet())
			{
				data.append(entry.getKey()).append(",");
				for (VaccineReportInfo vaccineInfo : entry.getValue()) {
					if (vaccineInfo.getTotal() == null || BigInteger.ZERO.equals(vaccineInfo.getTotal())) {
						data.append(StringUtils.EMPTY).append(",");
					}
					else {
						data.append(vaccineInfo.getTotal());
						if (vaccineInfo.getNumberOfFinished() == null || BigInteger.ZERO.equals(vaccineInfo.getNumberOfFinished())) {
							data.append(StringUtils.EMPTY).append(",");
						}
						else {
							data.append("(").append(vaccineInfo.getNumberOfFinished()).append(")").append(",");
						}
					}
				}
				data.append("\n");
			}
		}
		return MssFileUtils.saveFile(destDir, fileName, data.toString());
	}
	
	/**
	 * vaccine management
	 *
	 * @param vaccineHospitalModel the vaccine hospital model
	 * @param model the model
	 * @return the model and view
	 * @throws Exception the exception
	 */
	@NavigationConfig(group = {NavigationGroup.VACCINE_MANAGEMENT, NavigationGroup.VACCINE_LIST})
	@RequestMapping(value = "/vaccine-management", method = {RequestMethod.GET})
	public ModelAndView vaccineManagement(@RequestParam(value = "vaccineHospitalId", required = false) Integer vaccineHospitalId, ModelMap model) throws Exception {
		LOG.info("[Start] Vaccine management.");
		model.addAttribute("vaccineModels", createMapVaccine());
		VaccineHospitalModel vaccineHospitalModel = new VaccineHospitalModel();
		if (vaccineHospitalId == null) {
			model.addAttribute("isUpdate", false);
		} else {
			vaccineHospitalModel = this.vaccineHospitalService.findById(vaccineHospitalId);
			if (vaccineHospitalModel.getFromDate() != null) {
				vaccineHospitalModel.setStrFromDate(MssDateTimeUtil.convertTimestampToString(vaccineHospitalModel.getFromDate(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
			}
			if (vaccineHospitalModel.getToDate() != null) {
				vaccineHospitalModel.setStrToDate(MssDateTimeUtil.convertTimestampToString(vaccineHospitalModel.getToDate(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
			}
			
			model.addAttribute("isUpdate", true);
		}
		
		LOG.info("[End] Vaccine management.");
		return new ModelAndView("back.vaccine.management", "vaccineHospital", vaccineHospitalModel);
	}
	
	private Map<Integer, String> createMapVaccine() throws Exception {
		Map<Integer, String> mapVaccine = new LinkedHashMap<Integer, String>();
		//List<VaccineModel> lstVaccineModel = this.vaccineService.findVaccineByActiveFlg(ActiveFlag.ACTIVE.toInt());
		List<VaccineInfo> vaccineInfoList = this.vaccineService.getVaccineInfoList(MssContextHolder.getHospitalId().toString(), MssContextHolder.getUserLanguage());
		if (CollectionUtils.isNotEmpty(vaccineInfoList)) {
			for (VaccineInfo vaccine : vaccineInfoList) {
				mapVaccine.put(vaccine.getVaccineId(), vaccine.getVaccineName());
			}
		}
		return mapVaccine;
	}
	
	/**
	 * Ajax init vaccine hospital list.
	 *
	 * @param vaccineHospitalModel the vaccine hospital model
	 * @param session the session
	 * @return the ajax response
	 * @throws Exception the exception
	 */
	@NavigationConfig(group = {NavigationGroup.VACCINE_MANAGEMENT, NavigationGroup.VACCINE_LIST})
	@RequestMapping(value = "/ajax-init-vaccine-hospital-schedule-list", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxInitVaccineHospitalList(@ModelAttribute("vaccineHospital") VaccineHospitalModel vaccineHospitalModel, HttpSession session) throws Exception {
		LOG.info("[Start] Ajax init vaccine hospital list.");
		List<VaccineHospitalModel> lsVaccineHospitalModel = this.vaccineHospitalService.getVaccineHospital(MssContextHolder.getHospitalId());
		
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.status(HttpStatus.OK).data(lsVaccineHospitalModel);
		
		LOG.info("[End] Ajax init vaccine hospital list.");
		return builder.build();
	}
	
	/**
	 * Adds the vaccine hospital.
	 *
	 * @param vaccineHospitalModel the vaccine hospital model
	 * @param result the result
	 * @param model the model
	 * @return the model and view
	 * @throws Exception the exception
	 */
	@NavigationConfig(group = {NavigationGroup.VACCINE_MANAGEMENT, NavigationGroup.VACCINE_LIST})
	@RequestMapping(value = "/vaccine-management", method = {RequestMethod.POST})
	public ModelAndView addVaccineHospital(@Valid @ModelAttribute("vaccineHospital") VaccineHospitalModel vaccineHospitalModel, BindingResult result, ModelMap model) throws Exception {
		LOG.info("[Start] Adds the vaccine hospital.");
		Integer hospitalId = this.getSysUser().getHospitalId();
		// Check duplicate
		if (this.vaccineHospitalService.findByHospitalIdVaccineId(hospitalId, vaccineHospitalModel.getVaccineId()) != null) {
			result.rejectValue("vaccineId", "be201.msg.add.duplicate.vaccineId");
		}
		if (result.hasErrors()) {
			ModelAndView modelAndView = new ModelAndView("back.vaccine.management", "vaccineHospital", vaccineHospitalModel);
			model.addAttribute("isUpdate", false);
			model.addAttribute("vaccineModels", createMapVaccine());
			return modelAndView; 
		}
		
		vaccineHospitalModel.setHospitalId(this.getSysUser().getHospitalId());
		if (StringUtils.isNotBlank(vaccineHospitalModel.getStrFromDate())) {
			vaccineHospitalModel.setFromDate(MssDateTimeUtil.convertStringToTimestamp(vaccineHospitalModel.getStrFromDate(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		}
		if (StringUtils.isNotBlank(vaccineHospitalModel.getStrToDate())) {
			vaccineHospitalModel.setToDate(MssDateTimeUtil.convertStringToTimestamp(vaccineHospitalModel.getStrToDate(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		}
		this.vaccineHospitalService.saveVaccineHospital(vaccineHospitalModel);
		this.addNotification(new NotificationModel(NotificationType.SUCCESS, this.getText("general.msg.add.new.success")));
		LOG.info("[End] Adds the vaccine hospital.");
		return new ModelAndView(new RedirectView("vaccine-management"));
	}
	
	/**
	 * Edits the vaccine hospital.
	 *
	 * @param vaccineHospitalModel the vaccine hospital model
	 * @param result the result
	 * @param model the model
	 * @return the model and view
	 * @throws Exception the exception
	 */
	@NavigationConfig(group = {NavigationGroup.VACCINE_MANAGEMENT, NavigationGroup.VACCINE_LIST})
	@RequestMapping(value = "/edit-vaccine-management", method = {RequestMethod.POST})
	public ModelAndView editVaccineHospital(@Valid @ModelAttribute("vaccineHospital") VaccineHospitalModel vaccineHospitalModel, BindingResult result, ModelMap model) throws Exception {
		LOG.info("[Start] Edit the vaccine hospital.");
		if (result.hasErrors()) {
			ModelAndView modelAndView = new ModelAndView("back.vaccine.management", "vaccineHospital", vaccineHospitalModel);
			model.addAttribute("isUpdate", false);
			model.addAttribute("vaccineModels", createMapVaccine());
			return modelAndView; 
		}
		
		if (StringUtils.isNotBlank(vaccineHospitalModel.getStrFromDate())) {
			vaccineHospitalModel.setFromDate(MssDateTimeUtil.convertStringToTimestamp(vaccineHospitalModel.getStrFromDate(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		}
		if (StringUtils.isNotBlank(vaccineHospitalModel.getStrToDate())) {
			vaccineHospitalModel.setToDate(MssDateTimeUtil.convertStringToTimestamp(vaccineHospitalModel.getStrToDate(), DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND));
		}
		this.vaccineHospitalService.saveVaccineHospital(vaccineHospitalModel);
		this.addNotification(new NotificationModel(NotificationType.SUCCESS, this.getText("general.msg.update.success")));
		LOG.info("[End] Edit the vaccine hospital.");
		return new ModelAndView(new RedirectView("vaccine-management"));
	}
	
	/**
	 * Ajax delete vaccine hospital.
	 *
	 * @param vaccineHospitalModel the vaccine hospital model
	 * @return the ajax response
	 * @throws Exception the exception
	 */
	@NavigationConfig(group = {NavigationGroup.VACCINE_MANAGEMENT, NavigationGroup.VACCINE_LIST})
	@RequestMapping(value = "/ajax-delete-vaccineHospital", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxDeleteVaccineHospital(@RequestBody VaccineHospitalModel vaccineHospitalModel) throws Exception {
		LOG.info("[Start] Ajax delete vaccine hospital.");
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();
		Integer vaccinceHospitalId = vaccineHospitalModel.getVaccineHospitalId();
		if (vaccinceHospitalId == null) {
			responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be201.msg.delete.error"));
			return responseBuilder.build();
		}
		VaccineHospitalModel vaccineHospitalModel2 = this.vaccineHospitalService.findById(vaccinceHospitalId);
		if (vaccineHospitalModel2 == null) {
			responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be201.msg.delete.error"));
			return responseBuilder.build();
		}
		
		// Check: if exist booking with this vaccine
		List<VaccineChildHistoryModel> lstVaccineChildHistoryModel = this.vaccineChildHistoryService.findByVaccineId(vaccineHospitalModel2.getVaccineId());
		if (CollectionUtils.isNotEmpty(lstVaccineChildHistoryModel)) {
			responseBuilder.status(HttpStatus.INTERNAL_SERVER_ERROR).message(this.getText("be201.msg.error.vaccine.exist.booking"));
			return responseBuilder.build();
		}
		
		this.vaccineHospitalService.deleteVaccineHospital(vaccineHospitalModel2);
		responseBuilder.status(HttpStatus.OK).message(this.getText("be201.msg.delete.success")).data("vaccine-management");
		LOG.info("[End] Ajax delete vaccine hospital.");
		return responseBuilder.build();
	}
	
}

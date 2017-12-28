package nta.mss.controller;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;

import javax.servlet.http.HttpServletRequest;
import javax.validation.Valid;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.util.StringUtils;
import org.springframework.validation.BindingResult;
import org.springframework.validation.Errors;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.NotificationType;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.HospitalModel;
import nta.mss.model.NotificationModel;
import nta.mss.model.SysUserModel;
import nta.mss.security.WebSysUserDetails;
import nta.mss.service.IHospitalService;

/**
 * The Class MailController.
 * 
 * @author DinhNX
 * @CrtDate Jul 21, 2014
 */
@NavigationConfig(leftMenuType = NavigationType.BACK_LEFT_MENU)
@Controller
@Scope("prototype")
@RequestMapping(value = "/hospital")
public class HospitalController extends BaseController {

	private static final Logger LOG = LogManager.getLogger(HospitalController.class);

	private IHospitalService hospitalService;

	public HospitalController() {
		super();
	}

	@Autowired
	public HospitalController(IHospitalService hospitalService) {
		this.hospitalService = hospitalService;
	}

	/**
	 * Gets the sys user.
	 *
	 * @return the sys user
	 */
	public SysUserModel getSysUser() {
		if (SecurityContextHolder.getContext().getAuthentication() != null) {
			Object principal = (WebSysUserDetails) SecurityContextHolder.getContext().getAuthentication()
					.getPrincipal();
			if (principal instanceof WebSysUserDetails) {
				return ((WebSysUserDetails) principal).getSysUser();
			}
		}
		return null;
	}

	@NavigationConfig(group = { NavigationGroup.HOSPITAL_MANAGEMENT })
	@RequestMapping(value = "/hospital-manage-detail")
	public ModelAndView viewHospitalDetail(ModelMap model) {
		LOG.info("[Start] View hospital detail.");
		HospitalModel hospitalModel = new HospitalModel();
		Integer hospitalId = MssContextHolder.getHospitalId();
		if (hospitalId != null) {
			hospitalModel = this.hospitalService.findHospital(hospitalId);
		}
		model.addAttribute("hospitalModel", hospitalModel);
		LOG.info("[End] View hospital detail.");
		return new ModelAndView("back.hospital.detail");

	}

	@NavigationConfig(group = { NavigationGroup.HOSPITAL_MANAGEMENT })
	@RequestMapping(value = "/hospital-manage-detail", method = RequestMethod.POST, params = { "validate" })
	public ModelAndView saveHospitalDetail(@Valid @ModelAttribute("hospitalModel") HospitalModel hospitalModel,
			BindingResult result, ModelMap model, HttpServletRequest request) {
		LOG.info("[Start] Save hospital.");
		ModelAndView modelAndView = new ModelAndView("back.hospital.detail");
		try {
			MultipartFile file = hospitalModel.getFile();
			// valid file
			if (!file.isEmpty()) {
				validate(file, result);
				if (result.hasErrors()) {
					return modelAndView;
				}
				// upload
				String name = file.getOriginalFilename();
				String rootPath = MssConfiguration.getInstance().getDirImageFileUpload()
						+ MssContextHolder.getHospCode() + File.separator;
				String hospitalIconPath = MssConfiguration.getInstance().getHospitalLogo()
						+ MssContextHolder.getHospCode() + File.separator + name;
				hospitalModel.setHospitalIconPath(hospitalIconPath);
				if (!uploadFile(file, rootPath, name)) {
					result.reject("be202.msg.upload.fail");
					return modelAndView;
				}
			}
			if (result.hasErrors()) {
				return modelAndView;
			}

			model.addAttribute("validation", true);
			LOG.info("[Start] Save hospital.");
			return modelAndView;
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
		}
		return modelAndView;
	}

	@NavigationConfig(group = { NavigationGroup.HOSPITAL_MANAGEMENT })
	@RequestMapping(value = "/hospital-manage-detail", method = RequestMethod.POST)
	public ModelAndView saveHospitalDetailConfirm(@Valid @ModelAttribute("hospitalModel") HospitalModel hospitalModel,
			BindingResult result, ModelMap model, HttpServletRequest request) {
		LOG.info("[Start] Save hospital confirm.");
		Integer rowUpdated = this.hospitalService.updateHospital(hospitalModel);
		if (rowUpdated != null && rowUpdated > 0) {
			MssContextHolder.setHospitalIconPath(hospitalModel.getHospitalIconPath());
			MssContextHolder.setHospitalName(hospitalModel.getHospitalName());
			MssContextHolder.setHospitalEmail(hospitalModel.getEmail());
			this.addNotification(
					new NotificationModel(NotificationType.SUCCESS, this.getText("be202.msg.update.success")));
		} else {
			this.addNotification(new NotificationModel(NotificationType.ERROR, this.getText("be202.msg.update.fail")));
		}
		LOG.info("[End] Save hospital confirm.");
		return new ModelAndView(new RedirectView("hospital-manage-detail"));
	}

	private void validate(Object target, Errors errors) {
		try {
			MultipartFile multipartFile = (MultipartFile) target;

			// empty uploads
			if (multipartFile.isEmpty()) {
				LOG.debug("Rejecting empty file content: " + multipartFile.getOriginalFilename());
				errors.reject("EmptyContent.file", new String[] { multipartFile.getOriginalFilename() }, "");
				return;
			}

			// empty file names
			if (StringUtils.isEmpty(multipartFile.getOriginalFilename())) {
				LOG.debug("Rejecting empty file name.");
				errors.reject("EmptyName.file");
				return;
			}

			Long maxSize = MssConfiguration.getInstance().getMaxSizeImgFile();
			if (maxSize != null && multipartFile.getSize() > maxSize) {
				if (LOG.isDebugEnabled()) {
					LOG.debug("Rejecting file, file size to big: " + multipartFile.getSize());
					LOG.debug("Maximum file size is: " + maxSize);
				}
				errors.reject("be202.maxsize.file");
			}
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
		}
	}

	private boolean uploadFile(MultipartFile file, String rootPath, String name) {
		LOG.info("[Start] uploadFile");
		String path = rootPath + name;
		try {
			byte[] bytes = file.getBytes();

			// Creating the directory to store file
			File dir = new File(rootPath);
			if (!dir.exists()) {
				if (!dir.mkdirs()) {
					LOG.error("Upload file: cannot create directory at: " + rootPath);
					return false;
				}
			}

			// Create the file on server
			File serverFile = new File(path);
			BufferedOutputStream stream = new BufferedOutputStream(new FileOutputStream(serverFile));
			stream.write(bytes);
			stream.close();
			LOG.info("Server File Location=" + serverFile.getAbsolutePath());
			LOG.info("You successfully uploaded file=" + path);
			return true;
		} catch (Exception e) {
			LOG.error(" You failed to upload " + path + " => " + e.getMessage(), e);
			return false;
		} finally {
			LOG.info("[End] uploadFile");
		}
	}
}

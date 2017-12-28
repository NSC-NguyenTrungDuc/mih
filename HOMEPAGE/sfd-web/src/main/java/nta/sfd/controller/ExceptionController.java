package nta.sfd.controller;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.servlet.ModelAndView;

/**
 * Exception handler for all method has annotation {@link org.springframework.web.bind.annotation.RequestMapping}
 *
 * @author DinhNX
 * @CrtDate Aug 15, 2014
 *
 */
@ControllerAdvice
public class ExceptionController extends BaseController {
	private static final Logger LOG = LogManager.getLogger(ExceptionController.class);
	
	/**
	 * Handle exception.
	 *
	 * @param exception the exception
	 * @return the model and view
	 */
	@ExceptionHandler(Exception.class)
	public ModelAndView handleException(Exception exception) {
		LOG.error(exception.getMessage(), exception);
		return new ModelAndView("error");
	}
}

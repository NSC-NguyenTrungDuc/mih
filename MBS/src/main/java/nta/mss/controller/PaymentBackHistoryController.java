package nta.mss.controller;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;
import javax.servlet.http.HttpSession;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import nta.kcck.model.KcckUpdatePaymentStatusModel;
import nta.mss.info.AjaxResponse;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.SessionValidate;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.OrderMedicineModel;
import nta.mss.model.PaymentHistoriesModel;
import nta.mss.model.PaymentInfoModel;
import nta.mss.model.PaymentModel;
import nta.mss.model.SearchPaymentTransaction;
import nta.mss.service.IPaymentHistoryService;
import nta.mss.service.IUserService;

@Controller
@Scope("prototype")
@RequestMapping("back/payment-history")
@NavigationConfig(leftMenuType = NavigationType.BACK_LEFT_MENU)
public class PaymentBackHistoryController {
	private static final Logger LOG = LogManager.getLogger(PaymentBackHistoryController.class);	
	@Resource
	private IPaymentHistoryService paymentHistoryService;
	@Resource
	private IUserService userService;
	
	@RequestMapping("/index")
	@NavigationConfig(group = { NavigationGroup.BACK_PAYMENT_HISTORY })
	public ModelAndView Index() {
		LOG.info("[Start] View payment history.");
		return new ModelAndView("back.payment.history.index");
	}
	
	@NavigationConfig(group = {NavigationGroup.BACK_PAYMENT_HISTORY})
	@RequestMapping(value = "/ajax-init-payment-history", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxPaymentHistoryList( HttpSession session, @RequestBody Map<String,String> request) throws Exception {
		LOG.info("[Start] Ajax payment history list.");
		String orderField = request.get("orderField");
		String orderValue = request.get("orderValue");
		String sort_col_name = orderField+"|"+orderValue;
		String paymentFromDate = request.get("paymentFromDate");
		String paymentToDate = request.get("paymentToDate");
		String invoiceNo = request.get("invoiceNo");
		String examFromDate = request.get("examFromDate");
		String examToDate = request.get("examToDate");
		String transactionId = request.get("transactionId");
		String amountFrom = request.get("amountFrom");
		String amountTo = request.get("amountTo");
		String paymentStatus = request.get("paymentStatus");
		String patientCode = request.get("patientCode");
		String pageIndex = request.get("pageIndex");
		String pageSize = request.get("pageSize");
		SearchPaymentTransaction searchPaymentTransaction = new SearchPaymentTransaction(paymentFromDate, paymentToDate, 
				invoiceNo, examFromDate,examToDate,transactionId,amountFrom,amountTo,paymentStatus,
				patientCode, pageIndex,pageSize,sort_col_name,MssContextHolder.getHospCode());
		PaymentHistoriesModel paymentHistoryModel = paymentHistoryService.getPaymentHistory(searchPaymentTransaction);
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.status(HttpStatus.OK).data(paymentHistoryModel);		
		LOG.info("[End] Ajax init vaccine hospital list.");
		return builder.build();
	}
	@NavigationConfig(group = {NavigationGroup.BACK_PAYMENT_HISTORY})
	@RequestMapping(value = "/ajax-init-payment-detail-popup", method = {RequestMethod.POST}, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@ResponseBody public AjaxResponse ajaxInitVaccineHospitalList(HttpSession session , @RequestBody Map<String, String> request) throws Exception {
		PaymentModel paymentModel = paymentHistoryService.getKcckPayment(request.get("fk_out"), request.get("patient_code"), MssContextHolder.getHospCode(), request.get("order_id"));
		MssContextHolder.setPaymentInfo(paymentModel.getPaymentInfo());
		List<OrderMedicineModel> orderMedicines = paymentModel.getOrderMedicine();
		AjaxResponseBuilder builder = new AjaxResponseBuilder();
		builder.status(HttpStatus.OK).data(orderMedicines);
		return builder.build();
	}
	
	@RequestMapping(value = "/ajax-detail-payment", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse showPopupDetailPayment(@RequestBody Map<String, String> request) {
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();
		// Call API -> get data;
		Map<String, String> dataSend = new HashMap<>();
		PaymentInfoModel paymentInfo = MssContextHolder.getPaymentInfo();
		dataSend.put("datetimeExamination", paymentInfo.getDatetimeExamination());
		dataSend.put("patientCode-detail", paymentInfo.getPatientCode());
		dataSend.put("patientName-detail", paymentInfo.getPatientName());
		dataSend.put("address-detail", paymentInfo.getAddress());
		dataSend.put("phone-detail", paymentInfo.getPhone());
		dataSend.put("email-detail", paymentInfo.getEmail());
		dataSend.put("transaction-detail", request.get("transaction_id"));
		dataSend.put("cardType", "Credid Card");
		dataSend.put("status", request.get("status"));
		String totalPayment = paymentInfo.getAmount();
		if (!totalPayment.equals("")) {
			totalPayment = String.format("%d", (int) Double.parseDouble(totalPayment));
		}
		dataSend.put("totalPayment", totalPayment);
		responseBuilder.data(dataSend);
		responseBuilder.status(HttpStatus.OK);
		return responseBuilder.build();
	}
	
	@RequestMapping(value = "/update-detail-payment", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse updateDetailPayment(@RequestBody Map<String, String> request) {
		String userBackLogin = MssContextHolder.getUserBack();
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();	
		KcckUpdatePaymentStatusModel kcckUpdatePaymentStatusModel = new KcckUpdatePaymentStatusModel(request.get("patient_code"),  MssContextHolder.getHospCode(), request.get("order_id"),
				request.get("status"), request.get("transaction_id"), request.get("fk_out"),request.get("comment"), "",request.get("tran_date"),userBackLogin);
		boolean updatePayment = paymentHistoryService.updatePayment(kcckUpdatePaymentStatusModel);
		responseBuilder.status(HttpStatus.OK).data(updatePayment);
		return responseBuilder.build();
	}
}

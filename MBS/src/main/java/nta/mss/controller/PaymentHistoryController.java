package nta.mss.controller;

import java.util.ArrayList;
import java.util.Currency;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import nta.mss.service.IPatientService;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import nta.mss.entity.DataTableJsonObject;
import nta.mss.info.AjaxResponse;
import nta.mss.info.AjaxResponse.AjaxResponseBuilder;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.SessionValidate;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationGroup;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.OrderMedicineModel;
import nta.mss.model.PaymentHistoriesModel;
import nta.mss.model.PaymentHistory;
import nta.mss.model.PaymentInfoModel;
import nta.mss.model.PaymentModel;
import nta.mss.model.SearchPaymentTransaction;
import nta.mss.model.UserModel;
import nta.mss.security.WebUserDetails;
import nta.mss.service.IPaymentHistoryService;
import nta.mss.service.IUserService;

/**
 * 
 * @author TungLT Controller allow user show history of payment when booking
 *         clinic
 */
@Controller
@Scope("prototype")
@RequestMapping("payment-history")
@NavigationConfig(leftMenuType = NavigationType.FRONT_LEFT_MENU)
public class PaymentHistoryController {

	private static final Logger LOG = LogManager.getLogger(PaymentHistoryController.class);

	@Resource
	private IPaymentHistoryService paymentHistoryService;
	@Resource
	private IUserService userService;
	@Resource
	private IPatientService patientService;

	@RequestMapping("/index")
	@NavigationConfig(group = { NavigationGroup.PAYMENT_HISTORY })
	public ModelAndView Index() {
		LOG.info("[Start] View payment history.");
		return new ModelAndView("payment.history.index");
	}

	public UserModel getUser() {
		if (SecurityContextHolder.getContext().getAuthentication() != null) {
			Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();
			if (principal instanceof WebUserDetails) {
				return ((WebUserDetails) principal).getUser();
			}
		}
		return null;
	}

	@RequestMapping(value = "/get-history-payment", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String getPaymentHistory(@RequestParam int iDisplayStart, HttpServletRequest request,
			HttpSession session, @RequestParam int iDisplayLength) {

		LOG.info("[Start] View get data history insurance.");
		String colSort = request.getParameter("iSortCol_0");
		String typeSort = request.getParameter("sSortDir_0");
		String sort_col_name = "";
		if (colSort.equals("0")) {
			sort_col_name = "transactionId|" + typeSort;
		} else if (colSort.equals("2")) {
			sort_col_name = "examDate|" + typeSort;
		} else if (colSort.equals("4")) {
			sort_col_name = "transactionDateTime|" + typeSort;
		}
		UserModel userModel = getUser();
		String token = userModel.getToken();
		Integer userId = userModel.getUserId();
		String patientCode = patientService.getStrPatientCodeFromAccountClinic(token, userId);
		if(Strings.isEmpty(patientCode))
		{
			DataTableJsonObject<PaymentHistory> paymentHistoryJsonObject = new DataTableJsonObject<>();

			paymentHistoryJsonObject.setiTotalDisplayRecords(0);
			paymentHistoryJsonObject.setiTotalRecords(0);
			paymentHistoryJsonObject.setAaData(new ArrayList<>());
			GsonBuilder builder = new GsonBuilder();
			builder.serializeNulls();
			Gson gson = builder.create();
			String jsonOBJ = gson.toJson(paymentHistoryJsonObject);

			return jsonOBJ;
		}
		Integer pageNumber = (iDisplayStart / iDisplayLength) + 1;
		Integer offset = iDisplayLength;

		String hospCode = MssContextHolder.getHospCode();
		String paymentDateFrom = request.getParameter("patient_from_date");
		String paymentDateEnd = request.getParameter("payment_to_date");
		String invoiceNo = request.getParameter("invoice_no");
		String examDateFrom = request.getParameter("exam_from_date");
		String examToDate = request.getParameter("exam_to_date");
		String transactionId = request.getParameter("transaction_id");
		String amountFrom = request.getParameter("amount_from");
		String amountTo = request.getParameter("amount_to");
		String status = request.getParameter("status");

		SearchPaymentTransaction searchPaymentTransaction = new SearchPaymentTransaction(paymentDateFrom,
				paymentDateEnd, invoiceNo, examDateFrom, examToDate, transactionId, amountFrom, amountTo, status,
				patientCode, String.valueOf(pageNumber), String.valueOf(offset), sort_col_name, hospCode);

		PaymentHistoriesModel paymentHistoryModel = paymentHistoryService.getPaymentHistory(searchPaymentTransaction);
		Integer totalRecord = paymentHistoryModel.getTotalRecord();
		DataTableJsonObject<PaymentHistory> paymentHistoryJsonObject = new DataTableJsonObject<>();
		paymentHistoryJsonObject.setiTotalDisplayRecords(totalRecord);
		paymentHistoryJsonObject.setiTotalRecords(totalRecord);
		paymentHistoryJsonObject.setAaData(paymentHistoryModel.getPaymentHistories());
		GsonBuilder builder = new GsonBuilder();
		builder.serializeNulls();
		Gson gson = builder.create();
		String jsonOBJ = gson.toJson(paymentHistoryJsonObject);

		return jsonOBJ;
	}

	@RequestMapping(value = "/ajax-detail_payment", method = {
			RequestMethod.POST }, produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
	@SessionValidate
	@ResponseBody
	public AjaxResponse showPopupDetailPayment(@RequestBody Map<String, String> request) {
		AjaxResponseBuilder responseBuilder = new AjaxResponseBuilder();
		PaymentModel paymentModel = paymentHistoryService.getKcckPayment(request.get("fk_out"),
				request.get("patient_code"), MssContextHolder.getHospCode(), request.get("order_id"));
		// Call API -> get data;
		Map<String, String> dataSend = new HashMap<>();
		PaymentInfoModel paymentInfo = paymentModel.getPaymentInfo();
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
		List<OrderMedicineModel> orderMedicines = new ArrayList<>();
		orderMedicines = paymentModel.getOrderMedicine();
		MssContextHolder.setOrderMedicines(orderMedicines);
		responseBuilder.data(dataSend);
		responseBuilder.status(HttpStatus.OK);
		return responseBuilder.build();
	}

	@RequestMapping(value = "/get-order-medicine", method = RequestMethod.GET, produces = {
			"application/json; charset=UTF-8" })
	public @ResponseBody String getOrderMedicine(ModelMap model) {
		LOG.info("[Start] View order medicine.");
		List<OrderMedicineModel> orderMedicines = MssContextHolder.getOrderMedicines();
		DataTableJsonObject<OrderMedicineModel> orderMedicineInfo = new DataTableJsonObject<>();
		orderMedicineInfo.setiTotalDisplayRecords(orderMedicines.size());
		orderMedicineInfo.setiTotalRecords(orderMedicines.size());
		orderMedicineInfo.setAaData(orderMedicines);
		GsonBuilder builder = new GsonBuilder();
		builder.serializeNulls();
		Gson gson = builder.create();
		String jsonOBJ = gson.toJson(orderMedicineInfo);
		return jsonOBJ;
	}

}

package nta.mss.controller;

import java.net.URLEncoder;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Currency;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Optional;
import java.util.ResourceBundle;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import nta.kcck.model.KcckUpdatePaymentStatusModel;
import nta.mss.entity.DataTableJsonObject;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.PaymentStatus;
import nta.mss.misc.navigation.NavigationConfig;
import nta.mss.misc.navigation.NavigationConfig.NavigationType;
import nta.mss.model.OrderMedicineModel;
import nta.mss.model.PaymentInfoModel;
import nta.mss.model.PaymentModel;
import nta.mss.model.PaymentProcessModel;
import nta.mss.service.IPaymentHistoryService;

/**
 * 
 * @author TungLT
 * @category Controller perform integrate-interactive MBS-Web with third-party
 *           payment system GMO
 * @version 1.0
 */

@Controller
@Scope("prototype")
@RequestMapping("payment-process")
@NavigationConfig(leftMenuType = NavigationType.FRONT_LEFT_MENU)
public class PaymentProcessController extends BaseController {
	private static final Logger LOG = LogManager.getLogger(PaymentProcessController.class);


	@Resource
	private IPaymentHistoryService paymentHistoryService;

	@RequestMapping("/index")
	public ModelAndView index(ModelMap model,
			HttpServletRequest request) throws Exception {	
		String hospCode = MssContextHolder.getHospCode();
		String fkOut = "";
		String patientCode = "";
		String orderId = "";
		PaymentInfoModel paymentInfo1 = MssContextHolder.getPaymentInfo();
		if(paymentInfo1!=null && request.getParameter("fk_out") == null && request.getParameter("order_id") == null){
			fkOut = paymentInfo1.getFkOut();
			patientCode = paymentInfo1.getPatientCode();
			orderId = paymentInfo1.getOrderId();
		}
		else{
		 fkOut = request.getParameter("fk_out");		
		 patientCode = request.getParameter("patient_code");
		 orderId = request.getParameter("order_id");
		}
		LOG.info("FkOut is " +fkOut + " Hospital code is " +hospCode + " patientCode is " + patientCode + " orderID is " + orderId);
	    PaymentModel paymentModel = paymentHistoryService.getKcckPayment(fkOut, patientCode, hospCode, orderId);

		if(StringUtils.isEmpty(paymentModel.getExpireLink()) || !paymentModel.getExpireLink().equals("1"))
		{
			LOG.info("[Start] Start process payment ");
			PaymentProcessModel payment = paymentModel.getPaymentProcess();  //new PaymentProcessModel();
			String baseURL = MssConfiguration.getInstance().getServerAddressJp();
			if (!StringUtils.isEmpty(MssContextHolder.getUserLanguage())) {
				if (MssContextHolder.getUserLanguage().equals("ja")) {
					baseURL = MssConfiguration.getInstance().getServerAddressJp();
				} else {
					baseURL = MssConfiguration.getInstance().getServerAddress();
				}
			}
			String shopId = paymentModel.getPaymentProcess() == null ? "" :paymentModel.getPaymentProcess().getShopId();
			String redirectURL = "https://pt01.mul-pay.jp/link/" + shopId + "/Multi/Entry";
			orderId = paymentModel.getPaymentProcess() == null ? "" :paymentModel.getPaymentProcess().getOrderId();
			String amount = paymentModel.getPaymentInfo() == null ? "0" :paymentModel.getPaymentInfo().getAmount();
			if(amount != null && payment.getCurrency().equals(Currency.getInstance(Locale.JAPAN).getCurrencyCode()))
			{
				amount = String.format("%d", (int)Double.parseDouble(amount));
			}
			String tax = Strings.isEmpty(payment.getTax()) ? "0" : payment.getTax();
			String password = paymentModel.getPaymentProcess() == null ? "" :paymentModel.getPaymentProcess().getShopPass();
			String orderTime = new SimpleDateFormat("YYYYMMddHHmmss").format(new Date());
			String shopPassString = EncryptionUtils
					.cryptWithMD5(shopId + "|" + orderId + "|" + amount + "|" + tax + "|" + password + "|" + orderTime);
		
			payment.setShopId(shopId);
			payment.setOrderId(orderId); 
			payment.setAmount(amount);
			payment.setTax(tax);
			payment.setUserCredit("1");
			payment.setDateTime(orderTime);
			payment.setShopPassString(shopPassString);
			payment.setRetURL(baseURL + "/payment-process/result");
			payment.setUserInfo("pc");
			payment.setRetryMax("2");
			payment.setSessionTimeout("9999");
			payment.setLang("ja");
			payment.setConfirm("1");
			payment.setUserCredit("1");
			payment.setTemplateNo("1");
			payment.setJobCd("CAPTURE");

			PaymentInfoModel paymentInfo = paymentModel.getPaymentInfo();

			paymentInfo.setShopPass(payment.getShopPassString());
			paymentInfo.setCardType("Credit card");
			paymentInfo.setOrderId(orderId);
			paymentInfo.setAmount(payment.getAmount());
			paymentInfo.setTotalPayment(payment.getAmount());
			paymentInfo.setPassword(password);
			payment.setCancelURL(baseURL + "/payment-process/index?patient_code=" + paymentInfo.getPatientCode() +  "&fk_out=" + paymentInfo.getFkOut() + "&order_id="  + paymentInfo.getOrderId() + "&hosp_code=" + MssContextHolder.getTokenHospCode());

			MssContextHolder.setPaymentInfo(paymentInfo);
			List<OrderMedicineModel> orderMedicines = paymentModel.getOrderMedicine();//new ArrayList<>();
			MssContextHolder.setOrderMedicines(orderMedicines);
			model.addAttribute("paymentInput", payment);
			model.addAttribute("redirectURL", redirectURL);
			model.addAttribute("paymentInfo", paymentInfo);
			return new ModelAndView("payment.process.index");
		}
		else
		{
			return new ModelAndView("front.booking.expire");
		}


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

	@RequestMapping("/result")
	public ModelAndView resultProcessPayment(ModelMap model, HttpServletRequest request) {
		LOG.info("[Start] View result process payment.");
		PaymentInfoModel paymentInfo = MssContextHolder.getPaymentInfo();
		String password = MssContextHolder.getPaymentInfo().getPassword();
		List<String> paramsReturn = Arrays.asList("OrderID", "Forwarded", "Method", "PayTimes", "Approve", "TranID",
				"TranDate", "CheckString","ErrCode","ErrInfo");
		Map<String, Object> resultPayment = new HashMap<>();
		for (String param : paramsReturn) {
			resultPayment.put(param, request.getParameter(param));
		}
		String errCode = Optional.ofNullable(resultPayment.get("ErrCode")).map(Object::toString).orElse("null");
		String errInfo = Optional.ofNullable(resultPayment.get("ErrInfo")).map(Object::toString).orElse("null");
		String orderID = Optional.ofNullable(resultPayment.get("OrderID")).map(Object::toString).orElse("null");
		String forwarded = Optional.ofNullable(resultPayment.get("Forwarded")).map(Object::toString).orElse("null");
		String method = Optional.ofNullable(resultPayment.get("Method")).map(Object::toString).orElse("null");
		String payTimes = Optional.ofNullable(resultPayment.get("PayTimes")).map(Object::toString).orElse("null");
		String approve = Optional.ofNullable(resultPayment.get("Approve")).map(Object::toString).orElse("null");
		String tranID = Optional.ofNullable(resultPayment.get("TranID")).map(Object::toString).orElse("null");
		String tranDate = Optional.ofNullable(resultPayment.get("TranDate")).map(Object::toString).orElse("null");
		String checkString = Optional.ofNullable(resultPayment.get("CheckString")).map(Object::toString).orElse("null");
		String returnPass = EncryptionUtils.cryptWithMD5(orderID+forwarded+method+payTimes+approve+tranID+tranDate+password);
		boolean isSuccess = false;
		if (returnPass.equals(checkString) && StringUtils.isEmpty(errCode) && StringUtils.isEmpty(errInfo)) {
			//Call KCCK API -> update payment status (INPROGRESS)

			KcckUpdatePaymentStatusModel kcckUpdatePaymentStatusModel = new KcckUpdatePaymentStatusModel(paymentInfo.getPatientCode(), MssContextHolder.getHospCode(), paymentInfo.getOrderId(),
					String.valueOf(PaymentStatus.FINISHED.toInt()), tranID, paymentInfo.getFkOut(), "", "", tranDate, "");

			isSuccess = paymentHistoryService.updatePayment(kcckUpdatePaymentStatusModel);
			model.addAttribute("transactionIdReturn", tranID);
			model.addAttribute("paymentDate", MssDateTimeUtil.formatDateString(tranDate));
		}
		else
		{		
			isSuccess = false;

			if(!nta.med.common.util.Strings.isEmpty(tranID))
			{
				KcckUpdatePaymentStatusModel kcckUpdatePaymentStatusModel = new KcckUpdatePaymentStatusModel(paymentInfo.getPatientCode(),  MssContextHolder.getHospCode(),
						paymentInfo.getOrderId(), String.valueOf(PaymentStatus.FAILED.toInt()), tranID, paymentInfo.getFkOut(), "", errInfo, tranDate, "");
				paymentHistoryService.updatePayment(kcckUpdatePaymentStatusModel);
			}
			else
			{

				LOG.warn("Transaction id is empty order Id: "+ orderID+ " errCode="+errCode+"" +
						" errInfo="+errInfo+" method="+method+" payTimes="+payTimes+" approve="+ approve+" tranID="+
						tranID+" tranDate"+tranDate+" checkString="+ checkString+" returnPass="+returnPass+" forwarded="+ forwarded);
			}
			String messageErr = "";
			try{
			ResourceBundle rb = ResourceBundle.getBundle("gmo_messages_ja",this.getLocale());
			messageErr = rb.getString(errInfo + "_JA");
			}
			catch(Exception e)
			{
				messageErr = this.getText("fe903.error.title");
			}
			model.addAttribute("errorCode", messageErr);
		}
		model.addAttribute("isSuccess", isSuccess);
		model.addAttribute("paymentInfo", paymentInfo);
		return new ModelAndView("payment.process.result");
	}
	
}

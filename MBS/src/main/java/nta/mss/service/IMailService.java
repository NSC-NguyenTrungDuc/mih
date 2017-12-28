package nta.mss.service;

import java.util.List;
import java.util.Map;

import nta.mss.entity.MailListDetail;
import nta.mss.info.MailInfo;
import nta.mss.info.ReminderMailInfo;
import nta.mss.model.MailListDetailModel;
import nta.mss.model.MailListModel;
import nta.mss.model.MailTemplateModel;

/**
 * The Interface IMailService.
 * 
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
public interface IMailService {

	/**
	 * Gets the all mail templates.
	 *
	 * @return the all mail templates
	 */
	List<MailTemplateModel> getAllMailTemplates();

	/**
	 * Gets the all active mail templates.
	 *
	 * @return the all active mail templates
	 */
	List<MailTemplateModel> getAllActiveMailTemplates();

	/**
	 * Gets the mail template.
	 * 
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @return the mail template
	 */
	public abstract MailTemplateModel getMailTemplate(String templateCode, String locale, Integer hospitalId);

	/**
	 * Gets the mail template by id and locale.
	 *
	 * @param mailTemplateId
	 *            the mail template id
	 * @param locale
	 *            the locale
	 * @return the mail template by id and locale
	 */
	MailTemplateModel getMailTemplateByIdAndLocale(Integer mailTemplateId, String locale, Integer hospitalId);

	/**
	 * Gets the mail template by id.
	 *
	 * @param mailTemplateId
	 *            the mail template id
	 * @return the mail template by id
	 */
	MailTemplateModel getMailTemplateById(Integer mailTemplateId);

	/**
	 * Send mail.
	 * 
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @param mailInfo
	 *            the mail info
	 * @param toList
	 *            the to list
	 * @param patientId
	 *            the patient id
	 * @param reservationId
	 *            the reservation id
	 */
	public void sendMail(String templateCode, String locale, MailInfo mailInfo, List<String> toList, Integer patientId,
			Integer reservationId, Integer hospitalId, String bccEmail, String domainName);

	/**
	 * Send mail.
	 *
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @param mailInfo
	 *            the mail info
	 * @param toList
	 *            the to list
	 */
	public void sendMail(String templateCode, String locale, MailInfo mailInfo, List<String> toList, Integer hospitalId,
			String bccEmail, String domainName);

	/**
	 * Send user mail.
	 *
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @param mailInfo
	 *            the mail info
	 * @param toList
	 *            the to list
	 */
	public void sendUserMail(String templateCode, String locale, MailInfo mailInfo, List<String> toList,
			Integer hospitalId, String bccEmail, String domainName);

	/**
	 * Get MailList by active flg
	 * 
	 * @param activeFlg
	 * @return
	 */
	List<MailListModel> getMailListByActiveFlg(Integer activeFlg, Integer hospitalId);

	/**
	 * @author linh.nguyen.trong
	 * @since 08/08/2014
	 * 
	 *        Save mail list
	 * 
	 * @param mail
	 *            List name
	 * @return
	 * @throws Exception
	 */
	public MailListModel saveMailList(String mailListName, List<ReminderMailInfo> reminderMailInfos, Integer hospitalId)
			throws Exception;

	/**
	 * @author linh.nguyen.trong
	 * @since 20140811
	 * 
	 *        Save mail list detail
	 * 
	 * @param mailListId
	 * @param email
	 * @param name
	 * @return
	 * @throws Exception
	 */
	public MailListDetail saveMailListDetail(Integer mailListId, String email, String name, String phone)
			throws Exception;
	
	public MailListDetail saveMailListDetailNew(Integer mailListId, String email, String name, String phone,Integer hospitalId)
			throws Exception;
	/**
	 * @author linhnt
	 * @since 20140813
	 * 
	 * @param mailListId
	 * @param activeFlg
	 * @return
	 * @throws Exception
	 */
	public List<MailListDetailModel> getMailListDetail(Integer mailListId, Integer activeFlg) throws Exception;

	/**
	 * find mail list by id
	 * 
	 * @param mailListId
	 * @return
	 * @throws Exception
	 */
	public MailListModel findByMailListId(Integer mailListId) throws Exception;

	/**
	 * Save mail list.
	 *
	 * @param mailListName
	 *            the mail list name
	 * @param reminderMailInfo
	 *            the reminder mail info
	 * @throws Exception
	 *             the exception
	 */
	public void saveMailList(String mailListName, ReminderMailInfo reminderMailInfo) throws Exception;

	/**
	 * get all mail list
	 * 
	 * @return map
	 */
	Map<Integer, String> getAllMailList();

	/**
	 * 
	 * @param mailingListModel
	 * @return List
	 */
	List<MailListModel> searchMailListHistory(MailListModel mailingListModel);

	/**
	 * Delete mail template.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @return true, if successful
	 */
	boolean deleteMailTemplate(MailTemplateModel mailTemplateModel);

	/**
	 * Update mail template.
	 *
	 * @param mailTemplateModel
	 *            the mail template model
	 * @return true, if successful
	 */
	boolean updateMailTemplate(MailTemplateModel mailTemplateModel);

	// /**
	// * Delete mail list.
	// *
	// * @param mailListModel the mail list model
	// * @throws Exception the exception
	// */
	// void updateMailList(MailListModel mailListModel) throws Exception;

	/**
	 * Update mail list detail.
	 *
	 * @param mailListDetailModel
	 *            the mail list detail model
	 * @throws Exception
	 *             the exception
	 */
	public void updateMailListDetail(MailListDetailModel mailListDetailModel) throws Exception;

	/**
	 * Find by mail list id and email.
	 *
	 * @param mailListId
	 *            the mail list id
	 * @param email
	 *            the email
	 * @return the mail list detail model
	 * @throws Exception
	 *             the exception
	 */
	public MailListDetailModel findByMailListIdAndEmail(Integer mailListId, String email) throws Exception;

	/**
	 * Delete mail list.
	 *
	 * @param mailListModel
	 *            the mail list model
	 * @param lstMailListDetail
	 *            the lst mail list detail
	 * @throws Exception
	 *             the exception
	 */
	public void deleteMailList(MailListModel mailListModel, List<MailListDetailModel> lstMailListDetail)
			throws Exception;

	/**
	 * Delete mail list detail.
	 *
	 * @param mailListDetailModel
	 *            the mail list detail model
	 * @throws Exception
	 *             the exception
	 */
	public void deleteMailListDetail(MailListDetailModel mailListDetailModel) throws Exception;

	/**
	 * Adds the new mail detail.
	 *
	 * @param mailListId
	 *            the mail list id
	 * @param reminderMailInfos
	 *            the reminder mail infos
	 * @throws Exception
	 *             the exception
	 */
	public void addNewMailDetail(Integer mailListId, List<ReminderMailInfo> reminderMailInfos) throws Exception;

	/**
	 * Update mail list detail.
	 *
	 * @param email
	 *            the email
	 * @param name
	 *            the name
	 * @param mailListId
	 *            the mail list id
	 * @param emailOld
	 *            the email old
	 * @throws Exception
	 *             the exception
	 */
	public void updateMailListDetail(String email, String name, Integer mailListId, String emailOld) throws Exception;

	/**
	 * Update mail list.
	 *
	 * @param mailListName
	 *            the mail list name
	 * @param lstReminderMailInfo
	 *            the lst reminder mail info
	 * @throws Exception
	 *             the exception
	 */
	public void updateMailList(Integer mailListId, String mailListName, ReminderMailInfo reminderMailInfo)
			throws Exception;

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Process mail csv.
	 *
	 * @param name
	 *            the name
	 * @throws Exception
	 *             the exception
	 */
	public abstract void processMailCsv(String name) throws Exception;

	/**
	 * @author linh.nguyen.trong
	 * 
	 *         Find by name.
	 *
	 * @param name
	 *            the name
	 * @return the list
	 * @throws Exception
	 *             the exception
	 */
	public List<MailListModel> findByName(String name) throws Exception;

	/**
	 * Send mail.
	 *
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @param mailInfo
	 *            the mail info
	 * @param toList
	 *            the to list
	 * @param mailListId
	 *            the mail list id
	 * @param patientId
	 *            the patient id
	 * @param reservationId
	 *            the reservation id
	 * @throws Exception
	 *             the exception
	 */
	public void sendMail(String templateCode, String locale, MailInfo mailInfo, List<String> toList, Integer mailListId,
			Integer patientId, Integer reservationId, Integer hospitalId, String bccEmail, String domainName)
					throws Exception;

	/**
	 * Update reading flg.
	 *
	 * @param mailSendingId
	 *            the mail sending id
	 * @param readingFlg
	 *            the reading flg
	 */
	public boolean updateReadingFlg(Integer mailSendingId, Integer readingFlg);

	/**
	 * Find all template customize.
	 *
	 * @return the list
	 */
	public List<MailTemplateModel> findAllTemplateCustomize(Integer hospitalId, String locale);

	/**
	 * getAllActiveMailTemplatesByHospitalId
	 * 
	 * @return
	 */
	public List<MailTemplateModel> getAllActiveMailTemplatesByHospitalId(Integer hospitalId, String locale);
	
	public List<MailTemplateModel> getAllActiveSmsTemplatesByHospitalId(Integer hospitalId, String locale); 

	public List<MailTemplateModel> findByHospIdAndLocale(Integer hospitalId, String locale);

	public List<MailTemplateModel> getTemplateByTemplateType(Integer templateType, Integer hospitalId, String locale);

	public List<MailTemplateModel> getCrmTemplate(Integer hospitalId, String locale);
	
	/**
	 * Send SMS.
	 *
	 */
//	public void sendSms(String templateCode, String locale, MailInfo mailInfo,Integer hospitalId, String recieverNumber);
//	public void sendInfoSms(String message,String recieverNumber,String sender,String locale);
}

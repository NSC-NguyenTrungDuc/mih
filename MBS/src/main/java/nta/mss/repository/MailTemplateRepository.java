package nta.mss.repository;

import java.util.List;

import nta.mss.entity.MailTemplate;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface MailTemplateRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface MailTemplateRepository extends JpaRepository<MailTemplate, Integer>{
	
	/**
	 * Find by mail template.
	 * 
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @return the mail template
	 */
	@Query("SELECT m FROM MailTemplate m WHERE m.templateCode = ?1 AND m.locale = ?2 AND m.hospitalId = ?3 AND m.sendType = ?4")
	public List<MailTemplate> findByMailTemplate(String templateCode, String locale, Integer hospitalId, Integer sendType);
	
	/**
	 * Find by mail template id.
	 *
	 * @param templateId the template id
	 * @param locale the locale
	 * @return the mail template
	 */
	@Query("SELECT m FROM MailTemplate m WHERE m.mailTemplateId = ?1 AND m.locale = ?2 AND m.hospitalId = ?3 AND m.sendType = ?4")
	public List<MailTemplate> findByMailTemplateId(Integer templateId, String locale, Integer hospitalId, Integer sendType);
	
	/**
	 * Find all active.
	 *
	 * @return the list
	 */
	@Query("SELECT m FROM MailTemplate m WHERE m.activeFlg = 1 AND m.sendType = ?1")
	public List<MailTemplate> findAllActive(Integer sendType);
	
	@Query("SELECT m FROM MailTemplate m WHERE m.templateType = 1 and m.activeFlg = 1  AND m.hospitalId = ?1 AND m.locale = ?2 AND m.sendType = ?3 order by mailTemplateId asc ")
	public List<MailTemplate> findAllTemplateCustomize(Integer hospitalId, String locale, Integer sendType);

	@Query("SELECT m FROM MailTemplate m WHERE m.templateType = 1 and m.activeFlg = 1  AND m.hospitalId = ?1 AND m.locale = ?2 AND m.sendType = ?3 order by mailTemplateId asc ")
	public List<MailTemplate> findByHospIdAndLocale(Integer hospitalId, String locale, Integer sendType);
	
	@Query("SELECT m FROM MailTemplate m WHERE m.activeFlg = 1 AND m.hospitalId = :hospitalId AND m.locale = :locale AND m.sendType = :sendType")
	public List<MailTemplate> findAllActiveByHospitalId(@Param("hospitalId") Integer hospitalId, @Param("locale") String locale, @Param("sendType") Integer sendType);
	
	@Query("SELECT m FROM MailTemplate m WHERE m.templateType = ?1 and m.activeFlg = 1  AND m.hospitalId = ?2 AND m.locale = ?3 AND m.sendType = ?4 order by mailTemplateId asc ")
	public List<MailTemplate> findByHospIdAndTemplateTypeAndLocale(Integer templateType, Integer hospitalId, String locale, Integer sendType);

	@Query("SELECT m FROM MailTemplate m WHERE m.activeFlg = 1  AND m.hospitalId = ?1 AND m.locale = ?2 AND m.sendType = ?3 AND (template_code = 'CUSTOMER_RELATION_MANAGEMENT' OR is_new = '1')   order by templateCode asc ")
	public List<MailTemplate> getCrmTemplateByLocale(Integer hospitalId, String locale, Integer int1);
}

package nta.med.data.dao.mss;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.mss.MailTemplate;

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
	@Query("SELECT m FROM MailTemplate m WHERE m.templateCode = ?1 AND m.locale = ?2 AND m.hospitalId = ?3")
	public List<MailTemplate> findByMailTemplate(String templateCode, String locale, String hospitalId);
}

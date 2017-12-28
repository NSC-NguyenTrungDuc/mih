package nta.med.data.dao.regis;


import nta.med.core.domain.hp.HpMailTemplate;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface MailTemplateRepository extends JpaRepository<HpMailTemplate, Integer>{
	
	/**
	 * Find by mail template.
	 * 
	 * @param templateCode
	 *            the template code
	 * @param language
	 *            the locale
	 * @return the mail template
	 */
	@Query("SELECT m FROM HpMailTemplate m WHERE m.templateCode = ?1 AND m.language = ?2")
	public List<HpMailTemplate> findByMailTemplate(String templateCode, String language);
}

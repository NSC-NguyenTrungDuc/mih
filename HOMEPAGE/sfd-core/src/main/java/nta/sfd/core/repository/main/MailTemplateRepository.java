package nta.sfd.core.repository.main;

import nta.sfd.core.entity.MailTemplate;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

/**
 * The Interface MailTemplateRepository.
 *
 * @author MinhLS
 * @crtDate 2015/07/02
 */
@Repository
public interface MailTemplateRepository extends JpaRepository<MailTemplate, Integer>{

	/**
	 * Find by mail template.
	 *
	 * @param templateCode the template code
	 * @param locale the locale
	 * @return the mail template
	 */
	@Query("SELECT m FROM MailTemplate m WHERE m.templateCode = ?1 AND m.language = ?2 ")
	public MailTemplate findByMailTemplate(String templateCode, String language);
}

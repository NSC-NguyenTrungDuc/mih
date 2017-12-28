package nta.med.data.dao.medi.adm;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import nta.med.core.domain.adm.IhisMailTemplate;

public interface IhisMailTemplateRepository  extends JpaRepository<IhisMailTemplate, Integer>{
	
	/**
	 * Find by mail template.
	 * 
	 * @param templateCode
	 *            the template code
	 * @param locale
	 *            the locale
	 * @return the mail template
	 */
	@Query("SELECT m FROM IhisMailTemplate m WHERE m.templateCode = ?1 AND m.language = ?2")
	public List<IhisMailTemplate> findByMailTemplate(String templateCode, String language);
}

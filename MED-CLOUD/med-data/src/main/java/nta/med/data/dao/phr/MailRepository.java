package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.phr.PhrMail;

@Repository
public interface MailRepository extends JpaRepository<PhrMail, Integer> {

	@Modifying
	@Query("SELECT a FROM PhrMail a WHERE type = :f_type and locale = :f_locale")
	public List<PhrMail> findByTypeAndLocale(@Param("f_type") String type, @Param("f_locale") String locale);
}

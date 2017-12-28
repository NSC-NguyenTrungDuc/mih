package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0003;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0003Repository extends JpaRepository<Adm0003, Long>, Adm0003RepositoryCustom {
	@Query("SELECT msg FROM Adm0003 WHERE adm0003Pk = :adm0003Pk and language = :language")
	public String getFormEnvironInfoMessage(@Param("language") String language,
			@Param("adm0003Pk") Double adm0003Pk);
}


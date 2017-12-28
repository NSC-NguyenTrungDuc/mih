package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0740;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0740Repository extends JpaRepository<Adm0740, Long>, Adm0740RepositoryCustom {
}


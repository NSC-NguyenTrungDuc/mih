package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0730;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0730Repository extends JpaRepository<Adm0730, Long>, Adm0730RepositoryCustom {
}


package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0720;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0720Repository extends JpaRepository<Adm0720, Long>, Adm0720RepositoryCustom {
}


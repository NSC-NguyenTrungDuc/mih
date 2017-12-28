package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0000Repository extends JpaRepository<Adm0000, Long>, Adm0000RepositoryCustom {
}


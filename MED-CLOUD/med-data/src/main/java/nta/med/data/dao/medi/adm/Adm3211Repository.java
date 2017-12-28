package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm3211;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm3211Repository extends JpaRepository<Adm3211, Long>, Adm3211RepositoryCustom {
}


package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm4400;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm4400Repository extends JpaRepository<Adm4400, Long>, Adm4400RepositoryCustom {
}


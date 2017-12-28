package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg2020;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg2020Repository extends JpaRepository<Drg2020, Long>, Drg2020RepositoryCustom {
}


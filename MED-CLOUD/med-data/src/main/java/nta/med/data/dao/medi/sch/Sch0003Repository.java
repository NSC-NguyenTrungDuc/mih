package nta.med.data.dao.medi.sch;

import nta.med.core.domain.sch.Sch0003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch0003Repository extends JpaRepository<Sch0003, Long>, Sch0003RepositoryCustom {
}


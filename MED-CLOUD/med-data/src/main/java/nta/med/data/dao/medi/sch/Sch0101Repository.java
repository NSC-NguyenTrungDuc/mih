package nta.med.data.dao.medi.sch;

import nta.med.core.domain.sch.Sch0101;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch0101Repository extends JpaRepository<Sch0101, Long>, Sch0101RepositoryCustom {
}


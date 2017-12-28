package nta.med.data.dao.medi.drg;

import nta.med.core.domain.drg.Drg0129;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg0129Repository extends JpaRepository<Drg0129, Long>, Drg0129RepositoryCustom {
}


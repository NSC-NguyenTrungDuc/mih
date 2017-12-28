package nta.med.data.dao.medi.nut;

import nta.med.core.domain.nut.Nut1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nut1001Repository extends JpaRepository<Nut1001, Long>, Nut1001RepositoryCustom {
}


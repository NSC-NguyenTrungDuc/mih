package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0307;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0307Repository extends JpaRepository<Cpl0307, Long>, Cpl0307RepositoryCustom {
}


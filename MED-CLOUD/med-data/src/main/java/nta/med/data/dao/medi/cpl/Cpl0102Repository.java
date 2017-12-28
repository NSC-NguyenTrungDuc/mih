package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0102;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0102Repository extends JpaRepository<Cpl0102, Long>, Cpl0102RepositoryCustom {
}


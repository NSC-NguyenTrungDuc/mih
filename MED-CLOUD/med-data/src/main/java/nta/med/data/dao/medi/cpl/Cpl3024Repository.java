package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl3024;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl3024Repository extends JpaRepository<Cpl3024, Long>, Cpl3024RepositoryCustom {
}


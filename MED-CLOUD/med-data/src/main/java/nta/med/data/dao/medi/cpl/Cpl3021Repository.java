package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl3021;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl3021Repository extends JpaRepository<Cpl3021, Long>, Cpl3021RepositoryCustom {
}


package nta.med.data.dao.medi.apl;

import nta.med.core.domain.apl.Apl0301;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Apl0301Repository extends JpaRepository<Apl0301, Long>, Apl0301RepositoryCustom {
}


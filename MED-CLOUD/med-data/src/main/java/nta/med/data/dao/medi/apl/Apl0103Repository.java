package nta.med.data.dao.medi.apl;

import nta.med.core.domain.apl.Apl0103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Apl0103Repository extends JpaRepository<Apl0103, Long>, Apl0103RepositoryCustom {
}


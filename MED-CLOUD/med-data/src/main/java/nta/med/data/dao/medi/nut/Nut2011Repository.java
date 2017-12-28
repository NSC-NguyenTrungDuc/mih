package nta.med.data.dao.medi.nut;

import nta.med.core.domain.nut.Nut2011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nut2011Repository extends JpaRepository<Nut2011, Long>, Nut2011RepositoryCustom {
}


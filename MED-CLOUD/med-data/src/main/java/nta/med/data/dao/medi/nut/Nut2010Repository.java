package nta.med.data.dao.medi.nut;

import nta.med.core.domain.nut.Nut2010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nut2010Repository extends JpaRepository<Nut2010, Long>, Nut2010RepositoryCustom {
}


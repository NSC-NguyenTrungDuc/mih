package nta.med.data.dao.medi.inv;

import nta.med.core.domain.inv.Inv0113;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inv0113Repository extends JpaRepository<Inv0113, Long>, Inv0113RepositoryCustom {
}


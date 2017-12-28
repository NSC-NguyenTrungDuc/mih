package nta.med.data.dao.medi.inv;

import nta.med.core.domain.inv.Inv0111;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inv0111Repository extends JpaRepository<Inv0111, Long>, Inv0111RepositoryCustom {
}


package nta.med.data.dao.medi.phy;

import nta.med.core.domain.phy.Phy7401;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Phy7401Repository extends JpaRepository<Phy7401, Long>, Phy7401RepositoryCustom {
}


package nta.med.data.dao.medi.phy;

import nta.med.core.domain.phy.Phy2000;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Phy2000Repository extends JpaRepository<Phy2000, Long>, Phy2000RepositoryCustom {
}


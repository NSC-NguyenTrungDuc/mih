package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif1102;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif1102Repository extends JpaRepository<Oif1102, Long>, Oif1102RepositoryCustom {
}


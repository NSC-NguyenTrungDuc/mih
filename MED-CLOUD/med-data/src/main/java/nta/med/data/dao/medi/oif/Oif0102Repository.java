package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif0102;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif0102Repository extends JpaRepository<Oif0102, Long>, Oif0102RepositoryCustom {
}


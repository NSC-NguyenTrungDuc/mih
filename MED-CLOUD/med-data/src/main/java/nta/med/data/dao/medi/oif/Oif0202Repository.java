package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif0202;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif0202Repository extends JpaRepository<Oif0202, Long>, Oif0202RepositoryCustom {
}


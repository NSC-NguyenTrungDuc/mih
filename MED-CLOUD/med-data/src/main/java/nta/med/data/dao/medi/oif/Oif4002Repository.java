package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif4002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif4002Repository extends JpaRepository<Oif4002, Long>, Oif4002RepositoryCustom {
}


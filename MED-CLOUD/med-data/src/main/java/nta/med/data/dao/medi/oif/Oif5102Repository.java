package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif5102;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif5102Repository extends JpaRepository<Oif5102, Long>, Oif5102RepositoryCustom {
}


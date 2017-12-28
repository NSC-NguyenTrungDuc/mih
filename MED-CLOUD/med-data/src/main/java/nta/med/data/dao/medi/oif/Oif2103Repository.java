package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif2103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif2103Repository extends JpaRepository<Oif2103, Long>, Oif2103RepositoryCustom {
}


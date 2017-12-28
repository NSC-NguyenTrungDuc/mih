package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif1103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif1103Repository extends JpaRepository<Oif1103, Long>, Oif1103RepositoryCustom {
}


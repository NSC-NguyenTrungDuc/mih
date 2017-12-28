package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5007;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5007Repository extends JpaRepository<Nur5007, Long>, Nur5007RepositoryCustom {
}


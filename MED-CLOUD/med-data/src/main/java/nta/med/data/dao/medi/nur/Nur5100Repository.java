package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5100;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5100Repository extends JpaRepository<Nur5100, Long>, Nur5100RepositoryCustom {
}


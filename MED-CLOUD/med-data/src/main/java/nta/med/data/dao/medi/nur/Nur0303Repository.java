package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0303;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0303Repository extends JpaRepository<Nur0303, Long>, Nur0303RepositoryCustom {
}


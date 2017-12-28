package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6006;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6006Repository extends JpaRepository<Nur6006, Long>, Nur6006RepositoryCustom {
}


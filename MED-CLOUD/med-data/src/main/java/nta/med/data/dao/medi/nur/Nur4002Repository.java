package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur4002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur4002Repository extends JpaRepository<Nur4002, Long>, Nur4002RepositoryCustom {
}


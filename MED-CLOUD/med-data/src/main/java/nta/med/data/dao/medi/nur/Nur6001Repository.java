package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6001Repository extends JpaRepository<Nur6001, Long>, Nur6001RepositoryCustom {
}


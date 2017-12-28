package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6004Repository extends JpaRepository<Nur6004, Long>, Nur6004RepositoryCustom {
}


package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5001Repository extends JpaRepository<Nur5001, Long>, Nur5001RepositoryCustom {
}


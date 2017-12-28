package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5005;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5005Repository extends JpaRepository<Nur5005, Long>, Nur5005RepositoryCustom {
}


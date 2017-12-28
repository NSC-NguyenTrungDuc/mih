package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5010Repository extends JpaRepository<Nur5010, Long>, Nur5010RepositoryCustom {
}


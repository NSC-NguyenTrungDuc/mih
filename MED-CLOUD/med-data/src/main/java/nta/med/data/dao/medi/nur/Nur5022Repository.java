package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5022;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5022Repository extends JpaRepository<Nur5022, Long>, Nur5022RepositoryCustom {
}


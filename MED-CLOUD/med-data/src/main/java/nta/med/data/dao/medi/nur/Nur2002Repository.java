package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur2002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur2002Repository extends JpaRepository<Nur2002, Long>, Nur2002RepositoryCustom {
}


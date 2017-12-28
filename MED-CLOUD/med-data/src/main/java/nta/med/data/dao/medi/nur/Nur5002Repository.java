package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5002Repository extends JpaRepository<Nur5002, Long>, Nur5002RepositoryCustom {
}


package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur9002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur9002Repository extends JpaRepository<Nur9002, Long>, Nur9002RepositoryCustom {
}


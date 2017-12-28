package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0301;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0301Repository extends JpaRepository<Nur0301, Long>, Nur0301RepositoryCustom {
}


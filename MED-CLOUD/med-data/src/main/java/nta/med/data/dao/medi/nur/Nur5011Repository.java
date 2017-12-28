package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5011Repository extends JpaRepository<Nur5011, Long>, Nur5011RepositoryCustom {
}


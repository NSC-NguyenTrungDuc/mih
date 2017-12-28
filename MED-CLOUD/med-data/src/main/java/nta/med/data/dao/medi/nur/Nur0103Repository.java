package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0103Repository extends JpaRepository<Nur0103, Long>, Nur0103RepositoryCustom {
}


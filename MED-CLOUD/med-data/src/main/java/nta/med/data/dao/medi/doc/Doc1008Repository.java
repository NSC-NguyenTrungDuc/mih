package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc1008;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc1008Repository extends JpaRepository<Doc1008, Long>, Doc1008RepositoryCustom {
}


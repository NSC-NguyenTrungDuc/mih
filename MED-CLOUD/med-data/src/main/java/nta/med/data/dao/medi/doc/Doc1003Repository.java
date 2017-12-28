package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc1003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc1003Repository extends JpaRepository<Doc1003, Long>, Doc1003RepositoryCustom {
}


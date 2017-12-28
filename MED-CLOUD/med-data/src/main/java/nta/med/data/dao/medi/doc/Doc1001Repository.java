package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc1001Repository extends JpaRepository<Doc1001, Long>, Doc1001RepositoryCustom {
}


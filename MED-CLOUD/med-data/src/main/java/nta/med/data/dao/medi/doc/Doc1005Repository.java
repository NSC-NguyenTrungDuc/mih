package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc1005;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc1005Repository extends JpaRepository<Doc1005, Long>, Doc1005RepositoryCustom {
}


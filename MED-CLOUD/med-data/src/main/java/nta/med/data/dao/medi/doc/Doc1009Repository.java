package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc1009;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc1009Repository extends JpaRepository<Doc1009, Long>, Doc1009RepositoryCustom {
}


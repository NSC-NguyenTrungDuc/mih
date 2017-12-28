package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc1004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc1004Repository extends JpaRepository<Doc1004, Long>, Doc1004RepositoryCustom {
}


package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc4001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc4001Repository extends JpaRepository<Doc4001, Long>, Doc4001RepositoryCustom {
}


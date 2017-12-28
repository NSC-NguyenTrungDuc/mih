package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc2001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc2001Repository extends JpaRepository<Doc2001, Long>, Doc2001RepositoryCustom {
}


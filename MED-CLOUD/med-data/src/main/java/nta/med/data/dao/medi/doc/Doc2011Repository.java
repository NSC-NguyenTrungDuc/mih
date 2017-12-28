package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc2011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc2011Repository extends JpaRepository<Doc2011, Long>, Doc2011RepositoryCustom {
}


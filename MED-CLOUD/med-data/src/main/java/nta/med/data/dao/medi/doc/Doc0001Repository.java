package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc0001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc0001Repository extends JpaRepository<Doc0001, Long>, Doc0001RepositoryCustom {
}


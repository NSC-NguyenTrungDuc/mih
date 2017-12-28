package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc3001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc3001Repository extends JpaRepository<Doc3001, Long>, Doc3001RepositoryCustom {
}


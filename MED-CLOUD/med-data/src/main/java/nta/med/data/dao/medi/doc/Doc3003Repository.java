package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc3003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc3003Repository extends JpaRepository<Doc3003, Long>, Doc3003RepositoryCustom {
}


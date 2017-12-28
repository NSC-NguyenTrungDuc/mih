package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc3006;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc3006Repository extends JpaRepository<Doc3006, Long>, Doc3006RepositoryCustom {
}


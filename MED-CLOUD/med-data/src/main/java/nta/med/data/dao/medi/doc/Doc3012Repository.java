package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc3012;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc3012Repository extends JpaRepository<Doc3012, Long>, Doc3012RepositoryCustom {
}


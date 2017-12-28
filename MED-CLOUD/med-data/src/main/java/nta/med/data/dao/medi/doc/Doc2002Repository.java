package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc2002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc2002Repository extends JpaRepository<Doc2002, Long>, Doc2002RepositoryCustom {
}


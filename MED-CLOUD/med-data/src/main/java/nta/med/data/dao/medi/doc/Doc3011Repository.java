package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc3011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc3011Repository extends JpaRepository<Doc3011, Long>, Doc3011RepositoryCustom {
}


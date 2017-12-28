package nta.med.data.dao.medi.fabric;

import nta.med.core.domain.fabric.FabricGroup;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface FabricGroupRepository extends JpaRepository<FabricGroup, Long> {
}

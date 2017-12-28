package nta.med.data.dao.medi.fabric;

import nta.med.core.domain.fabric.FabricSharding;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author DEV-TiepNM
 */
@Repository
public interface FabricShardingRepository extends JpaRepository<FabricSharding, Long> {
}

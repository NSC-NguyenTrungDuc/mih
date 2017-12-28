package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0170;
import nta.med.data.dao.medi.CacheRepository;

import java.util.List;

/**
 * @author dainguyen.
 */

public interface Ocs0170Repository extends Ocs0170RepositoryCustom, CacheRepository<Ocs0170> {
    public List<Ocs0170> getHIOcsSpecificComment(String hospCode, String specificComment);
}


package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.core.domain.adm.AdmsGroup;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface AdmsGroupRepository extends JpaRepository<AdmsGroup, Long>, AdmsGroupRepositoryCustom {
	@Modifying	
	@Query(" SELECT ams FROM AdmsGroup ams WHERE hospCode = :hospCode and grpId = :grpId ")
	public List<AdmsGroup> getAdmsGroupItem (
			@Param("hospCode") String hospCode,
			@Param("grpId") String grpId
			);
}


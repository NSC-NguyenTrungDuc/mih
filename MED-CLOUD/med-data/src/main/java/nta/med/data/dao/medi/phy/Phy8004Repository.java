package nta.med.data.dao.medi.phy;

import java.util.List;

import nta.med.core.domain.phy.Phy8004;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Phy8004Repository extends JpaRepository<Phy8004, Long>, Phy8004RepositoryCustom {
	@Query("SELECT a FROM Phy8004 a WHERE hospCode = :hospCode AND fkOcsIrai = :fkOcsIrai ")
	public List<Phy8004> getByFkOcsIrai(@Param("hospCode") String hospCode,
			@Param("fkOcsIrai") Double fkOcsIrai);
	
	@Modifying
	@Query("	DELETE Phy8004 							"
			+"	WHERE pkPhySyougai =:pkPhySyougai       "
			+"	AND hospCode   = :hospCode              ")
	public Integer deletePhy8002U018004(
			@Param("hospCode") String hospCode,
			@Param("pkPhySyougai") Double pkPhySyougai);
}


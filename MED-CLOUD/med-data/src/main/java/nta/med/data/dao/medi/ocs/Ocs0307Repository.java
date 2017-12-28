package nta.med.data.dao.medi.ocs;

import java.math.BigDecimal;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs0307;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0307Repository extends JpaRepository<Ocs0307, Long>, Ocs0307RepositoryCustom {
	@Modifying
	@Query("UPDATE Ocs0307 SET activeFlg = :activeFlg, updDate = SYSDATE(), updId = :updId " 
							+ " WHERE   hospCode 	 = :hospCode "
								+ " AND id 	 		 = :id 		 ")
	public Integer deleteOcs0307u00(@Param("hospCode") String hospCode,
									@Param("updId") String userId,
									@Param("id") Long id,
									@Param("activeFlg") BigDecimal activeFlg);
}

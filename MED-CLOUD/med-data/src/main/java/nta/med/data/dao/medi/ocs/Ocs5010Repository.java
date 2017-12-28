package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs5010;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs5010Repository extends JpaRepository<Ocs5010, Long>, Ocs5010RepositoryCustom {
	@Modifying
	@Query("UPDATE Ocs5010                     "
		 + "  SET updId       = :userId        "
		 + "     ,updDate     = :currentDate   "
		 + "     ,confirmYn   = :confirmYn     "
		 + "     ,resultDate  = :orderDate     "
		 + "WHERE hospCode    = :hospCode      "
		 + "  AND doctor       = :doctor       "
		 + "  AND bunho        = :bunho        "
		 + "  AND jundalTable = 'DRG'          ")
	public Integer updateOcs5010(@Param("userId") String userId, 
			@Param("currentDate") Date currentDate, 
			@Param("confirmYn") String confirmYn, 
			@Param("orderDate") Date orderDate, 
			@Param("hospCode") String hospCode, 
			@Param("doctor") String doctor, 
			@Param("bunho") String bunho );
	// user_id not exist in table ocs0510 , then  if case update set updId=userId,else insert set sysId =userId
	@Modifying
	@Query("UPDATE Ocs5010 SET updId = :userId, updDate = :currentDate, confirmYn = 'Y' "
			+ "WHERE hospCode = :hospCode AND doctor = :doctor AND bunho = :bunho AND jundalTable = :jundalTable")
	public Integer updateOcs5010CPL0000Q00ScreenOpenUpdate(@Param("userId") String userId, 
			@Param("currentDate") Date currentDate,
			@Param("hospCode") String hospCode, 
			@Param("doctor") String doctor, 
			@Param("bunho") String bunho,
			@Param("jundalTable") String jundalTable);
}


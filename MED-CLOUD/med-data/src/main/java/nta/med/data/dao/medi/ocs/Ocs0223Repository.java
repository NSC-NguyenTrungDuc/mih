package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0223;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0223Repository extends JpaRepository<Ocs0223, Long>, Ocs0223RepositoryCustom {
	@Modifying
	@Query("UPDATE Ocs0223                    " +
		"   SET updDate      = :updDate     , " +
		"       updId        = :updId       , " +
		"       serial       = :serial      , " +
		"       commentTitle = :commentTitle, " +
		"       commentText  = :commentText   " +
		" WHERE jundalPart   = :jundalPart    " +
		"   AND seq          = :seq         ")
	public Integer updateOcs0223(@Param("updDate") Date updDate,
			@Param("updId") String updId,
			@Param("serial") Double serial,
			@Param("commentTitle") String commentTitle,
			@Param("commentText") String commentText,
			@Param("jundalPart") String jundalPart,
			@Param("seq") Double seq);
	
	@Modifying
	@Query("DELETE FROM Ocs0223 WHERE jundalPart = :jundalPart AND seq = :seq")
	public Integer deleteOcs0223(@Param("jundalPart") String jundalPart,
			@Param("seq") Double seq);
				
}


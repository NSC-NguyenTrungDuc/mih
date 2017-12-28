package nta.med.data.dao.medi.bas;

import java.util.Date;

import nta.med.core.domain.bas.Bas0230;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0230Repository extends JpaRepository<Bas0230, Long>, Bas0230RepositoryCustom {
	@Modifying
	@Query("UPDATE Bas0230 SET updId = :updId, updDate = :updDate, bunName = :bunName"
			+ " WHERE hospCode = :hospCode AND bunCode = :bunCode AND bunYmd = :bunYmd AND language = :language ")
	public Integer updateBAS0230U00(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("bunName") String bunName,
			@Param("hospCode") String hospCode,
			@Param("bunCode") String bunCode,
			@Param("bunYmd") Date bunYmd,
			@Param("language") String language);
	
	@Modifying
	@Query("DELETE FROM Bas0230 WHERE hospCode = :hospCode "
			+ " AND bunCode = :bunCode AND bunYmd = :bunYmd AND language = :language ")
	public Integer deleteBAS0230U00(
			@Param("hospCode") String hospCode,
			@Param("bunCode") String bunCode,
			@Param("bunYmd") Date bunYmd,
			@Param("language") String language);
}


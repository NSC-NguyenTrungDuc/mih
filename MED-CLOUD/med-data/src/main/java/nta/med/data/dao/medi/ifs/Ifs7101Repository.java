package nta.med.data.dao.medi.ifs;

import java.util.Date;

import nta.med.core.domain.ifs.Ifs7101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7101Repository extends JpaRepository<Ifs7101, Long>, Ifs7101RepositoryCustom {
	
	
	@Modifying
	@Query("DELETE FROM Ifs7101 A WHERE A.hospCode = :hospCode AND A.pkifs7101 = :pkifs7101")
	public boolean deleteIfs7101(@Param("hospCode") String hospCode
			,@Param("pkifs7101") Double pkifs7101);
	
	@Modifying
	@Query("UPDATE Ifs7101 A SET A.updId = :updId, A.updDate = :updDate, A.ifDate = :ifDate "
			+ ", A.ifTime = :ifTime, A.ifFlag = :ifFlag, A.ifErr = :ifErr "
			+ "WHERE A.hospCode = :hospCode AND A.pkifs7101 = :pkifs7101")
	public Integer updateIfs7101(@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("ifDate") Date ifDate,
			@Param("ifTime") String ifTime,
			@Param("ifFlag") String ifFlag,
			@Param("ifErr") String ifErr,
			@Param("hospCode") String hospCode,
			@Param("pkifs7101") Double pkifs7101);
}


package nta.med.data.dao.medi.drg;

import java.util.Date;

import nta.med.core.domain.drg.Drg4010;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg4010Repository extends JpaRepository<Drg4010, Long>, Drg4010RepositoryCustom {
	
	@Modifying
	@Query("DELETE FROM Drg4010 A WHERE A.hospCode = :hospCode AND A.pkdrg4010 = :pkdrg4010")
	public boolean deleteDrg4010(@Param("hospCode") String hospCode,@Param("pkdrg4010") Double pkdrg4010);
	
	@Modifying
	@Query("UPDATE Drg4010 A SET A.updDate = :updDate, A.updId = :updId, A.ifSendFlag = :ifSendFlag "
			+ "WHERE A.hospCode = :hospCode AND A.pkdrg4010 = :pkdrg4010")
	public boolean updateDrg4010(@Param("updDate") Date updDate,
			@Param("updId") String updId,
			@Param("ifSendFlag") String ifSendFlag,
			@Param("hospCode") String hospCode,
			@Param("pkdrg4010") Double pkdrg4010);
	
	
}


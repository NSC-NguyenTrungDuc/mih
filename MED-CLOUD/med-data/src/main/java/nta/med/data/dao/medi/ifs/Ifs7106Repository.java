package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7106;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7106Repository extends JpaRepository<Ifs7106, Long>, Ifs7106RepositoryCustom {
	
	@Modifying
	@Query("DELETE FROM Ifs7106 A WHERE A.hospCode = :hospCode AND A.fkifs7101 = :fkifs7101 AND A.seqRp = :seqRp AND A.seqRpDrg = :seqRpDrg")
	public boolean deleteIfs7106(@Param("hospCode") String hospCode,
			@Param("fkifs7101") Double fkifs7101,
			@Param("seqRp") Double seqRp,
			@Param("seqRpDrg") Double seqRpDrg);
	
	@Modifying
	@Query("UPDATE Ifs7106 A SET A.endFlag = :endFlag WHERE A.hospCode = :hospCode AND A.fkifs7101 = :fkifs7101 AND A.seqRp = :seqRp AND A.seqRpDrg = :seqRpDrg")
	public Integer updateIfs7106(@Param("endFlag") String endFlag,
			@Param("hospCode") String hospCode,
			@Param("fkifs7101") Double fkifs7101,
			@Param("seqRp") Double seqRp,
			@Param("seqRpDrg") Double seqRpDrg);
}


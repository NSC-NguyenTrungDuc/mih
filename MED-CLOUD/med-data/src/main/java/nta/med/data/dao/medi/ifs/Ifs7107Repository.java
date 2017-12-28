package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7107;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7107Repository extends JpaRepository<Ifs7107, Long>, Ifs7107RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Ifs7107 A WHERE A.hospCode = :hospCode AND A.fkifs7101 = :fkifs7101 "
			+ " AND A.seqRp = :seqRp AND A.seqRpDrg = :seqRpDrg AND A.seq = :seq")
	public boolean deleteIfs7107(@Param("hospCode") String hospCode,
			@Param("fkifs7101") Double fkifs7101,
			@Param("seqRp") Double seqRp,
			@Param("seqRpDrg") Double seqRpDrg,
			@Param("seq") Double seq);
	
	@Modifying
	@Query("UPDATE Ifs7107 A SET A.endFlag = :endFlag WHERE A.hospCode = :hospCode AND A.fkifs7101 = :fkifs7101 "
			+ " AND A.seqRp = :seqRp AND A.seqRpDrg = :seqRpDrg AND A.seq = :seq")
	public Integer updateIfs7107(@Param("endFlag") String endFlag,
			@Param("hospCode") String hospCode,
			@Param("fkifs7101") Double fkifs7101,
			@Param("seqRp") Double seqRp,
			@Param("seqRpDrg") Double seqRpDrg,
			@Param("seq") Double seq);
}


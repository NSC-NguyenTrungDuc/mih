package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7104;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7104Repository extends JpaRepository<Ifs7104, Long>, Ifs7104RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Ifs7104 A WHERE A.hospCode = :hospCode AND A.fkifs7101 = :fkifs7101 AND A.seqRp = :seqRp")
	public boolean deleteIfs7104(@Param("hospCode") String hospCode,
			@Param("fkifs7101") Double fkifs7101,
			@Param("seqRp") Double seqRp);
}


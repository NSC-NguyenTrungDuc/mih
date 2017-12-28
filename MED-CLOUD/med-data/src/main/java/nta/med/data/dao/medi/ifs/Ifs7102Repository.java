package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7102;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7102Repository extends JpaRepository<Ifs7102, Long>, Ifs7102RepositoryCustom {
	
	@Modifying
	@Query("DELETE FROM Ifs7102 A WHERE A.hospCode = :hospCode AND A.fkifs7101 = :fkifs7101 AND A.seq = :seq")
	public boolean deleteIfs7102(@Param("hospCode") String hospCode,
			@Param("fkifs7101") Double fkifs7101,
			@Param("seq") Double seq);
}


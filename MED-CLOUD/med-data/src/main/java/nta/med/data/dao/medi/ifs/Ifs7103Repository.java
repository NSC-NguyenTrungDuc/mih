package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7103;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7103Repository extends JpaRepository<Ifs7103, Long>, Ifs7103RepositoryCustom {
	
	@Modifying
	@Query("DELETE FROM Ifs7103 A WHERE A.hospCode = :hospCode AND A.fkifs7101 = :fkifs7101")
	public boolean deleteIfs7103(@Param("hospCode") String hospCode,
			@Param("fkifs7101") Double fkifs7101);
}


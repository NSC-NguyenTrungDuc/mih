package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0312;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0312Repository extends JpaRepository<Bas0312, Long>, Bas0312RepositoryCustom {
	@Query("SELECT COUNT(*)  "
		+	"  FROM Bas0312 " 
		+	"  WHERE sgCode = :f_sg_code")
	public Integer getCountBAS0312WhereHospCodeSgCode(@Param("f_sg_code") String sgCode);
}


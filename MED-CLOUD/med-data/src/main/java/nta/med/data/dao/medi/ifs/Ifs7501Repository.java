package nta.med.data.dao.medi.ifs;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ifs.Ifs7501;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7501Repository extends JpaRepository<Ifs7501, Long>, Ifs7501RepositoryCustom {

	@Query(" SELECT T FROM Ifs7501 T WHERE T.hospCode = :f_hosp_code AND T.fknut2011 = :f_fknut2011 ")
	public List<Ifs7501> findByHospCodeFkNut2011(@Param("f_hosp_code") String hospCode,
												 @Param("f_fknut2011") Double fknut2011);
	
	
}

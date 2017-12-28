package nta.med.data.dao.medi.inp;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inp.Inp1008;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp1008Repository extends JpaRepository<Inp1008, Long>, Inp1008RepositoryCustom {
	@Query("SELECT 'Y' FROM Inp1008   WHERE hospCode  = :f_hosp_code AND fkinp1002  = :f_pkinp1002")
	public List<String> getYByPkinp1002(@Param("f_hosp_code") String hospCode, @Param("f_pkinp1002") String fkout1001);
	
	@Modifying
	@Query("DELETE FROM Inp1008 WHERE hospCode = :f_hosp_code AND fkinp1002 = :f_pkinp1002")
	public Integer deleteInp1008ByPkout1001(@Param("f_hosp_code") String hospCode, @Param("f_pkinp1002") String fkinp1002);
	
	@Query("SELECT T FROM Inp1008 T WHERE hospCode  = :f_hosp_code AND gongbiCode = :f_gongbi_code AND fkinp1002  = :f_pkinp1002")
	public List<Inp1008> findByHospCodeGongbiCodeFkInp1002(@Param("f_hosp_code") String hospCode, 
														   @Param("f_gongbi_code") String param,
														   @Param("f_pkinp1002") String fkinp1002);
}


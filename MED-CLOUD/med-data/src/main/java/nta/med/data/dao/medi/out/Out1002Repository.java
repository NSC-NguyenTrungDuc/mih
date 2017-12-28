package nta.med.data.dao.medi.out;

import java.util.List;

import nta.med.core.domain.out.Out1002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out1002Repository extends JpaRepository<Out1002, Long>, Out1002RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Out1002 WHERE hospCode = :hospitalCode AND fkout1001 = :fkout1001")
	public Integer deleteOut1002ById(@Param("hospitalCode") String hospitalCode, @Param("fkout1001") String pkout1001);
	
	@Query("SELECT 'Y' FROM Out1002   WHERE hospCode  = :f_hosp_code AND fkout1001  = :f_pk1001 ")
	public List<String> getYByPkout1001(@Param("f_hosp_code") String hospCode, @Param("f_pk1001") Double pk1001);
}


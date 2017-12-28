package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp1002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp1002Repository extends JpaRepository<Inp1002, Long>, Inp1002RepositoryCustom {
	@Modifying
	@Query(" UPDATE Inp1002 set gubun = :f_gubun WHERE hospCode = :f_hosp_code AND  fkinp1001 = :f_pk1001 AND pkinp1002 = :f_pkinp1002 ")
	public Integer oRDERTRANProcessRequiUpdateInp1002(@Param("f_hosp_code") String hospCode,
			@Param("f_hosp_code") String gubun,
			@Param("f_pk1001") Double pk1001,
			@Param("f_pkinp1002") String pkinp1002);
}


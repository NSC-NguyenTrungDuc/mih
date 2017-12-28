package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.orca.OrcaReception;

@Repository
public interface OrcaReceptionRepository extends JpaRepository<OrcaReception, Long>, OrcaReceptionRepositoryCustom{

	@Query("SELECT T FROM OrcaReception T WHERE T.hospCode = :hospCode AND T.fkout1001 = :fkout1001 AND T.activeFlg = 1")
	public List<OrcaReception> findByHospCodeAndFkOut1001(@Param("hospCode") String hospCode, @Param("fkout1001") Double fkout1001);
}

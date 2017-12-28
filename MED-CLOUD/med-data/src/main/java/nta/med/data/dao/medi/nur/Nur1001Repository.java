package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.nur.Nur1001;

@Repository
public interface Nur1001Repository extends JpaRepository<Nur1001, Long>, Nur1001RepositoryCustom{
	@Query("SELECT T FROM Nur1001 T WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND fkinp1001 = :f_fkinp1001")
	public List<Nur1001> findByHospCodeBunhoFkinp1001(@Param("f_hosp_code") String hospCode
													, @Param("f_bunho") String bunho
													, @Param("f_fkinp1001") Double fkinp1001);
}

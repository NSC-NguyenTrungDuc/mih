package nta.med.data.dao.medi.out;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.out.TmpPatient;

@Repository
public interface TmpPatientRepository extends JpaRepository<TmpPatient, Long>{

	@Modifying
	@Query(" delete TmpPatient WHERE hospCode = :f_hosp_code ")
	public int deleteByHospCode(@Param("f_hosp_code") String hospCode);
}

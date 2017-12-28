package nta.med.data.dao.mss;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.mss.Hospital;

@Repository
public interface HospitalRepository extends JpaRepository<Hospital, Long>, HospitalRepositoryCustom {
	
	@Query("SELECT h FROM Hospital h WHERE h.hospitalCode = :hospitalCode AND h.activeFlg = 1")
	public List<Hospital> findByHospitalCode(@Param("hospitalCode") String hospitalCode);
	
}

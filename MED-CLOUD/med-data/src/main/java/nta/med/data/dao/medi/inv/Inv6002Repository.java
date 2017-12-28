package nta.med.data.dao.medi.inv;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inv.Inv6002;

@Repository
public interface Inv6002Repository extends JpaRepository<Inv6002, Long>, Inv6002RepositoryCustom {

	@Query("SELECT T FROM Inv6002 T WHERE T.hospCode = :f_hosp_code AND T.magamMonth = :f_magam_month AND T.jaeryoCode = :f_jaeryo_code")
	public List<Inv6002> findByHospCodeMagamMonthJaeryoCode(@Param("f_hosp_code") String hospCode, @Param("f_magam_month") String magamMonth, @Param("f_jaeryo_code") String jaeryoCode);
}

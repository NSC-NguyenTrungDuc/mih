package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur8003;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur8003Repository extends JpaRepository<Nur8003, Long>, Nur8003RepositoryCustom {

	@Modifying
	@Query("DELETE Nur8003 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND writeDate = :f_write_date")
	public Integer deleteByHospCodeBunhoWriteDate(@Param("f_hosp_code") String hospCode, @Param("f_bunho") String bunho,
			@Param("f_write_date") Date writeDate);

	@Query("SELECT T FROM Nur8003 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho AND T.writeDate = :writeDate AND T.firstGubun = :firstGubun AND T.grCode = :grCode ")
	public List<Nur8003> findByHospCodeBunhoWriteDateFirstGubunGrCode(@Param("hospCode") String hospCode,
			@Param("bunho") String bunho, @Param("writeDate") Date writeDate, @Param("firstGubun") String firstGubun,
			@Param("grCode") String grCode);
}

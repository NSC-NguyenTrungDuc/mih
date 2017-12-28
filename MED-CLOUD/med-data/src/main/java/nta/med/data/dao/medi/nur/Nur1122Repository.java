package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1122;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1122Repository extends JpaRepository<Nur1122, Long>, Nur1122RepositoryCustom {
	
	@Query("SELECT T FROM Nur1122 T WHERE T.hospCode = :hospCode AND T.fkinp1001 = :fkinp1001 AND T.ymd = :ymd AND T.hangmogName = :hangmogName")
	public List<Nur1122> findByHospCodeFkinp1001YmdHangmogName(@Param("hospCode") String hospCode,
															   @Param("fkinp1001") Double fkinp1001,
															   @Param("ymd") Date ymd,
															   @Param("hangmogName") String hangmogName);
	
	@Query("DELETE FROM Nur1122 WHERE hospCode = :hospCode AND bunho = :bunho AND fkinp1001 = :fkinp1001 AND ymd = :ymd AND hangmogName = :hangmogName")
	public Integer deleteByHospCodeFkinp1001YmdHangmogName(@Param("hospCode") String hospCode,
														   @Param("bunho") String bunho,
														   @Param("fkinp1001") Double fkinp1001,
														   @Param("ymd") Date ymd,
														   @Param("hangmogName") String hangmogName);
	
	@Query("DELETE FROM Nur1122 WHERE hospCode = :hospCode AND bunho = :bunho AND fkinp1001 = :fkinp1001 AND ymd = :ymd AND hangmogCode = :hangmogCode")
	public Integer deleteByHospCodeFkinp1001YmdHangmogCode(@Param("hospCode") String hospCode,
														   @Param("bunho") String bunho,
														   @Param("fkinp1001") Double fkinp1001,
														   @Param("ymd") Date ymd,
														   @Param("hangmogCode") String hangmogCode);
}


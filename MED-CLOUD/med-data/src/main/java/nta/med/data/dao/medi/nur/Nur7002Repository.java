package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur7002;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur7002Repository extends JpaRepository<Nur7002, Long>, Nur7002RepositoryCustom {
	
	@Query("SELECT T FROM Nur7002 T WHERE T.hospCode = :hospCode AND T.fkinp1001 = :fkinp1001 AND T.bunho = :bunho AND T.hangmogGubun = :hangmogGubun AND T.ymd = :ymd")
	public List<Nur7002> findByFkinp1001BunhoHangmogGubunYmd(@Param("hospCode") String hospCode,
															 @Param("fkinp1001") Double fkinp1001,
															 @Param("bunho") String bunho,
															 @Param("hangmogGubun") String hangmogGubun,
															 @Param("ymd") Date ymd);
	
	@Query("SELECT T FROM Nur7002 T WHERE T.hospCode = :hospCode AND T.fkinp1001 = :fkinp1001 AND T.bunho = :bunho AND T.hangmogGubun = :hangmogGubun AND T.ymd BETWEEN :f_fr_date AND :f_to_date")
	public List<Nur7002> findByFkinp1001BunhoHangmogGubunWriteDate(@Param("hospCode") String hospCode,
															 @Param("fkinp1001") Double fkinp1001,
															 @Param("bunho") String bunho,
															 @Param("hangmogGubun") String hangmogGubun,
															 @Param("f_fr_date") Date frDate,
															 @Param("f_to_date") Date toDate);
	
}


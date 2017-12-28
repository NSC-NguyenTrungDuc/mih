package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1023;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1023Repository extends JpaRepository<Nur1023, Long>, Nur1023RepositoryCustom {
	
	@Query("SELECT T FROM Nur1023 T WHERE T.hospCode = :hospCode AND T.fkinp1001 = :fkinp1001 AND T.bunho = :bunho AND T.orderDate = :orderDate ")
	public List<Nur1023> findByHospCodeFkinp1001BunhoOrderdate( @Param("hospCode") String hospCode,
																@Param("fkinp1001") Double fkinp1001,
																@Param("bunho") String bunho,
																@Param("orderDate") Date orderDate);
}


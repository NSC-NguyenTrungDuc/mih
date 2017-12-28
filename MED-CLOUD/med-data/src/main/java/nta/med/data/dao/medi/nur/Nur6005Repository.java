package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur6005;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur6005Repository extends JpaRepository<Nur6005, Long>, Nur6005RepositoryCustom {

	@Query("SELECT T FROM Nur6005 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho ORDER BY startDate DESC")
	public List<Nur6005> findByHospCodeBunho(@Param("hospCode") String hospCode, @Param("bunho") String bunho);

	@Query("SELECT T FROM Nur6005 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho AND T.startDate = :startDate")
	public List<Nur6005> findByHospCodeBunhoStartDate(@Param("hospCode") String hospCode, @Param("bunho") String bunho,
			@Param("startDate") Date startDate);

}

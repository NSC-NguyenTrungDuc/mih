package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur9999;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur9999Repository extends JpaRepository<Nur9999, Long>, Nur9999RepositoryCustom {

	@Query("SELECT T FROM Nur9999 T WHERE T.hospCode = :hospCode AND T.pknur9999 = :pknur9999 ")
	public List<Nur9999> findByHospCodePknur9999(@Param("hospCode") String hospCode,
			@Param("pknur9999") Double pknur9999);

	@Modifying
	@Query("DELETE Nur9999 WHERE hospCode = :hospCode AND pknur9999 = :pknur9999 ")
	public List<Nur9999> DELETEByHospCodePknur9999(@Param("hospCode") String hospCode,
			@Param("pknur9999") Double pknur9999);
}

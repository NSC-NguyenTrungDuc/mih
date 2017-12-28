package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur5023;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5023Repository extends JpaRepository<Nur5023, Long>, Nur5023RepositoryCustom {

	@Query("SELECT T FROM Nur5023 T WHERE T.hospCode = :hospCode AND T.pknur5023 = :pknur5023")
	public List<Nur5023> findByHospCodePknur5023(@Param("hospCode") String hospCode,
			@Param("pknur5023") Double pknur5023);
}

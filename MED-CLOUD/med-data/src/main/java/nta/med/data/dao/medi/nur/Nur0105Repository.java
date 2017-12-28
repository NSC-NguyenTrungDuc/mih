package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0105;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0105Repository extends JpaRepository<Nur0105, Long>, Nur0105RepositoryCustom {

	@Query("SELECT T FROM Nur0105 T WHERE T.hospCode = :hospCode AND T.vspatnGubun = :vspatnGubun")
	public List<Nur0105> findByHospCodeVspatnGubun(@Param("hospCode") String hospCode,
												   @Param("vspatnGubun") String vspatnGubun);

}

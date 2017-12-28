package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5020;

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
public interface Nur5020Repository extends JpaRepository<Nur5020, Long>, Nur5020RepositoryCustom {

	@Query("SELECT T FROM Nur5020 T WHERE T.hospCode = :hospCode AND T.nurWrdt = :nurWrdt AND T.hoDong = :hoDong ")
	public List<Nur5020> findByHospCodeNurWrdtHoDong(@Param("hospCode") String hospCode, 
													 @Param("nurWrdt") Date nurWrdt,
													 @Param("hoDong") String hoDong);

}

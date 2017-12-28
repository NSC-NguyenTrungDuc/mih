package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur5021;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5021Repository extends JpaRepository<Nur5021, Long>, Nur5021RepositoryCustom {
	
	@Query("SELECT T FROM Nur5021 T WHERE T.hospCode = :hospCode AND T.nurWrdt = :nurWrdt AND T.hoDong = :hoDong ")
	public List<Nur5021> findByHospCodeNurWrdtHoDong(@Param("hospCode") String hospCode, 
													 @Param("nurWrdt") Date nurWrdt,
													 @Param("hoDong") String hoDong);
	
}


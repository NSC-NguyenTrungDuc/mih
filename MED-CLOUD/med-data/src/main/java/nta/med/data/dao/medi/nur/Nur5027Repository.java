package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur5027;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5027Repository extends JpaRepository<Nur5027, Long>, Nur5027RepositoryCustom {
	
	@Query("SELECT T FROM Nur5027 T WHERE T.hospCode = :hospCode AND T.nurWrdt = :nurWrdt AND T.hoDong = :hoDong AND T.nurGrade = :nurGrade ")
	public List<Nur5027> findByHospCodeNurWrdtHoDong(@Param("hospCode") String hospCode, 
													 @Param("nurWrdt") Date nurWrdt,
													 @Param("hoDong") String hoDong,
													 @Param("nurGrade") String nurGrade);
	
}


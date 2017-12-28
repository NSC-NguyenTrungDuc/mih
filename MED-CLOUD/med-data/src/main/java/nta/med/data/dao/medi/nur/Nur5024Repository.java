package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur5024;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5024Repository extends JpaRepository<Nur5024, Long>, Nur5024RepositoryCustom {
	
	@Query("SELECT T FROM Nur5024 T WHERE T.hospCode = :hospCode AND T.nurWrdt = :nurWrdt AND T.hoDong = :hoDong AND T.gubun = '1' AND T.detailGubun = '1' AND T.bunho = :bunho ")
	public List<Nur5024> findByHospCodeNurWrdtHoDongBunho(@Param("hospCode") String hospCode, 
													 @Param("nurWrdt") Date nurWrdt,
													 @Param("hoDong") String hoDong,
													 @Param("bunho") String bunho);
	
	@Query("SELECT T FROM Nur5024 T WHERE T.hospCode = :hospCode AND T.nurWrdt = :nurWrdt AND T.hoDong = :hoDong AND T.gubun = '1' AND T.detailGubun = :detailGubun AND T.bunho = :bunho ")
	public List<Nur5024> findByHospCodeNurWrdtHoDongBunhoDetailGubun(@Param("hospCode") String hospCode, 
													 @Param("nurWrdt") Date nurWrdt,
													 @Param("hoDong") String hoDong,
													 @Param("bunho") String bunho,
													 @Param("detailGubun") String detailGubun);
	
}


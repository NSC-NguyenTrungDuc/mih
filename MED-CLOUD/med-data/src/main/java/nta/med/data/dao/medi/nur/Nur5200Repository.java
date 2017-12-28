package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5200;

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
public interface Nur5200Repository extends JpaRepository<Nur5200, Long>, Nur5200RepositoryCustom {

	@Query("SELECT T FROM Nur5200 T WHERE T.hospCode = :hospCode AND T.hoDong = :hoDong AND T.nurWrdt = :nurWrdt "
			+ "AND T.seq = (SELECT MAX(seq) FROM Nur5200 WHERE hospCode = :hospCode AND hoDong = :hoDong AND nurWrdt = :nurWrdt)")
	public List<Nur5200> findByHospCodeHoDongNurWrdtSeq(@Param("hospCode") String hospCode,
			@Param("hoDong") String hoDong, @Param("nurWrdt") Date nurWrdt);

}

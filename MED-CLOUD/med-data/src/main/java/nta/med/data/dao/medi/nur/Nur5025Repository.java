package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur5025;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5025Repository extends JpaRepository<Nur5025, Long>, Nur5025RepositoryCustom {

	@Query("SELECT MAX(seq) FROM Nur5025 T WHERE T.hospCode = :hospCode AND T.hoDong = :hoDong AND T.commentDate = :commentDate")
	public Double getMaxSeq(@Param("hospCode") String hospCode, @Param("hoDong") String hoDong,
			@Param("commentDate") Date commentDate);

	@Query("SELECT T FROM Nur5025 T WHERE T.hospCode = :hospCode AND T.hoDong = :hoDong AND T.commentDate = :commentDate AND T.seq = :seq")
	public List<Nur5025> findByHospCodeHoDongCommentDateSeq(@Param("hospCode") String hospCode,
			@Param("hoDong") String hoDong, @Param("commentDate") Date commentDate, @Param("seq") Double seq);
}

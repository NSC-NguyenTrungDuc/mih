package nta.med.data.dao.phr;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardFitnessDistance;

public interface StandardFitnessDistanceRepository extends JpaRepository<PhrStandardFitnessDistance, Long>, StandardFitnessDistanceRepositoryCustom {
	
	@Query("select T from PhrStandardFitnessDistance T where T.id = :id AND T.profileId = :profileId AND T.activeFlg = 1 ")
	public List<PhrStandardFitnessDistance> getStandardFitnessDistanceByIdAndProfileIdAndActiveFlg(@Param("id") Long id, @Param("profileId") Long profileId);
	
	@Query("select T from PhrStandardFitnessDistance T where T.id = :id AND T.profileId = :profileId ")
	public List<PhrStandardFitnessDistance> getStandardFitnessDistanceByIdAndProfileId(@Param("id") Long id, @Param("profileId") Long profileId);
	
	@Query("select P from PhrStandardFitnessDistance P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardFitnessDistance> getStandardFitnessDistanceByprofileId(@Param("profileId") Long profileId, Pageable pageable);

	@Query("select SUM(S.walkRunDistance) from PhrStandardFitnessDistance S where S.profileId = :profileId and S.activeFlg = 1 and DATE_FORMAT(S.datetimeRecord, '%Y%m%d') = DATE_FORMAT(SYSDATE(), '%Y%m%d') ")
	public BigDecimal getLastestFitnessDistanceByProfileId(@Param("profileId") Long profileId);
}

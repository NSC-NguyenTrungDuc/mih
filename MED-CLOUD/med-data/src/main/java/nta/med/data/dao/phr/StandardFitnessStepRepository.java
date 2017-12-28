package nta.med.data.dao.phr;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardFitnessStep;

public interface StandardFitnessStepRepository extends JpaRepository<PhrStandardFitnessStep, Long>, StandardFitnessStepRepositoryCustom {
	
	@Query("select T from PhrStandardFitnessStep T where T.id = :id AND T.profileId = :profileId AND T.activeFlg = 1  ")
	public List<PhrStandardFitnessStep> getStandardFitnessStepByIdAndProfileIdAndActiveFlg(@Param("id") Long id, @Param("profileId") Long profileId);
	
	@Query("select T from PhrStandardFitnessStep T where T.id = :id AND T.profileId = :profileId  ")
	public List<PhrStandardFitnessStep> getStandardFitnessStepByIdAndProfileId(@Param("id") Long id, @Param("profileId") Long profileId);

	@Query("select P from PhrStandardFitnessStep P where P.profileId = :profileId and P.activeFlg = 1 order by P.datetimeRecord desc")
	public List<PhrStandardFitnessStep> getStandardFitnessStepByprofileId(@Param("profileId") Long profileId, Pageable pageable);

	@Query("select SUM(S.stepsCount) from PhrStandardFitnessStep S where S.profileId = :profileId and S.activeFlg = 1 and DATE_FORMAT(S.datetimeRecord, '%Y%m%d') = DATE_FORMAT(SYSDATE(), '%Y%m%d') ")
	public BigDecimal getLastestFitnessStepByProfileId(@Param("profileId") Long profileId);
	
}

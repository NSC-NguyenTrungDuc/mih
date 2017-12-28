package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardTemperature;

public interface StandardTemperatureRepository extends JpaRepository<PhrStandardTemperature, Long>, StandardTemperatureRepositoryCustom {
	
	@Query("select T from PhrStandardTemperature T where T.profileId = :profileId and T.activeFlg = 1 order by T.dateMeasure desc")
	public List<PhrStandardTemperature> getTemperatureByProfileId(@Param("profileId") Long profileId);
	
	@Query("select T from PhrStandardTemperature T where T.profileId = :profileId and T.id = :id and activeFlg = 1")
	public PhrStandardTemperature getDetailTemperature(@Param("profileId") Long profileId, @Param("id") Long id);
	
	@Query("select T from PhrStandardTemperature T where T.profileId = :profileId and T.activeFlg = 1 order by T.dateMeasure desc")
	public List<PhrStandardTemperature> getLimitTemperature(@Param("profileId") Long profileId, Pageable pageable);
}

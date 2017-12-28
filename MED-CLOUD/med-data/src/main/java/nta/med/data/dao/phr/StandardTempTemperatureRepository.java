package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardTempTemperature;

public interface StandardTempTemperatureRepository extends JpaRepository<PhrStandardTempTemperature, Long>, StandardTempTemperatureRepositoryCustom {
	
	@Query("select T from PhrStandardTempTemperature T where T.syncId = :syncId ")
	public List<PhrStandardTempTemperature> getStandardTempTemperatureBySyncId(@Param("syncId") BigInteger syncId);

	@Modifying
	@Query(" UPDATE PhrStandardTempTemperature SET activeFlg = 0 WHERE syncId = :syncId ")
	public void deleteStandardTempTemperatureBySyncId(@Param("syncId") BigInteger syncId);
	
	@Query("select P from PhrStandardTempTemperature P where P.profileId = :profileId and P.activeFlg = 1 order by P.dateMeasure desc")
	public List<PhrStandardTempTemperature> getStandardTempTemperatureByprofileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrStandardTempTemperature H where H.id = :tempId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardTempTemperature getStandardTempTemperatureByIdAndProfileIdAndActiveFlg(@Param("tempId") Long tempId, @Param("profileId") Long profileId);
	
	@Query("select H from PhrStandardTempTemperature H where H.id = :tempId and H.profileId = :profileId ")
	public PhrStandardTempTemperature getStandardTempTemperatureByIdAndProfileId(@Param("tempId") Long tempId, @Param("profileId") Long profileId);

	@Query("select S from PhrStandardTempTemperature S where S.profileId = :profileId and S.activeFlg = 1 and S.dateMeasure = (select max(H.dateMeasure) from PhrStandardTempTemperature H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrStandardTempTemperature> getLastestTempTemperatureByProfileId(@Param("profileId") Long profileId);
}

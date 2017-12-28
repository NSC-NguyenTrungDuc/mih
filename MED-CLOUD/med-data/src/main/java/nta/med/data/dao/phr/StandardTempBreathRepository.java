package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardTempBreath;

public interface StandardTempBreathRepository extends JpaRepository<PhrStandardTempBreath, Long>, StandardTempBreathRepositoryCustom{
	@Query("select T from PhrStandardTempBreath T where T.syncId = :syncId ")
	public List<PhrStandardTempBreath> getStandardTempBreathBySyncId(@Param("syncId") BigInteger syncId);

	@Modifying
	@Query(" UPDATE PhrStandardTempBreath SET activeFlg = 0 WHERE syncId = :syncId ")
	public void deleteStandardTempBreathBySyncId(@Param("syncId") BigInteger syncId);
	
	@Query("select P from PhrStandardTempBreath P where P.profileId = :profileId and P.activeFlg = 1 order by P.dateMeasure desc")
	public List<PhrStandardTempBreath> getStandardTempBreathByprofileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrStandardTempBreath H where H.id = :tempId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardTempBreath getStandardTempBreathByIdAndProfileIdAndActiveFlg(@Param("tempId") Long tempId, @Param("profileId") Long profileId);
	
	@Query("select H from PhrStandardTempBreath H where H.id = :tempId and H.profileId = :profileId  ")
	public PhrStandardTempBreath getStandardTempBreathByIdAndProfileId(@Param("tempId") Long tempId, @Param("profileId") Long profileId);

	@Query("select S from PhrStandardTempBreath S where S.profileId = :profileId and S.activeFlg = 1 and S.dateMeasure = (select max(H.dateMeasure) from PhrStandardTempBreath H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrStandardTempBreath> getLastestTempBreathByProfileId(@Param("profileId") Long profileId);
}

package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardTempHeartrate;

public interface StandardTempHeartrateRepository extends JpaRepository<PhrStandardTempHeartrate, Long>, StandardTempHeartrateRepositoryCustom {
	@Query("select T from PhrStandardTempHeartrate T where T.syncId = :syncId ")
	public List<PhrStandardTempHeartrate> getStandardTempHeartrateBySyncId(@Param("syncId") BigInteger syncId);

	@Modifying
	@Query(" UPDATE PhrStandardTempHeartrate SET activeFlg = 0 WHERE syncId = :syncId ")
	public void deleteStandardTempHeartrateBySyncId(@Param("syncId") BigInteger syncId);
	
	@Query("select P from PhrStandardTempHeartrate P where P.profileId = :profileId and P.activeFlg = 1 order by P.dateMeasure desc")
	public List<PhrStandardTempHeartrate> getStandardTempHeartrateByprofileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrStandardTempHeartrate H where H.id = :tempId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardTempHeartrate getStandardTempHeartrateByIdAndProfileIdAndActiveFlg(@Param("tempId") Long tempId, @Param("profileId") Long profileId);
	
	@Query("select H from PhrStandardTempHeartrate H where H.id = :tempId and H.profileId = :profileId ")
	public PhrStandardTempHeartrate getStandardTempHeartrateByIdAndProfileId(@Param("tempId") Long tempId, @Param("profileId") Long profileId);

	@Query("select S from PhrStandardTempHeartrate S where S.profileId = :profileId and S.activeFlg = 1 and S.dateMeasure = (select max(H.dateMeasure) from PhrStandardTempHeartrate H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrStandardTempHeartrate> getLastestTempHeartrateByProfileId(@Param("profileId") Long profileId);
}

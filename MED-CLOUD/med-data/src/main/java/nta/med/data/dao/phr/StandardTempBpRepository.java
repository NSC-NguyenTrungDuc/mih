package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardTempBp;

public interface StandardTempBpRepository extends JpaRepository<PhrStandardTempBp, Long>, StandardTempBpRepositoryCustom {
	@Query("select T from PhrStandardTempBp T where T.syncId = :syncId ")
	public List<PhrStandardTempBp> getStandardTempBpBySyncId(@Param("syncId") BigInteger syncId);

	@Modifying
	@Query(" UPDATE PhrStandardTempBp SET activeFlg = 0 WHERE syncId = :syncId ")
	public void deleteStandardTempBpBySyncId(@Param("syncId") BigInteger syncId);
	
	@Query("select P from PhrStandardTempBp P where P.profileId = :profileId and P.activeFlg = 1 order by P.dateMeasure desc")
	public List<PhrStandardTempBp> getStandardTempBpByprofileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrStandardTempBp H where H.id = :tempId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardTempBp getStandardTempBpByIdAndProfileIdAndActiveFlg(@Param("tempId") Long tempId, @Param("profileId") Long profileId);
	
	@Query("select H from PhrStandardTempBp H where H.id = :tempId and H.profileId = :profileId ")
	public PhrStandardTempBp getStandardTempBpByIdAndProfileId(@Param("tempId") Long tempId, @Param("profileId") Long profileId);

	@Query("select S from PhrStandardTempBp S where S.profileId = :profileId and S.activeFlg = 1 and S.dateMeasure = (select max(H.dateMeasure) from PhrStandardTempBp H where H.profileId = :profileId and H.activeFlg = 1 )")
	public List<PhrStandardTempBp> getLastestTempBpByProfileId(@Param("profileId") Long profileId);
}

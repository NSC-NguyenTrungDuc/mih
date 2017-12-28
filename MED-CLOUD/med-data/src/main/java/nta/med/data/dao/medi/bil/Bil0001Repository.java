package nta.med.data.dao.medi.bil;

import org.springframework.data.jpa.repository.JpaRepository;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bill.Bil0001;

import java.util.List;

@Repository
public interface Bil0001Repository extends JpaRepository<Bil0001, Long>, Bil0001RepositoryCustom {


    @Query(" select count(*) from Bil0001 where  hospCode = :hospCode and hangmogCode = :hangmogCode")
    public Integer countByHangmogCodeAndPatientGrp( @Param("hospCode") String hospCode, @Param("hangmogCode") String hangmogCode);

    public List<Bil0001> findByHospCodeAndHangmogCode(String hospCode,  String hangmogCode);
}

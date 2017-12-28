package nta.med.data.dao.medi.inv;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inv.Inv2004;

import java.util.List;

@Repository
public interface Inv2004Repository extends JpaRepository<Inv2004, Long>, Inv2004RepositoryCustom {

    @Query(" select count(*) from Inv2004 where  hospCode = :hospCode and fkinv2003 = :fkinv2003 and jaeryoCode = :jaeryoCode")
    public Integer countByHospcodeAndFkinv2003AndJaeryoCode( @Param("hospCode") String hospCode, @Param("fkinv2003") Double fkinv2003, @Param("jaeryoCode") String jaeryoCode );

    public List<Inv2004> findByHospCodeAndFkinv2003AndJaeryoCode(String hospCode, Double fkinv2003, String jaeryoCode);



}

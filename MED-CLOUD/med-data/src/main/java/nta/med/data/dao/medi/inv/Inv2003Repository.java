package nta.med.data.dao.medi.inv;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inv.Inv2003;

import java.util.List;

@Repository
public interface Inv2003Repository extends JpaRepository<Inv2003, Long>, Inv2003RepositoryCustom {
    public List<Inv2003> findByHospCodeAndPkinv2003(String hospcode, Double Pkinv2003);

}

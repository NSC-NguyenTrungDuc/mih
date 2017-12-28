package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Acc001;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface Acc001Repository extends JpaRepository<Acc001, Long>, Acc001RepositoryCustom {

}

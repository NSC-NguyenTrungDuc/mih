package nta.med.data.dao.medi.kinki;

import nta.med.core.domain.kinki.DrugKinkiMessage;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DrugKinkiMessageRepository  extends JpaRepository<DrugKinkiMessage, Long>, DrugKinkiMessageRepositoryCustom{

}

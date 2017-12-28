package nta.med.data.dao.emr;

import nta.med.core.domain.emr.EmrTemplateType;

import org.springframework.data.jpa.repository.JpaRepository;

public interface EmrTemplateTypeRepository  extends JpaRepository<EmrTemplateType, Long>, EmrTemplateTypeRepositoryCustom {

}

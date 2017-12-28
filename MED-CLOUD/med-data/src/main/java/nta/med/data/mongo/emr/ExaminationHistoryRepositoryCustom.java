package nta.med.data.mongo.emr;

import nta.med.core.domain.emr.ExaminationHistory;

import java.util.List;

/**
 * @author dainguyen.
 */
public interface ExaminationHistoryRepositoryCustom {

    List<ExaminationHistory> findShortFields(String hospCode, String patientId);
}

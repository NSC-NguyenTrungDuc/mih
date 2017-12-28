package nta.med.data.mongo.emr.impl;

import nta.med.core.domain.emr.ExaminationHistory;
import nta.med.data.mongo.emr.ExaminationHistoryRepositoryCustom;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;

import javax.annotation.Resource;
import java.util.List;

/**
 * @author dainguyen.
 */
public class ExaminationHistoryRepositoryImpl implements ExaminationHistoryRepositoryCustom {

    @Resource
    private MongoTemplate mongoTemplate;

    @Override
    public List<ExaminationHistory> findShortFields(String hospCode, String patientId) {
        Query query = new Query();
        //query.with(new Sort(Sort.Direction.ASC, "revision"));
        query.fields().include("id");
        query.fields().include("patientId");
        query.fields().include("hospCode");
        query.fields().include("revision");
        query.fields().include("doctor");
        query.fields().include("comment");
        query.addCriteria(Criteria.where("hospCode").is(hospCode))
                .addCriteria(Criteria.where("patientId").is(patientId));
        List<ExaminationHistory> histories = mongoTemplate.find(query, ExaminationHistory.class);
        return histories;
    }
}

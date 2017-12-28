package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NUR2016Q00GrdPatientListInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class NUR2016Q00GrdPatientListHandler extends ScreenHandler<NuroServiceProto.NUR2016Q00GrdPatientListRequest, NuroServiceProto.NUR2016Q00GrdPatientListResponse>   {
    @Resource
    private Out0101Repository out0101Repository;
    @Resource
    private Adm0000Repository adm0000Repository;

    @Override
    @Transactional(readOnly = true)
    public NuroServiceProto.NUR2016Q00GrdPatientListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NUR2016Q00GrdPatientListRequest request) throws Exception {

        NuroServiceProto.NUR2016Q00GrdPatientListResponse.Builder response = NuroServiceProto.NUR2016Q00GrdPatientListResponse.newBuilder();

        String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        Date birth = DateUtil.toDate(request.getBirth(), DateUtil.PATTERN_YYMMDD);
        
        String suName2 = adm0000Repository.callFnAdmConvertKanaFull(getHospitalCode(vertx, sessionId), request.getSuname2());
        List<NUR2016Q00GrdPatientListInfo> nur2016Q00GrdHospListInfos = out0101Repository.getNUR2016Q00GrdPatientListInfo(request.getHospCodeLink(), request.getSuname(),
        		suName2, request.getAddress(), birth, startNum, CommonUtils.parseInteger(offset), getHospitalCode(vertx, sessionId), request.getBunho());

        if (!CollectionUtils.isEmpty(nur2016Q00GrdHospListInfos)) {
                for (NUR2016Q00GrdPatientListInfo item : nur2016Q00GrdHospListInfos) {
                    NuroModelProto.NUR2016Q00GrdPatientListInfo.Builder info = NuroModelProto.NUR2016Q00GrdPatientListInfo.newBuilder();
                    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                    response.addGrdPatListItem(info);
                }
        }
        return response.build();
    }
}

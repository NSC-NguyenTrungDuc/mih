package nta.med.service.ihis.handler.system;

import nta.med.common.util.Collections;
import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.model.ihis.bass.WaitingPatientInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Collection;
import java.util.Date;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class GetWaitingPatientHandler extends ScreenHandler<SystemServiceProto.GetWaitingPatientRequest, SystemServiceProto.GetWaitingPatientResponse> {
    private static final Log LOGGER = LogFactory.getLog(GetWaitingPatientHandler.class);
    @Resource
    private Bas0260Repository bas0260Repository;

    @Resource
    private Bas0001Repository bas0001Repository;


    @Override
    @Transactional
    @Route(global = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, SystemServiceProto.GetWaitingPatientRequest request) throws Exception {
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List)){
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        }
        else{
            LOGGER.info("GetWaitingPatientHandler preHandle not found hosp code");
        }
    }



    @Override
    @Transactional(readOnly = true)
    @Route(global = false)
    public SystemServiceProto.GetWaitingPatientResponse handle(Vertx vertx, String clientId, String sessionId,
                                                               long contextId, SystemServiceProto.GetWaitingPatientRequest request) throws Exception {

        SystemServiceProto.GetWaitingPatientResponse.Builder response = SystemServiceProto.GetWaitingPatientResponse.newBuilder();
        List<WaitingPatientInfo> waitingPatientInfoList;
        if(Collections.isEmpty(request.getPatientCodeList()))
        {
            waitingPatientInfoList = bas0260Repository.getWaitingPatients(request.getDoctorCode(), request.getExaminationDate(),
                    request.getHospCode(), request.getDepartmentCode(), request.getLocale());
        }
        else
        {
            waitingPatientInfoList = bas0260Repository.getWaitingOfPatient(request.getExaminationDate(),
                    request.getHospCode(),  request.getLocale(), request.getPatientCodeList());
        }


        for(WaitingPatientInfo waitingPatientInfo : waitingPatientInfoList)
        {
            SystemModelProto.WaitingPatientInfo.Builder item =  SystemModelProto.WaitingPatientInfo.newBuilder();
            BeanUtils.copyProperties(waitingPatientInfo, item, Language.JAPANESE.toString());
            Integer reservationCode = waitingPatientInfo.getReservationCode().intValue();
            item.setReservationCode(String.valueOf(reservationCode));
            response.addWaitingPatients(item.build());
        }
        return response.build();
    }
}

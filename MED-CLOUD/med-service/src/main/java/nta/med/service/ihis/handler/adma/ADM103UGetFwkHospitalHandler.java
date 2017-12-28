package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM103UGetFwkHospitalRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM103UGetFwkHospitalResponse;
import nta.med.service.ihis.proto.CommonModelProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class ADM103UGetFwkHospitalHandler extends ScreenHandler<AdmaServiceProto.ADM103UGetFwkHospitalRequest, AdmaServiceProto.ADM103UGetFwkHospitalResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM103UGetFwkHospitalHandler.class);
    @Resource
    private Bas0001Repository bas0001Repository;

    @Override
    @Transactional(readOnly = true)
    public ADM103UGetFwkHospitalResponse handle(Vertx vertx, String clientId,
	   String sessionId, long contextId,
	   ADM103UGetFwkHospitalRequest request) throws Exception {
        AdmaServiceProto.ADM103UGetFwkHospitalResponse.Builder response = AdmaServiceProto.ADM103UGetFwkHospitalResponse.newBuilder();
        String language = "";
        if(!UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))){
        	language = getLanguage(vertx, sessionId);
        }
        List<ComboListItemInfo> list = bas0001Repository.getAdm103UHospitalInfo("%", language);
        if (!CollectionUtils.isEmpty(list)) {
            for (ComboListItemInfo item : list) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addHospList(info);
            }
        }
        return response.build();
    }
}
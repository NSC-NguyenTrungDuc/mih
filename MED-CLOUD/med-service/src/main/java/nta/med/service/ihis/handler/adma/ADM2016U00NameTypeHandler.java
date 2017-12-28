package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9983Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class ADM2016U00NameTypeHandler extends ScreenHandler<AdmaServiceProto.ADM2016U00NameTypeRequest, SystemServiceProto.ComboResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM2016U00NameTypeHandler.class);
    @Resource
    private Adm9983Repository adm9983Repository;

    @Override
    @Transactional(readOnly = true)
    public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM2016U00NameTypeRequest request) throws Exception {
    	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
   	  List<ComboListItemInfo> listResult = adm9983Repository.getCombo(getHospitalCode(vertx, sessionId));
    	for (ComboListItemInfo item : listResult) {
    		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
            BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            response.addComboItem(info);
		}
    	
        return response.build();
    }
}

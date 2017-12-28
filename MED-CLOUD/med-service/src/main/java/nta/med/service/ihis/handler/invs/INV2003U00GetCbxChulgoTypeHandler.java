package nta.med.service.ihis.handler.invs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class INV2003U00GetCbxChulgoTypeHandler extends ScreenHandler<InvsServiceProto.INV2003U00GetCbxChulgoTypeRequest, InvsServiceProto.INV2003U00GetCbxChulgoTypeResponse> {
    @Resource
    private Inv0102Repository inv0102Repository;

    @Override
    @Transactional(readOnly = true)
    public InvsServiceProto.INV2003U00GetCbxChulgoTypeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, InvsServiceProto.INV2003U00GetCbxChulgoTypeRequest request) throws Exception {
        InvsServiceProto.INV2003U00GetCbxChulgoTypeResponse.Builder response = InvsServiceProto.INV2003U00GetCbxChulgoTypeResponse.newBuilder();
        List<ComboListItemInfo> codeNames = inv0102Repository.getINV4001U00LoadCodeName(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
        if(!CollectionUtils.isEmpty(codeNames)){
            for(ComboListItemInfo item : codeNames){
                InvsModelProto.INV2003U00GetCbxChulgoTypeInfo.Builder info = InvsModelProto.INV2003U00GetCbxChulgoTypeInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addListInfo(info);
            }
        }
        return response.build();
    }
}

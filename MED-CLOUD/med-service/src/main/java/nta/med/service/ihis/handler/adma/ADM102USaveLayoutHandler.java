package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.Adm0300;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0300Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto.ADM102UGrdListItemInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class ADM102USaveLayoutHandler extends ScreenHandler<AdmaServiceProto.ADM102USaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM102USaveLayoutHandler.class);
    @Resource
    private Adm0300Repository adm0300Repository;
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){

        return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    
    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM102USaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        if (CollectionUtils.isEmpty(request.getInputListList())) {
            response.setResult(false);
        } else {
            boolean save = false;
            String language = getLanguage(vertx, sessionId);
            for (ADM102UGrdListItemInfo item : request.getInputListList()) {
                if (item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                	boolean isDupplicateKey = adm0300Repository.isExistedADM0300(item.getPgmId(), getLanguage(vertx, sessionId));
                	if(isDupplicateKey){
                		LOGGER.info("Duplicate entry for key " +item.getPgmId());
						response.setResult(false);
						throw new ExecutionException(response.build());
					}else {				
						save = insertAdm0300(item, request.getUserId(), language);
					}
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    save = updateAdm0300(item, request.getUserId(), language);
                } else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                    save = deleteAdm0300(item, language);
                }
                if (save) {
                    response.setResult(true);
                } else {
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
            }
        }
        return response.build();
    }

    public boolean insertAdm0300(ADM102UGrdListItemInfo item, String userId, String language) {
        Adm0300 adm0300 = new Adm0300();
        adm0300.setPgmId(item.getPgmId());
        adm0300.setPgmNm(item.getPgmNm());
        adm0300.setPgmTp(item.getPgmTp());
        adm0300.setSysId(item.getSysId());
        adm0300.setProdId(item.getProdId());
        adm0300.setSrvcId(item.getSrvcId());
        adm0300.setPgmEntGrad(CommonUtils.parseDouble(item.getPgmEntGrad()));
        adm0300.setPgmUpdGrad(CommonUtils.parseDouble(item.getPgmUpdGrad()));
        adm0300.setPgmScrt(item.getPgmScrt());
        adm0300.setPgmDupYn(item.getPgmDupYn());
        adm0300.setPgmAcsYn(item.getPgmAcsYn());
        adm0300.setEndYn(item.getEndYn());
        adm0300.setMangMemb(item.getMangMemb());
        adm0300.setAsmName(item.getAsmName());
        adm0300.setCrMemb(userId);
        adm0300.setCrTime(new Date());
        adm0300.setLanguage(language);
        adm0300Repository.save(adm0300);
        return true;
    }

    public boolean updateAdm0300(ADM102UGrdListItemInfo item, String userId, String language) {
        return adm0300Repository.updateAdm102UAdm0300(
                item.getPgmNm(),
                item.getPgmTp(),
                item.getSysId(),
                item.getProdId(),
                item.getSrvcId(),
                CommonUtils.parseDouble(item.getPgmEntGrad()),
                CommonUtils.parseDouble(item.getPgmUpdGrad()),
                item.getPgmScrt(),
                item.getPgmDupYn(),
                item.getPgmAcsYn(),
                item.getEndYn(),
                item.getMangMemb(),
                item.getAsmName(),
                userId,
                new Date(),
                item.getPgmId(),
                language) > 0;
    }

    public boolean deleteAdm0300(ADM102UGrdListItemInfo item, String language) {
        return adm0300Repository.deleteAdm102UAdm0300(item.getPgmId(), language) > 0;
    }
}